using Data;
using LinqToDB;
using LinqToDB.Async;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiariodeSaude.ViewsModels;

public class AtividadeFisicaLinq
{
    public async Task<List<AtividadeFisica>> ObterAtividadesFisicasAsync()
    {
        using var db = new BD();
        return await db.AtividadeFisica.ToListAsync();
    }

    public async Task<int> AdicionarAtividadeFisicaAsync(AtividadeFisica atividade)
    {
        using var db = new BD();
        var maxId = await db.AtividadeFisica.Select(a => (int?)a.Id).MaxAsync() ?? 0;
        atividade.Id = maxId + 1;
        await db.InsertAsync(atividade);
        return atividade.Id;
    }
}
