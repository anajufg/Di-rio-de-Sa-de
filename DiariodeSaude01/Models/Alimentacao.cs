using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Alimentacao
{
    public int Id { get; set; }
    public string? Descricao { get; set; }

    public static IEnumerable<Alimentacao> LerAlimentacao(string caminhoArquivo)
    {
        var linhas = File.ReadAllLines(caminhoArquivo).Skip(1);

        foreach (var linha in linhas)
        {
            var campos = linha.Split(',');

            var alimentacao = new Alimentacao
            {
                Id = int.Parse(campos[0]),
                Descricao = campos[1]
            };

            yield return alimentacao;
        }
    }
}
