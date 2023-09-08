using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SaveKids.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    FilePath = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CrimeCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrimeCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TelNumber = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Criminals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlaceOfBirth = table.Column<string>(type: "text", nullable: true),
                    Nationatily = table.Column<string>(type: "text", nullable: true),
                    Hair = table.Column<string>(type: "text", nullable: true),
                    Eyes = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    Height = table.Column<double>(type: "double precision", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    Detail = table.Column<string>(type: "text", nullable: true),
                    AttachmentId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criminals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Criminals_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Crimes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlaceOfCrime = table.Column<string>(type: "text", nullable: true),
                    DateOfCrime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Detail = table.Column<string>(type: "text", nullable: true),
                    CriminalId = table.Column<long>(type: "bigint", nullable: false),
                    CrimeCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Crimes_CrimeCategories_CrimeCategoryId",
                        column: x => x.CrimeCategoryId,
                        principalTable: "CrimeCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Crimes_Criminals_CriminalId",
                        column: x => x.CriminalId,
                        principalTable: "Criminals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Criminals",
                columns: new[] { "Id", "AttachmentId", "CreatedAt", "DateOfBirth", "Detail", "Eyes", "FirstName", "Gender", "Hair", "Height", "IsDeleted", "LastName", "Nationatily", "PlaceOfBirth", "UpdatedAt", "Weight" },
                values: new object[] { 1L, null, new DateTime(2023, 9, 8, 13, 17, 5, 798, DateTimeKind.Utc).AddTicks(5064), new DateTime(1964, 9, 6, 19, 0, 0, 0, DateTimeKind.Utc), "Fields II has a scar on his chest, his groin, his left calf, on both legs and both knees. He also has a tribal print tattoo on his right shoulder.", "Hazel", "Donald", "Male", "Brown", 180.0, false, "Eugene Fields II", "White American", "Kentucky", null, 90.0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DateOfBirth", "Email", "FirstName", "IsDeleted", "LastName", "Password", "Role", "TelNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 9, 8, 13, 17, 5, 798, DateTimeKind.Utc).AddTicks(4901), new DateTime(2024, 11, 5, 19, 0, 0, 0, DateTimeKind.Utc), "mansurjonmoydinov16072002@gmail.com", "Mansurjon", false, "Mo'ydinov", "mansurjon1512", 1, "+998908515979", null },
                    { 2L, new DateTime(2023, 9, 8, 13, 17, 5, 798, DateTimeKind.Utc).AddTicks(4907), new DateTime(2024, 1, 7, 19, 0, 0, 0, DateTimeKind.Utc), "turdiyevgmail.com", "Muhammadqodir", false, "Turdiyev", "mansurjon1512", 2, "+998912031759", null },
                    { 3L, new DateTime(2023, 9, 8, 13, 17, 5, 798, DateTimeKind.Utc).AddTicks(4910), new DateTime(2024, 12, 3, 19, 0, 0, 0, DateTimeKind.Utc), "jasurbek@gmail.com", "Nurullo", false, "Nurmatov", "mansurjon1512", 3, "+99890335578900", null },
                    { 4L, new DateTime(2023, 9, 8, 13, 17, 5, 798, DateTimeKind.Utc).AddTicks(4913), new DateTime(1999, 11, 3, 19, 0, 0, 0, DateTimeKind.Utc), "saidkamolgmail.com", "Saidkamol", false, "Saidjamolov", "mansurjon1512", 3, "+998908515979", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Crimes_CrimeCategoryId",
                table: "Crimes",
                column: "CrimeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Crimes_CriminalId",
                table: "Crimes",
                column: "CriminalId");

            migrationBuilder.CreateIndex(
                name: "IX_Criminals_AttachmentId",
                table: "Criminals",
                column: "AttachmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Crimes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CrimeCategories");

            migrationBuilder.DropTable(
                name: "Criminals");

            migrationBuilder.DropTable(
                name: "Attachments");
        }
    }
}
