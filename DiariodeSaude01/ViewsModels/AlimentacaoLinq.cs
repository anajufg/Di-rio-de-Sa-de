using Data;
using LinqToDB;
using LinqToDB.Async;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiariodeSaude.ViewsModels;

public class AlimentacaoLinq
{

    public async Task<List<Alimentacao>> ObterAlimentacoesAsync()
    {
        using var db = new BD();
        return await db.Alimentacao.ToListAsync();
    }

    public async Task<int> AdicionarAlimentacaoAsync(Alimentacao alimentacao)
    {
        using var db = new BD();
        var maxId = await db.Alimentacao.Select(a => (int?)a.Id).MaxAsync() ?? 0;
        alimentacao.Id = maxId + 1;
        await db.InsertAsync(alimentacao);
        return alimentacao.Id;
    }
}
