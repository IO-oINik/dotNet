using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Enities;

[Table("users")]
public class UserEntity: BaseEntity
{
    public string Nickname { get; set; }
    public string Login { get; set; }
    public string HashPassword { get; set; }
    public Role Role { get; set; }
    public List<Film> Films { get; set; }
}