using VOD_data.Interfaces;

namespace VOD_data.Entities
{
    public class UserLevel : IEntity
    {
        public int Id { get; set; }
        public string Level { get; set; }
        public ICollection<User> users { get; set; }
    }
}
