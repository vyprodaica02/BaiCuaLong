namespace SQVL.ViewAdd
{
    partial class AddCourses
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
            label2 = new Label();
            text = new Label();
            textCredits = new TextBox();
            textCourseName = new TextBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(276, 245);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 12;
            label2.Text = "Credits";
            // 
            // text
            // 
            text.AutoSize = true;
            text.Location = new Point(270, 199);
            text.Name = "text";
            text.Size = new Size(76, 15);
            text.TabIndex = 11;
            text.Text = "CourseName";
            // 
            // textCredits
            // 
            textCredits.Location = new Point(352, 237);
            textCredits.Name = "textCredits";
            textCredits.Size = new Size(172, 23);
            textCredits.TabIndex = 10;
            // 
            // textCourseName
            // 
            textCourseName.Location = new Point(352, 191);
            textCourseName.Name = "textCourseName";
            textCourseName.Size = new Size(172, 23);
            textCourseName.TabIndex = 9;
            // 
            // button1
            // 
            button1.Location = new Point(276, 294);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 13;
            button1.Text = "cant";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(449, 294);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 14;
            button2.Text = "add";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // AddCourses
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(text);
            Controls.Add(textCredits);
            Controls.Add(textCourseName);
            Name = "AddCourses";
            Text = "AddCourses";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label text;
        private TextBox textCredits;
        private TextBox textCourseName;
        private Button button1;
        private Button button2;
    }
}