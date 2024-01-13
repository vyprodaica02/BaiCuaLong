using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQVL.ISerVices
{
    public interface ICourses
    {
        public Task RloadCourses(DataGridView dataGridView);
        public Task addCourses(string CourseName,int Credits, DataGridView dataGridView);

    }
}
