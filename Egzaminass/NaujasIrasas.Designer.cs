namespace Egzaminas
{
    partial class NaujasIrasas
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
            groupBox1 = new GroupBox();
            buttonGenerate = new Button();
            textBoxPassword = new TextBox();
            textBoxProgram = new TextBox();
            label3 = new Label();
            label1 = new Label();
            buttonAccept = new Button();
            buttonCancel = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonGenerate);
            groupBox1.Controls.Add(textBoxPassword);
            groupBox1.Controls.Add(textBoxProgram);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(447, 210);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // buttonGenerate
            // 
            buttonGenerate.Location = new Point(185, 171);
            buttonGenerate.Name = "buttonGenerate";
            buttonGenerate.Size = new Size(111, 23);
            buttonGenerate.TabIndex = 7;
            buttonGenerate.Text = "Generuoti";
            buttonGenerate.UseVisualStyleBackColor = true;
            buttonGenerate.Click += ButtonGenerate_Click;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(126, 132);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(235, 23);
            textBoxPassword.TabIndex = 5;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // textBoxProgram
            // 
            textBoxProgram.Location = new Point(126, 62);
            textBoxProgram.Name = "textBoxProgram";
            textBoxProgram.Size = new Size(235, 23);
            textBoxProgram.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(198, 105);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 2;
            label3.Text = "Slaptažodis:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(205, 34);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 0;
            label1.Text = "Programa:";
            label1.Click += label1_Click;
            // 
            // buttonAccept
            // 
            buttonAccept.Location = new Point(12, 228);
            buttonAccept.Name = "buttonAccept";
            buttonAccept.Size = new Size(75, 23);
            buttonAccept.TabIndex = 1;
            buttonAccept.Text = "Patvirtinti";
            buttonAccept.UseVisualStyleBackColor = true;
            buttonAccept.Click += ButtonAccept_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(379, 227);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Atšaukti";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // FormInsertEntry
            // 
            AcceptButton = buttonAccept;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(466, 259);
            Controls.Add(buttonCancel);
            Controls.Add(buttonAccept);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormInsertEntry";
            Text = "Sukurti naują įrašą";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox textBoxPassword;
        private TextBox textBoxProgram;
        private Label label3;
        private Label label1;
        private Button buttonGenerate;
        private Button buttonAccept;
        private Button buttonCancel;
    }
}