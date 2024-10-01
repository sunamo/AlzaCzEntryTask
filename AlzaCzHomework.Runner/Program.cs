using AlzaCzEntryTask.Controllers;
using AlzaCzHomework.Tests.IntegrationTests;

namespace AlzaCzHomework.Runner;

internal class Program
{
    static void Main(string[] args)
    {
        MainAsync(args).GetAwaiter().GetResult();
    }

    static async Task MainAsync(string[] args)
    {
        ProductsControllerTests pc = new ProductsControllerTests(new Tests.Services.WebApiTestFactory());
        await pc.UpdateDescription_NewDescriptionMustBeSaved();

        Console.WriteLine("Finished");
        Console.ReadLine();
    }
}
