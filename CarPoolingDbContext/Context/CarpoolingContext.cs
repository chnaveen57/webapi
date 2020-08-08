using CarPooling.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolingDB
{
    public class CarpoolingContext:DbContext
    {
        public CarpoolingContext()
        {
        }

        public CarpoolingContext(DbContextOptions<CarpoolingContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<RentalOffer> RentalOffers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wallet>().HasIndex(w => w.UserID).IsUnique();
            modelBuilder.Entity<Rating>().HasIndex(r => r.BookingID).IsUnique();
        }

    }
}
