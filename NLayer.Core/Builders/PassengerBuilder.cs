using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Builders
{
    public abstract class PassengerBuilder
    {
        protected Passenger _passenger;

        public Passenger Passenger
        {
            get { return _passenger; }
        }

        //public PassengerBuilder(Passenger passenger)
        //{
        //    Passenger = passenger;
        //}

        //public abstract void SetName(string name);
        //public abstract void SetSurname(string surname);

        //public abstract void SetGender(string gender);

        //public abstract void SetDocumentNo(int documentNo);

        //public abstract void SetPassenger(Passenger passenger);
        public abstract void SetDocumentType(Passenger passenger);
    }
}
