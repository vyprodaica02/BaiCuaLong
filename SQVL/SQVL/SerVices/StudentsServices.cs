using Microsoft.EntityFrameworkCore;
using SQVL.ISerVices;
using SQVL.Models;
using SQVL.Random;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQVL.SerVices
{
    public class StudentsServices : IStudents
    {
        private readonly QlsvContext qlsvContext;
        private BindingSource bindingSource;
        private readonly Organzine organzine;
        public StudentsServices()
        {
            qlsvContext = new QlsvContext();
            bindingSource = new BindingSource();
            organzine = new Organzine();
        }

     

        public async Task addStudent(string name, string lastname, DateOnly ngaySinh, string email, DataGridView dataGridView)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thêm sinh viên?", "Xác nhận thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (var trans = qlsvContext.Database.BeginTransaction())
                {
                    try
                    {
                        // Tạo một đối tượng Student mới
                        var newStudent = new Student
                        {
                            FirstName = name,
                            LastName = lastname,
                            DateOfBirth = ngaySinh,
                            Email = email
                        };

                        // Thêm sinh viên mới vào DbSet
                        qlsvContext.Students.Add(newStudent);

                        // Lưu thay đổi vào cơ sở dữ liệu
                        await qlsvContext.SaveChangesAsync();

                        // Commit transaction
                        trans.Commit();
                        await organzine.RloadStudent(dataGridView);
                    }
                    catch (Exception ex)
                    {
                        // Nếu có lỗi, rollback transaction
                        trans.Rollback();
                        // Hiển thị thông báo hoặc xử lý lỗi tùy ý
                        MessageBox.Show($"Lỗi thêm sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
