using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQVL.ISerVices
{
    public interface IStudents
    {
        public Task RloadStudent(DataGridView dataGridView);
        public Task addStudent(string name,string lastname,DateOnly ngaySinh,string email, DataGridView dataGridView);
    }
}
