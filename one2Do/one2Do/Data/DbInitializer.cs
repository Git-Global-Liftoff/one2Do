using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using one2Do.Models.QuoteModels;
using System;
using System.Linq;

namespace one2Do.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new one2doDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<one2doDbContext>>()))
            {
                if (context.Quotes.Any())
                {
                    return;   // DB has been seeded
                }

                var quotes = new Quote[]
                {
                    new Quote { Text = "You're doing great! Keep it up!" },
                    new Quote { Text = "Small steps lead to big changes." },
                    new Quote { Text = "Every day is a fresh start." },
                    // Add remaining quotes later
                };

                foreach (Quote q in quotes)
                {
                    context.Quotes.Add(q);
                }
                context.SaveChanges();
            }
        }
    }
}
