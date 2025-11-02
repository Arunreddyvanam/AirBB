using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Airbnb.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    DOB = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Residence",
                columns: table => new
                {
                    ResidenceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ResidencePicture = table.Column<string>(type: "TEXT", nullable: false),
                    GuestNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    BedroomNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    BathroomNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    PricePerNight = table.Column<string>(type: "TEXT", nullable: false),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residence", x => x.ResidenceId);
                    table.ForeignKey(
                        name: "FK_Residence_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReservationStartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReservationEndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ResidenceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservation_Residence_ResidenceId",
                        column: x => x.ResidenceId,
                        principalTable: "Residence",
                        principalColumn: "ResidenceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "LocationId", "Name" },
                values: new object[,]
                {
                    { 1, "San Francisco" },
                    { 2, "Los Angeles" },
                    { 3, "Dallas" },
                    { 4, "Boston" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "DOB", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "03/15/1998", "michael.green@airbnb.com", "Michael Green", "201-101-2020" },
                    { 2, "11/22/1999", "sophia.lee@airbnb.com", "Sophia Lee", "241-303-4040" },
                    { 3, "08/09/2001", "david.carter@airbnb.com", "David Carter", "608-505-6060" }
                });

            migrationBuilder.InsertData(
                table: "Residence",
                columns: new[] { "ResidenceId", "BathroomNumber", "BedroomNumber", "GuestNumber", "LocationId", "Name", "PricePerNight", "ResidencePicture" },
                values: new object[,]
                {
                    { 1, 1, 1, 3, 1, "Golden Gate Condo", "140", "GoldenGate.png" },
                    { 2, 2, 2, 5, 2, "LA Downtown Loft", "180", "LaDowntown.png" },
                    { 3, 2, 3, 7, 3, "Dallas Ranch Home", "90", "DallasRanch.png" },
                    { 4, 1, 2, 4, 4, "Boston Harbor Apartment", "110", "BostonHarbor.png" }
                });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "ReservationId", "ReservationEndDate", "ReservationStartDate", "ResidenceId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2025, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2026, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ResidenceId",
                table: "Reservation",
                column: "ResidenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Residence_LocationId",
                table: "Residence",
                column: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Residence");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
