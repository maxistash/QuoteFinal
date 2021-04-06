using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuoteFinal.Models;
using QuoteFinal.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IQuoteRepository _repository;

        //create the repository
        public HomeController(ILogger<HomeController> logger, IQuoteRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        //send view model to the index page to display data
        public IActionResult Index()
        {
            return View(new QuoteViewModel
            {
                //also may have to make this a repository
                Quotes = _repository.Quotes
            });
        }

        //First appearance of the Edit Quote option
        [HttpGet]
        public IActionResult EditQuote(string quoteID)
        {
            if(quoteID == null)
            {
                return View("Error");
            }
            int shID = int.Parse(quoteID);
            Quote q = _repository.Quotes.
                Where(q => q.QuoteID == shID).FirstOrDefault<Quote>();

            return View(new EditQuoteViewModel { Quote = q });
        }

        // updates the quote
        [HttpPost]
        public IActionResult EditQuote(Quote quote)
        {
            _repository.UpdateQuote(quote);

            return View("Home/Index", new QuoteViewModel
            {
                Quotes = _repository.Quotes
            });
            
        }

        //Saves the changes
        public IActionResult SaveQuote (int quoteID, string aQuote, string author, string date, string subject, string citation)
        {
            Quote quote = _repository.Quotes.
                Where(q => q.QuoteID == quoteID).
                FirstOrDefault();
            quote.aQuote = aQuote;
            quote.Author = author;
            quote.Date = date;
            quote.Subject = citation;

            _repository.UpdateQuote(quote);

            return Redirect("/Home/Index");
        }
        //Delete the quote
        [HttpPost]
        public IActionResult DeleteQuote(string quoteID)
        {
            if (quoteID == null)
            {
                return View("Error");
            }

            int shID = int.Parse(quoteID);
            Quote quote = _repository.Quotes.
                Where(q => q.QuoteID == shID).FirstOrDefault<Quote>();

            _repository.DeleteQuote(quote);

            return View("Index", new QuoteViewModel
            {
                Quotes = _repository.Quotes
            });
        }

        //display the form
        [HttpGet]
        public IActionResult QuoteForm()
        {
            return View();
        }
        //Add data to the database
        [HttpPost]
        public IActionResult QuoteForm(Quote quote)
        {
            if (ModelState.IsValid)
            {
                _repository.AddQuote(quote);
            }
            return Redirect("/Home/Index");
        }
      
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
