﻿using IndraPU.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndraPU.Logic.Interface
{
    public interface IInstructorLogic : IBaseLogic<Instructor>
    {
        List<Instructor> GetInstructorByType(string type);
    }
}
