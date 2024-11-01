using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace DataAccessLayer
{
    public class HotelminiDBContext : DbContext
    {
        public HotelminiDBContext() { }

        public HotelminiDBContext(DbContextOptions<HotelminiDBContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("FUMiniHotelManagement");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<RoomInformation> RoomInformations { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BookingReservation> BookingReservations { get; set; }
        public DbSet<BookingDetail> BookingDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define composite key for BookingDetail
            modelBuilder.Entity<BookingDetail>()
                .HasKey(bd => new { bd.BookingReservationID, bd.RoomID });

            // Configure relationships
            modelBuilder.Entity<BookingDetail>()
                .HasOne(bd => bd.BookingReservation)
                .WithMany(br => br.BookingDetails)
                .HasForeignKey(bd => bd.BookingReservationID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookingDetail>()
                .HasOne(bd => bd.RoomInformation)
                .WithMany(ri => ri.BookingDetails)
                .HasForeignKey(bd => bd.RoomID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RoomInformation>()
                .HasOne(ri => ri.RoomType)
                .WithMany(rt => rt.Rooms)
                .HasForeignKey(ri => ri.RoomTypeID);

            modelBuilder.Entity<BookingReservation>()
                .HasOne(br => br.Customer)
                .WithMany(c => c.BookingReservations)
                .HasForeignKey(br => br.CustomerID);

            // Seed data for RoomType
            modelBuilder.Entity<RoomType>().HasData(
                new RoomType { RoomTypeID = 1, RoomTypeName = "Standard room", TypeDescription = "Basic amenities such as a bed, dresser, and TV.", TypeNote = "N/A" },
                new RoomType { RoomTypeID = 2, RoomTypeName = "Suite", TypeDescription = "Offers more space and amenities like a living area and kitchenette.", TypeNote = "N/A" },
                new RoomType { RoomTypeID = 3, RoomTypeName = "Deluxe room", TypeDescription = "Deluxe rooms with additional features like balcony or sea view.", TypeNote = "N/A" },
                new RoomType { RoomTypeID = 4, RoomTypeName = "Executive room", TypeDescription = "Designed for business travelers with perks like free breakfast.", TypeNote = "N/A" },
                new RoomType { RoomTypeID = 5, RoomTypeName = "Family Room", TypeDescription = "Specifically designed for families with multiple beds and additional space.", TypeNote = "N/A" },
                new RoomType { RoomTypeID = 6, RoomTypeName = "Connecting Room", TypeDescription = "Rooms with a connecting door for larger groups or families.", TypeNote = "N/A" },
                new RoomType { RoomTypeID = 7, RoomTypeName = "Penthouse Suite", TypeDescription = "An extravagant suite with exceptional views and exclusive amenities.", TypeNote = "N/A" },
                new RoomType { RoomTypeID = 8, RoomTypeName = "Bungalow", TypeDescription = "Standalone cottage-style accommodation for privacy.", TypeNote = "N/A" }
            );

            // Seed data for RoomInformation
            modelBuilder.Entity<RoomInformation>().HasData(
                new RoomInformation { RoomID = 1, RoomNumber = "2364", RoomDetailDescription = "A basic room with essential amenities.", RoomMaxCapacity = 3, RoomTypeID = 1, RoomStatus = 1, RoomPricePerDate = 149.00M },
                new RoomInformation { RoomID = 2, RoomNumber = "3345", RoomDetailDescription = "Deluxe room with additional features.", RoomMaxCapacity = 5, RoomTypeID = 3, RoomStatus = 1, RoomPricePerDate = 299.00M },
                new RoomInformation { RoomID = 3, RoomNumber = "4432", RoomDetailDescription = "Luxurious room with separate living and sleeping areas.", RoomMaxCapacity = 4, RoomTypeID = 2, RoomStatus = 1, RoomPricePerDate = 199.00M },
                new RoomInformation { RoomID = 5, RoomNumber = "3342", RoomDetailDescription = "Floor 3, North West window.", RoomMaxCapacity = 5, RoomTypeID = 5, RoomStatus = 1, RoomPricePerDate = 219.00M },
                new RoomInformation { RoomID = 7, RoomNumber = "4434", RoomDetailDescription = "Floor 4, South window.", RoomMaxCapacity = 4, RoomTypeID = 1, RoomStatus = 1, RoomPricePerDate = 179.00M }
            );

            // Seed data for Customer
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerID = 3, CustomerFullName = "William Shakespeare", Telephone = "0903939393", EmailAddress = "WilliamShakespeare@FUMiniHotel.org", CustomerBirthday = new DateOnly(1990, 2, 2), CustomerStatus = 1, Password = "123@" },
                new Customer { CustomerID = 5, CustomerFullName = "Elizabeth Taylor", Telephone = "0903939377", EmailAddress = "ElizabethTaylor@FUMiniHotel.org", CustomerBirthday = new DateOnly(1991, 3, 3), CustomerStatus = 1, Password = "144@" },
                new Customer { CustomerID = 8, CustomerFullName = "James Cameron", Telephone = "0903946582", EmailAddress = "JamesCameron@FUMiniHotel.org", CustomerBirthday = new DateOnly(1992, 11, 10), CustomerStatus = 1, Password = "443@" },
                new Customer { CustomerID = 9, CustomerFullName = "Charles Dickens", Telephone = "0903955633", EmailAddress = "CharlesDickens@FUMiniHotel.org", CustomerBirthday = new DateOnly(1991, 12, 5), CustomerStatus = 1, Password = "563@" },
                new Customer { CustomerID = 10, CustomerFullName = "George Orwell", Telephone = "0913933493", EmailAddress = "GeorgeOrwell@FUMiniHotel.org", CustomerBirthday = new DateOnly(1993, 12, 24), CustomerStatus = 1, Password = "177@" },
                new Customer { CustomerID = 11, CustomerFullName = "Victoria Beckham", Telephone = "0983246773", EmailAddress = "VictoriaBeckham@FUMiniHotel.org", CustomerBirthday = new DateOnly(1990, 9, 9), CustomerStatus = 1, Password = "654@" }
            );

            // Seed data for BookingReservation
            modelBuilder.Entity<BookingReservation>().HasData(
                new BookingReservation { BookingReservationID = 1, BookingDate = new DateOnly(2023, 12, 20), TotalPrice = 378.00M, CustomerID = 3, BookingStatus = 1 },
                new BookingReservation { BookingReservationID = 2, BookingDate = new DateOnly(2023, 12, 21), TotalPrice = 1493.00M, CustomerID = 3, BookingStatus = 1 }
            );

            // Seed data for BookingDetail
            modelBuilder.Entity<BookingDetail>().HasData(
                new BookingDetail { BookingReservationID = 1, RoomID = 3, StartDate = new DateOnly(2024, 1, 1), EndDate = new DateOnly(2024, 1, 2), ActualPrice = 199.00M },
                new BookingDetail { BookingReservationID = 1, RoomID = 7, StartDate = new DateOnly(2024, 1, 1), EndDate = new DateOnly(2024, 1, 2), ActualPrice = 179.00M },
                new BookingDetail { BookingReservationID = 2, RoomID = 3, StartDate = new DateOnly(2024, 1, 5), EndDate = new DateOnly(2024, 1, 6), ActualPrice = 199.00M },
                new BookingDetail { BookingReservationID = 2, RoomID = 5, StartDate = new DateOnly(2024, 1, 5), EndDate = new DateOnly(2024, 1, 9), ActualPrice = 219.00M }
            );
        }
    }
}
