using Microsoft.EntityFrameworkCore;
using VOD_data.Entities;

namespace VOD_data.Context;

internal class VOD_Context : DbContext
{
    public VOD_Context(DbContextOptions<VOD_Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Anything else that should happen on creating the model.
    }

    public DbSet<Video> Videos => Set<Video>();
}
