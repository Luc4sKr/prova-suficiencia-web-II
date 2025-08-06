using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        // dotnet ef migrations add FirstMigration --startup-project ./src/Api --project ./src/Infra.Data
        // dotnet ef database update --startup-project ./src/Api --project ./src/Infra.Data

        #region DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Comanda> Comandas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ComandaProduto> ComandasProdutos { get; set; }
        #endregion
    }
}
