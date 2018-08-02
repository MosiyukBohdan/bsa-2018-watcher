﻿namespace Watcher.Extensions
{
    using System;
    using System.Diagnostics;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class MigrationsExtension
    {
        public static IWebHost Migrate<T>(this IWebHost webhost, Action<T> seedAction = null) where T : DbContext, IDisposable
        {
            using (var scope = webhost.Services.GetService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<T>())
                {
                    try
                    {
                        context?.Database?.Migrate();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error occured while Migration Database!");
                        //context?.Database?.EnsureDeleted();
                        //context?.Database?.Migrate();
                    }

                    seedAction?.Invoke(context);
                }
            }

            return webhost;
        }
    }
}
