using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebApplication2.Controllers;
namespace WebApplication2.Models
{
    public class DB : DbContext
    {
        public DB() : base("name=Reisebestillinger")
        {
            Database.CreateIfNotExists();

            Database.SetInitializer(new DBinit());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public virtual DbSet<Kunde> Kunder { get; set; }

        public virtual DbSet<Reise> Reiser { get; set; }

        public virtual DbSet<Bestilling> Bestillinger { get; set; }
    }
}
    
