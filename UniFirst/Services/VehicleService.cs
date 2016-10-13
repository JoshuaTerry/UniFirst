using System.IO;
using UniFirst.Models;

namespace UniFirst.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository repo;

        public VehicleService(IVehicleRepository repository)
        {
            this.repo = repository;
        }
        public bool AddBranchToDistribution(IDistributionCenter distroCenter, IBranch branch)
        {
            distroCenter.Branches.Add(branch);
            /* <Insert Magical Save Functionality Here> */
            return repo.SaveDistributionCenter(distroCenter);
        }

        public bool AddVehicleToBranch<T>(IBranch branch, T vehicle) where T : IVehicle, IBranchBound
        {
            branch.Vehicles.Add(vehicle);
            /* <Insert Magical Save Functionality Here> */
            return repo.SaveBranch(branch);
        }

        public bool AddVehicleToDistribution<T>(IDistributionCenter distroCenter, T vehicle) where T : IVehicle, IDistributionBound
        {
            distroCenter.Vehicles.Add(vehicle);
            /* <Insert Magical Save Functionality Here> */
            return repo.SaveDistributionCenter(distroCenter);
        }

        public bool BranchTransfer<T>(IBranch branch, T vehicle) where T : IVehicle, IBranchBound
        {
            vehicle.ParentId = branch.Id;
            if (vehicle.ParentId == 0)
                throw new InvalidDataException("Vehicle does not belong to a Distribution Center.");
            else if (vehicle.Status != VehicleStatus.StandBy)
                throw new InvalidDataException("Vehicle is in an invalid Status for transfer.");
            else
            {
                vehicle.ParentId = branch.Id; 
            } 
            return repo.SaveBranch(branch);
        }

        public bool ChangeVehicleStatus(IVehicle vehicle, VehicleStatus status)
        {
            vehicle.Status = status;
            // Possible future status workflow validation here
             
            return repo.SaveVehicle(vehicle);
        }

        public bool DistributionTransfer<T>(IDistributionCenter distroCenter, T vehicle) where T : IVehicle, IDistributionBound
        {
            if (vehicle.ParentId == 0)
                throw new InvalidDataException("Vehicle does not belong to a Distribution Center.");
            else if (vehicle.Status != VehicleStatus.StandBy)
                throw new InvalidDataException("Vehicle is in an invalid Status for transfer.");
            else
            {
                vehicle.ParentId = distroCenter.Id; 
            }

            return repo.SaveDistributionCenter(distroCenter);
        }

        public IBranch GetBranchById(int id)
        {
            return repo.GetBranch(id);
        }

        public IDistributionCenter GetDistributionCenterById(int id)
        {
            return repo.GetDistributionCenter(id);
        }

        public T GetVehicleById<T>(int id) where T : IVehicle, new()
        {
            return repo.GetVehicle<T>(id);
        }
    }
}