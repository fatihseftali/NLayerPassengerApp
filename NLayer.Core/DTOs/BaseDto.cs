using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public abstract class BaseDto
    {
        public int UniquePassengerId { get; set; }
        public DateTime IssueDate { get; set; }
    }
}
