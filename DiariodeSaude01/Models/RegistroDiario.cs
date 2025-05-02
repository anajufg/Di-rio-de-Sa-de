using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class RegistroDiario
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public int HumorId { get; set; }  
    public int SonoId { get; set; }   
    public int AlimentacaoId { get; set; } 
    public int AtividadeFisicaId { get; set; } 

    public static IEnumerable<RegistroDiario> LerRegistroDiario(string caminhoArquivo)
    {
        var linhas = File.ReadAllLines(caminhoArquivo).Skip(1);

        foreach (var linha in linhas)
        {
            var campos = linha.Split(',');
            var registro = new RegistroDiario
            {
                Id = int.Parse(campos[0]),
                Data = DateTime.Parse(campos[1]),
                HumorId = int.Parse(campos[2]),
                SonoId = int.Parse(campos[3]),
                AlimentacaoId = int.Parse(campos[4]),
                AtividadeFisicaId = int.Parse(campos[5])
            };

            yield return registro;
        }
    }
}
