using NLayer.Core.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Builders
{
    public class PassengerConstructor
    {
        public PassengerBuilder _builder;
        public void Passenger(PassengerBuilder builder)
        {
            _builder = builder;
        }
    }
}
