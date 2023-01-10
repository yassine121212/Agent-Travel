using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotn.Migrations
{
    /// <inheritdoc />
    public partial class MultipleMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GuidePartenairs",
                columns: table => new
                {
                    IdGuide = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameGuide = table.Column<string>(name: "Name_Guide", type: "nvarchar(35)", maxLength: 35, nullable: false),
                    CityGuide = table.Column<string>(name: "City_Guide", type: "nvarchar(max)", nullable: false),
                    PhoneGuide = table.Column<int>(name: "Phone_Guide", type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidePartenairs", x => x.IdGuide);
                });

            migrationBuilder.CreateTable(
                name: "HotelPartenairs",
                columns: table => new
                {
                    IdHotel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameHotel = table.Column<string>(name: "Name_Hotel", type: "nvarchar(35)", maxLength: 35, nullable: false),
                    CityHotel = table.Column<string>(name: "City_Hotel", type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    PictureHotel = table.Column<string>(name: "Picture_Hotel", type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelPartenairs", x => x.IdHotel);
                });

            migrationBuilder.CreateTable(
                name: "TransportPartenairs",
                columns: table => new
                {
                    IdTransport = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTransport = table.Column<string>(name: "Name_Transport", type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Classe = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    PictureTransport = table.Column<string>(name: "Picture_Transport", type: "nvarchar(max)", nullable: false),
                    Villedepart = table.Column<string>(name: "Ville_depart", type: "nvarchar(25)", maxLength: 25, nullable: true),
                    VilleArrivee = table.Column<string>(name: "Ville_Arrivee", type: "nvarchar(25)", maxLength: 25, nullable: true),
                    heuredepart = table.Column<DateTime>(name: "heure_depart", type: "datetime2", nullable: true),
                    heureArrivee = table.Column<DateTime>(name: "heure_Arrivee", type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportPartenairs", x => x.IdTransport);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameUser = table.Column<string>(name: "Name_User", type: "nvarchar(35)", maxLength: 35, nullable: false),
                    LastNameUser = table.Column<string>(name: "LastName_User", type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureUser = table.Column<string>(name: "Picture_User", type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isAdmin = table.Column<bool>(name: "is_Admin", type: "bit", nullable: true),
                    isActived = table.Column<bool>(name: "is_Actived", type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleOffre = table.Column<string>(name: "Title_Offre", type: "nvarchar(max)", nullable: false),
                    PriceOffre = table.Column<double>(name: "Price_Offre", type: "float", nullable: false),
                    DescriptionOffre = table.Column<string>(name: "Description_Offre", type: "nvarchar(max)", nullable: false),
                    PictureOffre = table.Column<string>(name: "Picture_Offre", type: "nvarchar(max)", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    VilleArrivee = table.Column<string>(name: "Ville_Arrivee", type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Pays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateEnd = table.Column<DateTime>(name: "Date_End", type: "datetime2", nullable: false),
                    DateBegin = table.Column<DateTime>(name: "Date_Begin", type: "datetime2", nullable: false),
                    IdHotel = table.Column<int>(type: "int", nullable: true),
                    IdTransport = table.Column<int>(type: "int", nullable: true),
                    IdGuide = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offres_GuidePartenairs_IdGuide",
                        column: x => x.IdGuide,
                        principalTable: "GuidePartenairs",
                        principalColumn: "IdGuide");
                    table.ForeignKey(
                        name: "FK_Offres_HotelPartenairs_IdHotel",
                        column: x => x.IdHotel,
                        principalTable: "HotelPartenairs",
                        principalColumn: "IdHotel");
                    table.ForeignKey(
                        name: "FK_Offres_TransportPartenairs_IdTransport",
                        column: x => x.IdTransport,
                        principalTable: "TransportPartenairs",
                        principalColumn: "IdTransport");
                });

            migrationBuilder.CreateTable(
                name: "Commandes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<double>(name: "Total_Price", type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commandes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commandes_Offres_Id",
                        column: x => x.Id,
                        principalTable: "Offres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commandes_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offres_IdGuide",
                table: "Offres",
                column: "IdGuide");

            migrationBuilder.CreateIndex(
                name: "IX_Offres_IdHotel",
                table: "Offres",
                column: "IdHotel");

            migrationBuilder.CreateIndex(
                name: "IX_Offres_IdTransport",
                table: "Offres",
                column: "IdTransport");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commandes");

            migrationBuilder.DropTable(
                name: "Offres");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "GuidePartenairs");

            migrationBuilder.DropTable(
                name: "HotelPartenairs");

            migrationBuilder.DropTable(
                name: "TransportPartenairs");
        }
    }
}
