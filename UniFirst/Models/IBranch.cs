using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniFirst.Models
{
    public interface IBranch
    {
        int Id { get; set; }
        string Name { get; set; }
        List<IVehicle> Vehicles { get; set; }
    }

    public interface IBranchBound { }
}
