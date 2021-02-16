using Microsoft.EntityFrameworkCore.Migrations;

namespace RaceTrack.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                   name: "Vehicles",
                   columns: table => new
                   {
                       Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                       Name = table.Column<string>(maxLength: 256, nullable: true),                      
                   },
                   constraints: table =>
                   {
                       table.PrimaryKey("PK_Vehicles", x => x.Id);
                   });

            migrationBuilder.CreateTable(
               name: "VehiclesOnTrack",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                   VehicleId = table.Column<int>(nullable: false),                 
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_VehiclesOnTrack", x => x.Id);
                   table.ForeignKey(
                       name: "FK_VehiclesOnTrack_Vehicles_VehicleId",
                       column: x => x.VehicleId,
                       principalTable: "Vehicles",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
               });          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {         
            migrationBuilder.DropTable(
                name: "VehiclesOnTrack");

            migrationBuilder.DropTable(
              name: "Vehicles");
        }
    }
}
