using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public enum DocumentType
    {
         Visa, Pasaport, TravelDocument
    }
    public class Passenger : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Gender { get; set; }

        public int DocumentNo { get; set; }
        public DocumentType DocumentType { get; set; }
    }
}
