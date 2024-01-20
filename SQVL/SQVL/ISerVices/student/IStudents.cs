using SQVL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQVL.ISerVices.student
{
    public interface IStudents
    {
        public Task<IQueryable<Student>> GetAll();
        public Task addStudent(Student student, DataGridView dataGridView, DialogResult result);
    }
}
