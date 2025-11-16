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
                    SSN = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    DOB = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserType = table.Column<string>(type: "TEXT", nullable: false)
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
                    BathroomNumber = table.Column<decimal>(type: "TEXT", nullable: false),
                    PricePerNight = table.Column<string>(type: "TEXT", nullable: false),
                    BuildYear = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Residence_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
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
                columns: new[] { "UserId", "DOB", "Email", "Name", "PhoneNumber", "SSN", "UserType" },
                values: new object[,]
                {
                    { 1, new DateTime(2003, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.green@airbnb.com", "Michael Green", "201-101-2020", "343-466-6262", "Owner" },
                    { 2, new DateTime(2009, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "sophia.lee@airbnb.com", "Sophia Lee", "241-303-4040", "343-466-8978", "Client" },
                    { 3, new DateTime(1990, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "david.carter@airbnb.com", "David Carter", "608-505-6060", "343-466-5656", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Residence",
                columns: new[] { "ResidenceId", "BathroomNumber", "BedroomNumber", "BuildYear", "GuestNumber", "LocationId", "Name", "PricePerNight", "ResidencePicture", "UserId" },
                values: new object[,]
                {
                    { 1, 1m, 1, new DateTime(2003, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, "Golden Gate Condo", "140", "GoldenGate.png", 1 },
                    { 2, 2m, 2, new DateTime(2023, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2, "LA Downtown Loft", "180", "LaDowntown.png", 1 },
                    { 3, 2m, 3, new DateTime(2009, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 3, "Dallas Ranch Home", "90", "DallasRanch.png", 2 },
                    { 4, 1m, 2, new DateTime(2002, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4, "Boston Harbor Apartment", "110", "BostonHarbor.png", 3 }
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

            migrationBuilder.CreateIndex(
                name: "IX_Residence_UserId",
                table: "Residence",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Residence");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
