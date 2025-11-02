using Microsoft.EntityFrameworkCore;

namespace Airbnb.Models
{
    public class AirBnbContext : DbContext
    {
        public AirBnbContext(DbContextOptions<AirBnbContext> options)
            : base(options) { }

        public DbSet<Reservation> Reservation { get; set; } = null!;
        public DbSet<User> User { get; set; } = null!;
        public DbSet<Residence> Residence { get; set; } = null!;
        public DbSet<Location> Location { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>().HasData(
                new Reservation
                {
                    ReservationId = 1,
                    ResidenceId = 1,
                    ReservationStartDate = new DateTime(2025, 11, 10),
                    ReservationEndDate = new DateTime(2025, 11, 13)
                },
                new Reservation
                {
                    ReservationId = 2,
                    ResidenceId = 2,
                    ReservationStartDate = new DateTime(2025, 12, 5),
                    ReservationEndDate = new DateTime(2025, 12, 9)
                },
                new Reservation
                {
                    ReservationId = 3,
                    ResidenceId = 3,
                    ReservationStartDate = new DateTime(2026, 5, 2),
                    ReservationEndDate = new DateTime(2026, 5, 8)
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Name = "Michael Green",
                    PhoneNumber = "201-101-2020",
                    Email = "michael.green@airbnb.com",
                    DOB = "03/15/1998"
                },
                new User
                {
                    UserId = 2,
                    Name = "Sophia Lee",
                    PhoneNumber = "241-303-4040",
                    Email = "sophia.lee@airbnb.com",
                    DOB = "11/22/1999"
                },
                new User
                {
                    UserId = 3,
                    Name = "David Carter",
                    PhoneNumber = "608-505-6060",
                    Email = "david.carter@airbnb.com",
                    DOB = "08/09/2001"
                }
            );

            modelBuilder.Entity<Residence>().HasData(
                new Residence
                {
                    ResidenceId = 1,
                    Name = "Golden Gate Condo",
                    ResidencePicture = "GoldenGate.png",
                    LocationId = 1,
                    GuestNumber = 3,
                    BedroomNumber = 1,
                    BathroomNumber = 1,
                    PricePerNight = "140"
                },
                new Residence
                {
                    ResidenceId = 2,
                    Name = "LA Downtown Loft",
                    ResidencePicture = "LaDowntown.png",
                    LocationId = 2,
                    GuestNumber = 5,
                    BedroomNumber = 2,
                    BathroomNumber = 2,
                    PricePerNight = "180"
                },
                new Residence
                {
                    ResidenceId = 3,
                    Name = "Dallas Ranch Home",
                    ResidencePicture = "DallasRanch.png",
                    LocationId = 3,
                    GuestNumber = 7,
                    BedroomNumber = 3,
                    BathroomNumber = 2,
                    PricePerNight = "90"
                },
                new Residence
                {
                    ResidenceId = 4,
                    Name = "Boston Harbor Apartment",
                    ResidencePicture = "BostonHarbor.png",
                    LocationId = 4,
                    GuestNumber = 4,
                    BedroomNumber = 2,
                    BathroomNumber = 1,
                    PricePerNight = "110"
                }
            );

            modelBuilder.Entity<Location>().HasData(
                new Location { LocationId = 1, Name = "San Francisco" },
                new Location { LocationId = 2, Name = "Los Angeles" },
                new Location { LocationId = 3, Name = "Dallas" },
                new Location { LocationId = 4, Name = "Boston" }
            );
        }

    }
}
