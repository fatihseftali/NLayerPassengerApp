using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public abstract class BaseEntity
    {
        public int UniquePassengerId { get; set; }
        public DateTime IssueDate { get; set; }
    }
}
