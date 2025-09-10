namespace Conner_Henrie_C969
{
    partial class LoginForm
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
            this.lblLoginFormUsername = new System.Windows.Forms.Label();
            this.lblLoginFormPassword = new System.Windows.Forms.Label();
            this.lblLoginFormLocale = new System.Windows.Forms.Label();
            this.btnLoginForm = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblLoginFormUsername
            // 
            this.lblLoginFormUsername.AutoSize = true;
            this.lblLoginFormUsername.Location = new System.Drawing.Point(93, 24);
            this.lblLoginFormUsername.Name = "lblLoginFormUsername";
            this.lblLoginFormUsername.Size = new System.Drawing.Size(55, 13);
            this.lblLoginFormUsername.TabIndex = 0;
            this.lblLoginFormUsername.Text = "Username";
            // 
            // lblLoginFormPassword
            // 
            this.lblLoginFormPassword.AutoSize = true;
            this.lblLoginFormPassword.Location = new System.Drawing.Point(94, 73);
            this.lblLoginFormPassword.Name = "lblLoginFormPassword";
            this.lblLoginFormPassword.Size = new System.Drawing.Size(53, 13);
            this.lblLoginFormPassword.TabIndex = 2;
            this.lblLoginFormPassword.Text = "Password";
            // 
            // lblLoginFormLocale
            // 
            this.lblLoginFormLocale.AutoSize = true;
            this.lblLoginFormLocale.Location = new System.Drawing.Point(88, 219);
            this.lblLoginFormLocale.Name = "lblLoginFormLocale";
            this.lblLoginFormLocale.Size = new System.Drawing.Size(64, 13);
            this.lblLoginFormLocale.TabIndex = 4;
            this.lblLoginFormLocale.Text = "Locale is en";
            // 
            // btnLoginForm
            // 
            this.btnLoginForm.Location = new System.Drawing.Point(83, 136);
            this.btnLoginForm.Name = "btnLoginForm";
            this.btnLoginForm.Size = new System.Drawing.Size(75, 23);
            this.btnLoginForm.TabIndex = 4;
            this.btnLoginForm.Text = "Login";
            this.btnLoginForm.UseVisualStyleBackColor = true;
            this.btnLoginForm.Click += new System.EventHandler(this.btnLoginForm_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(41, 40);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(159, 20);
            this.txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(41, 89);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(158, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 275);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.btnLoginForm);
            this.Controls.Add(this.lblLoginFormLocale);
            this.Controls.Add(this.lblLoginFormPassword);
            this.Controls.Add(this.lblLoginFormUsername);
            this.Name = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLoginFormUsername;
        private System.Windows.Forms.Label lblLoginFormPassword;
        private System.Windows.Forms.Label lblLoginFormLocale;
        private System.Windows.Forms.Button btnLoginForm;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
    }
}