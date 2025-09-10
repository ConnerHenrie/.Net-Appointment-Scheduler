namespace Conner_Henrie_C969
{
    partial class Reports
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.mcReport = new System.Windows.Forms.MonthCalendar();
            this.btnReport1 = new System.Windows.Forms.Button();
            this.btnReport2 = new System.Windows.Forms.Button();
            this.btnReport3 = new System.Windows.Forms.Button();
            this.btnReportsBack = new System.Windows.Forms.Button();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.lblTypeMessage = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(689, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Schedule";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1203, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Appointments Per Customer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Appointments by Type/Month";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label4.Location = new System.Drawing.Point(672, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 31);
            this.label4.TabIndex = 3;
            this.label4.Text = "Reports";
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(98, 134);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(144, 21);
            this.cmbType.TabIndex = 1;
            // 
            // mcReport
            // 
            this.mcReport.Location = new System.Drawing.Point(56, 191);
            this.mcReport.MaxSelectionCount = 1;
            this.mcReport.Name = "mcReport";
            this.mcReport.TabIndex = 2;
            // 
            // btnReport1
            // 
            this.btnReport1.Location = new System.Drawing.Point(120, 616);
            this.btnReport1.Name = "btnReport1";
            this.btnReport1.Size = new System.Drawing.Size(75, 23);
            this.btnReport1.TabIndex = 3;
            this.btnReport1.Text = "Run";
            this.btnReport1.UseVisualStyleBackColor = true;
            this.btnReport1.Click += new System.EventHandler(this.btnReport1_Click);
            // 
            // btnReport2
            // 
            this.btnReport2.Location = new System.Drawing.Point(678, 616);
            this.btnReport2.Name = "btnReport2";
            this.btnReport2.Size = new System.Drawing.Size(75, 23);
            this.btnReport2.TabIndex = 5;
            this.btnReport2.Text = "Run";
            this.btnReport2.UseVisualStyleBackColor = true;
            this.btnReport2.Click += new System.EventHandler(this.btnReport2_Click);
            // 
            // btnReport3
            // 
            this.btnReport3.Location = new System.Drawing.Point(1236, 616);
            this.btnReport3.Name = "btnReport3";
            this.btnReport3.Size = new System.Drawing.Size(75, 23);
            this.btnReport3.TabIndex = 7;
            this.btnReport3.Text = "Run";
            this.btnReport3.UseVisualStyleBackColor = true;
            this.btnReport3.Click += new System.EventHandler(this.btnReport3_Click);
            // 
            // btnReportsBack
            // 
            this.btnReportsBack.Location = new System.Drawing.Point(1367, 695);
            this.btnReportsBack.Name = "btnReportsBack";
            this.btnReportsBack.Size = new System.Drawing.Size(75, 23);
            this.btnReportsBack.TabIndex = 8;
            this.btnReportsBack.Text = "Back";
            this.btnReportsBack.UseVisualStyleBackColor = true;
            this.btnReportsBack.Click += new System.EventHandler(this.btnReportsBack_Click);
            // 
            // dgvUser
            // 
            this.dgvUser.AllowUserToAddRows = false;
            this.dgvUser.AllowUserToDeleteRows = false;
            this.dgvUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUser.Location = new System.Drawing.Point(462, 161);
            this.dgvUser.MultiSelect = false;
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.ReadOnly = true;
            this.dgvUser.RowHeadersVisible = false;
            this.dgvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUser.Size = new System.Drawing.Size(529, 435);
            this.dgvUser.TabIndex = 10;
            this.dgvUser.TabStop = false;
            // 
            // cmbUser
            // 
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(655, 134);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(144, 21);
            this.cmbUser.TabIndex = 4;
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(1196, 123);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(144, 21);
            this.cmbCustomer.TabIndex = 6;
            // 
            // lblTypeMessage
            // 
            this.lblTypeMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTypeMessage.Location = new System.Drawing.Point(53, 380);
            this.lblTypeMessage.Name = "lblTypeMessage";
            this.lblTypeMessage.Size = new System.Drawing.Size(230, 216);
            this.lblTypeMessage.TabIndex = 10;
            this.lblTypeMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomer
            // 
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblCustomer.Location = new System.Drawing.Point(1154, 380);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(230, 216);
            this.lblCustomer.TabIndex = 13;
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1454, 730);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.lblTypeMessage);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.cmbUser);
            this.Controls.Add(this.dgvUser);
            this.Controls.Add(this.btnReportsBack);
            this.Controls.Add(this.btnReport3);
            this.Controls.Add(this.btnReport2);
            this.Controls.Add(this.btnReport1);
            this.Controls.Add(this.mcReport);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Reports";
            this.Text = "Reports";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.MonthCalendar mcReport;
        private System.Windows.Forms.Button btnReport1;
        private System.Windows.Forms.Button btnReport2;
        private System.Windows.Forms.Button btnReport3;
        private System.Windows.Forms.Button btnReportsBack;
        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label lblTypeMessage;
        private System.Windows.Forms.Label lblCustomer;
    }
}