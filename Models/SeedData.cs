using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteFinal.Models
{
    // just for testing purposes; automatically fills the database
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            QuoteDBContext context = application.ApplicationServices.
                CreateScope().
                ServiceProvider.GetRequiredService<QuoteDBContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Quotes.Any())
            {
                context.Quotes.AddRange(
                    new Quote
                    {
                        aQuote = "Sandy's a girl?",
                        Author = "Patrick Star",
                        Date = "05/21/2001",
                        Subject = "Intrigue",
                        Citation = "Spongebob Squarepants Season 2, 'Pressure'"
                    });
                context.SaveChanges();
            }
        }
    }
}
