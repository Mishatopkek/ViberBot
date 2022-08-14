using Microsoft.EntityFrameworkCore;
using ViberBot.Entities;

namespace ViberBot.Contexts;

public class MsSqlContext : DbContext
{
    public MsSqlContext(DbContextOptions<MsSqlContext> options)
        : base(options)
    {}

    public DbSet<Track> TrackLocation { get; set; }
    public DbSet<Statistic> Statistics { get; set; }
}