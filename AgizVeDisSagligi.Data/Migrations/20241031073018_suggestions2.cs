using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgizVeDisSagligi.Data.Migrations
{
    /// <inheritdoc />
    public partial class suggestions2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Suggestions",
                columns: new[] { "ID", "Recommendation" },
                values: new object[,]
                {
                    { 1, "Diş hekiminizi yılda en az iki kez ziyaret edin." },
                    { 2, "Diş çürümelerini önlemek için florürlü diş macunu kullanın." },
                    { 3, "Alkol, ağız kuruluğuna neden olabilir; bu nedenle tüketimini sınırlayın." },
                    { 4, " Şekerli ve asitli yiyeceklerden uzak durarak dengeli bir diyet uygulayın." },
                    { 5, "Diş sağlığınızı takip etmek için uygulamalar veya günlükler kullanarak alışkanlıklarınızı gözlemleyin." },
                    { 6, "Dişlerinizin arasındaki yiyecekleri temizlemek için günde bir kez diş ipi kullanın." },
                    { 7, "Antiseptik ağız gargarası kullanarak ağız hijyeninizi artırın." },
                    { 8, "Gazlı içecekler ve meyve suları gibi asidik içecekleri sınırlayın." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Suggestions",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Suggestions",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Suggestions",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Suggestions",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Suggestions",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Suggestions",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Suggestions",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Suggestions",
                keyColumn: "ID",
                keyValue: 8);
        }
    }
}
