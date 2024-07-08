namespace one2Do.Models
{
    public class ListTemplateCategory
    {
        public int ListTemplateId { get; set; }
        public ListTemplate ListTemplate { get; set; }
        
        public int CategoriesId { get; set; }
        public Categories Categories { get; set; }
    }
}
