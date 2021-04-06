using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteFinal.Models
{
    // our instance of the database
    public class EFQuoteRepository : IQuoteRepository
    {
        private QuoteDBContext _context;

        public EFQuoteRepository(QuoteDBContext context)
        {
            _context = context;
        }
        public IQueryable<Quote> Quotes => _context.Quotes;

        //Allows the addition of  a quote
        public void AddQuote(Quote quote)
        {
            _context.Quotes.Add(quote);
            _context.SaveChanges();
        }

        // Saves the quote to the database
        public void SaveQuote(Quote quote)
        {
            _context.SaveChanges();
        }

        // updates the quote
        public void UpdateQuote(Quote quote)
        {
            Quote quoteobject = _context.Quotes.
                Where(q => q.QuoteID == quote.QuoteID).
                FirstOrDefault();

            quoteobject.aQuote = quote.aQuote;
            quoteobject.Author = quote.Author;
            quoteobject.Date = quote.Date;
            quoteobject.Subject = quote.Subject;
            quoteobject.Citation = quote.Citation;

            _context.SaveChanges();
        }
        // deletes the quote

        public void DeleteQuote(Quote quote)
        {
            _context.Quotes.Remove(quote);
            _context.SaveChanges();
        }
    }
}
