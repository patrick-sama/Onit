using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Onit.Models;

namespace Onit.Data
{
    public class OnitContext : DbContext
    {
        public OnitContext (DbContextOptions<OnitContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComponenteDelCarello>().HasKey(sc => new { sc.CarelloId, sc.ComponenteId });
            
            modelBuilder.Entity<ComponenteDelCarello>()
                .HasOne<Carello>(c => c.Carello)
                .WithMany(co => co.ComponentiDelCarello)
                .HasForeignKey(c => c.CarelloId);

            modelBuilder.Entity<ComponenteDelCarello>()
                .HasOne<Componente>(co => co.Componente)
                .WithMany(c => c.ComponentiDelCarello)
                .HasForeignKey(co => co.ComponenteId);

            modelBuilder.Entity<Arrivi>().HasKey(sc => new { sc.CarelloId, sc.LocazioneId });

            modelBuilder.Entity<Arrivi>()
                .HasOne<Carello>(ca => ca.Carello)
                .WithMany(a => a.Arrivi)
                .HasForeignKey(ca => ca.CarelloId);

            modelBuilder.Entity<Arrivi>()
                .HasOne<Locazione>(lo => lo.Locazione)
                .WithMany(a => a.Arrivi)
                .HasForeignKey(lo => lo.LocazioneId);
        }
        public DbSet<Onit.Models.Componente> Componente { get; set; }
   
        public DbSet<Onit.Models.Area> Aree { get; set; }

        public DbSet<Onit.Models.Carello> Carelli { get; set; }

        public DbSet<Onit.Models.ComponenteDelCarello> ComponentiDeiCarelli { get; set; }

        public DbSet<Onit.Models.Locazione> Locazioni { get; set; }

        public DbSet<Onit.Models.Arrivi> Arrivi { get; set; }

    }
}
