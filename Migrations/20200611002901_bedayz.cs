using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bedayzAPI.Migrations
{
    public partial class bedayz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Marka = table.Column<byte>(nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    PreviousCost = table.Column<double>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: false),
                    NumberInStock = table.Column<int>(nullable: false),
                    Info = table.Column<string>(nullable: false),
                    KargoFiyatı = table.Column<double>(nullable: false),
                    ToplamSiparisSayisi = table.Column<int>(nullable: false),
                    Tag = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sepet",
                columns: table => new
                {
                    SepetId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(nullable: false),
                    SepeteKonulmaTarihi = table.Column<DateTime>(nullable: false),
                    Adet = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sepet", x => x.SepetId);
                    table.ForeignKey(
                        name: "FK_Sepet_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sepet_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Siparis",
                columns: table => new
                {
                    SiparisId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SiparisTarihi = table.Column<DateTime>(nullable: false),
                    Adet = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparis", x => x.SiparisId);
                    table.ForeignKey(
                        name: "FK_Siparis_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Siparis_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 100, "T-SHIRTS" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 101, "HOODIES" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 102, "AKSESUAR" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "LastName", "Name", "Password", "UserName" },
                values: new object[] { 1, "deneme1@gmail.com", "DSoyad1", "Deneme1", "1234", "deneme1" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "LastName", "Name", "Password", "UserName" },
                values: new object[] { 2, "deneme2@gmail.com", "DSoyad2", "Deneme2", "4567", "deneme2" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Cost", "Info", "KargoFiyatı", "Marka", "Name", "NumberInStock", "PreviousCost", "Tag", "ToplamSiparisSayisi", "Url" },
                values: new object[] { 102, 100, 90.0, "BLUE", 0.0, (byte)1, "QUARANTINE T-SHIRT", 10, 100.0, (byte)1, 0, "https://www.bedayz.com/quarantine-t-shirt" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Cost", "Info", "KargoFiyatı", "Marka", "Name", "NumberInStock", "PreviousCost", "Tag", "ToplamSiparisSayisi", "Url" },
                values: new object[] { 103, 100, 100.0, "BLACK", 0.0, (byte)1, "BETTERDAYZ OVERSIZE T-SHIRT ", 8, 5000.0, (byte)3, 0, "https://www.bedayz.com/betterdayz-oversize-t-shirt" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Cost", "Info", "KargoFiyatı", "Marka", "Name", "NumberInStock", "PreviousCost", "Tag", "ToplamSiparisSayisi", "Url" },
                values: new object[] { 104, 100, 110.0, "WHITE", 0.0, (byte)1, "TOKYO OVERSIZE T-SHIRT ", 15, 150.0, (byte)2, 0, "https://www.bedayz.com/tokyo-oversize-t-shirt" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Cost", "Info", "KargoFiyatı", "Marka", "Name", "NumberInStock", "PreviousCost", "Tag", "ToplamSiparisSayisi", "Url" },
                values: new object[] { 105, 100, 90.0, "RED", 0.0, (byte)1, "RED MUNCHIES OVERSIZE T - SHIRT", 3, 100.0, (byte)2, 0, "https://www.bedayz.com/red-munchies-oversize-t-shirt" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Cost", "Info", "KargoFiyatı", "Marka", "Name", "NumberInStock", "PreviousCost", "Tag", "ToplamSiparisSayisi", "Url" },
                values: new object[] { 100, 102, 45.0, "GOLD VINTAGE", 0.0, (byte)1, "GOLD VINTAGE KOLYE", 15, 50.0, (byte)1, 0, "https://www.bedayz.com/gold-vintage-kolye" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Cost", "Info", "KargoFiyatı", "Marka", "Name", "NumberInStock", "PreviousCost", "Tag", "ToplamSiparisSayisi", "Url" },
                values: new object[] { 101, 102, 45.0, "SILVER VINTAGE", 0.0, (byte)1, "SILVER VINTAGE KOLYE", 9, 50.0, (byte)3, 0, "https://www.bedayz.com/silver-vintage-kolye" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "ProductId", "Url" },
                values: new object[] { 102, "TeoriV2-106613_large.jpg", 102, "https://www.bedayz.com/Uploads/UrunResimleri/thumb/quarantine-t-shirt-7983.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "ProductId", "Url" },
                values: new object[] { 103, "TeoriV2-105445-7_large.jpg", 103, "https://www.bedayz.com/Uploads/UrunResimleri/thumb/betterdayz-oversize-t-shirt-b9f9.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "ProductId", "Url" },
                values: new object[] { 104, "TeoriV2-106597_large.jpg", 104, "https://www.bedayz.com/Uploads/UrunResimleri/thumb/tokyo-oversize-t-shirt-8171.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "ProductId", "Url" },
                values: new object[] { 105, "TeoriV2-105271-4_large.jpg", 105, "https://www.bedayz.com/Uploads/UrunResimleri/thumb/red-munchies-oversize-t-shirt-d1b2.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "ProductId", "Url" },
                values: new object[] { 100, "TeoriV2-106687_large.jpg", 100, "https://www.bedayz.com/Uploads/UrunResimleri/thumb/gold-vintage-kolye-de93.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "ProductId", "Url" },
                values: new object[] { 101, "TeoriV2-97788_large.jpg", 101, "https://www.bedayz.com/Uploads/UrunResimleri/thumb/silver-vintage-kolye-8181.jpg" });

            migrationBuilder.InsertData(
                table: "Sepet",
                columns: new[] { "SepetId", "Adet", "ProductID", "SepeteKonulmaTarihi", "UserId" },
                values: new object[] { 1, 1, 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Sepet",
                columns: new[] { "SepetId", "Adet", "ProductID", "SepeteKonulmaTarihi", "UserId" },
                values: new object[] { 2, 1, 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.InsertData(
                table: "Siparis",
                columns: new[] { "SiparisId", "Adet", "ProductID", "SiparisTarihi", "UserId" },
                values: new object[] { 1, 1, 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Siparis",
                columns: new[] { "SiparisId", "Adet", "ProductID", "SiparisTarihi", "UserId" },
                values: new object[] { 2, 1, 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Sepet_ProductID",
                table: "Sepet",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Sepet_UserId",
                table: "Sepet",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_ProductID",
                table: "Siparis",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_UserId",
                table: "Siparis",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Sepet");

            migrationBuilder.DropTable(
                name: "Siparis");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
