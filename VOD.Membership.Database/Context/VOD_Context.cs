using Microsoft.EntityFrameworkCore;
using VOD.Membership.Data.Entities;

namespace VOD.Membership.Data.Context;

public class VOD_Context : DbContext
{

	public VOD_Context(DbContextOptions<VOD_Context> options) : base(options)
	{

	}

	protected override void OnModelCreating(ModelBuilder builder)
	{
		foreach (var relation in builder
			.Model.GetEntityTypes()
			.SelectMany(e => e.GetForeignKeys())
				)
		{
			relation.DeleteBehavior = DeleteBehavior.Restrict;
		}
	}
	public DbSet<Director> Directors => Set<Director>();
	public DbSet<Film> Films => Set<Film>();
	public DbSet<Genre> Genres => Set<Genre>();
}
