using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using NUnit.Framework;
using TestProject.Models.Request;
using TestProject.Services.Models;

namespace TestProject.Tests.Tests.Controllers
{
    [TestFixture]
    public class ReportControllerTests : BaseTests
    {
        [Test]
        public void GetAllAreas_ReturnsOkObjectResult_WithAllAreas()
        {
            // Arrange
            var controller = GetReportController();

            // Act
            var actionResult = controller.GetAllAreas();
            var collection = (actionResult?.Result as OkObjectResult)?.Value as List<Area>;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(collection);
            Assert.IsTrue(collection.Any());
        }

        [Test]
        public void Get_ReturnsOkObjectResult_WithProperReport()
        {
            // Arrange
            var controller = GetReportController();

            // Act
            var actionResult = controller.Get(1);
            var collection = (actionResult?.Result as OkObjectResult)?.Value as Dictionary<string, List<Report>>;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(collection);
            Assert.IsTrue(collection.Any());
        }

        [Test]
        public async Task Create_ReturnsOkObjectResult_WithProperReport()
        {
            // Arrange
            var controller = GetReportController();

            // Act
            var model = Mapper.Map<CreateReportModel>(Common.Constants.ReportConstants.NewReportEntity);
            var result = await controller.Create(model);
            var okResult = result as OkObjectResult;
            var report = okResult?.Value as Report;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.IsNotNull(okResult.Value);
            Assert.IsNotNull(report);
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
