using AutoMapper;
using System;
using System.Threading.Tasks;
using TestProject.Data.Entities;
using TestProject.Repositories;
using TestProject.Services.Models;

namespace TestProject.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarCategoryRepository _carCategoryRepository;
        private readonly IGarageRepository _garageRepository;

        public CarService(ICarRepository carRepository,
            ICarCategoryRepository carCategoryRepository,
            IGarageRepository garageRepository)
        {
            _carRepository = carRepository;
            _carCategoryRepository = carCategoryRepository;
            _garageRepository = garageRepository;
        }

        public async Task<Car> CreateAsync(Car car)
        {
            if (car == null)
            {
                throw new ArgumentException(nameof(car));
            }

            if (!car.CategoryId.HasValue)
            {
                throw new ArgumentException(nameof(car.CategoryId));
            }

            if (!car.GarageId.HasValue)
            {
                throw new ArgumentException(nameof(car.GarageId));
            }

            if (!_garageRepository.AnyAsync(g => g.Id == car.GarageId).Result)
            {
                throw new Exception("Bad Request: garage is not exists");
            }

            if (!_carCategoryRepository.AnyAsync(c => c.Id == car.CategoryId).Result)
            {
                throw new Exception("Bad Request: car category is not exists");
            }

            var carEntity = new CarEntity
            {
                DateCreated = DateTime.Now
            };

            PopulateCarData(carEntity, car);

            _carRepository.Add(carEntity);
            await _carRepository.SaveChangesAsync();

            return Mapper.Map<Car>(carEntity);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var isDeleted = await _carRepository.DeleteAsync(id);

            if (isDeleted)
            {
                await _carRepository.SaveChangesAsync();
            }

            return isDeleted;
        }

        public async Task<Car> GetAsync(long carId)
        {
            var car = await _carRepository.GetByIdAsync(carId);
            return Mapper.Map<Car>(car);
        }

        public async Task<bool> UpdateAsync(Car carDto)
        {
            if (carDto == null)
                return false;

            var carEntity = await _carRepository.GetByIdAsync(carDto.Id);

            if (carEntity == null)
                return false;

            carEntity.DateModified = DateTime.Now;
            carEntity.ModifiedRevCounter ++;
            carEntity.ModifiedFrom = carDto.ModifiedFrom;

            PopulateCarData(carEntity, carDto);
            await _carRepository.SaveChangesAsync();

            return true;
        }

        private void PopulateCarData(CarEntity carEntity, Car carDto)
        {
            if (carEntity == null || carDto == null)
                return;

            carEntity.Description = carDto.Description;
            carEntity.Title = carDto.Title;

            if (carDto.CategoryId.HasValue)
            {
                carEntity.CategoryId = carDto.CategoryId.Value;
            }

            if (carDto.GarageId.HasValue)
            {
                carEntity.GarageId = carDto.GarageId.Value;
            }

            carEntity.ObjectStatus = carDto.ObjectStatus;
        }
    }
}
