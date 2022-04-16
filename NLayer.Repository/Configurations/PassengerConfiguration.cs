using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Configurations
{
    internal class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.HasKey(x => x.UniquePassengerId);
            builder.Property(x => x.UniquePassengerId).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(200);

            builder.Property(x => x.Gender).IsRequired().HasMaxLength(10);

            builder.Property(x => x.DocumentNo).IsRequired();

            builder.Property(x => x.DocumentType).IsRequired();

            builder.ToTable("Passengers");
        }
    }
}
