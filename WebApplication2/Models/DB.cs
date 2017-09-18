using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebApplication2.Models
{
    public class DB : DbContext
    {
        public DB()
            : base("name=Kunde")
        {
            Database.CreateIfNotExists();
        }
        public DbSet<Kunde> Kunder { get; set; }
        public DbSet<Reise> Reiser { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}