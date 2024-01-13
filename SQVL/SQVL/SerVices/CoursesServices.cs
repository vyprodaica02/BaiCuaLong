﻿using Microsoft.EntityFrameworkCore;
using SQVL.ISerVices;
using SQVL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SQVL.SerVices
{
    public class CoursesServices : ICourses
    {
        private readonly QlsvContext qlsvContext;
        private BindingSource bindingSource;

        public CoursesServices()
        {
            qlsvContext = new QlsvContext();
            bindingSource = new BindingSource();
        }

        public async Task addCourses(string CourseName, int Credits, DataGridView dataGridView)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thêm Courses?", "Xác nhận thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (var trans = qlsvContext.Database.BeginTransaction())
                {
                    try
                    {
                        // Tạo một đối tượng Student mới
                        var newCourses = new Course
                        {
                            CourseName = CourseName,
                            Credits = Credits,

                        };

                        qlsvContext.Courses.Add(newCourses);
                        await qlsvContext.SaveChangesAsync();
                        trans.Commit();
                       await RloadCourses(dataGridView);
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show($"Lỗi thêm Courses: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public async Task RloadCourses(DataGridView dataGridView)
        {
            var courses = await qlsvContext.Courses.ToListAsync();

            // Thiết lập các cột muốn hiển thị
            dataGridView.AutoGenerateColumns = false;
            dataGridView.Columns.Clear();

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CourseId",
                HeaderText = "Course ID",
                ReadOnly = true
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CourseName",
                HeaderText = "Course Name",
                ReadOnly = true
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Credits",
                HeaderText = "Credits",
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
                    // Lấy đối tượng Course từ dòng được chọn
                    var selectedCourse = dataGridView.Rows[e.RowIndex].DataBoundItem as Course;

                    if (selectedCourse != null)
                    {
                        // Lấy giá trị CourseId từ đối tượng Course
                        int courseId = selectedCourse.CourseId;

                        // Hiển thị hộp thoại xác nhận
                        DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            using (var trans = qlsvContext.Database.BeginTransaction())
                            {
                                try
                                {
                                    // Lấy đối tượng Course từ database
                                    var courseToDelete = await qlsvContext.Courses.FindAsync(courseId);

                                    if (courseToDelete != null)
                                    {
                                        // Xóa khóa học
                                        qlsvContext.Courses.Remove(courseToDelete);

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
                                    MessageBox.Show($"Lỗi xóa khóa học: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }

                            // Reload lại dữ liệu
                            await RloadCourses(dataGridView);
                        }
                    }
                }
            };

            dataGridView.AllowUserToAddRows = false;
            bindingSource.DataSource = courses;
            dataGridView.DataSource = bindingSource;
        }

    }
}