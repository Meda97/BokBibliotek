using BokBibliotek.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BokBibliotek.Data
{
    public class BokbibliotekContext : DbContext
    {
        //EF går in i context och skickar det till sql //EF genererar till sql

        public DbSet<Bok> Bok { get; set; }
        public DbSet<Boklån> Boklån { get; set; }
        public DbSet<Författare> Författare { get; set; }
        public DbSet<Låntagare> Låntagare { get; set; }
        public DbSet<BokFörfattare> BokFörfattare { get; set; }

        public BokbibliotekContext(DbContextOptions<BokbibliotekContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            // skapa composite primary key
            // BokId och FörfattareId är tillsammans alltså primary key
            modelbuilder.Entity<BokFörfattare>()
                .HasKey(sc => new { sc.BokId, sc.FörfattareId });

            // säga till EF vad relationen mellan BokFörfattare och bok är
            // sätta att BokId är foreign key 
            modelbuilder.Entity<BokFörfattare>()
                .HasOne(sc => sc.Bok)
                .WithMany(s => s.BokFörfattare)
                .HasForeignKey(sc => sc.BokId);
            //.OnDelete(DeleteBehavior.Restrict)


            // säga till EF vad relationen mellan BokFörfattare och Författare är
            // sätta att FörfattareId är foreign key 
            modelbuilder.Entity<BokFörfattare>()
                .HasOne(sc => sc.Författare)
                .WithMany(c => c.BokFörfattare)
                .HasForeignKey(sc => sc.FörfattareId);


            //Lånedatum och Returdatum (DateTime)
            modelbuilder.Entity<Boklån>()
            .Property(l => l.Lånedatum)
            .HasDefaultValueSql("GETDATE()");

        }

    }
}
