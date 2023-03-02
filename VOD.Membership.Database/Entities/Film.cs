using AutoMapper.Configuration.Conventions;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using VOD.Membership.Database.Interfaces;

namespace VOD.Membership.Data.Entities;

public class Film : IEntity
{
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string Title { get; set; }
    [MaxLength(1024), AllowNull]
    public string Description { get; set; }
    public DateTime Uploaded { get; set; }
    public int DirectorId { get; set; }
    public virtual Director Director { get; set; }
    [AllowNull]
    public virtual ICollection<Genre>? Genres { get; set; }
    public bool Free { get; set; } = true;
    [Required, MaxLength(255)]
    public string FilmUrl { get; set; }
    [AllowNull]
    public virtual ICollection<Film>? SimilarFilms { get; set; }
}