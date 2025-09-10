namespace Conner_Henrie_C969
{
    partial class Main
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
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.lblMainAppointments = new System.Windows.Forms.Label();
            this.lblMainCustomers = new System.Windows.Forms.Label();
            this.btnMainAppointmentAdd = new System.Windows.Forms.Button();
            this.btnMainAppointmentUpdate = new System.Windows.Forms.Button();
            this.btnMainAppointmentDelete = new System.Windows.Forms.Button();
            this.btnMainCustomersDelete = new System.Windows.Forms.Button();
            this.btnMainCustomersAdd = new System.Windows.Forms.Button();
            this.btnMainCustomersUpdate = new System.Windows.Forms.Button();
            this.btnMainLogout = new System.Windows.Forms.Button();
            this.btnMainReporting = new System.Windows.Forms.Button();
            this.rbtnMainAppointmentsAll = new System.Windows.Forms.RadioButton();
            this.rbtnMainAppointmentsMonth = new System.Windows.Forms.RadioButton();
            this.rbtnMainAppointmentsDay = new System.Windows.Forms.RadioButton();
            this.mcMain = new System.Windows.Forms.MonthCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.AllowUserToDeleteRows = false;
            this.dgvAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.Location = new System.Drawing.Point(12, 64);
            this.dgvAppointments.MultiSelect = false;
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.RowHeadersVisible = false;
            this.dgvAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppointments.Size = new System.Drawing.Size(1439, 262);
            this.dgvAppointments.TabIndex = 0;
            this.dgvAppointments.TabStop = false;
            this.dgvAppointments.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvAppointments_DataBindingComplete);
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Location = new System.Drawing.Point(12, 441);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.RowHeadersVisible = false;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(913, 262);
            this.dgvCustomers.TabIndex = 1;
            this.dgvCustomers.TabStop = false;
            this.dgvCustomers.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCustomers_DataBindingComplete);
            // 
            // lblMainAppointments
            // 
            this.lblMainAppointments.AutoSize = true;
            this.lblMainAppointments.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainAppointments.Location = new System.Drawing.Point(12, 21);
            this.lblMainAppointments.Name = "lblMainAppointments";
            this.lblMainAppointments.Size = new System.Drawing.Size(180, 31);
            this.lblMainAppointments.TabIndex = 2;
            this.lblMainAppointments.Text = "Appointments";
            // 
            // lblMainCustomers
            // 
            this.lblMainCustomers.AutoSize = true;
            this.lblMainCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainCustomers.Location = new System.Drawing.Point(12, 398);
            this.lblMainCustomers.Name = "lblMainCustomers";
            this.lblMainCustomers.Size = new System.Drawing.Size(146, 31);
            this.lblMainCustomers.TabIndex = 3;
            this.lblMainCustomers.Text = "Customers";
            // 
            // btnMainAppointmentAdd
            // 
            this.btnMainAppointmentAdd.Location = new System.Drawing.Point(175, 332);
            this.btnMainAppointmentAdd.Name = "btnMainAppointmentAdd";
            this.btnMainAppointmentAdd.Size = new System.Drawing.Size(75, 23);
            this.btnMainAppointmentAdd.TabIndex = 1;
            this.btnMainAppointmentAdd.Text = "Add";
            this.btnMainAppointmentAdd.UseVisualStyleBackColor = true;
            this.btnMainAppointmentAdd.Click += new System.EventHandler(this.btnMainAppointmentAdd_Click);
            // 
            // btnMainAppointmentUpdate
            // 
            this.btnMainAppointmentUpdate.Location = new System.Drawing.Point(338, 332);
            this.btnMainAppointmentUpdate.Name = "btnMainAppointmentUpdate";
            this.btnMainAppointmentUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnMainAppointmentUpdate.TabIndex = 2;
            this.btnMainAppointmentUpdate.Text = "Update";
            this.btnMainAppointmentUpdate.UseVisualStyleBackColor = true;
            this.btnMainAppointmentUpdate.Click += new System.EventHandler(this.btnMainAppointmentUpdate_Click);
            // 
            // btnMainAppointmentDelete
            // 
            this.btnMainAppointmentDelete.Location = new System.Drawing.Point(483, 332);
            this.btnMainAppointmentDelete.Name = "btnMainAppointmentDelete";
            this.btnMainAppointmentDelete.Size = new System.Drawing.Size(75, 23);
            this.btnMainAppointmentDelete.TabIndex = 3;
            this.btnMainAppointmentDelete.Text = "Delete";
            this.btnMainAppointmentDelete.UseVisualStyleBackColor = true;
            this.btnMainAppointmentDelete.Click += new System.EventHandler(this.btnMainAppointmentDelete_Click);
            // 
            // btnMainCustomersDelete
            // 
            this.btnMainCustomersDelete.Location = new System.Drawing.Point(483, 709);
            this.btnMainCustomersDelete.Name = "btnMainCustomersDelete";
            this.btnMainCustomersDelete.Size = new System.Drawing.Size(75, 23);
            this.btnMainCustomersDelete.TabIndex = 6;
            this.btnMainCustomersDelete.Text = "Delete";
            this.btnMainCustomersDelete.UseVisualStyleBackColor = true;
            this.btnMainCustomersDelete.Click += new System.EventHandler(this.btnMainCustomersDelete_Click);
            // 
            // btnMainCustomersAdd
            // 
            this.btnMainCustomersAdd.Location = new System.Drawing.Point(175, 709);
            this.btnMainCustomersAdd.Name = "btnMainCustomersAdd";
            this.btnMainCustomersAdd.Size = new System.Drawing.Size(75, 23);
            this.btnMainCustomersAdd.TabIndex = 4;
            this.btnMainCustomersAdd.Text = "Add";
            this.btnMainCustomersAdd.UseVisualStyleBackColor = true;
            this.btnMainCustomersAdd.Click += new System.EventHandler(this.btnMainCustomersAdd_Click);
            // 
            // btnMainCustomersUpdate
            // 
            this.btnMainCustomersUpdate.Location = new System.Drawing.Point(338, 709);
            this.btnMainCustomersUpdate.Name = "btnMainCustomersUpdate";
            this.btnMainCustomersUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnMainCustomersUpdate.TabIndex = 5;
            this.btnMainCustomersUpdate.Text = "Update";
            this.btnMainCustomersUpdate.UseVisualStyleBackColor = true;
            this.btnMainCustomersUpdate.Click += new System.EventHandler(this.btnMainCustomersUpdate_Click);
            // 
            // btnMainLogout
            // 
            this.btnMainLogout.Location = new System.Drawing.Point(1326, 724);
            this.btnMainLogout.Name = "btnMainLogout";
            this.btnMainLogout.Size = new System.Drawing.Size(105, 39);
            this.btnMainLogout.TabIndex = 8;
            this.btnMainLogout.Text = "Logout";
            this.btnMainLogout.UseVisualStyleBackColor = true;
            this.btnMainLogout.Click += new System.EventHandler(this.btnMainLogout_Click);
            // 
            // btnMainReporting
            // 
            this.btnMainReporting.Location = new System.Drawing.Point(1326, 649);
            this.btnMainReporting.Name = "btnMainReporting";
            this.btnMainReporting.Size = new System.Drawing.Size(105, 39);
            this.btnMainReporting.TabIndex = 7;
            this.btnMainReporting.Text = "Reports";
            this.btnMainReporting.UseVisualStyleBackColor = true;
            this.btnMainReporting.Click += new System.EventHandler(this.btnMainReporting_Click);
            // 
            // rbtnMainAppointmentsAll
            // 
            this.rbtnMainAppointmentsAll.AutoSize = true;
            this.rbtnMainAppointmentsAll.Checked = true;
            this.rbtnMainAppointmentsAll.Location = new System.Drawing.Point(928, 338);
            this.rbtnMainAppointmentsAll.Name = "rbtnMainAppointmentsAll";
            this.rbtnMainAppointmentsAll.Size = new System.Drawing.Size(103, 17);
            this.rbtnMainAppointmentsAll.TabIndex = 4;
            this.rbtnMainAppointmentsAll.Text = "All Appointments";
            this.rbtnMainAppointmentsAll.UseVisualStyleBackColor = true;
            this.rbtnMainAppointmentsAll.CheckedChanged += new System.EventHandler(this.rbtnMainAppointmentsAll_CheckedChanged);
            // 
            // rbtnMainAppointmentsMonth
            // 
            this.rbtnMainAppointmentsMonth.AutoSize = true;
            this.rbtnMainAppointmentsMonth.Location = new System.Drawing.Point(1117, 338);
            this.rbtnMainAppointmentsMonth.Name = "rbtnMainAppointmentsMonth";
            this.rbtnMainAppointmentsMonth.Size = new System.Drawing.Size(136, 17);
            this.rbtnMainAppointmentsMonth.TabIndex = 12;
            this.rbtnMainAppointmentsMonth.Text = "Appointments by Month";
            this.rbtnMainAppointmentsMonth.UseVisualStyleBackColor = true;
            this.rbtnMainAppointmentsMonth.CheckedChanged += new System.EventHandler(this.rbtnMainAppointmentsMonth_CheckedChanged);
            // 
            // rbtnMainAppointmentsDay
            // 
            this.rbtnMainAppointmentsDay.AutoSize = true;
            this.rbtnMainAppointmentsDay.Location = new System.Drawing.Point(1326, 338);
            this.rbtnMainAppointmentsDay.Name = "rbtnMainAppointmentsDay";
            this.rbtnMainAppointmentsDay.Size = new System.Drawing.Size(125, 17);
            this.rbtnMainAppointmentsDay.TabIndex = 13;
            this.rbtnMainAppointmentsDay.Text = "Appointments by Day";
            this.rbtnMainAppointmentsDay.UseVisualStyleBackColor = true;
            this.rbtnMainAppointmentsDay.CheckedChanged += new System.EventHandler(this.rbtnMainAppointmentsDay_CheckedChanged);
            // 
            // mcMain
            // 
            this.mcMain.Location = new System.Drawing.Point(1063, 367);
            this.mcMain.MaxSelectionCount = 1;
            this.mcMain.Name = "mcMain";
            this.mcMain.TabIndex = 14;
            this.mcMain.TabStop = false;
            this.mcMain.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.mcMain_DateSelected);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1463, 775);
            this.Controls.Add(this.mcMain);
            this.Controls.Add(this.rbtnMainAppointmentsDay);
            this.Controls.Add(this.rbtnMainAppointmentsMonth);
            this.Controls.Add(this.rbtnMainAppointmentsAll);
            this.Controls.Add(this.btnMainReporting);
            this.Controls.Add(this.btnMainLogout);
            this.Controls.Add(this.btnMainCustomersUpdate);
            this.Controls.Add(this.btnMainCustomersAdd);
            this.Controls.Add(this.btnMainCustomersDelete);
            this.Controls.Add(this.btnMainAppointmentDelete);
            this.Controls.Add(this.btnMainAppointmentUpdate);
            this.Controls.Add(this.btnMainAppointmentAdd);
            this.Controls.Add(this.lblMainCustomers);
            this.Controls.Add(this.lblMainAppointments);
            this.Controls.Add(this.dgvCustomers);
            this.Controls.Add(this.dgvAppointments);
            this.Name = "Main";
            this.Text = "Main Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Label lblMainAppointments;
        private System.Windows.Forms.Label lblMainCustomers;
        private System.Windows.Forms.Button btnMainAppointmentAdd;
        private System.Windows.Forms.Button btnMainAppointmentUpdate;
        private System.Windows.Forms.Button btnMainAppointmentDelete;
        private System.Windows.Forms.Button btnMainCustomersDelete;
        private System.Windows.Forms.Button btnMainCustomersAdd;
        private System.Windows.Forms.Button btnMainCustomersUpdate;
        private System.Windows.Forms.Button btnMainLogout;
        private System.Windows.Forms.Button btnMainReporting;
        private System.Windows.Forms.RadioButton rbtnMainAppointmentsAll;
        private System.Windows.Forms.RadioButton rbtnMainAppointmentsMonth;
        private System.Windows.Forms.RadioButton rbtnMainAppointmentsDay;
        private System.Windows.Forms.MonthCalendar mcMain;
    }
}

