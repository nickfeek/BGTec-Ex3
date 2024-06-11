using System;
using System.IO;
using FluentAssertions;
using RazorLight;
using System.Threading.Tasks;

namespace AgeCalculatorWebsite.Tests
{
    [TestClass]
    public class PageTests
    {
        //[TestMethod] // ATTEMPTING TO TEST THE ACTUAL VIEW BY REDERING PAGES USING RAZORLIGHT. NOT WORKING CURRENTLY - COMMENTED OUT
        public async Task AgeCalculatorPage_RendersCorrectHtml()
        {
            

            // Construct absolute path to the Pages directory
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory; // Get the base directory of the application
            string pagesDirectory = Path.GetFullPath(Path.Combine(projectDirectory, "..", "..", "..", "..", "AgeCalculatorWebsite", "Pages"));

            Console.WriteLine(pagesDirectory);

            // Arrange
            var engine = new RazorLightEngineBuilder()
                .UseFileSystemProject(pagesDirectory) // Adjust the path as per your project structure
                .Build();

            // Construct the full path to the Razor Page file
            string pagePath = Path.Combine(pagesDirectory, "Index.cshtml");

            // Read the Razor Page file
            string razorPage = File.ReadAllText(pagePath);

            // Act
            string renderedHtml = await engine.CompileRenderStringAsync("Index", razorPage, new object(), null); // Provide a dummy object as the model and null as the view bag

            // Assert
            renderedHtml.Should().Contain("34 years, 1 months, 1 days, 1 hours, 49 minutes, 30 seconds."); // Example assertion
        }
    }
}
