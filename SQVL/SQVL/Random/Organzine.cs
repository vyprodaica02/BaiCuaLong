using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using SQVL.ISerVices;
using SQVL.ISerVices.student;
using SQVL.Models;
using SQVL.SerVices;
using SQVL.SerVices.SRStudents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BindingSource = System.Windows.Forms.BindingSource;

namespace SQVL.Random
{
    public class Organzine
    {
        private readonly QlsvContext qlsvContext;
        private BindingSource bindingSource;
        private readonly IDeleteStudent deleteStudent;
        public Organzine()
        {
            qlsvContext = new QlsvContext();
            deleteStudent = new deleteStudentSr();
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
                        int studentId = selectedStudent.StudentId;
                        DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            await deleteStudent.DeleteStudent(studentId);
                            await RloadStudent(dataGridView);
                        }
                    }
                }
            };
            dataGridView.AllowUserToAddRows = false;
            bindingSource.DataSource = students;
            dataGridView.DataSource = bindingSource;
        }

    }
}
