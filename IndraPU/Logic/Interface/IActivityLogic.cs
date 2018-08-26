using IndraPU.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndraPU.Logic.Interface
{
    public interface IActivityLogic : IBaseLogic<Activity>
    {
        List<Activity> GetActivitiesByOPDId(int opdId);
    }
}
