using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace pashokmatrkt4221.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_group",
                columns: table => new
                {
                    groupid = table.Column<int>(name: "group_id", type: "integer", nullable: false, comment: "Идентификатор записи группы")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cgroupname = table.Column<string>(name: "c_group_name", type: "varchar", maxLength: 100, nullable: false, comment: "Название группы")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_group_group_id", x => x.groupid);
                });

            migrationBuilder.CreateTable(
                name: "cd_student",
                columns: table => new
                {
                    studentid = table.Column<int>(name: "student_id", type: "integer", nullable: false, comment: "Идентификатор записи студента")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cstudentfirstname = table.Column<string>(name: "c_student_firstname", type: "varchar", maxLength: 100, nullable: false, comment: "Имя студента"),
                    cstudentlastname = table.Column<string>(name: "c_student_lastname", type: "varchar", maxLength: 100, nullable: false, comment: "Фамилия студента"),
                    cstudentmiddlename = table.Column<string>(name: "c_student_middlename", type: "varchar", maxLength: 100, nullable: true, comment: "Отчество студента"),
                    fgroupid = table.Column<int>(name: "f_group_id", type: "int4", nullable: false, comment: "Идентификатор группы")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_student_student_id", x => x.studentid);
                    table.ForeignKey(
                        name: "fk_f_group_id",
                        column: x => x.fgroupid,
                        principalTable: "cd_group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_student_fk_f_group_id",
                table: "cd_student",
                column: "f_group_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_student");

            migrationBuilder.DropTable(
                name: "cd_group");
        }
    }
}
