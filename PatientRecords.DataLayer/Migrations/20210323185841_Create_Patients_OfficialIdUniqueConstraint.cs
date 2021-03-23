using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientRecords.DataLayer.Migrations
{
    public partial class Create_Patients_OfficialIdUniqueConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE Patients ADD CONSTRAINT  AK_Patients_OfficialId UNIQUE(OfficialId); ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
