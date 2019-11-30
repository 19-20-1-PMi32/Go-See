﻿// <auto-generated />
using System;
using GS.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GS.DataBase.Migrations
{
    [DbContext(typeof(GSDbContext))]
    [Migration("20191127223928_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GS.DataBase.Entities.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Country");

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<bool>("IsCapital");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = new Guid("79c63500-3cdf-4ea5-a395-ed175da496b5"),
                            Country = "Ukraine",
                            Description = "Kiev is the capital city of Ukraine, its largest economical, political, educational and cultural centre. Kiev is often called the mother of Slavic cities. It is more than fifteen centuries old and during this time Kiev has come a long way from its beginning as an ancient settlement of nomadic tribes to being one of the largest cities in the world.",
                            IsCapital = true,
                            Name = "Kyiv"
                        },
                        new
                        {
                            Id = new Guid("b9cf7616-0eba-44cd-9efe-cca8cdc05dd2"),
                            Country = "Ukraine",
                            Description = "If you've spent time in other Ukrainian regions, Lviv will come as a shock. Mysterious and architecturally lovely, this Unesco-listed city is the country's least Soviet and exudes the same authentic Central European charm as pretourism Prague or Krakуw once did. Its quaint cobbles, bean-perfumed coffeehouses and rattling trams are a continent away from the Soviet brutalism of the east. It's also a place where the candle of Ukrainian national identity burns brightest and where Russian is definitely a minority language.",
                            IsCapital = false,
                            Name = "Lviv"
                        },
                        new
                        {
                            Id = new Guid("5fa68335-7124-455d-8b60-d2eddb08af75"),
                            Country = "Hungary",
                            Description = "The Danube River, a source of inspiration for many artists, divided Buda and Pest, two large towns that became a single city in 1873. It is currently one of Europe's most important capital cities. Enormous iron bridges join both banks, Buda, the formal Royal district and most elegant residential area with Pest, the commercial and financial heart of the city.",
                            IsCapital = true,
                            Name = "Budapest"
                        },
                        new
                        {
                            Id = new Guid("2fb28fea-174a-4c50-8373-812fe25bb0c7"),
                            Country = "‎Austria",
                            Description = "Vienna, also described as Europe's cultural capital, is a metropolis with unique charm, vibrancy and flair. It boasts outstanding infrastructure, is clean and safe, and has all the inspiration that you could wish for in order to discover this wonderful part of Europe.",
                            IsCapital = true,
                            Name = "Vienna"
                        },
                        new
                        {
                            Id = new Guid("be3299db-161c-41ed-bfa0-7bac10702498"),
                            Country = "Italy",
                            Description = "Rome, Italian Roma, historic city and capital of Roma provincia (province), of Lazio regione (region), and of the country of Italy. Rome is located in the central portion of the Italian peninsula, on the Tiber River about 15 miles (24 km) inland from the Tyrrhenian Sea. Once the capital of an ancient republic and empire whose armies and polity defined the Western world in antiquity and left seemingly indelible imprints thereafter, the spiritual and physical seat of the Roman Catholic Church, and the site of major pinnacles of artistic and intellectual achievement, Rome is the Eternal City, remaining today a political capital, a religious centre, and a memorial to the creative imagination of the past. Area city, 496 square miles (1,285 square km); province, 2,066 square miles (5,352 square km). Pop. (2011) city, 2,617,175; province, 3,997,465; (2007 est.) urban agglom., 3,339,000; (2016 est.) city, 2,873,494; province, 4,353,738.",
                            IsCapital = true,
                            Name = "Rome"
                        },
                        new
                        {
                            Id = new Guid("ff6b700a-3786-4920-8560-dbeef260cc14"),
                            Country = "Czech Republic",
                            Description = "Prague, Czech Praha, city, capital of the Czech Republic. Lying at the heart of Europe, it is one of the continent's finest cities and the major Czech economic and cultural centre. The city has a rich architectural heritage that reflects both the uncertain currents of history in Bohemia and an urban life extending back more than 1,000 years.",
                            IsCapital = true,
                            Name = "Prague"
                        },
                        new
                        {
                            Id = new Guid("88d8d1b2-b2da-46e2-9233-0a11f421bdb8"),
                            Country = "Norway",
                            Description = "Oslo is considered as a global city and is the major Norwegian hub for trading, shipping and banking. Location of Oslo: Oslo is positioned at the northernmost end of the Oslofjord, and occupies around 40 big and small islands within its limits. The climate of the region is temperate, humid.",
                            IsCapital = true,
                            Name = "Oslo"
                        },
                        new
                        {
                            Id = new Guid("b5d87abe-c1bf-4d02-8be5-16b4c840dcd7"),
                            Country = "Germany",
                            Description = "Berlin is a city of art, artists and museums. More than 170 museums, including those on the famous museum island, put the treasures of the world on public display. Culturally minded visitors from all corners of the globe come to Berlin to see performances by leading orchestras – such as the internationally celebrated Berlin Philharmonic – and to attend ballets and operas at the three major opera houses. A multitude of theatres specialising in plays, variety, revue and cabaret offer stage entertainment in all its forms.",
                            IsCapital = true,
                            Name = "Berlin"
                        },
                        new
                        {
                            Id = new Guid("443e9796-a65b-4789-99e0-e10dd4d25d42"),
                            Country = "Poland",
                            Description = "Krakow is Poland's second largest city and the country's main tourist destination. The local economy is fueled mostly by expanding service sector although diverse industry and production still provide a fairly significant portion of jobs and wealth. The city remains the culture capital of Poland and its seven universities and nearly twenty other institutions of higher learning make Krakow the country's principal center of science and education. ",
                            IsCapital = false,
                            Name = "Krakow"
                        });
                });

            modelBuilder.Entity("GS.DataBase.Entities.Place", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CityId");

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Places");

                    b.HasData(
                        new
                        {
                            Id = new Guid("95c84711-1874-471d-a379-2be67ffe82b0"),
                            CityId = new Guid("79c63500-3cdf-4ea5-a395-ed175da496b5"),
                            Description = "Saint Sophia�s Cathedral is an outstanding complex; work started on it in 1037 and lasted for just three years. As the architectural monument has had only a few reconstructions, you can marvel at the Byzantine cathedral in close to its original form. In addition, as it is located at the intersection of the four leading roads in Kiev, climb to the cathedral�s bell tower and you�ll be rewarded with a magnificent view from the top.",
                            Name = "Saint Sophia's Cathedral",
                            Type = "architecture"
                        },
                        new
                        {
                            Id = new Guid("422eb593-d068-476f-9768-7ae6ac43d82c"),
                            CityId = new Guid("b9cf7616-0eba-44cd-9efe-cca8cdc05dd2"),
                            Description = "It is the heart of the city, that can be translated as Market Square. For the past 500 years it has been the bustling center of city life and till now retains all the charm of the old European city, without the pretentions of its more famous neighbors - Prague and Krakow.",
                            Name = "Rynok Square",
                            Type = "architecture"
                        },
                        new
                        {
                            Id = new Guid("c411a195-680e-461f-8675-060e11636c96"),
                            CityId = new Guid("5fa68335-7124-455d-8b60-d2eddb08af75"),
                            Description = "The Hungarian Parliament Building, which was designed and built in the Gothic Revival style, is one of the largest buildings in Hungary, and is home to hundreds of parliamentary offices. Although the impressive building looks fantastic from every angle, to see the whole building in its full glory, it is worth viewing it from the other side of the Danube.",
                            Name = "Parliament Building",
                            Type = "architecture"
                        },
                        new
                        {
                            Id = new Guid("7c53d6b6-50d0-4b19-8226-dda7d6eb7abd"),
                            CityId = new Guid("2fb28fea-174a-4c50-8373-812fe25bb0c7"),
                            Description = "The spectacular 18th-century Sch�nbrunn Palace (Schloss Sch�nbrunn) is worth visiting not only for its magnificent architecture, but also for its beautiful park-like setting. This Baroque palace contains more than 1,441 rooms and apartments, including those once used by Empress Maria Theresa.",
                            Name = "Sch�nbrunn Palace and Gardens",
                            Type = "nature"
                        },
                        new
                        {
                            Id = new Guid("9415bf74-04a0-4614-9340-22e0d3f058ae"),
                            CityId = new Guid("be3299db-161c-41ed-bfa0-7bac10702498"),
                            Description = "True Roman Carbonara is an art form. Impossibly creamy (with not a spot of cream in sight), this rich Roman sauce is one of those dishes you dream about for years to c",
                            Name = "Rigatoni Carbonara",
                            Type = "food"
                        },
                        new
                        {
                            Id = new Guid("69077c36-b070-4903-985b-1785d5547529"),
                            CityId = new Guid("ff6b700a-3786-4920-8560-dbeef260cc14"),
                            Description = "One of the most recognizable old bridges in Europe, magnificent Charles Bridge (Karluv Most) boasts 32 unique points of interest along its 621-meter span. Built in 1357, the bridge has long been the subject of a great deal of superstition, including the builders having laid the initial bridge stone on the 9th of July at exactly 5:31am, a precise set of numbers (135797531) believed to give the structure additional strength.",
                            Name = "Charles Bridge",
                            Type = "architecture"
                        },
                        new
                        {
                            Id = new Guid("636c9cfb-8abb-4393-9f13-b1c55a5295d4"),
                            CityId = new Guid("88d8d1b2-b2da-46e2-9233-0a11f421bdb8"),
                            Description = "No less exciting are similar ships from Tune and Gokstad, together with all the artefacts found buried with them like beds, small boats, a complete cart, tent components, wood carvings, textiles and other treasures brought to light in Viking graves.",
                            Name = "Viking Ship Museum",
                            Type = "museum"
                        },
                        new
                        {
                            Id = new Guid("fec0ed93-4f8a-405e-a2b2-4c7e14012845"),
                            CityId = new Guid("b5d87abe-c1bf-4d02-8be5-16b4c840dcd7"),
                            Description = "Home to three famous museums - the Pergamon, the Altes and the Bode.",
                            Name = "Museum Island",
                            Type = "museum"
                        },
                        new
                        {
                            Id = new Guid("bd9007a0-40db-443d-80b0-2d5175011aa4"),
                            CityId = new Guid("443e9796-a65b-4789-99e0-e10dd4d25d42"),
                            Description = "Pod Aniolami is a beautiful restaurant in Krakow Old Town with 13th-century interiors. You can choose different areas of the restaurant to dine in, including downstairs in the cosy cellars, or in the Garden in the medieval courtyard.",
                            Name = "Pod Aniolami",
                            Type = "food"
                        });
                });

            modelBuilder.Entity("GS.DataBase.Entities.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("PlaceId");

                    b.Property<int>("Rating");

                    b.Property<string>("Text")
                        .HasMaxLength(512);

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2d75c681-dde0-4ebf-b0aa-e5cfe170dca8"),
                            PlaceId = new Guid("95c84711-1874-471d-a379-2be67ffe82b0"),
                            Rating = 4,
                            Text = "This picturesque cathedral is also so typical of the Orthodox architecture and is really an awesome building. Its open to visit and to participate for those who wish to. Its just a short walk from the Heavens gate, Kiev Opera House and St Volodymyrs Cathedral.",
                            UserId = new Guid("8a255896-6f0f-4f67-9baa-551483e76bf6")
                        },
                        new
                        {
                            Id = new Guid("db43925d-6840-4f61-b4a7-4c1094d0a092"),
                            PlaceId = new Guid("422eb593-d068-476f-9768-7ae6ac43d82c"),
                            Rating = 3,
                            Text = "A lot of activity in the square, along with a very helpful tourist information center.",
                            UserId = new Guid("0f58a296-6f85-4f67-9baa-551483e76bf6")
                        },
                        new
                        {
                            Id = new Guid("bb305f87-3adf-45af-8337-d446b330d4f4"),
                            PlaceId = new Guid("c411a195-680e-461f-8675-060e11636c96"),
                            Rating = 5,
                            Text = "We walked around this massive building during the day. It was stunning to look at. So many spires and ornate tasteful details. We rode by it at night. With the building all lite up, it was majestic! A definite must see!",
                            UserId = new Guid("551483e7-6f85-4f67-9baa-0f58a2966bf6")
                        },
                        new
                        {
                            Id = new Guid("08ae14b8-8e59-4126-96de-4c9d42de3434"),
                            PlaceId = new Guid("7c53d6b6-50d0-4b19-8226-dda7d6eb7abd"),
                            Rating = 4,
                            Text = "Baroque style at its best. Impressive architecture, fantastic gardens. All clean and well maintained. It was magical listening to the concert in one of the main halls with out any AV input. Excellent connectivity from centre of Vienna. A must place to visit",
                            UserId = new Guid("551483e7-6f85-4f67-9baa-0f58a2966bf6")
                        },
                        new
                        {
                            Id = new Guid("837c4f6a-dc2c-4aff-9e16-90acd57425d3"),
                            PlaceId = new Guid("69077c36-b070-4903-985b-1785d5547529"),
                            Rating = 4,
                            Text = "Really nice bridge with way too many people on it. Not much more to say about it, very crowded probably better to visit really early in the morning.",
                            UserId = new Guid("8a255896-6f0f-4f67-9baa-551483e76bf6")
                        },
                        new
                        {
                            Id = new Guid("04714d94-dbaf-4747-aa9d-f417bdeb5c58"),
                            PlaceId = new Guid("636c9cfb-8abb-4393-9f13-b1c55a5295d4"),
                            Rating = 5,
                            Text = "Really loved this simple museum with wonderfully restored Viking ships (and contents) that were found in burial sites. Simply and impressively presented. We couldn't see a need for the new building they are planning - we loved it just as it is.",
                            UserId = new Guid("0f58a296-6f85-4f67-9baa-551483e76bf6")
                        });
                });

            modelBuilder.Entity("GS.DataBase.Entities.Trip", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Trips");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1a255896-6f0f-4f67-9baa-551483e76bf6"),
                            Name = "Rome 2019",
                            UserId = new Guid("8a255896-6f0f-4f67-9baa-551483e76bf6")
                        },
                        new
                        {
                            Id = new Guid("2b255896-6f0f-4f67-9baa-551483e76bf6"),
                            Name = "To the edge of the world",
                            UserId = new Guid("0f58a296-6f85-4f67-9baa-551483e76bf6")
                        },
                        new
                        {
                            Id = new Guid("3c255896-6f0f-4f67-9baa-551483e76bf6"),
                            Name = "Family trip",
                            UserId = new Guid("551483e7-6f85-4f67-9baa-0f58a2966bf6")
                        },
                        new
                        {
                            Id = new Guid("4d255896-6f0f-4f67-9baa-551483e76bf6"),
                            Name = "Honeymoon",
                            UserId = new Guid("9baa83e7-6f85-4f67-5514-0f58a2966bf6")
                        });
                });

            modelBuilder.Entity("GS.DataBase.Entities.TripNode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("PlaceId");

                    b.Property<int>("SequenceNumber");

                    b.Property<Guid>("TripId");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.HasIndex("TripId");

                    b.ToTable("TripNodes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("119007a0-40db-443d-80b0-2d5175011aa4"),
                            PlaceId = new Guid("95c84711-1874-471d-a379-2be67ffe82b0"),
                            SequenceNumber = 1,
                            TripId = new Guid("1a255896-6f0f-4f67-9baa-551483e76bf6")
                        },
                        new
                        {
                            Id = new Guid("129007a0-40db-443d-80b0-2d5175011aa4"),
                            PlaceId = new Guid("422eb593-d068-476f-9768-7ae6ac43d82c"),
                            SequenceNumber = 2,
                            TripId = new Guid("1a255896-6f0f-4f67-9baa-551483e76bf6")
                        },
                        new
                        {
                            Id = new Guid("139007a0-40db-443d-80b0-2d5175011aa4"),
                            PlaceId = new Guid("c411a195-680e-461f-8675-060e11636c96"),
                            SequenceNumber = 3,
                            TripId = new Guid("1a255896-6f0f-4f67-9baa-551483e76bf6")
                        },
                        new
                        {
                            Id = new Guid("149007a0-40db-443d-80b0-2d5175011aa4"),
                            PlaceId = new Guid("7c53d6b6-50d0-4b19-8226-dda7d6eb7abd"),
                            SequenceNumber = 4,
                            TripId = new Guid("1a255896-6f0f-4f67-9baa-551483e76bf6")
                        },
                        new
                        {
                            Id = new Guid("159007a0-40db-443d-80b0-2d5175011aa4"),
                            PlaceId = new Guid("9415bf74-04a0-4614-9340-22e0d3f058ae"),
                            SequenceNumber = 1,
                            TripId = new Guid("2b255896-6f0f-4f67-9baa-551483e76bf6")
                        },
                        new
                        {
                            Id = new Guid("169007a0-40db-443d-80b0-2d5175011aa4"),
                            PlaceId = new Guid("69077c36-b070-4903-985b-1785d5547529"),
                            SequenceNumber = 2,
                            TripId = new Guid("2b255896-6f0f-4f67-9baa-551483e76bf6")
                        },
                        new
                        {
                            Id = new Guid("179007a0-40db-443d-80b0-2d5175011aa4"),
                            PlaceId = new Guid("636c9cfb-8abb-4393-9f13-b1c55a5295d4"),
                            SequenceNumber = 3,
                            TripId = new Guid("2b255896-6f0f-4f67-9baa-551483e76bf6")
                        },
                        new
                        {
                            Id = new Guid("189007a0-40db-443d-80b0-2d5175011aa4"),
                            PlaceId = new Guid("fec0ed93-4f8a-405e-a2b2-4c7e14012845"),
                            SequenceNumber = 1,
                            TripId = new Guid("3c255896-6f0f-4f67-9baa-551483e76bf6")
                        },
                        new
                        {
                            Id = new Guid("199007a0-40db-443d-80b0-2d5175011aa4"),
                            PlaceId = new Guid("bd9007a0-40db-443d-80b0-2d5175011aa4"),
                            SequenceNumber = 2,
                            TripId = new Guid("3c255896-6f0f-4f67-9baa-551483e76bf6")
                        },
                        new
                        {
                            Id = new Guid("209007a0-40db-443d-80b0-2d5175011aa4"),
                            PlaceId = new Guid("bd9007a0-40db-443d-80b0-2d5175011aa4"),
                            SequenceNumber = 1,
                            TripId = new Guid("4d255896-6f0f-4f67-9baa-551483e76bf6")
                        },
                        new
                        {
                            Id = new Guid("219007a0-40db-443d-80b0-2d5175011aa4"),
                            PlaceId = new Guid("95c84711-1874-471d-a379-2be67ffe82b0"),
                            SequenceNumber = 2,
                            TripId = new Guid("4d255896-6f0f-4f67-9baa-551483e76bf6")
                        },
                        new
                        {
                            Id = new Guid("229007a0-40db-443d-80b0-2d5175011aa4"),
                            PlaceId = new Guid("422eb593-d068-476f-9768-7ae6ac43d82c"),
                            SequenceNumber = 3,
                            TripId = new Guid("4d255896-6f0f-4f67-9baa-551483e76bf6")
                        },
                        new
                        {
                            Id = new Guid("239007a0-40db-443d-80b0-2d5175011aa4"),
                            PlaceId = new Guid("fec0ed93-4f8a-405e-a2b2-4c7e14012845"),
                            SequenceNumber = 4,
                            TripId = new Guid("4d255896-6f0f-4f67-9baa-551483e76bf6")
                        });
                });

            modelBuilder.Entity("GS.DataBase.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Login")
                        .HasMaxLength(128);

                    b.Property<string>("PasswordHash")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8a255896-6f0f-4f67-9baa-551483e76bf6"),
                            Email = "jackleo@mail.com",
                            FirstName = "Jack",
                            LastName = "Leonardo",
                            Login = "jackleo",
                            PasswordHash = "lack1999",
                            Phone = "380942378556"
                        },
                        new
                        {
                            Id = new Guid("0f58a296-6f85-4f67-9baa-551483e76bf6"),
                            Email = "",
                            FirstName = "Lucy",
                            LastName = "Duveteri",
                            Login = "lucyduvet",
                            PasswordHash = "2012LuDu",
                            Phone = ""
                        },
                        new
                        {
                            Id = new Guid("551483e7-6f85-4f67-9baa-0f58a2966bf6"),
                            Email = "maxfizzer2000@mail.com",
                            FirstName = "Max",
                            LastName = "Fizzer",
                            Login = "maxfizz",
                            PasswordHash = "max_2000F",
                            Phone = ""
                        },
                        new
                        {
                            Id = new Guid("9baa83e7-6f85-4f67-5514-0f58a2966bf6"),
                            Email = "",
                            FirstName = "Loky",
                            LastName = "Igloomir",
                            Login = "iglooloky",
                            PasswordHash = "loky_vs_tor",
                            Phone = "380933379571"
                        });
                });

            modelBuilder.Entity("GS.DataBase.Entities.Place", b =>
                {
                    b.HasOne("GS.DataBase.Entities.City", "City")
                        .WithMany("Places")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("GS.DataBase.Entities.Review", b =>
                {
                    b.HasOne("GS.DataBase.Entities.Place", "Place")
                        .WithMany("Reviews")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GS.DataBase.Entities.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GS.DataBase.Entities.Trip", b =>
                {
                    b.HasOne("GS.DataBase.Entities.User", "User")
                        .WithMany("Trips")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GS.DataBase.Entities.TripNode", b =>
                {
                    b.HasOne("GS.DataBase.Entities.Place", "Place")
                        .WithMany("TripNodes")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GS.DataBase.Entities.Trip", "Trip")
                        .WithMany("TripNodes")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
