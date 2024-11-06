using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Enities;

[Table("persons")]
public class Person : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string nameForeign { get; set; }
    public DateOnly dateOfBirth { get; set; }
    public int CountryId { get; set; }
    public Country Country { get; set; }
    public List<Film> FilmsOfActor { get; set; }
    public List<Film> FilmsOfDirector { get; set; }
}