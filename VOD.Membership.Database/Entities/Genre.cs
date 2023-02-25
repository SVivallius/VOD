using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace VOD.Membership.Data.Entities;

public class Genre
{
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string Name { get; set; }
    [AllowNull]
    public virtual ICollection<Film> Films { get; set; }
}
