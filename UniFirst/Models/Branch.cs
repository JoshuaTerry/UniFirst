using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniFirst.Models
{
    public class Branch : IBranch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<IVehicle> Vehicles { get; set; }
    }
}