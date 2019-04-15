using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding_Planner.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Useres",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Firstname = table.Column<string>(nullable: false),
                    Lastname = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Useres", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "WeddingPlanes",
                columns: table => new
                {
                    WeddingPlanId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WedderOne = table.Column<string>(nullable: false),
                    WedderTwo = table.Column<string>(nullable: false),
                    Date = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeddingPlanes", x => x.WeddingPlanId);
                    table.ForeignKey(
                        name: "FK_WeddingPlanes_Useres_UserId",
                        column: x => x.UserId,
                        principalTable: "Useres",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resevationes",
                columns: table => new
                {
                    ResevationId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WeddingPlanId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resevationes", x => x.ResevationId);
                    table.ForeignKey(
                        name: "FK_Resevationes_Useres_UserId",
                        column: x => x.UserId,
                        principalTable: "Useres",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resevationes_WeddingPlanes_WeddingPlanId",
                        column: x => x.WeddingPlanId,
                        principalTable: "WeddingPlanes",
                        principalColumn: "WeddingPlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resevationes_UserId",
                table: "Resevationes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Resevationes_WeddingPlanId",
                table: "Resevationes",
                column: "WeddingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_WeddingPlanes_UserId",
                table: "WeddingPlanes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resevationes");

            migrationBuilder.DropTable(
                name: "WeddingPlanes");

            migrationBuilder.DropTable(
                name: "Useres");
        }
    }
}
