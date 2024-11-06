using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Enities;

[Table("resources_to_view")]
public class ResourceToView : BaseEntity
{
    public string Title { get; set; }
    public string MainUrl { get; set; }
}