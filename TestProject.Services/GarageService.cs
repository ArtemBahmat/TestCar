using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestProject.Data.Entities;
using TestProject.Repositories;
using TestProject.Services.Models;

namespace TestProject.Services
{
    public class GarageService : IGarageService
    {
        private readonly IGarageRepository _garageRepository;
        private readonly ICarCategoryRepository _carCategoryRepository;
        private readonly IAreaRepository _areaRepository;

        public GarageService(IGarageRepository garageRepository,
            ICarCategoryRepository carCategoryRepository,
            IAreaRepository areaRepository)
        {
            _garageRepository = garageRepository;
            _carCategoryRepository = carCategoryRepository;
            _areaRepository = areaRepository;
        }
        public async Task<Garage> CreateAsync(Garage garage)
        {
            if (garage == null)
            {
                throw new ArgumentException();
            }

            if (!garage.AreaId.HasValue)
            {
                throw new ArgumentException(nameof(garage.AreaId));
            }

            if (_garageRepository.GetByIdAsync(garage.Id).Result != null)
            {
                throw new Exception("Bad Request: garage already exists");
            }

            if (!_areaRepository.AnyAsync(a => a.Id == garage.AreaId).Result)
            {
                throw new Exception("Bad Request: area does not exist");
            }

            if (garage.Cars != null)
            {
                foreach (var car in garage.Cars)
                {
                    if (!car.CategoryId.HasValue || !_carCategoryRepository.AnyAsync(c => c.Id == car.CategoryId.Value).Result)
                    {
                        throw new Exception($"Bad Request: carCategory of {car.Title} does not exist");
                    }
                }
            }

            var garageEntity = Mapper.Map<GarageEntity>(garage);
            _garageRepository.Add(garageEntity);

            try
            {
                await _garageRepository.SaveChangesAsync();

                return Mapper.Map<Garage>(garageEntity);
            }
            catch (Exception e)
            {
                // log error
                throw e;
            }
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var isDeleted = await _garageRepository.DeleteAsync(id);

            if (isDeleted)
            {
                await _garageRepository.SaveChangesAsync();
            }

            return isDeleted;
        }

        public async Task<Garage> GetAsync(long id)
        {
            var garage = await _garageRepository.GetByIdAsync(id);

            return Mapper.Map<Garage>(garage);
        }

        public async Task<bool> UpdateAsync(Garage garageDto)
        {
            if (garageDto == null)
                return false;

            var garageEntity = await _garageRepository.GetByIdAsync(garageDto.Id);

            if (garageEntity == null)
                return false;

            garageEntity.DateModified = DateTime.Now;
            garageEntity.ModifiedRevCounter ++;

            PopulateGarageData(garageEntity, garageDto);
            await _garageRepository.SaveChangesAsync();

            return true;
        }

        private void PopulateGarageData(GarageEntity garageEntity, Garage garageDto)
        {
            if (garageEntity == null || garageDto == null) return;

            if (garageDto.AreaId.HasValue)
            {
                garageEntity.AreaId = garageDto.AreaId.Value;
            }

            garageEntity.GarageTypeId = garageDto.GarageTypeId;             // todo set other fields
            garageEntity.Name = garageDto.Name;
            garageEntity.Cars = Mapper.Map<HashSet<CarEntity>>(garageDto.Cars);
        }
    }
}
