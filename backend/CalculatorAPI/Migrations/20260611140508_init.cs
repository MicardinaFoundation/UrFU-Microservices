using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalculatorAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UName = table.Column<string>(type: "TEXT", nullable: false),
                    Login = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Variants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Desc = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Variants_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VariantUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    VariantId = table.Column<int>(type: "INTEGER", nullable: false),
                    Co2 = table.Column<double>(type: "REAL", nullable: false),
                    H2o = table.Column<double>(type: "REAL", nullable: false),
                    N2 = table.Column<double>(type: "REAL", nullable: false),
                    O2 = table.Column<double>(type: "REAL", nullable: false),
                    Gaz_used = table.Column<double>(type: "REAL", nullable: false),
                    Presure_putten_par = table.Column<double>(type: "REAL", nullable: false),
                    Temperature_eaten_water = table.Column<double>(type: "REAL", nullable: false),
                    Temperature_arrive_smoke = table.Column<double>(type: "REAL", nullable: false),
                    Temperature_of_incoming_gases_1 = table.Column<double>(type: "REAL", nullable: false),
                    Popravka_na_chair_radov_pipes_1 = table.Column<double>(type: "REAL", nullable: false),
                    Temperature_of_outcoming_gases_1 = table.Column<double>(type: "REAL", nullable: false),
                    Cross_sectional_area_for_passage_of_combustion_products_1 = table.Column<double>(type: "REAL", nullable: false),
                    Estimated_heating_surface_area_1 = table.Column<double>(type: "REAL", nullable: false),
                    Pipe_diametr_1 = table.Column<double>(type: "REAL", nullable: false),
                    Transverse_pitch_of_pipe_1 = table.Column<double>(type: "REAL", nullable: false),
                    Longitudinal_pitch_of_pipes_1 = table.Column<double>(type: "REAL", nullable: false),
                    Number_of_pipe_rows_1 = table.Column<double>(type: "REAL", nullable: false),
                    Temperature_of_the_the_heated_medium_at_The_inlet_1 = table.Column<double>(type: "REAL", nullable: false),
                    Temperature_of_the_the_heated_medium_at_The_outlet_1 = table.Column<double>(type: "REAL", nullable: false),
                    Temperature_of_incoming_gases_2 = table.Column<double>(type: "REAL", nullable: false),
                    Popravka_na_chair_radov_pipes_2 = table.Column<double>(type: "REAL", nullable: false),
                    Temperature_of_outcoming_gases_2 = table.Column<double>(type: "REAL", nullable: false),
                    Cross_sectional_area_for_passage_of_combustion_products_2 = table.Column<double>(type: "REAL", nullable: false),
                    Estimated_heating_surface_area_2 = table.Column<double>(type: "REAL", nullable: false),
                    Pipe_diametr_2 = table.Column<double>(type: "REAL", nullable: false),
                    Transverse_pitch_of_pipe_2 = table.Column<double>(type: "REAL", nullable: false),
                    Longitudinal_pitch_of_pipes_2 = table.Column<double>(type: "REAL", nullable: false),
                    Number_of_pipe_rows_2 = table.Column<double>(type: "REAL", nullable: false),
                    Temperature_of_the_the_heated_medium_at_The_inlet_2 = table.Column<double>(type: "REAL", nullable: false),
                    Temperature_of_the_the_heated_medium_at_The_outlet_2 = table.Column<double>(type: "REAL", nullable: false),
                    Temperature_of_incoming_gases_3 = table.Column<double>(type: "REAL", nullable: false),
                    Popravka_na_chair_radov_pipes_3 = table.Column<double>(type: "REAL", nullable: false),
                    Temperature_of_outcoming_gases_3 = table.Column<double>(type: "REAL", nullable: false),
                    Cross_sectional_area_for_passage_of_combustion_products_3 = table.Column<double>(type: "REAL", nullable: false),
                    Estimated_heating_surface_area_3 = table.Column<double>(type: "REAL", nullable: false),
                    Pipe_diametr_3 = table.Column<double>(type: "REAL", nullable: false),
                    Transverse_pitch_of_pipe_3 = table.Column<double>(type: "REAL", nullable: false),
                    Longitudinal_pitch_of_pipes_3 = table.Column<double>(type: "REAL", nullable: false),
                    Number_of_pipe_rows_3 = table.Column<double>(type: "REAL", nullable: false),
                    Temperature_of_the_the_heated_medium_at_The_inlet_3 = table.Column<double>(type: "REAL", nullable: false),
                    Temperature_of_the_the_heated_medium_at_The_outlet_3 = table.Column<double>(type: "REAL", nullable: false),
                    Temperature_of_incoming_gases_4 = table.Column<double>(type: "REAL", nullable: false),
                    Popravka_na_chair_radov_pipes_4 = table.Column<double>(type: "REAL", nullable: false),
                    Temperature_of_outcoming_gases_4 = table.Column<double>(type: "REAL", nullable: false),
                    Cross_sectional_area_for_passage_of_combustion_products_4 = table.Column<double>(type: "REAL", nullable: false),
                    Estimated_heating_surface_area_4 = table.Column<double>(type: "REAL", nullable: false),
                    Pipe_diametr_4 = table.Column<double>(type: "REAL", nullable: false),
                    Transverse_pitch_of_pipe_4 = table.Column<double>(type: "REAL", nullable: false),
                    Longitudinal_pitch_of_pipes_4 = table.Column<double>(type: "REAL", nullable: false),
                    Number_of_pipe_rows_4 = table.Column<double>(type: "REAL", nullable: false),
                    Temperature_of_the_the_heated_medium_at_The_inlet_4 = table.Column<double>(type: "REAL", nullable: false),
                    Temperature_of_the_the_heated_medium_at_The_outlet_4 = table.Column<double>(type: "REAL", nullable: false),
                    Proportion_of_intake_air = table.Column<double>(type: "REAL", nullable: false),
                    Thermal_resistance_of_deposits_on_pipes = table.Column<double>(type: "REAL", nullable: false),
                    The_emission_coefficient_of_a_completely_black_body = table.Column<double>(type: "REAL", nullable: false),
                    The_degree_of_blackness_of_the_walls_of_the_tube_package = table.Column<double>(type: "REAL", nullable: false),
                    Heat_preservation_coefficient = table.Column<double>(type: "REAL", nullable: false),
                    Purge_n = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariantUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VariantUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VariantUsers_Variants_VariantId",
                        column: x => x.VariantId,
                        principalTable: "Variants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Variants_UserId",
                table: "Variants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VariantUsers_UserId",
                table: "VariantUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VariantUsers_VariantId",
                table: "VariantUsers",
                column: "VariantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VariantUsers");

            migrationBuilder.DropTable(
                name: "Variants");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
