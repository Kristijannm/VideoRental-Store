using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Domain.Models;

namespace VideoRental.DataAccess
{
    public class VideoRentalDbContext : DbContext
    {
        public VideoRentalDbContext(DbContextOptions<VideoRentalDbContext> options) : base(options)  {}

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rental> Rentals { get; set;}
        public DbSet<Cast> Casts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.User)
                .WithMany(u => u.Rentals)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Movie)
                .WithMany(m => m.Rentals)
                .HasForeignKey(r => r.MovieId);

            modelBuilder.Entity<Cast>()
                .HasOne(c => c.Movie)
                .WithMany(m => m.Casts)
                .HasForeignKey(c => c.MovieId);
               
        }

        }
    }
