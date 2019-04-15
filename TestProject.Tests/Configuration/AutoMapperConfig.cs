using System;
using System.Collections.Generic;
using AutoMapper;
using TestProject.Data.Entities;
using TestProject.Models.Request;
using TestProject.Services.Models;

namespace TestProject.Tests.Configuration
{
    public class AutoMapperConfig
    {
        private static bool _initialized;

        public static void Register()
        {
            if (_initialized)
                return;

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Car, CarEntity>();
                cfg.CreateMap<CarEntity, CreateCarModel>();
                cfg.CreateMap<GarageEntity, UpdateGarageModel>()
                    .ForMember(destination => destination.Cars, opts => opts.MapFrom(source => source.Cars ?? new HashSet<CarEntity>()));
                cfg.CreateMap<GarageEntity, CreateGarageModel>()
                    .ForMember(destination => destination.Cars, opts => opts.MapFrom(source => source.Cars ?? new HashSet<CarEntity>()));
                cfg.CreateMap<CarEntity, UpdateCarModel>();
                cfg.CreateMap<CarCategory, CarCategoryEntity>();
                cfg.CreateMap<Garage, GarageEntity>();
                cfg.CreateMap<GarageEntity, Garage>()
                    .ForMember(destination => destination.Cars, opts => opts.MapFrom(source => source.Cars ?? new HashSet<CarEntity>()));
                cfg.CreateMap<Area, AreaEntity>();
                cfg.CreateMap<Report, ReportEntity>();
                cfg.CreateMap<CarImpactClass, CarImpactClassEntity>();
                cfg.CreateMap<CarProbabilityClass, CarProbabilityClassEntity>();
                cfg.CreateMap<CreateCarModel, Car>()
                    .ForMember(destination => destination.Id, opts => opts.MapFrom(source => Guid.NewGuid()))
                    .ForMember(destination => destination.DateCreated, opts => opts.MapFrom(source => DateTime.UtcNow));
                cfg.CreateMap<CreateGarageModel, Garage>()
                    .ForMember(destination => destination.Id, opts => opts.MapFrom(source => Guid.NewGuid()))
                    .ForMember(destination => destination.DateCreated, opts => opts.MapFrom(source => DateTime.Now));
                cfg.CreateMap<UpdateCarModel, Car>();
                cfg.CreateMap<UpdateGarageModel, Garage>();
                cfg.CreateMap<ReportEntity, CreateReportModel>();
                cfg.CreateMap<CreateReportModel, Report>();
                cfg.CreateMap<ReportEntity, Report>();
            });

            _initialized = true;
        }
    }
}
