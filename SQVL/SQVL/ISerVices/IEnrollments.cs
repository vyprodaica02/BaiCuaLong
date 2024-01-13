using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQVL.ISerVices
{
    public interface IEnrollments
    {
        public Task RloadEnrollments(DataGridView dataGridView);
        public Task addEnrollments(int StudentId , int CourseId,int Grade, DateOnly EnrollmentDate, DataGridView dataGridView);

    }
}
