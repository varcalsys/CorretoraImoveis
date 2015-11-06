using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CorretoraImoveis.Data.Mapping;
using CorretoraImoveis.Domain.Entities;

namespace CorretoraImoveis.Data.ContextDb
{
    public class CorretoraImoveisContext : DbContext
    {
         public CorretoraImoveisContext()
            : base("Name=CorretoraImoveisContext")
         {
             //Configuration.ProxyCreationEnabled = false;
             Configuration.LazyLoadingEnabled = true;
         }

       public DbSet<Foto> Fotos { get; set; }
        public DbSet<Imovel> Imoveis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {         

            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new FotoMap());
            modelBuilder.Configurations.Add(new ImovelMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
