using Microsoft.EntityFrameworkCore;
using SQVL.Common;
using SQVL.ISerVices.student;
using SQVL.Models;
using SQVL.Random;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQVL.SerVices.SRStudents
{
    public class StudentsServices : IStudents
    {
        private readonly QlsvContext qlsvContext;
        private readonly Organzine organzine;
        private readonly IRepository<Student> repository;
        public StudentsServices()
        {
            qlsvContext = new QlsvContext();
            organzine = new Organzine();
            repository = new ExRepository<Student>();
        }

        public async Task addStudent(Student student, DataGridView dataGridView, DialogResult result)
        {

            if (result == DialogResult.Yes)
            {
                using (var trans = qlsvContext.Database.BeginTransaction())
                {
                    try
                    {
                        await repository.AddAsync(student);
                        //await repository.CommitAsync();
                        // Commit transaction
                        trans.Commit();
                        await organzine.RloadStudent(dataGridView);
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show($"Lỗi thêm sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public async Task<IQueryable<Student>> GetAll()
        {
            return repository.Table;
        }
    }
}
