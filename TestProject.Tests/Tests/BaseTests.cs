using TestProject.Controllers;
using TestProject.Services;
using TestProject.Tests.Configuration;
using TestProject.Tests.MockRepositories;

namespace TestProject.Tests.Tests
{
    public abstract class BaseTests
    {
        protected BaseTests()
        {
            AutoMapperConfig.Register();
        }

        protected static IGarageService GetGarageService()
        {
            var garageRepository = new GarageMockRepository().Items;
            var carCategoryRepository = new CarCategoryMockRepository().Items;
            var areaRepository = new AreaMockRepository().Items;

            return new GarageService(garageRepository, carCategoryRepository, areaRepository);
        }

        protected static ICarService GetCarService()
        {
            var carRepository = new CarMockRepository().Items;
            var carCategoryRepository = new CarCategoryMockRepository().Items;
            var garageRepository = new GarageMockRepository().Items;

            return new CarService(carRepository, carCategoryRepository, garageRepository);
        }

        protected static IReportService GetReportService()
        {
            var reportRepository = new ReportMockRepository().Items;
            var areaRepository = new AreaMockRepository().Items;

            return new ReportService(areaRepository, reportRepository);
        }

        protected static GarageController GetGarageController()
        {
            return new GarageController(GetGarageService());
        }

        protected static CarController GetCarController()
        {
            return new CarController(GetCarService());
        }

        protected static ReportController GetReportController()
        {
            return new ReportController(GetReportService());
        }
    }
}
