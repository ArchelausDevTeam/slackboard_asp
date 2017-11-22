using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Unit
    {
        public virtual ApplicationUser User { get; set; }

        public int Id { get; set; }
        public string UnitId { get; set; }
        public string UnitName { get; set; }
        public string UnitDescription { get; set; }
        public string UnitCommencementDate { get; set; }
        public string UnitEndDate { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
