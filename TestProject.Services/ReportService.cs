using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Data.Entities;
using TestProject.Repositories;
using TestProject.Services.Models;
using Mapper = AutoMapper.Mapper;

namespace TestProject.Services
{
    public class ReportService : IReportService
    {
        private readonly IAreaRepository _areaRepository;
        private readonly IReportRepository _reportRepository;

        public ReportService(IAreaRepository areaRepository, IReportRepository reportRepository)
        {
            _areaRepository = areaRepository;
            _reportRepository = reportRepository;
        }
        public async Task<Report> CreateAsync(Report report)
        {
            if (report == null)
            {
                throw new ArgumentException(nameof(report));
            }

            if (!report.GarageId.HasValue)
            {
                throw new ArgumentException(nameof(report.GarageId));
            }

            if (string.IsNullOrEmpty(report.Notes))
            {
                throw new ArgumentException(nameof(report.Notes));
            }

            if (string.IsNullOrEmpty(report.ReportTimePeriod))
            {
                throw new ArgumentException(nameof(report.ReportTimePeriod));
            }

            var reportEntity = new ReportEntity
            {
                DateCreated = DateTime.Now,
                GarageId = report.GarageId.Value,
                Notes = report.Notes,
                ReportTimePeriod = report.ReportTimePeriod
            };

            _reportRepository.Add(reportEntity);
            await _reportRepository.SaveChangesAsync();

            return Mapper.Map<Report>(reportEntity);
        }

        public List<Area> GetAreas()
        {
            var areas = _areaRepository.GetAll();

            return Mapper.Map<List<Area>>(areas);
        }

        public Dictionary<string, List<Report>> GetReportsByArea(long areaId)
        {
            var reports = _reportRepository.GetAll()
                .Where(report => report.Garage.AreaId == areaId)
                .GroupBy(report => report.ReportTimePeriod)
                .ToDictionary(reportGroup => reportGroup.Key, reportGroup => reportGroup);

            return Mapper.Map<Dictionary<string, List<Report>>>(reports);
        }

        public async Task<Report> GetAsync(long id)
        {
            var report = await _reportRepository.GetByIdAsync(id);

            return Mapper.Map<Report>(report);
        }

        public async Task<bool> UpdateAsync(Report report)
        {
            if (report == null)
                return false;

            var reportEntity = await _reportRepository.GetByIdAsync(report.Id);

            if (reportEntity == null)
                return false;

            reportEntity.DateModified = DateTime.Now;
            reportEntity.ModifiedRevCounter++;
            reportEntity.ModifiedFrom = report.ModifiedFrom;
            reportEntity.ReportTimePeriod = report.ReportTimePeriod;

            await _reportRepository.SaveChangesAsync();

            return true;
        }


        public async Task<bool> DeleteAsync(long id)
        {
            var isDeleted = await _reportRepository.DeleteAsync(id);

            if (isDeleted)
            {
                await _reportRepository.SaveChangesAsync();
            }

            return isDeleted;
        }
    }
}
