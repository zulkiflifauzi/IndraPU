using IndraPU.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndraPU.Repositories.Interfaces
{
    public interface IActivityRepository : IBaseRepository<Activity>
    {
        List<Activity> GetActivitiesByOPDId(int opdId);
    }
}
