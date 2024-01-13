namespace Egzaminas
{
    partial class Registracija
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
            label1 = new Label();
            textBoxPassword = new TextBox();
            buttonAccept = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(98, 46);
            label1.Name = "label1";
            label1.Size = new Size(176, 15);
            label1.TabIndex = 0;
            label1.Text = "MASTER slaptažodžio sukurimas";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(87, 79);
            textBoxPassword.MaxLength = 256;
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(201, 23);
            textBoxPassword.TabIndex = 3;
            // 
            // buttonAccept
            // 
            buttonAccept.Location = new Point(87, 146);
            buttonAccept.Name = "buttonAccept";
            buttonAccept.Size = new Size(98, 22);
            buttonAccept.TabIndex = 7;
            buttonAccept.Text = "Patvirtinti";
            buttonAccept.UseVisualStyleBackColor = true;
            buttonAccept.Click += buttonAccept_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(190, 146);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(98, 23);
            buttonCancel.TabIndex = 8;
            buttonCancel.Text = "Atšaukti";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // FormFirstTime
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(357, 179);
            Controls.Add(buttonCancel);
            Controls.Add(buttonAccept);
            Controls.Add(textBoxPassword);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormFirstTime";
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxPassword;
        private Button buttonAccept;
        private Button buttonCancel;
    }
}