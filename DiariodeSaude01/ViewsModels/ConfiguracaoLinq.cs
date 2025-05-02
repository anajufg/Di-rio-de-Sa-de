using Data;
using LinqToDB;
using LinqToDB.Async;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiariodeSaude.ViewsModels;

public class ConfiguracaoLinq
{
    public async Task<List<Configuracao>> ObterConfiguracoesAsync()
    {
        using var db = new BD();
        return await db.GetTable<Configuracao>().ToListAsync();
    }

    public async Task<int> AdicionarConfiguracaoAsync(Configuracao config)
    {
        using var db = new BD();
        var maxId = await db.Configuracao.Select(c => (int?)c.Id).MaxAsync() ?? 0;
        config.Id = maxId + 1;
        await db.InsertAsync(config);
        return config.Id;
    }
}
