using VOD_data.Interfaces;

namespace VOD_data.Entities
{
    internal class Video : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Href { get; set; }
    }
}
