using Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data {
    public class ApplicationDbContext : DbContext {

        public ApplicationDbContext() : base() {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SongSanctuaryDb;Integrated Security=true; Encrypt=false;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Song>()
                .HasOne(e => e.Album)
                .WithMany(e => e.Songs)
                .HasForeignKey(e => e.AlbumId);

            modelBuilder.Entity<Album>()
                .HasOne(e => e.Band)
                .WithMany(e => e.Albums)
                .HasForeignKey(e => e.BandId);

            modelBuilder.Entity<Artist>()
                .HasOne(e => e.Band)
                .WithMany(e => e.Artists)
                .HasForeignKey(e => e.BandId);
        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Band> Bands { get; set; }
    }
}
