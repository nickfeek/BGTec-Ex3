using Microsoft.VisualStudio.TestTools.UnitTesting;
using AgeCalculatorWebsite.Helpers;
using System;
using FluentAssertions;


namespace AgeCalculatorWebsite.Tests
{
    [TestClass]
    public class CalculatorsHelperTests
    {

        [TestMethod]
        public void CalculateAge_ReturnsCorrectAge()
        {
            DateTime birthDate = new DateTime(1990, 6, 4, 10, 10, 30);
            DateTime todaysDate = new DateTime(2024, 7, 5, 12, 00, 00); // Set a specific current date for testing
            int expectedYears = 34; 
            int expectedMonths = 1; 
            int expectedDays = 1; 
            int expectedHours = 1; 
            int expectedMinutes = 49; 
            int expectedSeconds = 30; 
            CalculatorsHelper.CalculateAge(birthDate, todaysDate, out int years, out int months, out int days, out int hours, out int minutes, out int seconds);
            
            Action act = () =>
            {
                Assert.AreEqual(expectedYears, years, "The number of years calculated is not as expected");
                Assert.AreEqual(expectedMonths, months, "The number of months calculated is not as expected");
                Assert.AreEqual(expectedDays, days, "The number of days calculated is not as expected");
                Assert.AreEqual(expectedHours, hours, "The number of hours calculated is not as expected");
                Assert.AreEqual(expectedMinutes, minutes, "The number of minutes calculated is not as expected");
                Assert.AreEqual(expectedSeconds, seconds, "The number of seconds calculated is not as expected");
            };

            act.Should().NotThrow();
        }

        [TestMethod]
        public void CalculateAge_ReturnsCorrectAgePre2000()
        {
            DateTime birthDate = new DateTime(2001, 6, 4, 10, 10, 30);
            DateTime todaysDate = new DateTime(2024, 7, 5, 12, 00, 00); // Set a specific current date for testing
            int expectedYears = 23; 
            int expectedMonths = 1; 
            int expectedDays = 1; 
            int expectedHours = 1; 
            int expectedMinutes = 49; 
            int expectedSeconds = 30; 
            CalculatorsHelper.CalculateAge(birthDate, todaysDate, out int years, out int months, out int days, out int hours, out int minutes, out int seconds);
                    
            Action act = () =>
            {
                Assert.AreEqual(expectedYears, years, "The number of years calculated is not as expected");
                Assert.AreEqual(expectedMonths, months, "The number of months calculated is not as expected");
                Assert.AreEqual(expectedDays, days, "The number of days calculated is not as expected");
                Assert.AreEqual(expectedHours, hours, "The number of hours calculated is not as expected");
                Assert.AreEqual(expectedMinutes, minutes, "The number of minutes calculated is not as expected");
                Assert.AreEqual(expectedSeconds, seconds, "The number of seconds calculated is not as expected");
            };

            act.Should().NotThrow();
        }

        [TestMethod]
        public void CalculateAge_ReturnsCorrectAgeSmallValue()
        {
            DateTime birthDate = new DateTime(2023, 12, 31, 12, 00, 00);
            DateTime todaysDate = new DateTime(2024, 1, 1, 12, 00, 00); // Set a specific current date for testing
            int expectedYears = 0;
            int expectedMonths = 0;
            int expectedDays = 1;
            int expectedHours = 0;
            int expectedMinutes = 0;
            int expectedSeconds = 0;
            CalculatorsHelper.CalculateAge(birthDate, todaysDate, out int years, out int months, out int days, out int hours, out int minutes, out int seconds);

            Action act = () =>
            {
                Assert.AreEqual(expectedYears, years, "The number of years calculated is not as expected");
                Assert.AreEqual(expectedMonths, months, "The number of months calculated is not as expected");
                Assert.AreEqual(expectedDays, days, "The number of days calculated is not as expected");
                Assert.AreEqual(expectedHours, hours, "The number of hours calculated is not as expected");
                Assert.AreEqual(expectedMinutes, minutes, "The number of minutes calculated is not as expected");
                Assert.AreEqual(expectedSeconds, seconds, "The number of seconds calculated is not as expected");
            };

            act.Should().NotThrow();
        }
    }
}
