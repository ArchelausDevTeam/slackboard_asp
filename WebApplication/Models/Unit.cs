using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Unit
    {
        /// <summary>
        /// This is the primary key for the model
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// This is the proprietary course id to differentiate the units
        /// </summary>
        public string UnitId { get; set; }
        /// <summary>
        /// This is the name, no other explanation needed.
        /// </summary>
        public string UnitName { get; set; }
        /// <summary>
        /// This is the general description of the unit.
        /// </summary>
        public string UnitDescription { get; set; }
        /// <summary>
        /// This is the date that the unit is expected to begin for the year.
        /// </summary>
        public string UnitBeginDate { get; set; }
        /// <summary>
        /// This is the date that the unit is set to end for the year.
        /// </summary>
        public string UnitEndDate { get; set; }
    }
}
