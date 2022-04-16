using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    internal class PassengerSeed : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.HasData(new Passenger
            {
                UniquePassengerId = 1,
                Name = "Ayşe",
                Surname = "Kılıç",
                Gender  = "Kadın",
                DocumentNo = 1,
                IssueDate = DateTime.Now,
                DocumentType = DocumentType.Visa
            },
            new Passenger
            {
                UniquePassengerId = 2,
                Name = "Bora",
                Surname = "Demir",
                Gender = "Erkek",
                DocumentNo = 2,
                IssueDate = DateTime.Now,
                DocumentType = DocumentType.Pasaport
            },
            new Passenger
            {
                UniquePassengerId = 3,
                Name = "Deniz",
                Surname = "Aydın",
                Gender = "Kadın",
                DocumentNo = 3,
                IssueDate = DateTime.Now,
                DocumentType = DocumentType.TravelDocument
            },
            new Passenger
            {
                UniquePassengerId = 4,
                Name = "Erdem",
                Surname = "Kaya",
                Gender = "Erkek",
                DocumentNo = 4,
                IssueDate = DateTime.Now,
                DocumentType = DocumentType.Pasaport
            }
            );
        }
    }
}
