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
    public class EnrollmentsSerVices : IEnrollments
    {
        private readonly QlsvContext qlsvContext;
        private BindingSource bindingSource;

        public EnrollmentsSerVices()
        {
            qlsvContext = new QlsvContext();
            bindingSource = new BindingSource();
        }

        public async Task addEnrollments(int StudentId, int CourseId, int Grade, DateOnly EnrollmentDate, DataGridView dataGridView)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thêm Enrollments?", "Xác nhận thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (var trans = qlsvContext.Database.BeginTransaction())
                {
                    try
                    {
                        // Tạo một đối tượng Student mới
                        var newEnrollments = new Enrollment
                        {
                            StudentId = StudentId,
                            CourseId = CourseId,
                            Grade = Grade,
                            EnrollmentDate = EnrollmentDate,
                        };

                        qlsvContext.Enrollments.Add(newEnrollments);
                        await qlsvContext.SaveChangesAsync();
                        trans.Commit();
                        await RloadEnrollments(dataGridView);
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show($"Lỗi thêm Courses: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public async Task RloadEnrollments(DataGridView dataGridView)
        {
            var enrollments = await qlsvContext.Enrollments.ToListAsync();

            // Thiết lập các cột muốn hiển thị
            dataGridView.AutoGenerateColumns = false;
            dataGridView.Columns.Clear();

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "EnrollmentId",
                HeaderText = "Enrollment ID",
                ReadOnly = true
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "StudentId",
                HeaderText = "Student ID",
                ReadOnly = true
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CourseId",
                HeaderText = "Course ID",
                ReadOnly = true
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "EnrollmentDate",
                HeaderText = "Enrollment Date",
                ReadOnly = true
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Grade",
                HeaderText = "Grade",
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
                    // Lấy đối tượng Enrollment từ dòng được chọn
                    var selectedEnrollment = dataGridView.Rows[e.RowIndex].DataBoundItem as Enrollment;

                    if (selectedEnrollment != null)
                    {
                        // Lấy giá trị StudentId từ đối tượng Enrollment
                        int studentId = selectedEnrollment.EnrollmentId;

                        // Hiển thị hộp thoại xác nhận
                        DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            using (var trans = qlsvContext.Database.BeginTransaction())
                            {
                                try
                                {
                                    // Lấy đối tượng Student từ database
                                    var enrollmentsToDelete = await qlsvContext.Enrollments.FindAsync(studentId);

                                    if (enrollmentsToDelete != null)
                                    {
                                        // Xóa sinh viên
                                        qlsvContext.Enrollments.Remove(enrollmentsToDelete);
                                    }

                                    // Lưu thay đổi vào database
                                    await qlsvContext.SaveChangesAsync();

                                    // Commit transaction
                                    trans.Commit();
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
                            await RloadEnrollments(dataGridView);
                        }
                    }
                }
            };

            dataGridView.AllowUserToAddRows = false;
            bindingSource.DataSource = enrollments;
            dataGridView.DataSource = bindingSource;
        }

    }
}
