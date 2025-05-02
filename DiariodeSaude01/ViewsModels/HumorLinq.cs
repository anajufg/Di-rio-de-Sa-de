using Data;
using LinqToDB;
using LinqToDB.Async;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiariodeSaude.ViewsModels;

public class HumorLinq
{
    public async Task<List<Humor>> ObterHumoresAsync()
    {
        using var db = new BD();
        return await db.Humor.ToListAsync();
    }

    public async Task<int> AdicionarHumorAsync(Humor humor)
    {
        using var db = new BD();
        var maxId = await db.Humor.Select(h => (int?)h.Id).MaxAsync() ?? 0;
        humor.Id = maxId + 1;
        await db.InsertAsync(humor);
        return humor.Id;
    }
}


