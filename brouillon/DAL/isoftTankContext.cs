using brouillon.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace brouillon.DAL
{
    public class isoftTankContext: DbContext
    {
        public DbSet<ProduitModel> Produits { get; set; }
        public DbSet<MarketerModel> Marketers { get; set; }
        //public DbSet<DepotModel> Depots { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}