using UniFirst.Models;

namespace UniFirst.Services
{
    public interface IVehicleService
    {
        // Some places like the logic directly in the controller while 
        // others like to have it abstracted out.
        T GetVehicleById<T>(int id) where T : IVehicle, new();
        IBranch GetBranchById(int id);
        IDistributionCenter GetDistributionCenterById(int id);
        bool ChangeVehicleStatus(IVehicle vehicle, VehicleStatus status);
        bool DistributionTransfer<T>(IDistributionCenter distroCenter, T vehicle) where T : IVehicle, IDistributionBound;
        bool BranchTransfer<T>(IBranch branch, T vehicle) where T : IVehicle, IBranchBound;
        bool AddVehicleToBranch<T>(IBranch branch, T vehicle) where T : IVehicle, IBranchBound;
        bool AddVehicleToDistribution<T>(IDistributionCenter distroCenter, T vehicle) where T : IVehicle, IDistributionBound;
        bool AddBranchToDistribution(IDistributionCenter distroCenter, IBranch branch);
    }
}
