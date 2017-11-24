using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Assignment
    {
        public string AssignmentId { get; set; }
        public string AssignmentName { get; set; }
        public string AssignmentDescription { get; set; }
        public string AssignmentCommenceDate { get; set; }
        public string AssignmentEndDate { get; set; }
    }
}
