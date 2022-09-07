using Addie.Data;
using Addie.Models;
using Microsoft.EntityFrameworkCore;

namespace Addie.Helpers
{
    public static class Seeder
    {
        public static void AddData(this IServiceProvider serviceProvider)
        {
            using (var context = new DataContext(
                serviceProvider.GetRequiredService<DbContextOptions<DataContext>>()))
            {
                if (context.Users.Any()) return;

                context.Users.Add(
                    new User
                    {
                        Id = 1,
                        Username = "admin",
                        Password = "admin123"
                    });

                context.SaveChanges();
            }
        }
    }

}