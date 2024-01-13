namespace SQVL.ViewAdd
{
    partial class FormAddStudent
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
            button1 = new Button();
            button2 = new Button();
            panel1 = new Panel();
            textDateOfBirth = new DateTimePicker();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            text = new Label();
            textEmail = new TextBox();
            textLastName = new TextBox();
            FirstName = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(168, 292);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "cant";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(341, 292);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 1;
            button2.Text = "add";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(textDateOfBirth);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(text);
            panel1.Controls.Add(textEmail);
            panel1.Controls.Add(textLastName);
            panel1.Controls.Add(FirstName);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(590, 414);
            panel1.TabIndex = 2;
            // 
            // textDateOfBirth
            // 
            textDateOfBirth.Location = new Point(244, 163);
            textDateOfBirth.Name = "textDateOfBirth";
            textDateOfBirth.Size = new Size(171, 23);
            textDateOfBirth.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(168, 209);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 10;
            label4.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(168, 169);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 9;
            label3.Text = "DateOfBirth";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(168, 126);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 8;
            label2.Text = "LastName";
            // 
            // text
            // 
            text.AutoSize = true;
            text.Location = new Point(168, 80);
            text.Name = "text";
            text.Size = new Size(61, 15);
            text.TabIndex = 7;
            text.Text = "FirstName";
            // 
            // textEmail
            // 
            textEmail.Location = new Point(244, 201);
            textEmail.Name = "textEmail";
            textEmail.Size = new Size(172, 23);
            textEmail.TabIndex = 5;
            // 
            // textLastName
            // 
            textLastName.Location = new Point(244, 118);
            textLastName.Name = "textLastName";
            textLastName.Size = new Size(172, 23);
            textLastName.TabIndex = 3;
            // 
            // FirstName
            // 
            FirstName.Location = new Point(244, 72);
            FirstName.Name = "FirstName";
            FirstName.Size = new Size(172, 23);
            FirstName.TabIndex = 2;
            // 
            // FormAddStudent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(590, 414);
            Controls.Add(panel1);
            Name = "FormAddStudent";
            Text = "FormAddStudent";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Panel panel1;
        private TextBox textEmail;
        private TextBox textLastName;
        private TextBox FirstName;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label text;
        private DateTimePicker textDateOfBirth;
    }
}