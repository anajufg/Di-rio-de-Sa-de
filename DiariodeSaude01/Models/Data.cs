using LinqToDB;
using LinqToDB.Data;

namespace Data
{
    public class BD : DataConnection
    {
        public BD() : base(ProviderName.SQLite, "Data Source=Models/db.db;Version=3;")  { }

        public ITable<Humor> Humor => this.GetTable<Humor>();
        public ITable<RegistroDiario> RegistroDiario => this.GetTable<RegistroDiario>();
        public ITable<QualidadeSono> QualidadeSono => this.GetTable<QualidadeSono>();
        public ITable<Alimentacao> Alimentacao => this.GetTable<Alimentacao>();
        public ITable<AtividadeFisica> AtividadeFisica => this.GetTable<AtividadeFisica>();
        public ITable<Configuracao> Configuracao => this.GetTable<Configuracao>();
    }
}
