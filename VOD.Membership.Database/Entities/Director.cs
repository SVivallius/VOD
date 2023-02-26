using VOD.Membership.Database.Interfaces;

namespace VOD.Membership.Data.Entities;

public class Director : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Film> Films { get; set; }
}
