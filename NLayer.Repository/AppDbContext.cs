using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Passenger> Passengers { get; set; }

        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReference.IssueDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {                              
                                entityReference.IssueDate = DateTime.Now;
                                break;
                            }

                    }
                }
            }

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReference.IssueDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                entityReference.IssueDate = DateTime.Now;
                                break;
                            }

                    }
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Passenger>().HasData(new Passenger()
            {
                UniquePassengerId = 5,
                Name = "Test",
                Surname = "Test",
                Gender = "Kadın",
                DocumentNo = 5,
                DocumentType = DocumentType.Pasaport
        },
            new Passenger()
            {
                UniquePassengerId = 6,
                Name = "Test2",
                Surname = "Test2",
                Gender = "Erkek",
                DocumentNo = 6,
                DocumentType = DocumentType.Visa
            }); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
