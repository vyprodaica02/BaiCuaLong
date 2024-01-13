using SQVL.ISerVices;
using SQVL.SerVices;
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
            var textFirstName = FirstName.Text;
            var LastName = textLastName.Text;
            DateOnly ngaySinh = DateOnly.FromDateTime(textDateOfBirth.MaxDate);
            var Email = textEmail.Text;

            await students.addStudent(textFirstName, LastName, ngaySinh, Email, dataGridView);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                this.Close();

        }

    }
}
