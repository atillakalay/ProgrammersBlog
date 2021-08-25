using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Picture = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    About = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    YoutubeLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TwitterLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    InstagramLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FacebookLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LinkedInLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    GitHubLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WebsiteLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ViewsCount = table.Column<int>(type: "int", nullable: false),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
                    SeoAuthor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SeoDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SeoTags = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 720, DateTimeKind.Local).AddTicks(1382), "C# Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 720, DateTimeKind.Local).AddTicks(1410), "C#", "C# Blog Kategorisi" },
                    { 2, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 720, DateTimeKind.Local).AddTicks(1451), "C++ Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 720, DateTimeKind.Local).AddTicks(1455), "C++", "C++ Blog Kategorisi" },
                    { 3, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 720, DateTimeKind.Local).AddTicks(1471), "JavaScript Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 720, DateTimeKind.Local).AddTicks(1475), "JavaScript", "JavaScript Blog Kategorisi" },
                    { 4, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 720, DateTimeKind.Local).AddTicks(1490), "Typescript Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 720, DateTimeKind.Local).AddTicks(1495), "Typescript", "Typescript Blog Kategorisi" },
                    { 5, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 720, DateTimeKind.Local).AddTicks(1509), "Java Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 720, DateTimeKind.Local).AddTicks(1513), "Java", "Java Blog Kategorisi" },
                    { 6, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 720, DateTimeKind.Local).AddTicks(1525), "Python Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 720, DateTimeKind.Local).AddTicks(1527), "Python", "Python Blog Kategorisi" },
                    { 7, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 720, DateTimeKind.Local).AddTicks(1534), "Php Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 720, DateTimeKind.Local).AddTicks(1536), "Php", "Php Blog Kategorisi" },
                    { 8, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 720, DateTimeKind.Local).AddTicks(1547), "Kotlin Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 720, DateTimeKind.Local).AddTicks(1552), "Kotlin", "Kotlin Blog Kategorisi" },
                    { 9, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 720, DateTimeKind.Local).AddTicks(1561), "Swift Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 720, DateTimeKind.Local).AddTicks(1563), "Swift", "Swift Blog Kategorisi" },
                    { 10, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 720, DateTimeKind.Local).AddTicks(1571), "Ruby Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 720, DateTimeKind.Local).AddTicks(1573), "Ruby", "Ruby Blog Kategorisi" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 14, "0652bedf-0c1d-48ce-9051-2dd44c05dd45", "Role.Read", "ROLE.READ" },
                    { 15, "af87c513-11af-4229-a524-c1824b4df9f7", "Role.Update", "ROLE.UPDATE" },
                    { 16, "884f5a05-41f3-49d8-be5e-e4061fdc8673", "Role.Delete", "ROLE.DELETE" },
                    { 17, "93550c91-e816-4703-ac2c-994e6abcc3a6", "Comment.Create", "COMMENT.CREATE" },
                    { 22, "33c7f922-945f-4568-82ea-f1cff88bd205", "SuperAdmin", "SUPERADMIN" },
                    { 19, "247726ec-93e8-4371-ba1f-b639555825b0", "Comment.Update", "COMMENT.UPDATE" },
                    { 20, "37f45642-b46d-4234-ad6c-a00857509d87", "Comment.Delete", "COMMENT.DELETE" },
                    { 21, "9a6d2aee-4af3-47f7-87fd-d31abad6bfa0", "AdminArea.Home.Read", "ADMINAREA.HOME.READ" },
                    { 13, "746cf411-0e31-4d08-a60d-a5129d1543ae", "Role.Create", "ROLE.CREATE" },
                    { 18, "c8c305db-a7f8-49cc-8591-e3a69bb58ec3", "Comment.Read", "COMMENT.READ" },
                    { 12, "80633108-dfd5-4ee6-b465-ddfb2bc4a08c", "User.Delete", "USER.DELETE" },
                    { 7, "545048c3-87e0-4a35-ad52-148e03785a28", "Article.Update", "ARTICLE.UPDATE" },
                    { 10, "971898dc-100c-4671-9336-c237a2d9c8d1", "User.Read", "USER.READ" },
                    { 9, "28ffc585-3afe-4c5d-8b7e-9d5da814aff0", "User.Create", "USER.CREATE" },
                    { 8, "821427fa-9ebd-45f7-b1ca-c3027b91d917", "Article.Delete", "ARTICLE.DELETE" },
                    { 6, "4af26a3b-18e4-471c-bd1a-2fb825ea68a5", "Article.Read", "ARTICLE.READ" },
                    { 5, "8de6a84f-b22f-4724-8e2b-18df39d2e37f", "Article.Create", "ARTICLE.CREATE" },
                    { 4, "3751a6e9-3f86-4cd7-94d8-e4624bdcf0d3", "Category.Delete", "CATEGORY.DELETE" },
                    { 3, "4e2295f1-a6bd-41fe-8530-8aa5be263e30", "Category.Update", "CATEGORY.UPDATE" },
                    { 2, "e59107d1-2bdb-498e-b04d-ad7974f6fb0f", "Category.Read", "CATEGORY.READ" },
                    { 1, "f27a6061-aaac-4d71-8fb5-dcf6b444fd22", "Category.Create", "CATEGORY.CREATE" },
                    { 11, "a387cba6-5c6d-4610-a074-1b5c103e0486", "User.Update", "USER.UPDATE" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FacebookLink", "FirstName", "GitHubLink", "InstagramLink", "LastName", "LinkedInLink", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwitterLink", "TwoFactorEnabled", "UserName", "WebsiteLink", "YoutubeLink" },
                values: new object[,]
                {
                    { 1, "Admin User of ProgrammersBlog", 0, "9ede471b-4456-4d29-b432-734c7ff9243d", "adminuser@gmail.com", true, "https://facebook.com/adminuser", "Admin", "https://github.com/adminuser", "https://instagram.com/adminuser", "User", "https://linkedin.com/adminuser", false, null, "ADMINUSER@GMAIL.COM", "ADMINUSER", "AQAAAAEAACcQAAAAEBHcgx4lsWP5nhZEIqoLsFN7Ftpx5LtJ3lC6r32zCRBNofP/fBlWKRI+b+AzBvqZmw==", "+905555555555", true, "/userImages/defaultUser.png", "04e77697-da35-44f1-b14e-0a9205e34865", "https://twitter.com/adminuser", false, "adminuser", "https://programmersblog.com/", "https://youtube.com/adminuser" },
                    { 2, "Editor User of ProgrammersBlog", 0, "3b809c13-e599-4dff-9f50-134ba13f19b1", "editoruser@gmail.com", true, "https://facebook.com/editoruser", "Admin", "https://github.com/editoruser", "https://instagram.com/editoruser", "User", "https://linkedin.com/editoruser", false, null, "EDITORUSER@GMAIL.COM", "EDITORUSER", "AQAAAAEAACcQAAAAEHfws9jalNSJOu0rzBlxwOaDA5h/GAM4sK4+N1hMpXKx7ZovLi3PshdVLMULj07fbg==", "+905555555555", true, "/userImages/defaultUser.png", "d877b9a1-56a6-4bf1-867c-1411e18beb0a", "https://twitter.com/editoruser", false, "editoruser", "https://programmersblog.com/", "https://youtube.com/editoruser" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[,]
                {
                    { 1, 1, 0, "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.", "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 714, DateTimeKind.Local).AddTicks(5860), new DateTime(2021, 8, 25, 15, 50, 44, 714, DateTimeKind.Local).AddTicks(4468), true, false, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 714, DateTimeKind.Local).AddTicks(6568), "C# 9.0 ve .NET 5 Yenilikleri", "Alper Tunga", "C# 9.0 ve .NET 5 Yenilikleri", "C#, C# 9, .NET5, .NET Framework, .NET Core", "postImages/defaultThumbnail.jpg", "C# 9.0 ve .NET 5 Yenilikleri", 1, 100 },
                    { 10, 10, 0, "Esistono innumerevoli variazioni dei passaggi del Lorem Ipsum, ma la maggior parte hanno subito delle variazioni del tempo, a causa dell’inserimento di passaggi ironici, o di sequenze casuali di caratteri palesemente poco verosimili. Se si decide di utilizzare un passaggio del Lorem Ipsum, è bene essere certi che non contenga nulla di imbarazzante. In genere, i generatori di testo segnaposto disponibili su internet tendono a ripetere paragrafi predefiniti, rendendo questo il primo vero generatore automatico su intenet. Infatti utilizza un dizionario di oltre 200 vocaboli latini, combinati con un insieme di modelli di strutture di periodi, per generare passaggi di testo verosimili. Il testo così generato è sempre privo di ripetizioni, parole imbarazzanti o fuori luogo ecc.", "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 714, DateTimeKind.Local).AddTicks(8346), new DateTime(2021, 8, 25, 15, 50, 44, 714, DateTimeKind.Local).AddTicks(8344), true, false, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 714, DateTimeKind.Local).AddTicks(8348), "Ruby", "Alper Tunga", "Ruby, Ruby on Rails Web Programlama, AirBnb Klon", "Ruby on Rails, Ruby, Web Programlama, AirBnb", "postImages/defaultThumbnail.jpg", "Ruby on Rails ile AirBnb Klon Kodlayalım", 1, 26777 },
                    { 8, 8, 0, "Plusieurs variations de Lorem Ipsum peuvent être trouvées ici ou là, mais la majeure partie d'entre elles a été altérée par l'addition d'humour ou de mots aléatoires qui ne ressemblent pas une seconde à du texte standard. Si vous voulez utiliser un passage du Lorem Ipsum, vous devez être sûr qu'il n'y a rien d'embarrassant caché dans le texte. Tous les générateurs de Lorem Ipsum sur Internet tendent à reproduire le même extrait sans fin, ce qui fait de lipsum.com le seul vrai générateur de Lorem Ipsum. Iil utilise un dictionnaire de plus de 200 mots latins, en combinaison de plusieurs structures de phrases, pour générer un Lorem Ipsum irréprochable. Le Lorem Ipsum ainsi obtenu ne contient aucune répétition, ni ne contient des mots farfelus, ou des touches d'humour.", "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 714, DateTimeKind.Local).AddTicks(8328), new DateTime(2021, 8, 25, 15, 50, 44, 714, DateTimeKind.Local).AddTicks(8326), true, false, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 714, DateTimeKind.Local).AddTicks(8330), "Kotlin", "Alper Tunga", "Kotlin ile Mobil Programlama Baştan Sona Adım Adım", "kotlin, android, mobil, programlama", "postImages/defaultThumbnail.jpg", "Kotlin ile Mobil Programlama", 1, 750 },
                    { 7, 7, 0, "Contrairement à une opinion répandue, le Lorem Ipsum n'est pas simplement du texte aléatoire. Il trouve ses racines dans une oeuvre de la littérature latine classique datant de 45 av. J.-C., le rendant vieux de 2000 ans. Un professeur du Hampden-Sydney College, en Virginie, s'est intéressé à un des mots latins les plus obscurs, consectetur, extrait d'un passage du Lorem Ipsum, et en étudiant tous les usages de ce mot dans la littérature classique, découvrit la source incontestable du Lorem Ipsum. Il provient en fait des sections 1.10.32 et 1.10.33 du 0De Finibus Bonorum et Malorum' (Des Suprêmes Biens et des Suprêmes Maux) de Cicéron. Cet ouvrage, très populaire pendant la Renaissance, est un traité sur la théorie de l'éthique. Les premières lignes du Lorem Ipsum, 'Lorem ipsum dolor sit amet...'', proviennent de la section 1.10.32", "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 714, DateTimeKind.Local).AddTicks(8319), new DateTime(2021, 8, 25, 15, 50, 44, 714, DateTimeKind.Local).AddTicks(8317), true, false, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 714, DateTimeKind.Local).AddTicks(8321), "PHP", "Alper Tunga", "Php ile API Oluşturma Rehberi", "php, laravel, api, oop", "postImages/defaultThumbnail.jpg", "Php Laravel Başlangıç Rehberi | API", 1, 4818 },
                    { 6, 6, 0, "Le Lorem Ipsum est simplement du faux texte employé dans la composition et la mise en page avant impression. Le Lorem Ipsum est le faux texte standard de l'imprimerie depuis les années 1500, quand un imprimeur anonyme assembla ensemble des morceaux de texte pour réaliser un livre spécimen de polices de texte. Il n'a pas fait que survivre cinq siècles, mais s'est aussi adapté à la bureautique informatique, sans que son contenu n'en soit modifié. Il a été popularisé dans les années 1960 grâce à la vente de feuilles Letraset contenant des passages du Lorem Ipsum, et, plus récemment, par son inclusion dans des applications de mise en page de texte, comme Aldus PageMaker.", "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 714, DateTimeKind.Local).AddTicks(8309), new DateTime(2021, 8, 25, 15, 50, 44, 714, DateTimeKind.Local).AddTicks(8308), true, false, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 714, DateTimeKind.Local).AddTicks(8311), "Python", "Alper Tunga", "Python ile Veri Madenciliği", "Python, Veri Madenciliği Nasıl Yapılır?", "postImages/defaultThumbnail.jpg", "Python ile Veri Madenciliği | 2021", 1, 9999 },
                    { 9, 9, 0, "Al contrario di quanto si pensi, Lorem Ipsum non è semplicemente una sequenza casuale di caratteri. Risale ad un classico della letteratura latina del 45 AC, cosa che lo rende vecchio di 2000 anni. Richard McClintock, professore di latino al Hampden-Sydney College in Virginia, ha ricercato una delle più oscure parole latine, consectetur, da un passaggio del Lorem Ipsum e ha scoperto tra i vari testi in cui è citata, la fonte da cui è tratto il testo, le sezioni 1.10.32 and 1.10.33 del 'de Finibus Bonorum et Malorum' di Cicerone. Questo testo è un trattato su teorie di etica, molto popolare nel Rinascimento. La prima riga del Lorem Ipsum, 'Lorem ipsum dolor sit amet..'', è tratta da un passaggio della sezione 1.10.32.", "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 714, DateTimeKind.Local).AddTicks(8337), new DateTime(2021, 8, 25, 15, 50, 44, 714, DateTimeKind.Local).AddTicks(8335), true, false, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 714, DateTimeKind.Local).AddTicks(8339), "Swift", "Alper Tunga", "Swift ile IOS Mobil Programlama Baştan Sona Adım Adım", "IOS, android, mobil, programlama", "postImages/defaultThumbnail.jpg", "Swift ile IOS Programlama", 1, 14900 },
                    { 4, 4, 0, "É um facto estabelecido de que um leitor é distraído pelo conteúdo legível de uma página quando analisa a sua mancha gráfica. Logo, o uso de Lorem Ipsum leva a uma distribuição mais ou menos normal de letras, ao contrário do uso de 'Conteúdo aqui,conteúdo aqui'', tornando-o texto legível. Muitas ferramentas de publicação electrónica e editores de páginas web usam actualmente o Lorem Ipsum como o modelo de texto usado por omissão, e uma pesquisa por 'lorem ipsum' irá encontrar muitos websites ainda na sua infância. Várias versões têm evoluído ao longo dos anos, por vezes por acidente, por vezes propositadamente (como no caso do humor).", "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 714, DateTimeKind.Local).AddTicks(8289), new DateTime(2021, 8, 25, 15, 50, 44, 714, DateTimeKind.Local).AddTicks(8287), true, false, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 714, DateTimeKind.Local).AddTicks(8291), "Typescript 4.1 Yenilikleri", "Alper Tunga", "Typescript 4.1, Typescript, TYPESCRIPT 2021", "Typescript 4.1 Güncellemeleri", "postImages/defaultThumbnail.jpg", "Typescript 4.1", 1, 666 },
                    { 3, 3, 0, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan \"de Finibus Bonorum et Malorum\" (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan \"Lorem ipsum dolor sit amet\" 1.10.32 sayılı bölümdeki bir satırdan gelmektedir. 1500'lerden beri kullanılmakta olan standard Lorem Ipsum metinleri ilgilenenler için yeniden üretilmiştir. Çiçero tarafından yazılan 1.10.32 ve 1.10.33 bölümleri de 1914 H. Rackham çevirisinden alınan İngilizce sürümleri eşliğinde özgün biçiminden yeniden üretilmiştir.", "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 714, DateTimeKind.Local).AddTicks(8279), new DateTime(2021, 8, 25, 15, 50, 44, 714, DateTimeKind.Local).AddTicks(8276), true, false, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 714, DateTimeKind.Local).AddTicks(8281), "JavaScript ES2019 ve ES2020 Yenilikleri", "Alper Tunga", "JavaScript ES2019 ve ES2020 Yenilikleri", "JavaScript ES2019 ve ES2020 Yenilikleri", "postImages/defaultThumbnail.jpg", "JavaScript ES2019 ve ES2020 Yenilikleri", 1, 12 },
                    { 2, 2, 0, "Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır. Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.", "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 714, DateTimeKind.Local).AddTicks(8181), new DateTime(2021, 8, 25, 15, 50, 44, 714, DateTimeKind.Local).AddTicks(8178), true, false, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 714, DateTimeKind.Local).AddTicks(8183), "C++ 11 ve 19 Yenilikleri", "Alper Tunga", "C++ 11 ve 19 Yenilikleri", "C++ 11 ve 19 Yenilikleri", "postImages/defaultThumbnail.jpg", "C++ 11 ve 19 Yenilikleri", 1, 295 },
                    { 5, 5, 0, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan \"de Finibus Bonorum et Malorum\" (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan \"Lorem ipsum dolor sit amet\" 1.10.32 sayılı bölümdeki bir satırdan gelmektedir. 1500'lerden beri kullanılmakta olan standard Lorem Ipsum metinleri ilgilenenler için yeniden üretilmiştir. Çiçero tarafından yazılan 1.10.32 ve 1.10.33 bölümleri de 1914 H. Rackham çevirisinden alınan İngilizce sürümleri eşliğinde özgün biçiminden yeniden üretilmiştir.", "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 714, DateTimeKind.Local).AddTicks(8300), new DateTime(2021, 8, 25, 15, 50, 44, 714, DateTimeKind.Local).AddTicks(8298), true, false, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 714, DateTimeKind.Local).AddTicks(8302), "JAVA", "Alper Tunga", "Java, Android, Mobile, Kotlin, Uygulama Geliştirme", "Java, Mobil, Kotlin, Android, IOS, SWIFT", "postImages/defaultThumbnail.jpg", "Java ve Android'in Geleceği | 2021", 1, 3225 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 3, 2 },
                    { 20, 1 },
                    { 21, 1 },
                    { 22, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 4, 2 },
                    { 17, 2 },
                    { 6, 2 },
                    { 7, 2 },
                    { 8, 2 },
                    { 19, 1 },
                    { 18, 2 },
                    { 19, 2 },
                    { 5, 2 },
                    { 18, 1 },
                    { 13, 1 },
                    { 16, 1 },
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 8, 1 },
                    { 9, 1 },
                    { 10, 1 },
                    { 11, 1 },
                    { 12, 1 },
                    { 20, 2 },
                    { 14, 1 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 15, 1 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 17, 1 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 21, 2 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "Text" },
                values: new object[,]
                {
                    { 1, 1, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 728, DateTimeKind.Local).AddTicks(4100), true, false, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 728, DateTimeKind.Local).AddTicks(4114), "C# Makale Yorumu", "Lorem Ipsum pasajlarının birçok çeşitlemesi vardır. Ancak bunların büyük bir çoğunluğu mizah katılarak veya rastgele sözcükler eklenerek değiştirilmişlerdir. Eğer bir Lorem Ipsum pasajı kullanacaksanız, metin aralarına utandırıcı sözcükler gizlenmediğinden emin olmanız gerekir. İnternet'teki tüm Lorem Ipsum üreteçleri önceden belirlenmiş metin bloklarını yineler. Bu da, bu üreteci İnternet üzerindeki gerçek Lorem Ipsum üreteci yapar. Bu üreteç, 200'den fazla Latince sözcük ve onlara ait cümle yapılarını içeren bir sözlük kullanır. Bu nedenle, üretilen Lorem Ipsum metinleri yinelemelerden, mizahtan ve karakteristik olmayan sözcüklerden uzaktır." },
                    { 2, 2, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 728, DateTimeKind.Local).AddTicks(4134), true, false, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 728, DateTimeKind.Local).AddTicks(4136), "C++ Makale Yorumu", "Lorem Ipsum jest tekstem stosowanym jako przykładowy wypełniacz w przemyśle poligraficznym. Został po raz pierwszy użyty w XV w. przez nieznanego drukarza do wypełnienia tekstem próbnej książki. Pięć wieków później zaczął być używany przemyśle elektronicznym, pozostając praktycznie niezmienionym. Spopularyzował się w latach 60. XX w. wraz z publikacją arkuszy Letrasetu, zawierających fragmenty Lorem Ipsum, a ostatnio z zawierającym różne wersje Lorem Ipsum oprogramowaniem przeznaczonym do realizacji druków na komputerach osobistych, jak Aldus PageMaker" },
                    { 3, 3, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 728, DateTimeKind.Local).AddTicks(4142), true, false, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 728, DateTimeKind.Local).AddTicks(4143), "JavaScript Makale Yorumu", "Ang Lorem Ipsum ay ginagamit na modelo ng industriya ng pagpriprint at pagtytypeset. Ang Lorem Ipsum ang naging regular na modelo simula pa noong 1500s, noong may isang di kilalang manlilimbag and kumuha ng galley ng type at ginulo ang pagkaka-ayos nito upang makagawa ng libro ng mga type specimen. Nalagpasan nito hindi lang limang siglo, kundi nalagpasan din nito ang paglaganap ng electronic typesetting at nanatiling parehas. Sumikat ito noong 1960s kasabay ng pag labas ng Letraset sheets na mayroong mga talata ng Lorem Ipsum, at kamakailan lang sa mga desktop publishing software tulad ng Aldus Pagemaker ginamit ang mga bersyon ng Lorem Ipsum." },
                    { 4, 4, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 728, DateTimeKind.Local).AddTicks(4149), true, false, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 728, DateTimeKind.Local).AddTicks(4151), "Typescript Makale Yorumu", "Lorem Ipsum er rett og slett dummytekst fra og for trykkeindustrien. Lorem Ipsum har vært bransjens standard for dummytekst helt siden 1500-tallet, da en ukjent boktrykker stokket en mengde bokstaver for å lage et prøveeksemplar av en bok. Lorem Ipsum har tålt tidens tann usedvanlig godt, og har i tillegg til å bestå gjennom fem århundrer også tålt spranget over til elektronisk typografi uten vesentlige endringer. Lorem Ipsum ble gjort allment kjent i 1960-årene ved lanseringen av Letraset-ark med avsnitt fra Lorem Ipsum, og senere med sideombrekkingsprogrammet Aldus PageMaker som tok i bruk nettopp Lorem Ipsum for dummytekst." },
                    { 5, 5, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 728, DateTimeKind.Local).AddTicks(4156), true, false, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 728, DateTimeKind.Local).AddTicks(4158), "Java Makale Yorumu", "Lorem Ipsum este pur şi simplu o machetă pentru text a industriei tipografice. Lorem Ipsum a fost macheta standard a industriei încă din secolul al XVI-lea, când un tipograf anonim a luat o planşetă de litere şi le-a amestecat pentru a crea o carte demonstrativă pentru literele respective. Nu doar că a supravieţuit timp de cinci secole, dar şi a facut saltul în tipografia electronică practic neschimbată. A fost popularizată în anii '60 odată cu ieşirea colilor Letraset care conţineau pasaje Lorem Ipsum, iar mai recent, prin programele de publicare pentru calculator, ca Aldus PageMaker care includeau versiuni de Lorem Ipsum." },
                    { 6, 6, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 728, DateTimeKind.Local).AddTicks(4163), true, false, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 728, DateTimeKind.Local).AddTicks(4165), "Python Makale Yorumu", "Lorem Ipsum je jednostavno probni tekst koji se koristi u tiskarskoj i slovoslagarskoj industriji. Lorem Ipsum postoji kao industrijski standard još od 16-og stoljeća, kada je nepoznati tiskar uzeo tiskarsku galiju slova i posložio ih da bi napravio knjigu s uzorkom tiska. Taj je tekst ne samo preživio pet stoljeća, već se i vinuo u svijet elektronskog slovoslagarstva, ostajući u suštini nepromijenjen. Postao je popularan tijekom 1960-ih s pojavom Letraset listova s odlomcima Lorem Ipsum-a, a u skorije vrijeme sa software-om za stolno izdavaštvo kao što je Aldus PageMaker koji također sadrži varijante Lorem Ipsum-a." },
                    { 7, 7, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 728, DateTimeKind.Local).AddTicks(4171), true, false, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 728, DateTimeKind.Local).AddTicks(4172), "Php Makale Yorumu", "Lorem Ipsum – tas ir teksta salikums, kuru izmanto poligrāfijā un maketēšanas darbos. Lorem Ipsum ir kļuvis par vispārpieņemtu teksta aizvietotāju kopš 16. gadsimta sākuma. Tajā laikā kāds nezināms iespiedējs izveidoja teksta fragmentu, lai nodrukātu grāmatu ar burtu paraugiem. Tas ir ne tikai pārdzīvojis piecus gadsimtus, bet bez ievērojamām izmaiņām saglabājies arī mūsdienās, pārejot uz datorizētu teksta apstrādi. Tā popularizēšanai 60-tajos gados kalpoja Letraset burtu paraugu publicēšana ar Lorem Ipsum teksta fragmentiem un, nesenā pagātnē, tādas maketēšanas programmas kā Aldus PageMaker, kuras šablonu paraugos ir izmantots Lorem Ipsum teksts." },
                    { 8, 8, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 728, DateTimeKind.Local).AddTicks(4178), true, false, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 728, DateTimeKind.Local).AddTicks(4180), "Kotlin Makale Yorumu", "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like)." },
                    { 9, 9, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 728, DateTimeKind.Local).AddTicks(4185), true, false, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 728, DateTimeKind.Local).AddTicks(4187), "Swift Makale Yorumu", "هنالك العديد من الأنواع المتوفرة لنصوص لوريم إيبسوم، ولكن الغالبية تم تعديلها بشكل ما عبر إدخال بعض النوادر أو الكلمات العشوائية إلى النص. إن كنت تريد أن تستخدم نص لوريم إيبسوم ما، عليك أن تتحقق أولاً أن ليس هناك أي كلمات أو عبارات محرجة أو غير لائقة مخبأة في هذا النص. بينما تعمل جميع مولّدات نصوص لوريم إيبسوم على الإنترنت على إعادة تكرار مقاطع من نص لوريم إيبسوم نفسه عدة مرات بما تتطلبه الحاجة، يقوم مولّدنا هذا باستخدام كلمات من قاموس يحوي على أكثر من 200 كلمة لا تينية، مضاف إليها مجموعة من الجمل النموذجية، لتكوين نص لوريم إيبسوم ذو شكل منطقي قريب إلى النص الحقيقي. وبالتالي يكون النص الناتح خالي من التكرار، أو أي كلمات أو عبارات غير لائقة أو ما شابه. وهذا ما يجعله أول مولّد نص لوريم إيبسوم حقيقي على الإنترنت." },
                    { 10, 10, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 728, DateTimeKind.Local).AddTicks(4193), true, false, "InitialCreate", new DateTime(2021, 8, 25, 15, 50, 44, 728, DateTimeKind.Local).AddTicks(4194), "Ruby Makale Yorumu", "Lorem Ipsum，也称乱数假文或者哑元文本， 是印刷及排版领域所常用的虚拟文字。由于曾经一台匿名的打印机刻意打乱了一盒印刷字体从而造出一本字体样品书，Lorem Ipsum从西元15世纪起就被作为此领域的标准文本使用。它不仅延续了五个世纪，还通过了电子排版的挑战，其雏形却依然保存至今。在1960年代，”Leatraset”公司发布了印刷着Lorem Ipsum段落的纸张，从而广泛普及了它的使用。最近，计算机桌面出版软件”Aldus PageMaker”也通过同样的方式使Lorem Ipsum落入大众的视野。" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
