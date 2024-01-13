namespace Egzaminas
{
    partial class Prisijungimas
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
            textBoxMaster = new TextBox();
            buttonAccept = new Button();
            buttonCancel = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // textBoxMaster
            // 
            textBoxMaster.BackColor = SystemColors.Control;
            textBoxMaster.BorderStyle = BorderStyle.FixedSingle;
            textBoxMaster.Location = new Point(105, 79);
            textBoxMaster.Name = "textBoxMaster";
            textBoxMaster.Size = new Size(243, 23);
            textBoxMaster.TabIndex = 1;
            textBoxMaster.UseSystemPasswordChar = true;
            // 
            // buttonAccept
            // 
            buttonAccept.Location = new Point(134, 119);
            buttonAccept.Name = "buttonAccept";
            buttonAccept.Size = new Size(75, 23);
            buttonAccept.TabIndex = 2;
            buttonAccept.Text = "Prisijungti";
            buttonAccept.UseVisualStyleBackColor = true;
            buttonAccept.Click += buttonAccept_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(243, 119);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Atšaukti";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(149, 33);
            label2.Name = "label2";
            label2.Size = new Size(149, 15);
            label2.TabIndex = 4;
            label2.Text = "Įveskite MASTER slaptažodį";
            // 
            // FormConnect
            // 
            AcceptButton = buttonAccept;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(440, 229);
            Controls.Add(label2);
            Controls.Add(buttonCancel);
            Controls.Add(buttonAccept);
            Controls.Add(textBoxMaster);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormConnect";
            StartPosition = FormStartPosition.CenterParent;
            Load += FormConnect_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBoxMaster;
        private Button buttonAccept;
        private Button buttonCancel;
        private Label label2;
    }
}