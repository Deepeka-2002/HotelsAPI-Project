using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelsAPI.Migrations
{
    /// <inheritdoc />
    public partial class HotelDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "hotels",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    HotelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerDay = table.Column<int>(type: "int", nullable: false),
                    CreationYear = table.Column<int>(type: "int", nullable: false),
                    UpdateRooms = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotels", x => x.HotelId);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    PricePerNight = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    hotelsHotelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_rooms_hotels_hotelsHotelId",
                        column: x => x.hotelsHotelId,
                        principalTable: "hotels",
                        principalColumn: "HotelId");
                });

            migrationBuilder.CreateTable(
                name: "reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    roomsRoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_reservations_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservations_rooms_roomsRoomId",
                        column: x => x.roomsRoomId,
                        principalTable: "rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reservations_CustomerId",
                table: "reservations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_roomsRoomId",
                table: "reservations",
                column: "roomsRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_rooms_hotelsHotelId",
                table: "rooms",
                column: "hotelsHotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservations");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "rooms");

            migrationBuilder.DropTable(
                name: "hotels");
        }
    }
}
