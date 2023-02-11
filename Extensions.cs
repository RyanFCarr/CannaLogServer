using Microsoft.EntityFrameworkCore;

namespace Server
{
    public static class Extensions
    {
        public static WebApplication MigrateDatabase<T>(this WebApplication app) where T : DbContext
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>();
                try
                {
                    var db = services.GetRequiredService<T>();
                    logger.LogInformation("Migrating database...");
                    db.Database.Migrate();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while migrating the database.");
                }
            }
            return app;
        }
    }
}
