using System.Data.Entity;
using CorretoraImoveis.Security.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CorretoraImoveis.Security.ContextIdentity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("CorretoraImoveisContext", throwIfV1Schema: false)
        {

        }

        public DbSet<Client> Client { get; set; }

        public DbSet<Claims> Claims { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}