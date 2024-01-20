using SQVL.ISerVices.student;
using SQVL.Models;
using SQVL.SerVices;
using SQVL.SerVices.SRStudents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQVL.ViewAdd
{
    public partial class FormAddStudent : Form
    {
        private readonly IStudents students;
        private readonly DataGridView dataGridView;
        public FormAddStudent(DataGridView dataGridView)
        {
            InitializeComponent();
            students = new StudentsServices();
            this.dataGridView = dataGridView;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thêm sinh viên?", "Xác nhận thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           Student student = new Student();

            student.FirstName = FirstName.Text;
            student.LastName = textLastName.Text;
            student.DateOfBirth = DateOnly.FromDateTime(textDateOfBirth.MaxDate);
            student.Email = textEmail.Text;
            await students.addStudent(student, dataGridView, result);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                this.Close();

        }

    }
}
