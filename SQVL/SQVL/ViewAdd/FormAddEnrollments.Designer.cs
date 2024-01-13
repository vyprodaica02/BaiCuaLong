namespace SQVL.ViewAdd
{
    partial class FormAddEnrollments
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            StudentId = new ComboBox();
            EnrollmentDate = new DateTimePicker();
            CourseId = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            textGrade = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // StudentId
            // 
            StudentId.FormattingEnabled = true;
            StudentId.Location = new Point(330, 179);
            StudentId.Name = "StudentId";
            StudentId.Size = new Size(200, 23);
            StudentId.TabIndex = 0;
            // 
            // EnrollmentDate
            // 
            EnrollmentDate.Location = new Point(330, 238);
            EnrollmentDate.Name = "EnrollmentDate";
            EnrollmentDate.Size = new Size(200, 23);
            EnrollmentDate.TabIndex = 1;
            // 
            // CourseId
            // 
            CourseId.FormattingEnabled = true;
            CourseId.Location = new Point(330, 209);
            CourseId.Name = "CourseId";
            CourseId.Size = new Size(200, 23);
            CourseId.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(266, 182);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 3;
            label1.Text = "StudentId";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(266, 212);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 4;
            label2.Text = "CourseId";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(235, 246);
            label3.Name = "label3";
            label3.Size = new Size(89, 15);
            label3.TabIndex = 5;
            label3.Text = "EnrollmentDate";
            // 
            // button1
            // 
            button1.Location = new Point(282, 295);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 15;
            button1.Text = "cant";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(455, 295);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 16;
            button2.Text = "add";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textGrade
            // 
            textGrade.Location = new Point(330, 140);
            textGrade.Name = "textGrade";
            textGrade.Size = new Size(200, 23);
            textGrade.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(282, 148);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 18;
            label4.Text = "Grade";
            // 
            // FormAddEnrollments
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(textGrade);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(CourseId);
            Controls.Add(EnrollmentDate);
            Controls.Add(StudentId);
            Name = "FormAddEnrollments";
            Text = "FormAddEnrollments";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox StudentId;
        private DateTimePicker EnrollmentDate;
        private ComboBox CourseId;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button button2;
        private TextBox textGrade;
        private Label label4;
    }
}