using NLayer.Core.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Builders
{
    public class PasaportBuilder : PassengerBuilder
    {
        public PasaportBuilder()
        {        
            _passenger = new Passenger();
            SetDocumentType(_passenger);
        }

        //public override void SetName(string name)
        //{
        //    Passenger.Name = name;
        //}

        //public override void SetSurname(string surname)
        //{
        //    Passenger.Surname = surname;
        //}

        //public override void SetGender(string gender)
        //{
        //    Passenger.Gender = gender;
        //}

        //public override void SetDocumentNo(int documentNo)
        //{
        //    Passenger.DocumentNo = documentNo;
        //}

        //public override void SetPassenger(Passenger passenger)
        //{
        //    _passenger = passenger;
        //}

        public override void SetDocumentType(Passenger passenger)
        {
            passenger.DocumentType = DocumentType.Pasaport;
        }
    }
}
