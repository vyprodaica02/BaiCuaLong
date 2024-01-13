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
    public partial class AddCourses : Form
    {
        private readonly ICourses courses;
        private readonly DataGridView dataGridView;
        public AddCourses(DataGridView dataGridView)
        {
            InitializeComponent();
            courses = new CoursesServices();
            this.dataGridView = dataGridView;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var CourseName = textCourseName.Text;
            int Credits = int.Parse(textCredits.Text);
            await courses.addCourses(CourseName, Credits, dataGridView);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
