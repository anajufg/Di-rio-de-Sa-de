using System.Collections.Generic;
using System.IO;
using System.Linq;

public class AtividadeFisica
{
    public int Id { get; set; }
    public string? TipoAtividade { get; set; }
    public int DuracaoMinutos { get; set; }

    public static IEnumerable<AtividadeFisica> LerAtividadeFisica(string caminhoArquivo)
    {
        var linhas = File.ReadAllLines(caminhoArquivo).Skip(1);

        foreach (var linha in linhas)
        {
            var campos = linha.Split(',');
            var atvFisica = new AtividadeFisica
            {
                Id = int.Parse(campos[0]),
                TipoAtividade = campos[1],
                DuracaoMinutos = int.Parse(campos[2])
            };

            yield return atvFisica ;
        }
    }
}
