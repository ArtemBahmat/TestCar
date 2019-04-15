using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using TestProject.Models.Request;
using TestProject.Services.Models;

namespace TestProject.Tests.Tests.Controllers
{
    [TestFixture]
    public class GarageControllerTests : BaseTests
    {
        [Test]
        public async Task Get_ReturnsOkObjectResult_WithProperGarage()
        {
            // Arrange
            var controller = GetGarageController();

            // Act
            var result = await controller.Get(1);
            var okResult = result as OkObjectResult;
            var garage = okResult?.Value as Garage;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.IsNotNull(okResult.Value);
            Assert.IsNotNull(garage);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task Create_ReturnsOkObjectResult_WithProperGarage()
        {
            // Arrange
            var controller = GetGarageController();

            // Act
            var model = Mapper.Map<CreateGarageModel>(Common.Constants.GarageConstants.NewGarageEntity);
            var result = await controller.Create(model);
            var okResult = result as OkObjectResult;
            var garage = okResult?.Value as Garage;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.IsNotNull(okResult.Value);
            Assert.IsNotNull(garage);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task Update_ReturnsOkResult()
        {
            // Arrange
            var controller = GetGarageController();

            // Act
            var model = Mapper.Map<UpdateGarageModel>(Common.Constants.GarageConstants.GetMockCollection().First(x => x.Id == 2));
            model.GarageTypeId = 2;
            var result = await controller.Update(model);
            var okResult = result as OkResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task Delete_ReturnsOkResult()
        {
            // Arrange
            var controller = GetGarageController();

            // Act
            var result = await controller.Delete(1);
            var okResult = result as OkResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
