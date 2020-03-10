using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarBrands",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBrands", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "CarClasses",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarClasses", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    CustomerNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(maxLength: 60, nullable: false),
                    Lastname = table.Column<string>(maxLength: 60, nullable: false),
                    Address = table.Column<string>(maxLength: 60, nullable: false),
                    Address2 = table.Column<string>(maxLength: 60, nullable: true),
                    ZIP = table.Column<string>(maxLength: 10, nullable: false),
                    City = table.Column<string>(maxLength: 30, nullable: false),
                    PhoneNo = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    RegistrationPlate = table.Column<string>(maxLength: 60, nullable: false),
                    CarBrandGuId = table.Column<Guid>(nullable: false),
                    CarClassGuId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Cars_CarBrands_CarBrandGuId",
                        column: x => x.CarBrandGuId,
                        principalTable: "CarBrands",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_CarClasses_CarClassGuId",
                        column: x => x.CarClassGuId,
                        principalTable: "CarClasses",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DailyFees",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    CarClassGuId = table.Column<Guid>(nullable: false),
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    DayFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyFees", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_DailyFees_CarClasses_CarClassGuId",
                        column: x => x.CarClassGuId,
                        principalTable: "CarClasses",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    ReservationNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationState = table.Column<int>(nullable: false),
                    CustomerGuId = table.Column<Guid>(nullable: false),
                    CarClassGuId = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    NoOfRentalDays = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerRemark = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Reservations_CarClasses_CarClassGuId",
                        column: x => x.CarClassGuId,
                        principalTable: "CarClasses",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Customers_CustomerGuId",
                        column: x => x.CustomerGuId,
                        principalTable: "Customers",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    ContractNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationGuId = table.Column<Guid>(nullable: false),
                    CustomerGuId = table.Column<Guid>(nullable: false),
                    CarGuId = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    NoOfRentalDays = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DailyFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerRemark = table.Column<string>(maxLength: 250, nullable: true),
                    InternalRemark = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Contracts_Cars_CarGuId",
                        column: x => x.CarGuId,
                        principalTable: "Cars",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contracts_Customers_CustomerGuId",
                        column: x => x.CustomerGuId,
                        principalTable: "Customers",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contracts_Reservations_ReservationGuId",
                        column: x => x.ReservationGuId,
                        principalTable: "Reservations",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarBrandGuId",
                table: "Cars",
                column: "CarBrandGuId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarClassGuId",
                table: "Cars",
                column: "CarClassGuId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_CarGuId",
                table: "Contracts",
                column: "CarGuId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_CustomerGuId",
                table: "Contracts",
                column: "CustomerGuId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ReservationGuId",
                table: "Contracts",
                column: "ReservationGuId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyFees_CarClassGuId",
                table: "DailyFees",
                column: "CarClassGuId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CarClassGuId",
                table: "Reservations",
                column: "CarClassGuId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerGuId",
                table: "Reservations",
                column: "CustomerGuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "DailyFees");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "CarBrands");

            migrationBuilder.DropTable(
                name: "CarClasses");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
