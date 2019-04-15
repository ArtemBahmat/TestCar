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
    public class CarControllerTests : BaseTests
    {
        [Test]
        public async Task Get_ReturnsOkObjectResult_WithProperCar()
        {
            // Arrange
            var controller = GetCarController();

            // Act
            var result = await controller.Get(1);
            var okResult = result as OkObjectResult;
            var car = okResult?.Value as Car;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.IsNotNull(okResult.Value);
            Assert.IsNotNull(car);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task Create_ReturnsOkObjectResult_WithProperCar()
        {
            // Arrange
            var controller = GetCarController();

            // Act
            var model = Mapper.Map<CreateCarModel>(Common.Constants.CarConstants.NewCarEntity);
            var result = await controller.Create(model);
            var okResult = result as OkObjectResult;
            var car = okResult?.Value as Car;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.IsNotNull(okResult.Value);
            Assert.IsNotNull(car);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task Update_ReturnsOkResult()
        {
            // Arrange
            var controller = GetCarController();

            // Act
            var model = Mapper.Map<UpdateCarModel>(Common.Constants.CarConstants.GetMockCollection().First(x => x.Id == 2));
            model.Description = "Some new description";
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
            var controller = GetCarController();

            // Act
            var result = await controller.Delete(1);
            var okResult = result as OkResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
