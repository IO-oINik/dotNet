using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Enities;

[Table("films")]
public class Film : BaseEntity
{
    public string Title { get; set; }
    public string TitleForeign { get; set; }
    public string Slogan { get; set; }
    public string Description { get; set; }
    public int AgeLimitId { get; set; }
    public AgeLimit AgeLimit { get; set; }
    public List<Genre> Genres { get; set; }
    public List<Country> Countries { get; set; }
    public List<Person> Actors { get; set; }
    public List<Person> Directors { get; set; }
    public int CreatorId { get; set; }
    public UserEntity Creator { get; set; }
}