using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using AgeCalculatorWebsite.Helpers;

namespace AgeCalculatorWebsite.Pages
{
    public class IndexModel : PageModel
    {
        // Property to hold the date input from the form
        public string? Date { get; set; }

        // Method to handle the form POST request
        public IActionResult OnPost(string date)
        {
            try
            {
                // Validate the input date
                if (string.IsNullOrEmpty(date))
                {
                    ModelState.AddModelError("date", "Please enter your birthdate.");
                    return Page();
                }
                if (!DateTime.TryParse(date, out DateTime dateTime))
                {
                    // Unable to parse the date, input is invalid
                    ModelState.AddModelError("date", "Invalid date format.");
                    return Page();
                }
                // Check if the birthdate is in the future
                if (dateTime > DateTime.Now)
                {
                    ModelState.AddModelError("date", "Birthdate cannot be in the future.");
                    return Page();
                }

                // Perform age calculation
                CalculatorsHelper.CalculateAge(dateTime, DateTime.Now, out int years, out int months, out int days, out int hours, out int minutes, out int seconds);

                // Construct the age string
                string age = $"{years} years, {months} months, {days} days, {hours} hours, {minutes} minutes, {seconds} seconds.";

                // Store the age and submitted date in ViewData to display on the page
                ViewData["Age"] = age;
                ViewData["SubmittedDate"] = date;

                // Return the page with updated data
                return Page();
            }
            catch (Exception ex)
            {
                // Log the exception to console for debugging
                Console.WriteLine($"Error: An unexpected error occurred - {ex.Message}");
                return Page();
            }
        }
    }
}
