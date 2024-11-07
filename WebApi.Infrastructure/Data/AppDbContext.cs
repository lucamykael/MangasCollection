using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Entities;

namespace WebApi.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<MangaEntity> Mangas { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}
