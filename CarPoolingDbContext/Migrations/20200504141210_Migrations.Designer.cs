﻿// <auto-generated />
using System;
using CarpoolingDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarPoolingDbContext.Migrations
{
    [DbContext(typeof(CarpoolingContext))]
    [Migration("20200504141210_Migrations")]
    partial class Migrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarPooling.Models.Booking", b =>
                {
                    b.Property<string>("BookingID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("EndingPoint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRejected")
                        .HasColumnType("bit");

                    b.Property<string>("RentalOfferID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeatsNeeded")
                        .HasColumnType("int");

                    b.Property<string>("StartingPoint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BookingID");

                    b.HasIndex("UserID");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("CarPooling.Models.Rating", b =>
                {
                    b.Property<int>("RatingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookingID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("RideRating")
                        .HasColumnType("float");

                    b.HasKey("RatingID");

                    b.HasIndex("BookingID")
                        .IsUnique()
                        .HasFilter("[BookingID] IS NOT NULL");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("CarPooling.Models.RentalOffer", b =>
                {
                    b.Property<string>("RentalOfferID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("EndingPoint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("bit");

                    b.Property<decimal>("MoneyRecieved")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OfferPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SeatsAvailable")
                        .HasColumnType("int");

                    b.Property<string>("StartingPoint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VehicleID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ViaPoints")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RentalOfferID");

                    b.HasIndex("UserID");

                    b.HasIndex("VehicleID");

                    b.ToTable("RentalOffers");
                });

            modelBuilder.Entity("CarPooling.Models.User", b =>
                {
                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CarPooling.Models.Vehicle", b =>
                {
                    b.Property<string>("VehicleID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("VehicleID");

                    b.HasIndex("UserID");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("CarPooling.Models.Wallet", b =>
                {
                    b.Property<int>("WalletID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("balance")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("WalletID");

                    b.HasIndex("UserID")
                        .IsUnique()
                        .HasFilter("[UserID] IS NOT NULL");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("CarPooling.Models.Booking", b =>
                {
                    b.HasOne("CarPooling.Models.User", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("CarPooling.Models.Rating", b =>
                {
                    b.HasOne("CarPooling.Models.Booking", "Booking")
                        .WithMany("Rating")
                        .HasForeignKey("BookingID");
                });

            modelBuilder.Entity("CarPooling.Models.RentalOffer", b =>
                {
                    b.HasOne("CarPooling.Models.User", "User")
                        .WithMany("RentalOffers")
                        .HasForeignKey("UserID");

                    b.HasOne("CarPooling.Models.Vehicle", "Vehicle")
                        .WithMany("RentalOffer")
                        .HasForeignKey("VehicleID");
                });

            modelBuilder.Entity("CarPooling.Models.Vehicle", b =>
                {
                    b.HasOne("CarPooling.Models.User", "User")
                        .WithMany("Vehicles")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("CarPooling.Models.Wallet", b =>
                {
                    b.HasOne("CarPooling.Models.User", "User")
                        .WithMany("Wallet")
                        .HasForeignKey("UserID");
                });
#pragma warning restore 612, 618
        }
    }
}
