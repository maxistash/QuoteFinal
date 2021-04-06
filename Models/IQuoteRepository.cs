using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteFinal.Models
{
    // database on the front end
    public interface IQuoteRepository
    {
        IQueryable<Quote> Quotes { get; }

        public void AddQuote(Quote quote);
        public void UpdateQuote(Quote quote);
        public void DeleteQuote(Quote quote);
    }
}
