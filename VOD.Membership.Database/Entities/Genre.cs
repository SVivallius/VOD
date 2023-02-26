using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using VOD.Membership.Database.Interfaces;

namespace VOD.Membership.Data.Entities;

public class Genre : IEntity
{
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string Name { get; set; }
    [AllowNull]
    public virtual ICollection<Film> Films { get; set; }
}
