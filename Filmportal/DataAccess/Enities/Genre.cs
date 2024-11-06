using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Enities;

[Table("genres")]
public class Genre : BaseEntity
{
    public string Title { get; set; }
    public List<Film> Films { get; set; }
}