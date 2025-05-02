using Data;
using LinqToDB;
using LinqToDB.Async;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace DiariodeSaude.ViewsModels;

public class RegistroDiarioLinq
{
    public async Task<int> AdicionarRegistroDiarioAsync(RegistroDiario registro)
    {
        using var db = new BD();
        var maxId = await db.RegistroDiario.Select(r => (int?)r.Id).MaxAsync() ?? 0;
        registro.Id = maxId + 1;
        await db.InsertAsync(registro);
        return registro.Id;
    }

    public async Task<List<RegistroDiario>> ObterRegistrosAsync()
    {
        using var db = new BD();
        return await db.RegistroDiario.ToListAsync();
    }

}

