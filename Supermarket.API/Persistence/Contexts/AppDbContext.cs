using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Persistence.Contexts {
	public class AppDbContext : DbContext {
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
		}

		protected override void OnModelCreating(ModelBuilder builder) {
			base.OnModelCreating(builder);

			builder.Entity<Category>(e => {
				e.HasKey(p => p.Id);
				e.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
				e.Property(p => p.Name).IsRequired().HasMaxLength(30);

				//A category has many products. each product has only 1 category, with categoryId as the foreign key.
				e.HasMany(p => p.Products)
					.WithOne(p => p.Category)
					.HasForeignKey(p => p.CategoryId);

				//has data allows us to configure seed data
                e.HasData(
					new Category { Id = 100, Name = "Fruits and Vegetables" }, // Id set manually due to in-memory provider
					new Category { Id = 101, Name = "Dairy" }
				);
            });


			builder.Entity<Product>(e => {
				e.HasKey(p => p.Id);
				e.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
				e.Property(p => p.Name).IsRequired().HasMaxLength(50);
				e.Property(p => p.QuantityInPackage).IsRequired();
				e.Property(p => p.UnitOfMeasurement).IsRequired();

				e.HasData(
					new Product {
						Id = 100,
						Name = "Apple",
						QuantityInPackage = 1,
						UnitOfMeasurement = EUnitOfMeasurement.Unity,
						CategoryId = 100
					},
					new Product {
						Id = 101,
						Name = "Milk",
						QuantityInPackage = 2,
						UnitOfMeasurement = EUnitOfMeasurement.Liter,
						CategoryId = 101,
					}
				);
            });
		}
	}
}