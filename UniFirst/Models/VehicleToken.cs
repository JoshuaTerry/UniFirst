using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniFirst.Models
{
    // Some places like to use token objects if its only updating 
    // 1 or 2 fields.
    // If the application supports Asp.net Core you can also use 
    // the Patch verb to do the partial update.
    public class VehicleToken
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }
}