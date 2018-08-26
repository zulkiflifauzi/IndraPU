using IndraPU.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndraPU.Repositories.Interfaces
{
    public interface IOPDRepository : IBaseRepository<OPD>
    {
        bool IsOPDExist(string Title, int? exludeId);
    }
}
