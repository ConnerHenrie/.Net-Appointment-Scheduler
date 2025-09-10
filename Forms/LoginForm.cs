using Conner_Henrie_C969.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conner_Henrie_C969
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            Program.currentLocale = CultureInfo.CurrentCulture.TwoLetterISOLanguageName; ;
            Console.WriteLine(Program.currentLocale);
            SwapLocale(Program.currentLocale);



        }

        private void SwapLocale(string locale)
        {
            if (locale == "en")
            {
                //en here
                lblLoginFormUsername.Text = "Username";
                lblLoginFormPassword.Text = "Password";
                btnLoginForm.Text = "Login";
                lblLoginFormLocale.Text = "Locale is " + locale;
            }
            if (locale == "de")
            {
                //de here
                lblLoginFormUsername.Text = "Benutzername";
                lblLoginFormPassword.Text = "Passwort";
                btnLoginForm.Text = "Login";
                lblLoginFormLocale.Text = "Gebietsschema ist " + locale;
            }
        }

        private void btnLoginForm_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            bool isPasswordValid = false;

            if (username == "" && Program.currentLocale == "en")
            {
                MessageBox.Show("Please enter a username");
                return;
            }

            if (username == "" && Program.currentLocale == "de")
            {
                MessageBox.Show("Bitte geben Sie einen Benutzernamen ein");
                return;
            }

            if (password == "" && Program.currentLocale == "en")
            {
                MessageBox.Show("Please enter a password");
                return;
            }
            if (password == "" && Program.currentLocale == "de")
            {
                MessageBox.Show("Bitte geben Sie ein Passwort ein");
                return;
            }

            string loginSQL = "Select userID, userName, password FROM user";
            var loginCommand = new MySqlCommand(loginSQL, DBConnection.conn);

            try
            {
                DBConnection.openConnection();

                MySqlDataReader loginData = loginCommand.ExecuteReader();
                while (loginData.Read())
                {
                    if (loginData.GetString("username") == username && loginData.GetString("password") == password) {
                        isPasswordValid = true;
                        Program.currentUser = loginData.GetString("username");
                        Program.currentUserID = loginData.GetInt32("userId");
                        LogAttempt(username, isPasswordValid);
                        break;
                    }
                }
                loginData.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBConnection.closeConnection();
            }

            if (!isPasswordValid && Program.currentLocale == "en")
            {
                LogAttempt(username, isPasswordValid);
                MessageBox.Show("Username or password is incorrect");
               
                return;
            }
            if (!isPasswordValid && Program.currentLocale == "de")
            {
                LogAttempt(username, isPasswordValid);
                MessageBox.Show("Benutzername oder Passwort sind falsch");
                return;
            }

            

            this.Hide();
            new Main().ShowDialog();       
        }

        private void LogAttempt(string username, bool success)
        {
            string text;
            if (success)
            {
                text = $"{username} succesfully logged in at " + DateTime.Now.ToUniversalTime().ToString() +" UTC"+ Environment.NewLine;
            }
            else
            {
                text = $"{username} attempted login with incorrect password at " + DateTime.Now.ToUniversalTime().ToString() +" UTC"+ Environment.NewLine;
            }

            string projectRootDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;

            string logPath = Path.Combine(projectRootDirectory, "Logs/Login_History.txt");

            File.AppendAllText(logPath, text);
        }
    }
}
