namespace Egzaminas
{
    partial class Pagrindinis
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
        private void ActivateComponents()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridView = new DataGridView();
            buttonConnect = new Button();
            buttonNewEntry = new Button();
            textBoxSelectData = new TextBox();
            checkBoxShowPassword = new CheckBox();
            buttonUpdateEntry = new Button();
            buttonDeleteEntry = new Button();
            buttonCopypPaskirtis = new Button();
            buttonCopyPassword = new Button();
            buttonDisconnect = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowDrop = true;
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.BackgroundColor = SystemColors.Control;
            dataGridView.BorderStyle = BorderStyle.Fixed3D;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.GridColor = SystemColors.Control;
            dataGridView.Location = new Point(12, 49);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.RowTemplate.Height = 25;
            dataGridView.ScrollBars = ScrollBars.Vertical;
            dataGridView.Size = new Size(455, 565);
            dataGridView.TabIndex = 0;
            dataGridView.CellClick += DataGridView_Click;
            // 
            // buttonConnect
            // 
            buttonConnect.Location = new Point(12, 12);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new Size(142, 23);
            buttonConnect.TabIndex = 1;
            buttonConnect.Text = "Prisijungti ";
            buttonConnect.UseVisualStyleBackColor = true;
            buttonConnect.Click += ButtonConnect_Click;
            // 
            // buttonNewEntry
            // 
            buttonNewEntry.Enabled = false;
            buttonNewEntry.Location = new Point(482, 165);
            buttonNewEntry.Name = "buttonNewEntry";
            buttonNewEntry.Size = new Size(319, 89);
            buttonNewEntry.TabIndex = 2;
            buttonNewEntry.Text = "Sukurti ";
            buttonNewEntry.UseVisualStyleBackColor = true;
            buttonNewEntry.Click += ButtonNewEntry_Click;
            // 
            // textBoxSelectedData
            // 
            textBoxSelectData.BackColor = SystemColors.Control;
            textBoxSelectData.Location = new Point(482, 49);
            textBoxSelectData.Multiline = true;
            textBoxSelectData.Name = "textBoxSelectedData";
            textBoxSelectData.ReadOnly = true;
            textBoxSelectData.Size = new Size(585, 78);
            textBoxSelectData.TabIndex = 3;
            textBoxSelectData.TextChanged += textBoxSelectedData_TextChanged;
            // 
            // checkBoxShowPassword
            // 
            checkBoxShowPassword.AutoSize = true;
            checkBoxShowPassword.Location = new Point(482, 133);
            checkBoxShowPassword.Name = "checkBoxShowPassword";
            checkBoxShowPassword.Size = new Size(170, 19);
            checkBoxShowPassword.TabIndex = 4;
            checkBoxShowPassword.Text = "Rodyti pasirinktą slaptažodį";
            checkBoxShowPassword.UseVisualStyleBackColor = true;
            checkBoxShowPassword.CheckedChanged += ShowPassword_Box;
            // 
            // buttonUpdateEntry
            // 
            buttonUpdateEntry.Enabled = false;
            buttonUpdateEntry.Location = new Point(807, 165);
            buttonUpdateEntry.Name = "buttonUpdateEntry";
            buttonUpdateEntry.Size = new Size(260, 89);
            buttonUpdateEntry.TabIndex = 5;
            buttonUpdateEntry.Text = "Atnaujinti";
            buttonUpdateEntry.UseVisualStyleBackColor = true;
            buttonUpdateEntry.Click += ButtonUpdateEntry_Click;
            // 
            // buttonDeleteEntry
            // 
            buttonDeleteEntry.Enabled = false;
            buttonDeleteEntry.Location = new Point(482, 274);
            buttonDeleteEntry.Name = "buttonDeleteEntry";
            buttonDeleteEntry.Size = new Size(319, 76);
            buttonDeleteEntry.TabIndex = 6;
            buttonDeleteEntry.Text = "Trinti ";
            buttonDeleteEntry.UseVisualStyleBackColor = true;
            buttonDeleteEntry.Click += ButtonDeleteEntry_Click;
            // 
            // buttonCopyUser
            // 
            buttonCopypPaskirtis.Enabled = false;
            buttonCopypPaskirtis.Location = new Point(807, 274);
            buttonCopypPaskirtis.Name = "buttonCopyUser";
            buttonCopypPaskirtis.Size = new Size(260, 77);
            buttonCopypPaskirtis.TabIndex = 7;
            buttonCopypPaskirtis.Text = "Kopijuoti paskirti";
            buttonCopypPaskirtis.UseVisualStyleBackColor = true;
            buttonCopypPaskirtis.Click += ButtonCopyUser_Click;
            // 
            // buttonCopyPassword
            // 
            buttonCopyPassword.Enabled = false;
            buttonCopyPassword.Location = new Point(482, 372);
            buttonCopyPassword.Name = "buttonCopyPassword";
            buttonCopyPassword.Size = new Size(585, 82);
            buttonCopyPassword.TabIndex = 8;
            buttonCopyPassword.Text = "Kopijuoti slaptažodį";
            buttonCopyPassword.UseVisualStyleBackColor = true;
            buttonCopyPassword.Click += ButtonCopyPassword_Click;
            // 
            // buttonDisconnect
            // 
            buttonDisconnect.Enabled = false;
            buttonDisconnect.Location = new Point(925, 12);
            buttonDisconnect.Name = "buttonDisconnect";
            buttonDisconnect.Size = new Size(142, 23);
            buttonDisconnect.TabIndex = 9;
            buttonDisconnect.Text = "Atsijungti ";
            buttonDisconnect.UseVisualStyleBackColor = true;
            buttonDisconnect.Click += ButtonDisconnect_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1079, 626);
            Controls.Add(buttonDisconnect);
            Controls.Add(buttonCopyPassword);
            Controls.Add(buttonCopypPaskirtis);
            Controls.Add(buttonDeleteEntry);
            Controls.Add(buttonUpdateEntry);
            Controls.Add(checkBoxShowPassword);
            Controls.Add(textBoxSelectData);
            Controls.Add(buttonNewEntry);
            Controls.Add(buttonConnect);
            Controls.Add(dataGridView);
            KeyPreview = true;
            MaximizeBox = false;
            MaximumSize = new Size(1095, 665);
            MinimizeBox = false;
            MinimumSize = new Size(1095, 665);
            Name = "FormMain";
            Text = "Slaptažodžiai";
            FormClosed += PagrindineClose;
            Load += FormMain_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView;
        private Button buttonConnect;
        private Button buttonNewEntry;
        private TextBox textBoxSelectData;
        private CheckBox checkBoxShowPassword;
        private Button buttonUpdateEntry;
        private Button buttonDeleteEntry;
        private Button buttonCopypPaskirtis;
        private Button buttonCopyPassword;
        private Button buttonDisconnect;
    }
}