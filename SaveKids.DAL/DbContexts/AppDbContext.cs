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
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		#region Seet Data
		modelBuilder.Entity<User>()
				.HasData(
				new User { Id = 1, FirstName = "Mansurjon", LastName = "Mo'ydinov", Email = "mansurjonmoydinov16072002@gmail.com", DateOfBirth = new DateTimeOffset(new DateTime(2024, 11, 06)).UtcDateTime, TelNumber = "+998908515979", Role = Domain.Enums.UserRole.SuperAdmin, CreatedAt = DateTime.UtcNow, Password = "mansurjon1512" },
		  new User { Id = 2, FirstName = "Muhammadqodir", LastName = "Turdiyev", Email = @"turdiyevgmail.com", DateOfBirth = new DateTimeOffset(new DateTime(2024, 01, 08)).UtcDateTime, TelNumber = "+998912031759", Role = Domain.Enums.UserRole.Admin, CreatedAt = DateTime.UtcNow, Password = "mansurjon1512" },
		  new User { Id = 3, FirstName = "Nurullo", LastName = "Nurmatov", Email = "jasurbek@gmail.com", DateOfBirth = new DateTimeOffset(new DateTime(2024, 12, 04)).UtcDateTime, TelNumber = "+99890335578900", Role = Domain.Enums.UserRole.User, CreatedAt = DateTime.UtcNow, Password = "mansurjon1512" },
		  new User { Id = 4, FirstName = "Saidkamol", LastName = "Saidjamolov", Email = "saidkamolgmail.com", DateOfBirth = new DateTimeOffset(new DateTime(1999, 11, 04)).UtcDateTime, TelNumber = "+998908515979", Role = Domain.Enums.UserRole.User, CreatedAt = DateTime.UtcNow, Password = "mansurjon1512" }
		);
		#endregion
		#region  Fluent Api
		modelBuilder.Entity<CrimeCategory>()
				.HasMany(t => t.Crimes)
				.WithOne(t => t.CrimeCategory)
				.HasForeignKey(t => t.CrimeCategoryId);

		modelBuilder.Entity<Criminal>()
			.HasMany(t => t.Crimes)
			.WithOne(t => t.Criminal)
			.HasForeignKey(t => t.CriminalId);
		#endregion
	}
}