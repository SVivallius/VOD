namespace VOD.Membership.Data.Entities;

public class Director
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Film> Films { get; set; }
}
