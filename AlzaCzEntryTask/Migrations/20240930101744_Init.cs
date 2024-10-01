#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlzaCzEntryTask.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ImgUri = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: ["Id", "Description", "ImgUri", "Name", "Price"],
                values: new object[,]
                {
                    { new Guid("0b8d0b8c-7ed2-4adf-9690-8a1f3b3630a3"), "Laminovací fólie - A4, 100 kusů v balení, na dokumenty, tloušťka fólie 80 mikronů, lesklá, laminace za tepla, vhodné pro všechny typy stolních laminátorů a zvýrazňující vzhled dokumentu", "https://image.alza.cz/products/ALZ7908/ALZ7908.jpg?width=500&height=500", "Alza A4/160 lesklé - balení 100 ks", 189m },
                    { new Guid("2e2f8b30-b7a6-4131-91ad-336c0825221c"), "Starter kit Kitu obsahuje: ministativ Joby GorillaPod 1K Kit, LensPen čistíci pero na optické čočky originál, SanDisk Extreme Micro SDHC 32GB (100MB/s A1 Class)", "https://image.alza.cz/products/StarK013/StarK013.jpg?width=500&height=500", "Alza Foto Video Starter Kit", 469m },
                    { new Guid("4af6628f-435e-4861-bafd-7935defdd00f"), "Herní notebook - Intel Core i5 11400H Tiger Lake, 15.6\" IPS matný 1920 × 1080 144Hz, RAM 32GB DDR4, NVIDIA GeForce RTX 3050 Ti 4GB 75 W, SSD 1000GB, numerická klávesnice, podsvícená klávesnice, webkamera, USB 3.2 Gen 1, USB 3.2 Gen 2, USB-C, WiFi 6, Hmotnost 2,2 kg, Windows 11 Home - Originální produkt MS (nejedná se o druhotnou licenci)", "https://image.alza.cz/products/ALZAa02a6/ALZAa02a6.jpg?width=500&height=500", "Alza Gamebook 3050Ti", 16190m },
                    { new Guid("4d0ae329-cfbf-4e6b-9532-1dcca8d1cd58"), "Služba - Nechte si sestavit PC na míru dle Vašich požadavků. Náš technik pro Vás vybere nejlepší konfigurací komponent, zajistí profesionální montáž a otestování vašeho stroje.", "https://image.alza.cz/products/SL010j/SL010j.jpg?width=500&height=500", "Sestavení PC na míru", 1299m },
                    { new Guid("65def82c-bb80-46dd-830f-33625339ba5a"), "Alternativní toner pro tiskárny Brother MFC-L2700DN, Brother DCP-L2500D, Brother DCP-L2520DW, Brother DCP-L2540DN, Brother DCP-L2560DW, Brother HL-L2300D, Brother HL-L2340DW, Brother HL-L2360DN, Brother HL-L2365DW, Brother MFC-L2720DW, Brother MFC-L2740DW, Brother MFC-L2700DW, výtěžnost až 5200 stran", "https://image.alza.cz/products/ALZ7065a/ALZ7065a.jpg?width=500&height=500", "Alza TN-2320XL černý pro tiskárny Brother", 999m },
                    { new Guid("70ce100d-7c9a-4913-b67c-c0de3a68ad4a"), "", "", "Aha", 1m },
                    { new Guid("7e90f3a9-f235-4b84-ac8a-ead5274ba8d1"), "Tištěný voucher - se kterým během několika minut vyřešíte dárek pro vaše blízké, kamarády nebo kolegy v práci. Lze použít na veškeré zboží. Unikátní kód stačí zadat při nákupu a hodnota poukazu se odečte z celkové ceny. Platí 1 rok.", "https://image.alza.cz/products/XXbez107/XXbez107.jpg?width=500&height=500", "Dárkový poukaz Alza.cz na nákup zboží v hodnotě 1000 Kč", 1000m },
                    { new Guid("a07ec47e-a910-42bf-ac6d-ee6dd879e78a"), "podpora rychlonabíjení QC 3.0, PD 3.0, 1× výstup USB-A (max. 22,5 W), 2× vstup / výstup USB-C (max. 20 W), LED displej s indikátorem PD charging, 6násobná bezpečnostní ochrana, technologie Smart IC, automatická detekce připojeného zařízení, optimální distribuce výkonu, nabíjí až 3 zařízení současně, baterie Li-Polymer s kapacitou 37 Wh, USB-C kabel v balení, hmotnost 225 g", "https://image.alza.cz/products/APWPB171/APWPB171.jpg?width=500&height=500", "AlzaPower Garnet 10000mAh Power Delivery (22,5W) černá", 699m },
                    { new Guid("b166588a-8852-49a0-a171-42f6b3584e90"), "Napájecí adaptér 65 W - vstupní napětí 100 – 240 V, 50 – 60 Hz, konektor 6,00/3,00 mm", "https://image.alza.cz/products/ALZAb01/ALZAb01.jpg?width=500&height=500", "Adaptér pro Alza Ultrabook 65W černý", 949m },
                    { new Guid("b9938c91-e63c-4e94-aae6-3ee268e2ed39"), "Plyšák - alzák, s výškou 30 cm, vhodný pro děti od 1 roku, znáte z Mimozemšťan Alza", "https://image.alza.cz/products/MA0100/MA0100.jpg?width=500&height=500", "Plyšový mimozemšťan Alza II", 399m },
                    { new Guid("fb190017-e484-4805-a016-a275ed04c672"), "Služba - Máte vybrané komponenty a potřebujete jen poskládat PC dohromady? Právě pro Vás je služba montáž PC komponent. Alza technici zajistí profesionální montáž i testování.", "https://image.alza.cz/products/SL010i/SL010i.jpg?width=500&height=500", "Montáž PC komponent (realizace od 3 pracovních dnů)", 999m },
                    { new Guid("fec207ed-0e6b-4586-b8c8-230231a16d6d"), "Ultrabook - Intel Core i5 1135G7 Tiger Lake, 14\" IPS matný 1920 × 1080, RAM 24GB DDR4, Intel Iris Xe Graphics, SSD 1000GB, webkamera, USB 3.2 Gen 1, USB 3.2 Gen 2, WiFi 6, Hmotnost 1,15 kg, Windows 11 Pro - Originální produkt MS (nejedná se o druhotnou licenci), MIL-STD 810G", "https://image.alza.cz/products/ALZAa05n/ALZAa05n.jpg?width=500&height=500", "Alza Ultrabook Šedý celokovový", 17790m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
