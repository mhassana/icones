using brouillon.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace brouillon.DAL
{
    public class isoftTankContext: DbContext
    {
        public DbSet<BCModel> BCs { get; set; }
        public DbSet<BEBacBacModel> BE_BacBacs { get; set; }
        public DbSet<BEExportModel> BEExports { get; set; }
        public DbSet<BELivraisonModel> BELivraisons { get; set; }
        public DbSet<BESoutageModel> BESoutages { get; set; }
        public DbSet<BETransfertModel> BETransferts { get; set; }
        public DbSet<ClientModel> Clients { get; set; }
        public DbSet<CommandeClientModel> CommandeClients { get; set; }
        public DbSet<CommandeMarketerModel> CommandeMarketers { get; set; }
        public DbSet<CompteMarketerModel> CompteMarketers { get; set; }
        public DbSet<CompteUtilisateurModel> CompteUtilisateurs { get; set; }
        public DbSet<DepotModel> Depots { get; set; }
        public DbSet<DetteModel> Dettes { get; set; }
        public DbSet<FacturationClientModel> FacturationClients { get; set; }
        public DbSet<FacturationMarketerModel> FacturationMarketers { get; set; }
        public DbSet<FournisseurModel> Fournisseurs { get; set; }
        public DbSet<HistoriqueModel> Historiques { get; set; }
        public DbSet<JoinBE_SoutageToNavireModel> JoinBE_SoutageToNavires { get; set; }
        public DbSet<JoinDetteToProduitModel> JoinDetteToProduits { get; set; }
        public DbSet<JoinProduitToCommande_clientModel> JoinProduitToCommande_clients { get; set; }
        public DbSet<JoinTaxeToFacturationModel> JoinTaxeToFacturations { get; set; }
        public DbSet<MarketerModel> Marketers { get; set; }
        public DbSet<NavireModel> Navires { get; set; }
        public DbSet<Point_consommationModel> Point_consommations { get; set; }
        public DbSet<PompeModel> Pompes { get; set; }
        public DbSet<PompisteModel> Pompistes { get; set; }
        public DbSet<ProduitModel> Produits { get; set; }
        public DbSet<ReceptionModel> Receptions { get; set; }
        public DbSet<Reglement_detteModel> Reglement_dettes { get; set; }
        public DbSet<StationModel> Stations { get; set; }
        public DbSet<StockModel> Stocks { get; set; }
        public DbSet<TankerModel> Tankers { get; set; }
        public DbSet<TaxeModel> Taxes { get; set; }
        public DbSet<TrancheMarketerModel> TrancheMarketers { get; set; }
        public DbSet<TrancheModel> Tranches { get; set; }
        public DbSet<TransactionEffectueeModel> TransactionEffectuees { get; set; }
        public DbSet<TransporteurModel> Transporteurs { get; set; }
        public DbSet<UtilisateurModel> Utilisateurs { get; set; }
        public DbSet<Vente_carburantModel> Vente_carburants { get; set; }


        //public DbSet<DepotModel> Depots { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}