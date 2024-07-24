using System.Collections.Generic;
using one2Do.Models.QuoteModels;

namespace one2Do;
public class SelectedQuoteViewModel
{
    public InspirationalQuote[]? Quotes { get; set; }
    public string SelectedQuote { get; set; }

    public List<SavedQuote> SavedQuotes { get; set; }
    public List<Quote>? QuotesList { get; set; } //added/edited this....to be QuotesList. Good call or not? 
}




