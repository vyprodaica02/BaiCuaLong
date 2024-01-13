namespace SQVL
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel3 = new Panel();
            dataGridView1 = new DataGridView();
            panel2 = new Panel();
            Enrollments = new Button();
            Courses = new Button();
            Students = new Button();
            Add = new Button();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 450);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(dataGridView1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 100);
            panel3.Name = "panel3";
            panel3.Size = new Size(800, 350);
            panel3.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(800, 350);
            dataGridView1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(Add);
            panel2.Controls.Add(Enrollments);
            panel2.Controls.Add(Courses);
            panel2.Controls.Add(Students);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 100);
            panel2.TabIndex = 0;
            // 
            // Enrollments
            // 
            Enrollments.Location = new Point(174, 24);
            Enrollments.Name = "Enrollments";
            Enrollments.Size = new Size(75, 23);
            Enrollments.TabIndex = 2;
            Enrollments.Text = "Enrollments";
            Enrollments.UseVisualStyleBackColor = true;
            Enrollments.Click += Enrollments_Click;
            // 
            // Courses
            // 
            Courses.Location = new Point(93, 24);
            Courses.Name = "Courses";
            Courses.Size = new Size(75, 23);
            Courses.TabIndex = 1;
            Courses.Text = "Courses";
            Courses.UseVisualStyleBackColor = true;
            Courses.Click += Courses_Click;
            // 
            // Students
            // 
            Students.Location = new Point(12, 24);
            Students.Name = "Students";
            Students.Size = new Size(75, 23);
            Students.TabIndex = 0;
            Students.Text = "Students";
            Students.UseVisualStyleBackColor = true;
            Students.Click += Students_Click;
            // 
            // Add
            // 
            Add.Location = new Point(558, 30);
            Add.Name = "Add";
            Add.Size = new Size(75, 23);
            Add.TabIndex = 3;
            Add.Text = "Add";
            Add.UseVisualStyleBackColor = true;
            Add.Click += Add_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private DataGridView dataGridView1;
        private Button Students;
        private Button Enrollments;
        private Button Courses;
        private Button Add;
    }
}
