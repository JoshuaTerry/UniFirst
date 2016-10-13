using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace UniFirst.Models
{
    // All the methods using boolean as the return type for brevity in 
    // the scope of this example to represent the principle of returning 
    // information about the calls success.
    public class VehicleRepository : IVehicleRepository
    {
        public bool SaveDistributionCenter(IDistributionCenter distroCenter)
        {
            return true;
        }

        public bool SaveBranch(IBranch branch)
        {
            return true;
        }

        public bool SaveVehicle(IVehicle vehicle)
        {
            return true;
        }

        public IBranch GetBranch(int id)
        {
            return new Branch() { Id = id };
        }

        public IDistributionCenter GetDistributionCenter(int id)
        {
            return new DistributionCenter() { Id = id };
        }

        public T GetVehicle<T>(int id) where T : IVehicle, new()
        {
            return new T() { Id = id };
        }
    }
}