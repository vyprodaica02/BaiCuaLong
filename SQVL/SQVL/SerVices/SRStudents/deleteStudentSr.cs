using SQVL.Common;
using SQVL.ISerVices.student;
using SQVL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQVL.SerVices.SRStudents
{
    public class deleteStudentSr : IDeleteStudent
    {
        private readonly QlsvContext qlsvContext;
        private readonly IRepository<Student> repository;
        public deleteStudentSr()
        {
            repository = new ExRepository<Student>();
            qlsvContext = new QlsvContext();
        }

        public async Task DeleteStudent(int id)
        {
            var studentToDelete = await qlsvContext.Students.FindAsync(id);
            if (studentToDelete != null)
            {
                var EnrollmentHT = qlsvContext.Enrollments.FirstOrDefault(x => x.StudentId == id);
                if (EnrollmentHT != null)
                {
                    EnrollmentHT.StudentId = null;
                }
                qlsvContext.Students.Remove(studentToDelete);
                await qlsvContext.SaveChangesAsync();
            }
        }
    }
}
