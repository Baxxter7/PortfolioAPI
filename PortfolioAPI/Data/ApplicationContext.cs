using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using PortfolioAPI.Entities;

namespace PortfolioAPI.Data;

public class ApplicationContext: DbContext
{
    public DbSet<Experience> Experiences { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }
}