using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NUnit.Framework;
using TestProject.Services.Models;

namespace TestProject.Tests.Tests.Services
{
    [TestFixture]
    public class GarageServiceTests : BaseTests
    {
        [Test]
        public async Task GetAsync_ReturnsProperGarage()
        {
            // Arrange
            var garageService = GetGarageService();

            // Act
            var garage = await garageService.GetAsync(1);

            // Assert
            Assert.IsNotNull(garage);
            Assert.AreEqual(1, garage.Id);
        }

        [Test]
        public async Task CreateAsync_ReturnsGarage()
        {
            // Arrange
            var garageService = GetGarageService();

            // Act
            var model = Mapper.Map<Garage>(Common.Constants.GarageConstants.NewGarageEntity);
            var garage = await garageService.CreateAsync(model);

            // Assert
            Assert.IsNotNull(garage);
        }

        [Test]
        public async Task DeleteAsync_DeletesGarageFromDB()
        {
            // Arrange
            var garageService = GetGarageService();

            // Act
            await garageService.DeleteAsync(3);
            var garage = await garageService.GetAsync(3);

            // Assert
            Assert.IsNull(garage);
        }

        [Test]
        public async Task UpdateAsync_UpdatesGarage()
        {
            // Arrange
            var garageService = GetGarageService();

            // Act
            var model = Mapper.Map<Garage>(Common.Constants.GarageConstants.GetMockCollection().First(x => x.Id == 2));
            model.Name = "Garage 222";
            await garageService.UpdateAsync(model);
            var updatedGarage = await garageService.GetAsync(2);

            // Assert
            Assert.IsNotNull(updatedGarage);
            Assert.AreEqual("Garage 222", updatedGarage.Name);
        }

        [Test]
        public async Task CreateAsync_AddsGarageToDB()
        {
            // Arrange
            var garageService = GetGarageService();

            // Act
            var model = Mapper.Map<Garage>(Common.Constants.GarageConstants.NewGarageEntity);
            await garageService.CreateAsync(model);
            var newGarage = await garageService.GetAsync(4);

            // Assert
            Assert.IsNotNull(newGarage);
        }

        [Test]
        public void CreateAsync_FailsIfGarageIsNull()
        {
            // Arrange
            var garageService = GetGarageService();

            // Act, Assert
            Assert.ThrowsAsync<ArgumentException>(() => garageService.CreateAsync(null));
        }
    }
}
