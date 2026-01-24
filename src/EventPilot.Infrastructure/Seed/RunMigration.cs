using EventPilot.Infrastructure.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EventPilot.Infrastructure.Seed;

// public static class RunMigration
// {
//     public static void RunMigrations(this WebApplication app)
//     {
//         using (var scope = app.Services.CreateScope())
//         {
//             var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//
//             try
//             {
//                 db.Database.Migrate();
//                 app.Logger.LogInformation(
//                     new EventId(1001, "StartupApp"),
//                     "Migrating database done");
//             }
//             catch (Exception ex)
//             {
//                 app.Logger.LogError(new EventId(1001, "StartupApp"),
//                     "Migrating database NOT done");
//                 Console.WriteLine(ex);
//                 throw;
//             }
//         }
//
//     }
// }
