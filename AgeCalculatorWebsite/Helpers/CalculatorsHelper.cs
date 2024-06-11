namespace AgeCalculatorWebsite.Helpers
{
    public static class CalculatorsHelper
    {
        public static void CalculateAge(DateTime birthDate, DateTime todaysDate, out int years, out int months, out int days, out int hours, out int minutes, out int seconds)
        {
            // Initialize out parameters to default values
            years = 0;
            months = 0;
            days = 0;
            hours = 0;
            minutes = 0;
            seconds = 0;

            try{

                TimeSpan timeDifference = todaysDate - birthDate;

                // Calculate total months, adjusting for years
                years = todaysDate.Year - birthDate.Year;
                months = todaysDate.Month - birthDate.Month;
                days = todaysDate.Day - birthDate.Day;

                // If the birth date hasn't occurred yet this year
                if (months < 0)
                {
                    years--; // reduce years by one
                    months += 12; // increase 12 months to the months value
                }

                // If the day difference is negative, borrow from months
                if (days < 0)
                {
                    months--; // reduce months by one
                    days += DateTime.DaysInMonth(birthDate.Year, birthDate.Month); // add the days in the month to the negative days value
                }

                // Calculate time components
                hours = timeDifference.Hours;
                minutes = timeDifference.Minutes;
                seconds = timeDifference.Seconds;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: An unexpected error occurred - {e.Message}");
            }
        }

    }
}
