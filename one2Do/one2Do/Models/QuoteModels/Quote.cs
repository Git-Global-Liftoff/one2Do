using System.ComponentModel.DataAnnotations;

namespace one2Do.Models.QuoteModels
{
    public class Quote
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Text { get; set; }
    }
}

public class InspirationalQuote
{
    public string text { get; set; }
    public string? id { get; set; }
    public string author { get; set; }

}
