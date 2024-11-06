using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Enities;

[Table("countries")]
public class Country : BaseEntity
{
    public string Title { get; set; }
    public List<Person> Persons { get; set; }
    public List<Film> Films { get; set; }
}