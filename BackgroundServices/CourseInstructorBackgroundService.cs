

using EdInstitution.Data;
using Microsoft.EntityFrameworkCore;

namespace EdInstitution.BackgroundServices
{
    public class CourseInstructorBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _services;
        private readonly ILogger<CourseInstructorBackgroundService> _logger;

        public CourseInstructorBackgroundService(IServiceProvider services, ILogger<CourseInstructorBackgroundService> logger)
        {
            _services = services;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Course and Instructor Background Service is running.");

            while (!cancellationToken.IsCancellationRequested)
            {
                await FetchAndCacheDataAsync(cancellationToken);

                _logger.LogInformation("Course and Instructor Background Service is waiting 10 seconds.");

                await Task.Delay(TimeSpan.FromSeconds(10), cancellationToken);
            }
        }

        private async Task FetchAndCacheDataAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Course and Instructor Background Service is fetching data.");

            using var scope = _services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<InstitutionContext>();

            // Fetch course and instructor data from your context
            var courses = await context.Courses.ToListAsync(cancellationToken);
            var instructors = await context.Instructors.ToListAsync(cancellationToken);

            // Cache the data, you can use a caching mechanism of your choice

            _logger.LogInformation("Course and Instructor Background Service fetched and cached data.");
        }
    }
}
