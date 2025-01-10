using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WizardAcademyDropouts.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Failures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Failures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Knacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hp = table.Column<int>(type: "int", nullable: false),
                    HpMax = table.Column<int>(type: "int", nullable: false),
                    FailureId = table.Column<int>(type: "int", nullable: false),
                    KnackId = table.Column<int>(type: "int", nullable: false),
                    Conjuration = table.Column<int>(type: "int", nullable: false),
                    Elementalism = table.Column<int>(type: "int", nullable: false),
                    Enchantment = table.Column<int>(type: "int", nullable: false),
                    Illusion = table.Column<int>(type: "int", nullable: false),
                    Naturalism = table.Column<int>(type: "int", nullable: false),
                    Necromancy = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Failures_FailureId",
                        column: x => x.FailureId,
                        principalTable: "Failures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_Knacks_KnackId",
                        column: x => x.KnackId,
                        principalTable: "Knacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Failures",
                columns: new[] { "Id", "Description", "Name", "Summary" },
                values: new object[,]
                {
                    { 1, "I couldn't focus, and I changed my specialty constantly until my professors couldn't take it anymore. When you make a roll, you can drop the grade for the discipline of that roll by one letterand raise the grade of another discipline by one letter.", "DroppedOut", "I dropped out." },
                    { 2, "My spells are extra dangerous. I was kicked out for being a danger to the academy, myself, and everyone around me. My spells do +1 damage.", "KickedOut", "I was kicked out." },
                    { 3, "I'm so bad at magic, I'm resistant to it. Prevent 1 magical damage each round.", "FailedOut", "I failed out." }
                });

            migrationBuilder.InsertData(
                table: "Knacks",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Outside of combat, you can use double the number of words for a spell if the words are phrased as a rhyming couplet.", "Bardic" },
                    { 2, "You can sense the magic around you. You see auras of magic and can feel magic radiating off of items and spells. You get +1 to knowledge rolls for anything you can see or touch.", "Clairvoyant" },
                    { 3, "One or both of your parents is a Wizard Academy graduate and a generous donor. You start with one extra item from the common loot table.", "Legacy" },
                    { 4, "When all else fails, you aren't afraid to resort to good, old fashioned fisticuffs. You're stronger than the average wizard, and you can make a physical attack against an enemy as an action, dealing 1 damage to them. The enemy must be within striking damage or you must have something potentially dangerous to throw.", "Scrappy" },
                    { 5, "You are remarkably resilient. You have +2 max HP.", "Sturdy" },
                    { 6, "Whether with wings or an innate affinity for wind, you can fly.", "Windborne" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_FailureId",
                table: "Characters",
                column: "FailureId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_KnackId",
                table: "Characters",
                column: "KnackId");

            migrationBuilder.CreateIndex(
                name: "IX_Failures_Name",
                table: "Failures",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_CharacterId",
                table: "Items",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Knacks_Name",
                table: "Knacks",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Failures");

            migrationBuilder.DropTable(
                name: "Knacks");
        }
    }
}
