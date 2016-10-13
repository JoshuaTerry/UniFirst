using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniFirst.Models
{
    public interface IDistributionCenter
    {
        int Id { get; set; }
        string Name { get; set; }
        List<IBranch> Branches { get; set; }
        List<IVehicle> Vehicles { get; set; }
    }

    public interface IDistributionBound
    {
    }
}
