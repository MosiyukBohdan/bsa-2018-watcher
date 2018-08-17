﻿namespace Watcher.DataAccess.Interfaces
{
    using System;
    using System.Threading.Tasks;

    using Watcher.DataAccess.Interfaces.Repositories;

    public interface IUnitOfWork : IDisposable
    {
        ISamplesRepository SamplesRepository { get; }

        IUsersRepository UsersRepository { get; }

        IDashboardsRepository DashboardsRepository { get; }

        IOrganizationRepository OrganizationRepository { get; }

        IFeedbackRepository FeedbackRepository { get; }

        IResponseRepository ResponseRepository { get; }

        INotificationSettingsRepository NotificationSettingsRepository { get; }

        IInstanceRepository InstanceRepository { get; }

        IChartsRepository ChartsRepository { get;  }
        Task<bool> SaveAsync();
    }
}