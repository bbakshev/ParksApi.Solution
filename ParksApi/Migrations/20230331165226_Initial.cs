using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParksApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Parks",
                columns: table => new
                {
                    ParkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    State = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Established = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parks", x => x.ParkId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "Description", "Established", "Name", "State" },
                values: new object[,]
                {
                    { 1, "Crater Lake is a caldera lake in the U.S. state of Oregon. It is the deepest lake in the United States, with a maximum depth of 1,949 feet (594 m). The lake is famous for its water clarity, with a visibility of 42 feet (13 m) in 1997, and is the fifth deepest in the world.", "1902", "Crater Lake", "Oregon" },
                    { 2, "Yellowstone National Park is an American national park located in the western United States, largely in the northwest corner of Wyoming and extending into Montana and Idaho. It was established by the U.S. Congress and signed into law by President Ulysses S. Grant on March 1, 1872.", "1872", "Yellowstone", "Wyoming" },
                    { 3, "Yosemite National Park is an American national park located in the western Sierra Nevada of Central California, bounded on the southeast by Sierra National Forest and on the northwest by Stanislaus National Forest. The park is managed by the National Park Service and covers an area of 747,956 acres (1,169.22 sq mi; 3,026.18 km2) and sits in four counties: Tuolumne, Mariposa, and Madera in Central California, and Mono County, adjacent to the eastern boundary of the park.", "1890", "Yosemite", "California" },
                    { 4, "Grand Canyon National Park is an American national park located in northwestern Arizona. The park's central feature is the Grand Canyon, a gorge of the Colorado River, which is often considered one of the Seven Wonders of the World. The park, which covers 1,217,262 acres (4,926.1 km2; 1,901.9 sq mi), received more than six million recreational visitors in 2018, which is the second highest count of any U.S. national park after Great Smoky Mountains National Park.", "1919", "Grand Canyon", "Arizona" },
                    { 5, "Zion National Park is a United States national park located in southwestern Utah, near the city of Springdale. A prominent feature of the 229-square-mile (590 km2) park is Zion Canyon, which is 15 miles (24 km) long and up to half a mile (800 m) deep, cut through the reddish and tan-colored Navajo Sandstone by the North Fork of the Virgin River.", "1919", "Zion", "Utah" },
                    { 6, "Glacier National Park is a national park located in the U.S. state of Montana. The park encompasses over 1 million acres (4,000 km2) and includes parts of two mountain ranges, more than 130 named lakes, more than 1,000 different species of plants, and hundreds of species of animals. The park is situated on the continental divide, and its ecosystems include alpine meadows, more than 70 glaciers, rugged mountain peaks, and dense coniferous and deciduous forests.", "1910", "Glacier", "Montana" },
                    { 7, "Olympic National Park is a U.S. national park located in the state of Washington. The park is located in the Pacific Northwest region of the United States and is situated in the temperate rainforest biome. The park has four distinct ecosystems: marine, coastal, temperate rainforest, and high mountain. The highest point in the park is 7,965-foot (2,436 m) Mount Olympus, and the lowest is sea level.", "1938", "Olympic", "Washington" },
                    { 8, "Rocky Mountain National Park is an American national park located in the north-central region of the U.S. state of Colorado. The park is situated between the towns of Estes Park to the east and Grand Lake to the west. The eastern and westerns slopes of the Continental Divide run directly through the center of the park, with the headwaters of the Colorado River located in the park's northwestern region.", "1915", "Rocky Mountain", "Colorado" },
                    { 9, "Acadia National Park is a national park located on Mount Desert Island and other coastal islands in Maine. The park protects the natural environment of the highest rocky headlands along the Atlantic coastline of the United States, an abundance of habitats, and a rich cultural heritage. The park is home to a wide variety of plants and animals, with habitats ranging from forests and lakes to rocky coastline and glacier-capped mountains.", "1919", "Acadia", "Maine" },
                    { 10, "Grand Teton National Park is an American national park located in northwestern Wyoming. The park is situated south of Yellowstone National Park and northwest of Jackson Hole. The park is named after the Grand Teton mountain range, which is part of the Teton Range. The Teton Range is a sub-range of the Rocky Mountains, and is geologically young, with most peaks rising above 10,000 feet (3,000 m) in the late 19th century.", "1929", "Grand Teton", "Wyoming" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parks");
        }
    }
}
