using System.Collections.Generic;
using System.IO;
using System.Linq;
public class Humor
{
    public int Id { get; set; }
    public string? Descricao { get; set; }

    public static IEnumerable<Humor> LerHumor(string caminhoArquivo)
    {
        var linhas = File.ReadAllLines(caminhoArquivo).Skip(1);

        foreach (var linha in linhas)
        {
            var campos = linha.Split(',');
            var humor = new Humor
            {
                Id = int.Parse(campos[0]),
                Descricao = campos[1]
            };
    
            yield return humor;
        }
    }
}
