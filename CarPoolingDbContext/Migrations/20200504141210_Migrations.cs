using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarPoolingDbContext.Migrations
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingID = table.Column<string>(nullable: false),
                    RentalOfferID = table.Column<string>(nullable: true),
                    StartingPoint = table.Column<string>(nullable: true),
                    EndingPoint = table.Column<string>(nullable: true),
                    SeatsNeeded = table.Column<int>(nullable: false),
                    IsAccepted = table.Column<bool>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    IsRejected = table.Column<bool>(nullable: false),
                    Time = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleID = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Capacity = table.Column<int>(nullable: false),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleID);
                    table.ForeignKey(
                        name: "FK_Vehicles_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    WalletID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    balance = table.Column<decimal>(nullable: false),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.WalletID);
                    table.ForeignKey(
                        name: "FK_Wallets_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RatingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RideRating = table.Column<double>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    BookingID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingID);
                    table.ForeignKey(
                        name: "FK_Ratings_Bookings_BookingID",
                        column: x => x.BookingID,
                        principalTable: "Bookings",
                        principalColumn: "BookingID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RentalOffers",
                columns: table => new
                {
                    RentalOfferID = table.Column<string>(nullable: false),
                    StartingPoint = table.Column<string>(nullable: true),
                    EndingPoint = table.Column<string>(nullable: true),
                    ViaPoints = table.Column<string>(nullable: true),
                    SeatsAvailable = table.Column<int>(nullable: false),
                    MoneyRecieved = table.Column<decimal>(nullable: false),
                    IsClosed = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<string>(nullable: true),
                    OfferPrice = table.Column<decimal>(nullable: false),
                    UserID = table.Column<string>(nullable: true),
                    VehicleID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalOffers", x => x.RentalOfferID);
                    table.ForeignKey(
                        name: "FK_RentalOffers_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RentalOffers_Vehicles_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserID",
                table: "Bookings",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_BookingID",
                table: "Ratings",
                column: "BookingID",
                unique: true,
                filter: "[BookingID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RentalOffers_UserID",
                table: "RentalOffers",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_RentalOffers_VehicleID",
                table: "RentalOffers",
                column: "VehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UserID",
                table: "Vehicles",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_UserID",
                table: "Wallets",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "RentalOffers");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
