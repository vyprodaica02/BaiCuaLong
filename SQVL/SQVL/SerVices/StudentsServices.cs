using Microsoft.EntityFrameworkCore;
using SQVL.ISerVices;
using SQVL.Models;
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
        public StudentsServices()
        {
            qlsvContext = new QlsvContext();
            bindingSource = new BindingSource();
        }

        public async Task RloadStudent(DataGridView dataGridView)
        {
            var students = await qlsvContext.Students.ToListAsync();

            // Thiết lập các cột muốn hiển thị
            dataGridView.AutoGenerateColumns = false;
            dataGridView.Columns.Clear();

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FirstName",
                HeaderText = "First Name",
                ReadOnly = true
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LastName",
                HeaderText = "Last Name",
                ReadOnly = true
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DateOfBirth",
                HeaderText = "Date of Birth",
                ReadOnly = true
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Email",
                ReadOnly = true
            });

            // Thêm cột ButtonColumn cho việc xóa
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
            {
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                HeaderText = "Actions",
                Name = "DeleteButton",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dataGridView.Columns.Add(deleteButtonColumn);
            dataGridView.CellContentClick += async (sender, e) =>
            {
                // Kiểm tra nếu người dùng nhấp vào cột "DeleteButton"
                if (e.ColumnIndex == dataGridView.Columns["DeleteButton"].Index && e.RowIndex >= 0)
                {
                    // Lấy đối tượng Student từ dòng được chọn
                    var selectedStudent = dataGridView.Rows[e.RowIndex].DataBoundItem as Student;

                    if (selectedStudent != null)
                    {
                        // Lấy giá trị StudentId từ đối tượng Student
                        int studentId = selectedStudent.StudentId;

                        // Hiển thị hộp thoại xác nhận
                        DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            using (var trans = qlsvContext.Database.BeginTransaction())
                            {
                                try
                                {
                                    // Lấy đối tượng Student từ database
                                    var studentToDelete = await qlsvContext.Students.FindAsync(studentId);

                                    if (studentToDelete != null)
                                    {
                                        // Lấy tất cả các bản ghi Enrollments có StudentId tương ứng với sinh viên
                                        var enrollmentsToUpdate = qlsvContext.Enrollments.Where(e => e.StudentId == studentId);

                                        foreach (var enrollment in enrollmentsToUpdate)
                                        {
                                            enrollment.StudentId = null;
                                        }

                                        // Xóa sinh viên
                                        qlsvContext.Students.Remove(studentToDelete);

                                        // Lưu thay đổi vào database
                                        await qlsvContext.SaveChangesAsync();
                                        // Commit transaction
                                        trans.Commit();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    // Nếu có lỗi, rollback transaction
                                    trans.Rollback();
                                    // Hiển thị thông báo hoặc xử lý lỗi tùy ý
                                    MessageBox.Show($"Lỗi xóa sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            // Reload lại dữ liệu
                            await RloadStudent(dataGridView);
                        }

                    }
                }
            };
            dataGridView.AllowUserToAddRows = false;
            bindingSource.DataSource = students;
            dataGridView.DataSource = bindingSource;
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
                        await RloadStudent(dataGridView);
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
