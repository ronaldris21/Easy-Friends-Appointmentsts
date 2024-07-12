using Microsoft.EntityFrameworkCore;
using Summary.Core.Abstraction;
using Summary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summary.Infraestructure
{
    public class AppDbContext : DbContext , IDbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
            
        }

        public DbSet<Friend> Friend { get; set; }  
        public DbSet<Appointment> Appointment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasMany(a => a.Friends)
                .WithOne(f => f.Appointment);

            modelBuilder.Entity<Friend>()
                .HasOne(f => f.Appointment)
                .WithMany(a => a.Friends)
                .HasForeignKey(f=>f.AppointmentId);

        }


        public Task<int> SaveChangeAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
