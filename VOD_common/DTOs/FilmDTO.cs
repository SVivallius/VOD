namespace VOD.common.DTOs;

public class FilmDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Uploaded { get; set; }
    public int DirectorId { get; set; }
    public bool Free { get; set; }
    public string FilmUrl { get; set; }
}
