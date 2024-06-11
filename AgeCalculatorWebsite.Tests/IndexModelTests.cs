using Microsoft.VisualStudio.TestTools.UnitTesting;
using AgeCalculatorWebsite.Pages;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using FluentAssertions;

namespace AgeCalculatorWebsite.Tests
{
    [TestClass]
    public class IndexModelxTests
    {

        private static void InitializePageModel(PageModel pageModel)
        {
            var modelMetadataProvider = new EmptyModelMetadataProvider();
            var actionContext = new ActionContext(
                new DefaultHttpContext(),
                new Microsoft.AspNetCore.Routing.RouteData(),
                new PageActionDescriptor(),
                new ModelStateDictionary()
            );

            pageModel.PageContext = new PageContext(actionContext)
            {
                ViewData = new ViewDataDictionary(modelMetadataProvider, actionContext.ModelState)
            };
        }

        [TestMethod]
        public void OnPost_ReturnsAge()
        {
            var pageModel = new IndexModel();
            
            // init page model
            InitializePageModel(pageModel);
            
            pageModel.OnPost("12/03/1972");
            
            Action act = () =>
            {
                Assert.IsNotNull(pageModel.ViewData);
                if (pageModel.ViewData["Age"] is string ageString)
                {
                    Assert.IsTrue(Regex.IsMatch(ageString, "^\\d* years, \\d* months, \\d* days, \\d* hours, \\d* minutes, \\d* seconds.$"), "Age format incorrect");
                }                
                Assert.IsTrue(pageModel.ViewData.ContainsKey("Age"));
                Assert.IsTrue(pageModel.ViewData.ContainsKey("SubmittedDate"));
                Assert.AreEqual("12/03/1972", pageModel.ViewData["SubmittedDate"]);
            };

            act.Should().NotThrow();

        } 

        [TestMethod]
        public void OnPost_ReturnsValidationErrorForEmptyDate()
        {
            var pageModel = new IndexModel();
            
            // init page model
            InitializePageModel(pageModel);
            
            pageModel.OnPost("");
            
            // TODO - Check for error message being sent
            Assert.IsTrue(pageModel.ModelState.ContainsKey("Date"));
            Assert.AreEqual("Please enter your birthdate.", pageModel.ModelState["Date"]?.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void OnPost_ReturnsValidationErrorForInvalidDate()
        {
            var pageModel = new IndexModel();
            
            // init page model
            InitializePageModel(pageModel);
            
            pageModel.OnPost("qwdqwdqwd");

            // TODO - Check for error message being sent
            Assert.IsTrue(pageModel.ModelState.ContainsKey("Date"));
            Assert.AreEqual("Invalid date format.", pageModel.ModelState["Date"]?.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void OnPost_ReturnsValidationErrorForInvalidDateFormat()
        {
            var pageModel = new IndexModel();
            
            // init page model
            InitializePageModel(pageModel);
            
            pageModel.OnPost("12/25/2000"); // month first is not expected

            // TODO - Check for error message being sent
            Assert.IsTrue(pageModel.ModelState.ContainsKey("Date"));
            Assert.AreEqual("Invalid date format.", pageModel.ModelState["Date"]?.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void OnPost_ReturnsValidationErrorForFutureBirthdate()
        {
            var pageModel = new IndexModel();

            // init page model
            InitializePageModel(pageModel);

            pageModel.OnPost("12/02/2100"); // month first is not expected

            // TODO - Check for error message being sent
            Assert.IsTrue(pageModel.ModelState.ContainsKey("Date"));
            Assert.AreEqual("Birthdate cannot be in the future.", pageModel.ModelState["Date"]?.Errors[0].ErrorMessage);
        }


    }
}
