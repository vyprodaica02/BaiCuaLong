using SQVL.ISerVices;
using SQVL.SerVices;
using SQVL.ViewAdd;

namespace SQVL
{
    public partial class Form1 : Form
    {
        private readonly IStudents students;
        private readonly ICourses courses;
        private readonly IEnrollments enrollments;
        private string nameGridView;

        public Form1()
        {
            InitializeComponent();
            students = new StudentsServices();
            courses = new CoursesServices();
            enrollments = new EnrollmentsSerVices();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Students_Click(object sender, EventArgs e)
        {
            students.RloadStudent(dataGridView1);
            nameGridView = "students";
        }

        private void Courses_Click(object sender, EventArgs e)
        {
            courses.RloadCourses(dataGridView1);
            nameGridView = "courses";

        }

        private void Enrollments_Click(object sender, EventArgs e)
        {
            enrollments.RloadEnrollments(dataGridView1);
            nameGridView = "enrollments";
        }
        private void Add_Click(object sender, EventArgs e)
        {
            switch (nameGridView)
            {
                case "students":
                    FormAddStudent formAddStudent = new FormAddStudent(dataGridView1);
                    formAddStudent.Show();
                    break;
                case "courses":
                    AddCourses addCourses = new AddCourses(dataGridView1);
                    addCourses.Show();
                    break;
                case "enrollments":
                    FormAddEnrollments  formAddEnrollments = new FormAddEnrollments(dataGridView1);
                    formAddEnrollments.Show();
                    break;
            }

        }
    }
}
