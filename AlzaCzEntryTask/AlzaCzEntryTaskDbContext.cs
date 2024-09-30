
namespace AlzaCzEntryTask;
/// <summary>
/// DbContext for AlzaCzEntryTask
/// </summary>
/// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
public class AlzaCzEntryTaskDbContext : DbContext
{
    /// <summary>
    /// Gets or sets the products.
    /// </summary>
    /// <value>
    /// The products.
    /// </value>
    public DbSet<Product> Products { get; set; }

    /// <summary>
    /// Override this method to configure the database (and other options) to be used for this context.
    /// This method is called for each instance of the context that is created.
    /// The base implementation does nothing.
    /// </summary>
    /// <param name="optionsBuilder">A builder used to create or modify options for this context. Databases (and other extensions)
    /// typically define extension methods on this object that allow you to configure the context.</param>
    /// <remarks>
    /// <para>
    /// In situations where an instance of <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions" /> may or may not have been passed
    /// to the constructor, you can use <see cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured" /> to determine if
    /// the options have already been set, and skip some or all of the logic in
    /// <see cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" />.
    /// </para>
    /// <para>
    /// See <see href="https://aka.ms/efcore-docs-dbcontext">DbContext lifetime, configuration, and initialization</see>
    /// for more information and examples.
    /// </para>
    /// </remarks>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=AlzaCzEntryTask.db");
    }

    /// <summary>
    /// Override this method to further configure the model that was discovered by convention from the entity types
    /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
    /// and re-used for subsequent instances of your derived context.
    /// </summary>
    /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
    /// define extension methods on this object that allow you to configure aspects of the model that are specific
    /// to a given database.</param>
    /// <remarks>
    /// <para>
    /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
    /// then this method will not be run. However, it will still run when creating a compiled model.
    /// </para>
    /// <para>
    /// See <see href="https://aka.ms/efcore-docs-modeling">Modeling entity types and relationships</see> for more information and
    /// examples.
    /// </para>
    /// </remarks>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Product[] products = new Product[] {
            new Product {  Name = "AlzaPower Garnet 10000mAh Power Delivery (22,5W) černá", Description = "podpora rychlonabíjení QC 3.0, PD 3.0, 1× výstup USB-A (max. 22,5 W), 2× vstup / výstup USB-C (max. 20 W), LED displej s indikátorem PD charging, 6násobná bezpečnostní ochrana, technologie Smart IC, automatická detekce připojeného zařízení, optimální distribuce výkonu, nabíjí až 3 zařízení současně, baterie Li-Polymer s kapacitou 37 Wh, USB-C kabel v balení, hmotnost 225 g", Price = 699, ImgUri = "https://image.alza.cz/products/APWPB171/APWPB171.jpg?width=500&height=500" },
            new Product {  Name = "Dárkový poukaz Alza.cz na nákup zboží v hodnotě 1000 Kč", Description = "Tištěný voucher - se kterým během několika minut vyřešíte dárek pro vaše blízké, kamarády nebo kolegy v práci. Lze použít na veškeré zboží. Unikátní kód stačí zadat při nákupu a hodnota poukazu se odečte z celkové ceny. Platí 1 rok.", Price =  1000, ImgUri = "https://image.alza.cz/products/XXbez107/XXbez107.jpg?width=500&height=500"},
            new Product {  Name = "Alza Ultrabook Šedý celokovový", Description = "Ultrabook - Intel Core i5 1135G7 Tiger Lake, 14\" IPS matný 1920 × 1080, RAM 24GB DDR4, Intel Iris Xe Graphics, SSD 1000GB, webkamera, USB 3.2 Gen 1, USB 3.2 Gen 2, WiFi 6, Hmotnost 1,15 kg, Windows 11 Pro - Originální produkt MS (nejedná se o druhotnou licenci), MIL-STD 810G", Price = 17790, ImgUri = "https://image.alza.cz/products/ALZAa05n/ALZAa05n.jpg?width=500&height=500" },
            new Product {  Name = "Alza Gamebook 3050Ti", Description = "Herní notebook - Intel Core i5 11400H Tiger Lake, 15.6\" IPS matný 1920 × 1080 144Hz, RAM 32GB DDR4, NVIDIA GeForce RTX 3050 Ti 4GB 75 W, SSD 1000GB, numerická klávesnice, podsvícená klávesnice, webkamera, USB 3.2 Gen 1, USB 3.2 Gen 2, USB-C, WiFi 6, Hmotnost 2,2 kg, Windows 11 Home - Originální produkt MS (nejedná se o druhotnou licenci)", Price = 16190, ImgUri = "https://image.alza.cz/products/ALZAa02a6/ALZAa02a6.jpg?width=500&height=500"  },
            new Product {  Name = "Alza TN-2320XL černý pro tiskárny Brother", Description = "Alternativní toner pro tiskárny Brother MFC-L2700DN, Brother DCP-L2500D, Brother DCP-L2520DW, Brother DCP-L2540DN, Brother DCP-L2560DW, Brother HL-L2300D, Brother HL-L2340DW, Brother HL-L2360DN, Brother HL-L2365DW, Brother MFC-L2720DW, Brother MFC-L2740DW, Brother MFC-L2700DW, výtěžnost až 5200 stran", Price = 999, ImgUri = "https://image.alza.cz/products/ALZ7065a/ALZ7065a.jpg?width=500&height=500" },
            new Product {  Name = "Adaptér pro Alza Ultrabook 65W černý", Description= "Napájecí adaptér 65 W - vstupní napětí 100 – 240 V, 50 – 60 Hz, konektor 6,00/3,00 mm", Price= 949, ImgUri = "https://image.alza.cz/products/ALZAb01/ALZAb01.jpg?width=500&height=500" },
            new Product {  Name = "Montáž PC komponent (realizace od 3 pracovních dnů)", Description="Služba - Máte vybrané komponenty a potřebujete jen poskládat PC dohromady? Právě pro Vás je služba montáž PC komponent. Alza technici zajistí profesionální montáž i testování.", Price = 999, ImgUri= "https://image.alza.cz/products/SL010i/SL010i.jpg?width=500&height=500" },
            new Product {  Name = "Sestavení PC na míru", Description = "Služba - Nechte si sestavit PC na míru dle Vašich požadavků. Náš technik pro Vás vybere nejlepší konfigurací komponent, zajistí profesionální montáž a otestování vašeho stroje.", Price = 1299, ImgUri = "https://image.alza.cz/products/SL010j/SL010j.jpg?width=500&height=500"  },
            new Product {  Name = "Alza A4/160 lesklé - balení 100 ks", Description = "Laminovací fólie - A4, 100 kusů v balení, na dokumenty, tloušťka fólie 80 mikronů, lesklá, laminace za tepla, vhodné pro všechny typy stolních laminátorů a zvýrazňující vzhled dokumentu", Price = 189, ImgUri = "https://image.alza.cz/products/ALZ7908/ALZ7908.jpg?width=500&height=500" },
            new Product {  Name = "Alza Foto Video Starter Kit", Description = "Starter kit Kitu obsahuje: ministativ Joby GorillaPod 1K Kit, LensPen čistíci pero na optické čočky originál, SanDisk Extreme Micro SDHC 32GB (100MB/s A1 Class)", Price = 469, ImgUri = "https://image.alza.cz/products/StarK013/StarK013.jpg?width=500&height=500" },
            new Product {  Name = "Plyšový mimozemšťan Alza II", Description = "Plyšák - alzák, s výškou 30 cm, vhodný pro děti od 1 roku, znáte z Mimozemšťan Alza", Price = 399, ImgUri = "https://image.alza.cz/products/MA0100/MA0100.jpg?width=500&height=500" },
            new Product {  Name = "Aha", Price = 1, ImgUri = "" }
    };
        foreach (var product in products)
        {
            modelBuilder.Entity<Product>().HasData(product);
        }
    }
}