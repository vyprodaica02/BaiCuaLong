using SQVL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQVL.ISerVices.student
{
    public interface IDeleteStudent
    {
        public Task DeleteStudent(int id);

    }
}
