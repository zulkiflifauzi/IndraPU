using IndraPU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndraPU.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<ApplicationUser>
    {
        List<ApplicationUser> GetFreeUsers(List<int> exceptions);
    }
}
