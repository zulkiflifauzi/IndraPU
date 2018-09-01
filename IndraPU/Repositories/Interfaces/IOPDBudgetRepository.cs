using IndraPU.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndraPU.Repositories.Interfaces
{
    public interface IOPDBudgetRepository : IBaseRepository<OPDBudget>
    {
        List<OPDBudget> GetBudgetsByOPDId(int opdId);

        bool IsOPDBudgetExist(int year, int opdId, int? excludeId);
    }
}
