using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingTicketTrain.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<AppClient> clients { get; set; }
        public DbSet<Ticket> tickets { get; set; }
        public DbSet<Schedule> schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppClient>().HasData(new AppClient
            {
                AppClientId = Guid.NewGuid().ToString(),

            });

        }
    }
}
