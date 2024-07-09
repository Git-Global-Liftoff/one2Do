using System.ComponentModel.DataAnnotations;

namespace one2Do.Models
{
    public class Categories
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; } // Now each category has a Name
        public List<ListTemplateCategory> ListTemplateCategories { get; set; } = new List<ListTemplateCategory>();
    }
}
