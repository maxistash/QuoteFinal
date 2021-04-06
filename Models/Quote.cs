using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteFinal.Models
{
    // our quote class
    public class Quote
    {
        [Key]
        [Required]
        public int QuoteID { get; set; }
        [Required]
        public string aQuote { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Date { get; set; }
        public string Subject { get; set; }
        public string Citation { get; set; }

    }
}
