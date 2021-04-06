using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteFinal.Models.ViewModels
{
    // creates a sequence of objects that we can iterate through
    public class QuoteViewModel
    {
        public IEnumerable<Quote> Quotes { get; set; }
    }
}
