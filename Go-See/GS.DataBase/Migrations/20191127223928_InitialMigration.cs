using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace GS.DataBase.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Country = table.Column<string>(nullable: true),
                    IsCapital = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Login = table.Column<string>(maxLength: 128, nullable: true),
                    FirstName = table.Column<string>(maxLength: 128, nullable: false),
                    LastName = table.Column<string>(maxLength: 128, nullable: false),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    Phone = table.Column<string>(maxLength: 25, nullable: true),
                    PasswordHash = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    CityId = table.Column<Guid>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Places_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trips_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    PlaceId = table.Column<Guid>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Text = table.Column<string>(maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripNodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TripId = table.Column<Guid>(nullable: false),
                    PlaceId = table.Column<Guid>(nullable: false),
                    SequenceNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripNodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripNodes_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripNodes_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Country", "Description", "IsCapital", "Name" },
                values: new object[,]
                {
                    { new Guid("79c63500-3cdf-4ea5-a395-ed175da496b5"), "Ukraine", "Kiev is the capital city of Ukraine, its largest economical, political, educational and cultural centre. Kiev is often called the mother of Slavic cities. It is more than fifteen centuries old and during this time Kiev has come a long way from its beginning as an ancient settlement of nomadic tribes to being one of the largest cities in the world.", true, "Kyiv" },
                    { new Guid("b9cf7616-0eba-44cd-9efe-cca8cdc05dd2"), "Ukraine", "If you've spent time in other Ukrainian regions, Lviv will come as a shock. Mysterious and architecturally lovely, this Unesco-listed city is the country's least Soviet and exudes the same authentic Central European charm as pretourism Prague or Krakуw once did. Its quaint cobbles, bean-perfumed coffeehouses and rattling trams are a continent away from the Soviet brutalism of the east. It's also a place where the candle of Ukrainian national identity burns brightest and where Russian is definitely a minority language.", false, "Lviv" },
                    { new Guid("5fa68335-7124-455d-8b60-d2eddb08af75"), "Hungary", "The Danube River, a source of inspiration for many artists, divided Buda and Pest, two large towns that became a single city in 1873. It is currently one of Europe's most important capital cities. Enormous iron bridges join both banks, Buda, the formal Royal district and most elegant residential area with Pest, the commercial and financial heart of the city.", true, "Budapest" },
                    { new Guid("2fb28fea-174a-4c50-8373-812fe25bb0c7"), "‎Austria", "Vienna, also described as Europe's cultural capital, is a metropolis with unique charm, vibrancy and flair. It boasts outstanding infrastructure, is clean and safe, and has all the inspiration that you could wish for in order to discover this wonderful part of Europe.", true, "Vienna" },
                    { new Guid("be3299db-161c-41ed-bfa0-7bac10702498"), "Italy", "Rome, Italian Roma, historic city and capital of Roma provincia (province), of Lazio regione (region), and of the country of Italy. Rome is located in the central portion of the Italian peninsula, on the Tiber River about 15 miles (24 km) inland from the Tyrrhenian Sea. Once the capital of an ancient republic and empire whose armies and polity defined the Western world in antiquity and left seemingly indelible imprints thereafter, the spiritual and physical seat of the Roman Catholic Church, and the site of major pinnacles of artistic and intellectual achievement, Rome is the Eternal City, remaining today a political capital, a religious centre, and a memorial to the creative imagination of the past. Area city, 496 square miles (1,285 square km); province, 2,066 square miles (5,352 square km). Pop. (2011) city, 2,617,175; province, 3,997,465; (2007 est.) urban agglom., 3,339,000; (2016 est.) city, 2,873,494; province, 4,353,738.", true, "Rome" },
                    { new Guid("ff6b700a-3786-4920-8560-dbeef260cc14"), "Czech Republic", "Prague, Czech Praha, city, capital of the Czech Republic. Lying at the heart of Europe, it is one of the continent's finest cities and the major Czech economic and cultural centre. The city has a rich architectural heritage that reflects both the uncertain currents of history in Bohemia and an urban life extending back more than 1,000 years.", true, "Prague" },
                    { new Guid("88d8d1b2-b2da-46e2-9233-0a11f421bdb8"), "Norway", "Oslo is considered as a global city and is the major Norwegian hub for trading, shipping and banking. Location of Oslo: Oslo is positioned at the northernmost end of the Oslofjord, and occupies around 40 big and small islands within its limits. The climate of the region is temperate, humid.", true, "Oslo" },
                    { new Guid("b5d87abe-c1bf-4d02-8be5-16b4c840dcd7"), "Germany", "Berlin is a city of art, artists and museums. More than 170 museums, including those on the famous museum island, put the treasures of the world on public display. Culturally minded visitors from all corners of the globe come to Berlin to see performances by leading orchestras – such as the internationally celebrated Berlin Philharmonic – and to attend ballets and operas at the three major opera houses. A multitude of theatres specialising in plays, variety, revue and cabaret offer stage entertainment in all its forms.", true, "Berlin" },
                    { new Guid("443e9796-a65b-4789-99e0-e10dd4d25d42"), "Poland", "Krakow is Poland's second largest city and the country's main tourist destination. The local economy is fueled mostly by expanding service sector although diverse industry and production still provide a fairly significant portion of jobs and wealth. The city remains the culture capital of Poland and its seven universities and nearly twenty other institutions of higher learning make Krakow the country's principal center of science and education. ", false, "Krakow" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Login", "PasswordHash", "Phone" },
                values: new object[,]
                {
                    { new Guid("8a255896-6f0f-4f67-9baa-551483e76bf6"), "jackleo@mail.com", "Jack", "Leonardo", "jackleo", "lack1999", "380942378556" },
                    { new Guid("0f58a296-6f85-4f67-9baa-551483e76bf6"), "", "Lucy", "Duveteri", "lucyduvet", "2012LuDu", "" },
                    { new Guid("551483e7-6f85-4f67-9baa-0f58a2966bf6"), "maxfizzer2000@mail.com", "Max", "Fizzer", "maxfizz", "max_2000F", "" },
                    { new Guid("9baa83e7-6f85-4f67-5514-0f58a2966bf6"), "", "Loky", "Igloomir", "iglooloky", "loky_vs_tor", "380933379571" }
                });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "CityId", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("95c84711-1874-471d-a379-2be67ffe82b0"), new Guid("79c63500-3cdf-4ea5-a395-ed175da496b5"), "Saint Sophia�s Cathedral is an outstanding complex; work started on it in 1037 and lasted for just three years. As the architectural monument has had only a few reconstructions, you can marvel at the Byzantine cathedral in close to its original form. In addition, as it is located at the intersection of the four leading roads in Kiev, climb to the cathedral�s bell tower and you�ll be rewarded with a magnificent view from the top.", "Saint Sophia's Cathedral", "architecture" },
                    { new Guid("422eb593-d068-476f-9768-7ae6ac43d82c"), new Guid("b9cf7616-0eba-44cd-9efe-cca8cdc05dd2"), "It is the heart of the city, that can be translated as Market Square. For the past 500 years it has been the bustling center of city life and till now retains all the charm of the old European city, without the pretentions of its more famous neighbors - Prague and Krakow.", "Rynok Square", "architecture" },
                    { new Guid("c411a195-680e-461f-8675-060e11636c96"), new Guid("5fa68335-7124-455d-8b60-d2eddb08af75"), "The Hungarian Parliament Building, which was designed and built in the Gothic Revival style, is one of the largest buildings in Hungary, and is home to hundreds of parliamentary offices. Although the impressive building looks fantastic from every angle, to see the whole building in its full glory, it is worth viewing it from the other side of the Danube.", "Parliament Building", "architecture" },
                    { new Guid("7c53d6b6-50d0-4b19-8226-dda7d6eb7abd"), new Guid("2fb28fea-174a-4c50-8373-812fe25bb0c7"), "The spectacular 18th-century Sch�nbrunn Palace (Schloss Sch�nbrunn) is worth visiting not only for its magnificent architecture, but also for its beautiful park-like setting. This Baroque palace contains more than 1,441 rooms and apartments, including those once used by Empress Maria Theresa.", "Sch�nbrunn Palace and Gardens", "nature" },
                    { new Guid("9415bf74-04a0-4614-9340-22e0d3f058ae"), new Guid("be3299db-161c-41ed-bfa0-7bac10702498"), "True Roman Carbonara is an art form. Impossibly creamy (with not a spot of cream in sight), this rich Roman sauce is one of those dishes you dream about for years to c", "Rigatoni Carbonara", "food" },
                    { new Guid("69077c36-b070-4903-985b-1785d5547529"), new Guid("ff6b700a-3786-4920-8560-dbeef260cc14"), "One of the most recognizable old bridges in Europe, magnificent Charles Bridge (Karluv Most) boasts 32 unique points of interest along its 621-meter span. Built in 1357, the bridge has long been the subject of a great deal of superstition, including the builders having laid the initial bridge stone on the 9th of July at exactly 5:31am, a precise set of numbers (135797531) believed to give the structure additional strength.", "Charles Bridge", "architecture" },
                    { new Guid("636c9cfb-8abb-4393-9f13-b1c55a5295d4"), new Guid("88d8d1b2-b2da-46e2-9233-0a11f421bdb8"), "No less exciting are similar ships from Tune and Gokstad, together with all the artefacts found buried with them like beds, small boats, a complete cart, tent components, wood carvings, textiles and other treasures brought to light in Viking graves.", "Viking Ship Museum", "museum" },
                    { new Guid("fec0ed93-4f8a-405e-a2b2-4c7e14012845"), new Guid("b5d87abe-c1bf-4d02-8be5-16b4c840dcd7"), "Home to three famous museums - the Pergamon, the Altes and the Bode.", "Museum Island", "museum" },
                    { new Guid("bd9007a0-40db-443d-80b0-2d5175011aa4"), new Guid("443e9796-a65b-4789-99e0-e10dd4d25d42"), "Pod Aniolami is a beautiful restaurant in Krakow Old Town with 13th-century interiors. You can choose different areas of the restaurant to dine in, including downstairs in the cosy cellars, or in the Garden in the medieval courtyard.", "Pod Aniolami", "food" }
                });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("1a255896-6f0f-4f67-9baa-551483e76bf6"), "Rome 2019", new Guid("8a255896-6f0f-4f67-9baa-551483e76bf6") },
                    { new Guid("2b255896-6f0f-4f67-9baa-551483e76bf6"), "To the edge of the world", new Guid("0f58a296-6f85-4f67-9baa-551483e76bf6") },
                    { new Guid("3c255896-6f0f-4f67-9baa-551483e76bf6"), "Family trip", new Guid("551483e7-6f85-4f67-9baa-0f58a2966bf6") },
                    { new Guid("4d255896-6f0f-4f67-9baa-551483e76bf6"), "Honeymoon", new Guid("9baa83e7-6f85-4f67-5514-0f58a2966bf6") }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "PlaceId", "Rating", "Text", "UserId" },
                values: new object[,]
                {
                    { new Guid("2d75c681-dde0-4ebf-b0aa-e5cfe170dca8"), new Guid("95c84711-1874-471d-a379-2be67ffe82b0"), 4, "This picturesque cathedral is also so typical of the Orthodox architecture and is really an awesome building. Its open to visit and to participate for those who wish to. Its just a short walk from the Heavens gate, Kiev Opera House and St Volodymyrs Cathedral.", new Guid("8a255896-6f0f-4f67-9baa-551483e76bf6") },
                    { new Guid("db43925d-6840-4f61-b4a7-4c1094d0a092"), new Guid("422eb593-d068-476f-9768-7ae6ac43d82c"), 3, "A lot of activity in the square, along with a very helpful tourist information center.", new Guid("0f58a296-6f85-4f67-9baa-551483e76bf6") },
                    { new Guid("bb305f87-3adf-45af-8337-d446b330d4f4"), new Guid("c411a195-680e-461f-8675-060e11636c96"), 5, "We walked around this massive building during the day. It was stunning to look at. So many spires and ornate tasteful details. We rode by it at night. With the building all lite up, it was majestic! A definite must see!", new Guid("551483e7-6f85-4f67-9baa-0f58a2966bf6") },
                    { new Guid("08ae14b8-8e59-4126-96de-4c9d42de3434"), new Guid("7c53d6b6-50d0-4b19-8226-dda7d6eb7abd"), 4, "Baroque style at its best. Impressive architecture, fantastic gardens. All clean and well maintained. It was magical listening to the concert in one of the main halls with out any AV input. Excellent connectivity from centre of Vienna. A must place to visit", new Guid("551483e7-6f85-4f67-9baa-0f58a2966bf6") },
                    { new Guid("837c4f6a-dc2c-4aff-9e16-90acd57425d3"), new Guid("69077c36-b070-4903-985b-1785d5547529"), 4, "Really nice bridge with way too many people on it. Not much more to say about it, very crowded probably better to visit really early in the morning.", new Guid("8a255896-6f0f-4f67-9baa-551483e76bf6") },
                    { new Guid("04714d94-dbaf-4747-aa9d-f417bdeb5c58"), new Guid("636c9cfb-8abb-4393-9f13-b1c55a5295d4"), 5, "Really loved this simple museum with wonderfully restored Viking ships (and contents) that were found in burial sites. Simply and impressively presented. We couldn't see a need for the new building they are planning - we loved it just as it is.", new Guid("0f58a296-6f85-4f67-9baa-551483e76bf6") }
                });

            migrationBuilder.InsertData(
                table: "TripNodes",
                columns: new[] { "Id", "PlaceId", "SequenceNumber", "TripId" },
                values: new object[,]
                {
                    { new Guid("219007a0-40db-443d-80b0-2d5175011aa4"), new Guid("95c84711-1874-471d-a379-2be67ffe82b0"), 2, new Guid("4d255896-6f0f-4f67-9baa-551483e76bf6") },
                    { new Guid("209007a0-40db-443d-80b0-2d5175011aa4"), new Guid("bd9007a0-40db-443d-80b0-2d5175011aa4"), 1, new Guid("4d255896-6f0f-4f67-9baa-551483e76bf6") },
                    { new Guid("199007a0-40db-443d-80b0-2d5175011aa4"), new Guid("bd9007a0-40db-443d-80b0-2d5175011aa4"), 2, new Guid("3c255896-6f0f-4f67-9baa-551483e76bf6") },
                    { new Guid("189007a0-40db-443d-80b0-2d5175011aa4"), new Guid("fec0ed93-4f8a-405e-a2b2-4c7e14012845"), 1, new Guid("3c255896-6f0f-4f67-9baa-551483e76bf6") },
                    { new Guid("179007a0-40db-443d-80b0-2d5175011aa4"), new Guid("636c9cfb-8abb-4393-9f13-b1c55a5295d4"), 3, new Guid("2b255896-6f0f-4f67-9baa-551483e76bf6") },
                    { new Guid("149007a0-40db-443d-80b0-2d5175011aa4"), new Guid("7c53d6b6-50d0-4b19-8226-dda7d6eb7abd"), 4, new Guid("1a255896-6f0f-4f67-9baa-551483e76bf6") },
                    { new Guid("159007a0-40db-443d-80b0-2d5175011aa4"), new Guid("9415bf74-04a0-4614-9340-22e0d3f058ae"), 1, new Guid("2b255896-6f0f-4f67-9baa-551483e76bf6") },
                    { new Guid("229007a0-40db-443d-80b0-2d5175011aa4"), new Guid("422eb593-d068-476f-9768-7ae6ac43d82c"), 3, new Guid("4d255896-6f0f-4f67-9baa-551483e76bf6") },
                    { new Guid("139007a0-40db-443d-80b0-2d5175011aa4"), new Guid("c411a195-680e-461f-8675-060e11636c96"), 3, new Guid("1a255896-6f0f-4f67-9baa-551483e76bf6") },
                    { new Guid("129007a0-40db-443d-80b0-2d5175011aa4"), new Guid("422eb593-d068-476f-9768-7ae6ac43d82c"), 2, new Guid("1a255896-6f0f-4f67-9baa-551483e76bf6") },
                    { new Guid("119007a0-40db-443d-80b0-2d5175011aa4"), new Guid("95c84711-1874-471d-a379-2be67ffe82b0"), 1, new Guid("1a255896-6f0f-4f67-9baa-551483e76bf6") },
                    { new Guid("169007a0-40db-443d-80b0-2d5175011aa4"), new Guid("69077c36-b070-4903-985b-1785d5547529"), 2, new Guid("2b255896-6f0f-4f67-9baa-551483e76bf6") },
                    { new Guid("239007a0-40db-443d-80b0-2d5175011aa4"), new Guid("fec0ed93-4f8a-405e-a2b2-4c7e14012845"), 4, new Guid("4d255896-6f0f-4f67-9baa-551483e76bf6") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Places_CityId",
                table: "Places",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_PlaceId",
                table: "Reviews",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TripNodes_PlaceId",
                table: "TripNodes",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_TripNodes_TripId",
                table: "TripNodes",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_UserId",
                table: "Trips",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "TripNodes");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
