using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Enities;

[Table("agelimits")]
public class AgeLimit : BaseEntity
{
    public int Age { get; set; }
    public List<Film> Films { get; set; }
}