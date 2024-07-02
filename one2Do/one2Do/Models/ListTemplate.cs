namespace one2Do.Models;

public class ListTemplate
{
    public int Id {get; set; }
    public string? Title {get; set; }
    public List<Task>? Tasks {get; set; }
    public List<Categories>? Categories {get; set; }

    public ListTemplate(string title, int id)
    {
        Title = title;
        Id= id;
        Tasks = new List<Task>();
    }
    public ListTemplate()
    {

    }


}
