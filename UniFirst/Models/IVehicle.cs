using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UniFirst.Models
{
    public enum VehicleLocation {  Branch, DistributionCenter}
    public enum VehicleStatus { StandBy, Transit, Service, Repair }
    public interface IVehicle
    {
        [Key]
        int Id { get; set; }
        [Required]
        string Make { get; set; }
        [Required]
        string Model { get; set; }
        [Required]
        int Year { get; set; }
        [Required]
        [StringLength(24, MinimumLength = 24, ErrorMessage = "Invalid Length")]
        [RegularExpression(@"^(?=(?:\P{L}*\p{L}){8}).*\d{5}$")]
        string VIN { get; set; }
        [Required]
        VehicleStatus Status { get; set; }

        // I had to make some assumptions here regarding the instructions.  
        // The directions specify restrictions only on the vehicle types a 
        // parent can transfer and not the types they can contain.  Since 
        // all the vehicle types have transfer specifications I am inferring
        // that all vehicles should be inheritently transferrable.  On that 
        // assumption I have restricted the types of vehicles that can be 
        // added to each parent.
        [Required]
        int ParentId { get; set; }
        [Required]
        VehicleLocation Location { get; set; }
    }
}
