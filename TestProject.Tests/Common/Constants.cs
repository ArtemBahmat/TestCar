using System;
using System.Collections.Generic;
using System.Linq;
using TestProject.Data.Entities;

namespace TestProject.Tests.Common
{
    public static class Constants
    {
        public static class CarConstants
        {
            public static CarEntity NewCarEntity = new CarEntity
            {
                Id = 4,
                DateCreated = DateTime.Now,
                Title = "Title 4",
                Description = "Description 4",
                GarageId = 2,
                CategoryId = 3,
                ImpactClass_Index = 2,
                ProbabilityClass_Index = 1
            };

            public static IQueryable<CarEntity> GetMockCollection()
            {
                return new List<CarEntity>
                {
                    new CarEntity
                    {
                        Id = 1, DateCreated = DateTime.Now.AddYears(-3), Title = "Title 1", Description = "Description 1", GarageId = 1, CategoryId = 1, ImpactClass_Index = 1, ProbabilityClass_Index = 1,
                        Garage = GarageConstants.GetMockCollection().First(x => x.Id == 1),
                        Category = CarCategoryConstants.GetMockCollection().First(x => x.Id == 1),
                        CarImpactClass = CarImpactClassEntityConstants.GetMockCollection().First(x => x.Id == 1),
                        CarProbabilityClass = CarProbabilityClassEntityConstants.GetMockCollection().First(x => x.Id == 1)
                    },
                    new CarEntity
                    {
                        Id = 2, DateCreated = DateTime.Now.AddYears(-2), Title = "Title 2", Description = "Description 2", GarageId = 2, CategoryId = 2, ImpactClass_Index = 2, ProbabilityClass_Index = 3,
                        Garage = GarageConstants.GetMockCollection().First(x => x.Id == 2),
                        Category = CarCategoryConstants.GetMockCollection().First(x => x.Id == 2),
                        CarImpactClass = CarImpactClassEntityConstants.GetMockCollection().First(x => x.Id == 2),
                        CarProbabilityClass = CarProbabilityClassEntityConstants.GetMockCollection().First(x => x.Id == 2)
                    },
                    new CarEntity
                    {
                        Id = 3, DateCreated = DateTime.Now.AddYears(-1), Title = "Title 3", Description = "Description 3", GarageId = 3, CategoryId = 3, ImpactClass_Index = 3, ProbabilityClass_Index = 3,
                        Garage = GarageConstants.GetMockCollection().First(x => x.Id == 3),
                        Category = CarCategoryConstants.GetMockCollection().First(x => x.Id == 3),
                        CarImpactClass = CarImpactClassEntityConstants.GetMockCollection().First(x => x.Id == 3),
                        CarProbabilityClass = CarProbabilityClassEntityConstants.GetMockCollection().First(x => x.Id == 3)
                    }
                }.AsQueryable();
            }
        }

        public static class CarCategoryConstants
        {
            public static IQueryable<CarCategoryEntity> GetMockCollection()
            {
                return new List<CarCategoryEntity>
                {
                    new CarCategoryEntity
                    {
                        Id = 1, DateCreated = DateTime.Now.AddYears(-1), Name = "Name 1", ObjectStatus = "ObjectStatus 1"
                    },
                    new CarCategoryEntity
                    {
                        Id = 2, DateCreated = DateTime.Now.AddYears(-1), Name = "Name 2", ObjectStatus = "ObjectStatus 2"
                    },
                    new CarCategoryEntity
                    {
                        Id = 3, DateCreated = DateTime.Now.AddYears(-1), Name = "Name 3", ObjectStatus = "ObjectStatus 3"
                    }
                }.AsQueryable();
            }
        }

        public static class CarImpactClassEntityConstants
        {
            public static IQueryable<CarImpactClassEntity> GetMockCollection()
            {
                return new List<CarImpactClassEntity>
                {
                    new CarImpactClassEntity
                    {
                        Id = 1, Name = "CarImpact 1", Value = "Value 1"
                    },
                    new CarImpactClassEntity
                    {
                        Id = 2, Name = "CarImpact 2", Value = "Value 2"
                    },
                    new CarImpactClassEntity
                    {
                        Id = 3, Name = "CarImpact 3", Value = "Value 3"
                    }
                }.AsQueryable();
            }
        }

