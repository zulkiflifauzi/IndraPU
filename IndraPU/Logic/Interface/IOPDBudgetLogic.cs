using IndraPU.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndraPU.Logic.Interface
{
    public interface IOPDBudgetLogic : IBaseLogic<OPDBudget>
    {
        List<OPDBudget> GetBudgetsByOPDId(int opdId);
    }
}
