using IndraPU.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndraPU.Logic.Interface
{
    public interface IBaseLogic<T> where T : class
    {
        ResponseMessage Create(T entity);

        List<T> GetAll();

        T GetById(int id);

        ResponseMessage Edit(T entity);

        ResponseMessage Delete(int id);
    }
}
