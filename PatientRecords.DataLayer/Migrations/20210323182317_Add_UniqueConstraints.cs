using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientRecords.DataLayer.Migrations
{
    public partial class Add_UniqueConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("ALTER TABLE AspNetUsers ADD CONSTRAINT AK_AspNetUsers_UserName UNIQUE(UserName); ");
            migrationBuilder.Sql("ALTER TABLE AspNetUsers ADD CONSTRAINT AK_AspNetUsers_Email UNIQUE(Email); ");
            migrationBuilder.Sql("ALTER TABLE AspNetRoles ADD CONSTRAINT AK_AspNetRoles_Name UNIQUE(Name); ");
            migrationBuilder.Sql("CREATE UNIQUE NONCLUSTERED INDEX IDX_Patients_Email_NOTNULL ON Patients(Email) WHERE Email IS NOT NULL; ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
