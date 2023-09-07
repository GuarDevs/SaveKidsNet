using Microsoft.EntityFrameworkCore;
using SaveKids.Domain.Entities.Attachments;
using SaveKids.Domain.Entities.Crimes;
using SaveKids.Domain.Entities.Criminals;
using SaveKids.Domain.Entities.Users;

namespace SaveKids.DAL.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<User> Users { get; set; }
    public DbSet<Crime> Crimes { get; set; }
    public DbSet<Criminal> Criminals { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<CrimeCategory> CrimeCategories { get; set; }
}