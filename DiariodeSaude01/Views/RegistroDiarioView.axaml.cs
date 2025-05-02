using Avalonia.Controls;
using System;
using DiariodeSaude.ViewsModels;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Threading;
using System.Threading.Tasks;

namespace DiariodeSaude.Views;

public partial class RegistroDiarioView : UserControl
{
    private readonly RegistroDiarioLinq registroDiarioLinq = new RegistroDiarioLinq();
    private readonly HumorLinq humorLinq = new HumorLinq();
    private readonly AlimentacaoLinq alimentacaoLinq = new AlimentacaoLinq();
    private readonly SonoLinq sonoLinq = new SonoLinq();
    private readonly AtividadeFisicaLinq atividadeFisicaLinq = new AtividadeFisicaLinq();

    public RegistroDiarioView()
    {
         InitializeComponent();
    }

    private async void SalvarRegistroDiario(object? sender, RoutedEventArgs e)
    {
        try
        {
            string? descricaoHumor = null;
            if (this.FindControl<RadioButton>("HumorFeliz")?.IsChecked == true) descricaoHumor = "HumorFeliz";
            else if (this.FindControl<RadioButton>("HumorBom")?.IsChecked == true) descricaoHumor = "HumorBom";
            else if (this.FindControl<RadioButton>("HumorRegular")?.IsChecked == true) descricaoHumor = "HumorRegular";
            else if (this.FindControl<RadioButton>("HumorRuim")?.IsChecked == true) descricaoHumor = "HumorRuim";
            else if (this.FindControl<RadioButton>("HumorPessimo")?.IsChecked == true) descricaoHumor = "HumorPessimo";
            else if (string.IsNullOrEmpty(descricaoHumor))
            {
                MensagemErro("Selecione seu humor.");
                return;
            }
          
            if (!int.TryParse(sonoInput.Text, out var sono) || sono < 0 || sono > 10)
            {
                MensagemErro("A qualidade do sono deve estar entre 0 e 10.");
                return;
            }

             if (string.IsNullOrWhiteSpace(alimentacaoInput.Text))
            {
                MensagemErro("Informe como foi sua alimentação.");
                return;
            }

            if (string.IsNullOrWhiteSpace(atvFisicaInput.Text))
            {
                MensagemErro("Informe o tipo de atividade física.");
                return;
            }

            if (!int.TryParse(duracaoInput.Text, out var duracao) || duracao < 0)
            {
                MensagemErro("Informe uma duração válida para a atividade física.");
                return;
            }

            var novoHumor = new Humor { Descricao = descricaoHumor };
            var humorId = await humorLinq.AdicionarHumorAsync(novoHumor);

            var novoSono = new QualidadeSono { Descricao = sono };
            var sonoId = await sonoLinq.AdicionarSonoAsync(novoSono);

            var novaAlimentacao = new Alimentacao { Descricao = alimentacaoInput.Text.Trim() };
            var alimentacaoId = await alimentacaoLinq.AdicionarAlimentacaoAsync(novaAlimentacao);

            var novaAtividadeFisca = new AtividadeFisica
            {
                TipoAtividade = atvFisicaInput.Text.Trim(),
                DuracaoMinutos = duracao
            };
            var atividadeFisicaId = await atividadeFisicaLinq.AdicionarAtividadeFisicaAsync(novaAtividadeFisca);

            var novoRegistro = new RegistroDiario
            {
                Data = DateTime.Now,
                HumorId = humorId,
                SonoId = sonoId,
                AlimentacaoId = alimentacaoId,
                AtividadeFisicaId = atividadeFisicaId
            };
            await registroDiarioLinq.AdicionarRegistroDiarioAsync(novoRegistro);

            MensagemSucesso("Registro salvo com sucesso!");

            LimpaCampos();
        }
        catch (Exception ex)
        {
            MensagemErro($"Erro ao salvar: {ex.Message}");
        }
    }

    private void LimpaCampos() 
    {
        sonoInput.Text = "";
        alimentacaoInput.Text = "";
        atvFisicaInput.Text = "";
        duracaoInput.Text = "";

        foreach (var rb in new[] { "HumorFeliz", "HumorBom", "HumorRegular", "HumorRuim", "HumorPessimo" })
        {
            var radio = this.FindControl<RadioButton>(rb);
            if (radio != null) radio.IsChecked = false;
        }
    }

    private async void MensagemErro(string mensagem)
    {
        mensagemStatus.Text = mensagem;
        mensagemStatus.Foreground = Brushes.Red;
        mensagemStatus.IsVisible = true;
        await OcultarMensagemDepoisDeDelay();
    }
    private async void MensagemSucesso(string mensagem)
    {
        mensagemStatus.Text = mensagem;
        mensagemStatus.Foreground = Brushes.Green;
        mensagemStatus.IsVisible = true;
        await OcultarMensagemDepoisDeDelay();
    }

    private async Task OcultarMensagemDepoisDeDelay()
    {
        await Task.Delay(3000); 
        await Dispatcher.UIThread.InvokeAsync(() =>
        {
            mensagemStatus.IsVisible = false;
        });
    }
}