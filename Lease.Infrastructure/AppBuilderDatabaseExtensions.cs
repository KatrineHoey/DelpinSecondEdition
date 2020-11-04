using Lease.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Marketplace.Infrastructure
{
    public static class AppBuilderDatabaseExtensions
    {
        public static IApplicationBuilder EnsureDatabase(this IApplicationBuilder builder)
        {
            EnsureContextIsMigrated(builder.ApplicationServices.GetService<LeaseDbContext>());

            return builder;
        }

        private static void EnsureContextIsMigrated(DbContext context)
        {
            if (!context.Database.EnsureCreated())
                context.Database.Migrate();
        }
    }
}