        public static class CarProbabilityClassEntityConstants
        {
            public static IQueryable<CarProbabilityClassEntity> GetMockCollection()
            {
                return new List<CarProbabilityClassEntity>
                {
                    new CarProbabilityClassEntity
                    {
                        Id = 1, Name = "CarProbability 1", Value = "Value 1"
                    },
                    new CarProbabilityClassEntity
                    {
                        Id = 2, Name = "CarProbability 2", Value = "Value 2"
                    },
                    new CarProbabilityClassEntity
                    {
                        Id = 3, Name = "CarProbability 3", Value = "Value 3"
                    }
                }.AsQueryable();
            }
        }

        public static class GarageConstants
        {
            public static GarageEntity NewGarageEntity = new GarageEntity
            {
                Id = 4,
                DateCreated = DateTime.Now,
                Name = "Name 4",
                AreaId = 1,
                GarageTypeId = 1
            };

            public static IQueryable<GarageEntity> GetMockCollection()
            {
                return new List<GarageEntity>
                {
                    new GarageEntity
                    {
                        Id = 1, DateCreated = DateTime.Now.AddYears(-5), Name = "Garage 1", GarageTypeId = 1, AreaId = 1,
                        Area = AreaConstants.GetMockCollection().First(x => x.Id == 1)
                    },
                    new GarageEntity
                    {
                        Id = 2, DateCreated = DateTime.Now.AddYears(-8), Name = "Garage 2", GarageTypeId = 2, AreaId = 2,
                        Area = AreaConstants.GetMockCollection().First(x => x.Id == 2)
                    },
                    new GarageEntity
                    {
                        Id = 3, DateCreated = DateTime.Now.AddYears(-9), Name = "Garage 3", GarageTypeId = 3, AreaId = 3,
                        Area = AreaConstants.GetMockCollection().First(x => x.Id == 3)
                    }
                }.AsQueryable();
            }
        }

        public static class AreaConstants
        {
            public static IQueryable<AreaEntity> GetMockCollection()
            {
                return new List<AreaEntity>
                {
                    new AreaEntity
                    {
                        Id = 1, DateCreated = DateTime.Now.AddYears(-5), Name = "Region 1", TimeStamp = DateTime.Now.AddYears(-10)
                    },
                    new AreaEntity
                    {
                        Id = 2, DateCreated = DateTime.Now.AddYears(-6), Name = "Region 2", TimeStamp = DateTime.Now.AddYears(-11)
                    },
                    new AreaEntity
                    {
                        Id = 3, DateCreated = DateTime.Now.AddYears(-7), Name = "Region 3", TimeStamp = DateTime.Now.AddYears(-12)
                    }
                }.AsQueryable();
            }
        }

        public static class ReportConstants
        {
            public static ReportEntity NewReportEntity = new ReportEntity
            {
                Id = 4,
                DateCreated = DateTime.Now,
                Notes = "Name 4",
                ReportTimePeriod = "2017",
                GarageId = 3
            };

            public static IQueryable<ReportEntity> GetMockCollection()
            {
                return new List<ReportEntity>
                {
                    new ReportEntity
                    {
                        Id = 1, DateCreated = DateTime.Now.AddYears(-5), Notes = "Note 1", ReportTimePeriod = "2017", GarageId = 1,
                        Garage = GarageConstants.GetMockCollection().First(x => x.Id == 1)
                    },
                    new ReportEntity
                    {
                        Id = 2, DateCreated = DateTime.Now.AddYears(-4), Notes = "Note 2", ReportTimePeriod = "2018", GarageId = 2,
                        Garage = GarageConstants.GetMockCollection().First(x => x.Id == 2)
                    },
                    new ReportEntity
                    {
                        Id = 3, DateCreated = DateTime.Now.AddYears(-3), Notes = "Note 3", ReportTimePeriod = "2017", GarageId = 3,
                        Garage = GarageConstants.GetMockCollection().First(x => x.Id == 3)
                    }
                }.AsQueryable();
            }
        }
    }
}
