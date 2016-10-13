using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace UniFirst.Models
{
    public abstract class VehicleBase : IVehicle
    {
        public int Id { get; set; }
        public string Make { get; set; }

        public string Model { get; set; }

        public VehicleStatus Status { get; set; }

        private string vin = string.Empty;

        public string VIN
        {
            get { return vin; }
            set
            {
                if (Regex.IsMatch(value, @"^(?=.{24}$)(?=(?:\P{L}*\p{L}){8}).*\d{5}$"))
                {
                    vin = value;
                }
                else
                {
                    throw new InvalidDataException("Invalid VIN format.");
                }

            }
        }

        public int Year { get; set; }

        public int ParentId { get; set; }

        public VehicleLocation Location { get; set; }
    }
}