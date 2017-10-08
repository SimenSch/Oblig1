using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebApplication2.Controllers;
namespace WebApplication2.Models
{
    public class Kunde
    {
        public int Id { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public virtual Kontaktinfo Kontaktinfo { get;set;}

        public virtual List<Bestilling> Bestilling { get; set; }
        

    }
    public class Bestilling
    {
        public int Id { get; set; }
        
        public virtual Kunde Kunde { get; set; }

        public virtual Reise Reise { get; set; }
    }
    public class Kontaktinfo
    {   
        public int Id { get; set; }
        public int Telefon { get; set; }
        public string Epost { get; set; }
        public virtual List<Kunde> Kunde {get;set;}

    }
    public class Reise
    {
        public int Id { get; set; }

        public string Utreise { get; set; }

        public string Hjemreise { get; set; }

        public string Turtid { get; set; }

        public string Returtid { get; set; }

        public int Billettpris { get; set; }

        public int Antall { get; set; }
       
        public  int? Antallbarn { get; set; }

        public virtual List<Bestilling> Bestilling { get; set; }
    }
    public class Destinasjoner
    {
        public int Id { get; set; }
        public string Flyplass { get; set; }
        public int Pris { get; set; }

    }
    public class DB : DbContext
    {
        public DB() : base("name=Cryanair")
        {
            Database.CreateIfNotExists();

            Database.SetInitializer(new DBinit());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        
        public virtual DbSet<Kunde> alleBestillinger { get; set; }
        public virtual DbSet<Kontaktinfo> Kontaktinfo { get; set; }
        public virtual DbSet<Reise> Reiser { get; set; }
        public virtual DbSet<Destinasjoner> Destinasjoner { get; set; }

        public virtual DbSet<Bestilling> Bestillinger { get; set; }
    }
}
    
