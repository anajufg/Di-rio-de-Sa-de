using System.Collections.Generic;
using System.IO;
using System.Linq;
public class Configuracao
{
    public int Id { get; set; }
    public string? CaminhoBanco { get; set; }
    public string? Tema { get; set; } 
    public bool ImportacaoHabilitada { get; set; }
    public bool ExportacaoHabilitada { get; set; }

    public static IEnumerable<Configuracao> LerConfiguracao(string caminhoArquivo)
    {
        var linhas = File.ReadAllLines(caminhoArquivo).Skip(1);

        foreach (var linha in linhas)
        {
            var campos = linha.Split(',');
            var config = new Configuracao
            {
                Id = int.Parse(campos[0]),
                CaminhoBanco = campos[1],
                Tema = campos[2],
                ImportacaoHabilitada = bool.Parse(campos[3]),
                ExportacaoHabilitada = bool.Parse(campos[4])
            };

            yield return config;
        }
    }
}
