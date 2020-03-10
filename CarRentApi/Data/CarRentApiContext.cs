using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarRentApi.Models.Classes;

namespace CarRentApi.Data
{
    public class CarRentApiContext : DbContext
    {
        public CarRentApiContext(DbContextOptions<CarRentApiContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarClass> CarClasses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<DailyFee> DailyFees { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Car>(c =>
            {
                c.HasOne<CarClass>().WithMany().OnDelete(DeleteBehavior.Restrict);
                c.HasOne<CarBrand>().WithMany().OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Contract>(c =>
            {
                c.HasOne<Reservation>().WithMany().OnDelete(DeleteBehavior.Restrict);
                c.HasOne<Customer>().WithMany().OnDelete(DeleteBehavior.Restrict);
                c.HasOne<Car>().WithMany().OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<DailyFee>(c =>
            {
                c.HasOne<CarClass>().WithMany().OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Reservation>(c =>
            {
                c.HasOne<Customer>().WithMany().OnDelete(DeleteBehavior.Restrict);
                c.HasOne<CarClass>().WithMany().OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
