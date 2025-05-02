using System.Collections.Generic;
using System.IO;
using System.Linq;

public class QualidadeSono
{
    public int Id { get; set; }
    public int? Descricao { get; set; }

    public static IEnumerable<QualidadeSono> LerQualidadeSono(string caminhoArquivo)
    {
        var linhas = File.ReadAllLines(caminhoArquivo).Skip(1);

        foreach (var linha in linhas)
        {
            var campos = linha.Split(',');
            var sono = new QualidadeSono
            {
                Id = int.Parse(campos[0]),
                Descricao = int.TryParse(campos[1], out var descricao) ? descricao : (int?)null,
            };
        

            yield return sono;
        }
    }
}
