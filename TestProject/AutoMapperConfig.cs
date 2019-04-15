using System;
using System.Collections.Generic;
using AutoMapper;
using TestProject.Data.Entities;
using TestProject.Models.Request;
using TestProject.Services.Models;

namespace TestProject
{
    public partial class Startup
    {
        private static void RegisterAutoMapperConfig()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Car, CarEntity>();
                cfg.CreateMap<CarCategory, CarCategoryEntity>();
                cfg.CreateMap<Garage, GarageEntity>();
                cfg.CreateMap<GarageEntity, Garage>()
                    .ForMember(destination => destination.Cars, opts => opts.MapFrom(source => source.Cars ?? new HashSet<CarEntity>()));
                cfg.CreateMap<Area, AreaEntity>();
                cfg.CreateMap<ReportEntity, Report>()
                    .ForMember(destination => destination.Cars, opts => opts.MapFrom(source => source.Garage.Cars));
                cfg.CreateMap<CarImpactClass, CarImpactClassEntity>();
                cfg.CreateMap<CarProbabilityClass, CarProbabilityClassEntity>();
                cfg.CreateMap<CreateCarModel, Car>()
                    .ForMember(destination => destination.DateCreated, opts => opts.MapFrom(source => DateTime.Now));
                cfg.CreateMap<CreateGarageModel, Garage>()
                    .ForMember(destination => destination.DateCreated, opts => opts.MapFrom(source => DateTime.Now));
                cfg.CreateMap<UpdateCarModel, Car>();
                cfg.CreateMap<UpdateGarageModel, Garage>();
                cfg.CreateMap<CreateReportModel, Report>();
            });
        }
    }
}
