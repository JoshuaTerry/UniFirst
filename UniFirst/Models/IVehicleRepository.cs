using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniFirst.Models
{
    public interface IVehicleRepository
    {
        bool SaveDistributionCenter(IDistributionCenter distroCenter);
        bool SaveBranch(IBranch branch);
        bool SaveVehicle(IVehicle vehicle);
        IBranch GetBranch(int id);
        IDistributionCenter GetDistributionCenter(int id);
        T GetVehicle<T>(int id) where T : IVehicle, new();
    }
}