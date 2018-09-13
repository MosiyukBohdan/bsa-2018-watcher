﻿namespace Watcher.Core.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DataAccumulator.DataAccessLayer.Entities;
    using DataAccumulator.Shared.Models;

    public interface IInstanceAnomalyReportsService
    {
        Task<List<InstanceAnomalyReportDto>> GetAllReportsAsync();
        Task<List<InstanceAnomalyReportDto>> GetReportsByInstanceIdAsync(Guid instanceId);
        Task<InstanceAnomalyReportDto> GetReportByIdAsync(Guid reportId);
        Task AddReportAsync(InstanceAnomalyReport report);
        Task<bool> RemoveReportByIdAsync(Guid reportId);
        Task<bool> RemoveAllReportsAsync();
        Task<bool> ReportExistsAsync(Guid reportId);
        // string GetHtml(InstanceAnomalyReport report);
    }
}