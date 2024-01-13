using SQVL.ISerVices;
using SQVL.Models;
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
    public partial class FormAddEnrollments : Form
    {
        private readonly DataGridView dataGridView;
        private readonly QlsvContext qlsvContext;
        private readonly IEnrollments enrollments;
        public FormAddEnrollments(DataGridView dataGridView)
        {
            InitializeComponent();
            this.dataGridView = dataGridView;
            qlsvContext = new QlsvContext();
            enrollments = new EnrollmentsSerVices();
            LoadStudentIds();
            LoadSCourseIds();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Grade = int.Parse(textGrade.Text);
            var studenId = (int)StudentId.SelectedValue;
            var courseId = (int)CourseId.SelectedValue;

            DateOnly enrollmentDate = DateOnly.FromDateTime(EnrollmentDate.MaxDate);
            enrollments.addEnrollments(studenId, courseId, Grade, enrollmentDate, dataGridView);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }



        private void LoadStudentIds()
        {
            // Truy vấn danh sách học sinh từ CSDL
            var students = qlsvContext.Students.ToList();
            // Thiết lập ComboBox
            StudentId.DataSource = students;
            StudentId.DisplayMember = "FirstName";
            StudentId.ValueMember = "StudentId";
        }
        private void LoadSCourseIds()
        {
            // Truy vấn danh sách học sinh từ CSDL
            var courses = qlsvContext.Courses.ToList();
            // Thiết lập ComboBox
            CourseId.DataSource = courses;
            CourseId.DisplayMember = "CourseName";
            CourseId.ValueMember = "CourseId";
        }
    }
}
