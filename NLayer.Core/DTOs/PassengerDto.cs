using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public enum DocumentType
    {
        Pasaport,Visa,TravelDocument
    }
    public class PassengerDto : BaseDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Gender { get; set; }

        public int DocumentNo { get; set; }
        public DocumentType DocumentType { get; set; }      
    }
}
