using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteFinal.Models
{
    // creates the Database
    public class QuoteDBContext : DbContext
    {
        public QuoteDBContext(DbContextOptions<QuoteDBContext> options) : base(options)
        {

        }
        public DbSet<Quote> Quotes { get; set; }

    }
}
