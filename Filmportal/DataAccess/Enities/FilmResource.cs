using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Enities;

[Table("film_resource")]
public class FilmResource : BaseEntity
{
    public string Url { get; set; }
    
    public int FilmId { get; set; }
    public Film Film { get; set; }
    
    public int ResourceId { get; set; }
    public ResourceToView Resource { get; set; } 
}