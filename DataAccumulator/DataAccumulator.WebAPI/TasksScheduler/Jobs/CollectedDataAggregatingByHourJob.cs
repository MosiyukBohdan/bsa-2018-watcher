using System;
using System.Threading.Tasks;
using DataAccumulator.DataAggregator.Interfaces;
using DataAccumulator.Shared.Models;
using Microsoft.Extensions.Logging;
using Quartz;

namespace DataAccumulator.WebAPI.TasksScheduler.Jobs
{
    public class CollectedDataAggregatingByHourJob : IJob
    {
        private readonly IDataAggregatorCore<CollectedDataDto> _dataAggregatorCore;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<CollectedDataAggregatingByHourJob> _logger;

        public CollectedDataAggregatingByHourJob(IDataAggregatorCore<CollectedDataDto> dataAggregatorCore, 
            ILoggerFactory loggerFactory)
        {
            _dataAggregatorCore = dataAggregatorCore;
            _loggerFactory = loggerFactory;
            _logger = loggerFactory?.CreateLogger<CollectedDataAggregatingByHourJob>() ?? throw new ArgumentNullException(nameof(loggerFactory));
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                _logger.LogError($"CollectedDataAggregatingByHourJob start");
                var sourceType = CollectedDataType.Accumulation;
                var destinationType = CollectedDataType.AggregationForHour;
                var timeSpan = TimeSpan.FromHours(1);
                var deleteSource = true;

                // Run Aggregating CollectedData
                await _dataAggregatorCore.AggregatingData(sourceType, destinationType, timeSpan, deleteSource);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logger.LogError($"CollectedDataAggregatingByHourJob exception {e}");
                throw;
            }
        }
    }
}
