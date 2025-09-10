using MySql.Data.MySqlClient;
using System;
using Conner_Henrie_C969.Database;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conner_Henrie_C969
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();


            try
            {
                DBConnection.openConnection();

                var getTypeSQL = "SELECT type FROM appointment";
                var getTypeCommand = new MySqlCommand(getTypeSQL, DBConnection.conn);
                MySqlDataReader typeData = getTypeCommand.ExecuteReader();
                while (typeData.Read())
                {
                    string type = typeData.GetString("type");
                    if (!cmbType.Items.Contains(type))
                    {
                        cmbType.Items.Add(type);
                    }
                    
                }
                typeData.Close();

                var getUsersSQL = "SELECT userId, userName FROM user";
                var getUsersCommand = new MySqlCommand(getUsersSQL, DBConnection.conn);
                MySqlDataReader usersData = getUsersCommand.ExecuteReader();

                while (usersData.Read())
                {
                    string username = usersData.GetInt32("userId").ToString() +". " +  usersData.GetString("username");
                    if (!cmbUser.Items.Contains(username))
                    {
                        cmbUser.Items.Add(username);
                    }
                }
                usersData.Close();

                var getCustomersSQL = "SELECT customerId, customerName FROM customer";
                var getCustomersCommand = new MySqlCommand(getCustomersSQL, DBConnection.conn);
                MySqlDataReader customersData = getCustomersCommand.ExecuteReader();

                while (customersData.Read())
                {
                    string customer = customersData.GetInt32("customerId").ToString() + ". " + customersData.GetString("customerName");
                    if (!cmbCustomer.Items.Contains(customer))
                    {
                        cmbCustomer.Items.Add(customer);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBConnection.closeConnection();
            }
        }

        private void btnReportsBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // REPORT 1 - the number of appointment types by month
        private void btnReport1_Click(object sender, EventArgs e)
        {
            if (cmbType.Text == "")
            {
                MessageBox.Show("Please select a type");
                return;

            }
            string type = cmbType.Text;

            DateTime month = mcReport.SelectionStart.ToUniversalTime();
            int appointmentCount = 0;
            List<dynamic> appointmentsList = new List<dynamic>();
            try
            {
                DBConnection.openConnection();

                var getAppointmentsSQL = "SELECT type, start FROM appointment";
                var getAppointmentsCommand = new MySqlCommand(getAppointmentsSQL, DBConnection.conn);
                MySqlDataReader appointmentsData = getAppointmentsCommand.ExecuteReader();

                while (appointmentsData.Read())
                {
                    appointmentsList.Add(new
                    {
                        Type = appointmentsData.GetString("type"),
                        Start = appointmentsData.GetDateTime("start")
                    });
                }
                appointmentsData.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBConnection.closeConnection();
            }

            // LAMBDA 1 Start
            appointmentCount = appointmentsList.Count(appointment =>  
                appointment.Type == type &&
                appointment.Start.Month == month.Month &&
                appointment.Start.Year == month.Year
                );
            // LAMBDA 1 End
            if (appointmentCount == 1)
            {
                
                lblTypeMessage.Text = ("There is " + appointmentCount.ToString() + " " + type + " appointment during " + month.ToString("MMMM"));
            }
            else
            {
                lblTypeMessage.Text = ("There are " + appointmentCount.ToString() + " " + type + " appointments during " + month.ToString("MMMM"));
            }

        }

        // REPORT 2 - the schedule for each user
        private void btnReport2_Click(object sender, EventArgs e)
        {
            string userInfo = cmbUser.Text;
            string[] userID = userInfo.Split(new[] { ". " }, StringSplitOptions.None);

            if (userID.Length > 1)
            {
                userInfo = (userID[0]);
            }
            else
            {
                MessageBox.Show("Error: Please select a user.");
                return;
            }

            string appointmentssql = "SELECT title, location, start, end FROM appointment WHERE userId = " + userInfo +" ORDER BY start";
            var appointmentsdataadapter = new MySqlDataAdapter(appointmentssql, DBConnection.conn);
            DataTable appointmentsdt = new DataTable();
            appointmentsdataadapter.Fill(appointmentsdt);

            // LAMBDA 2 START
            appointmentsdt.AsEnumerable().ToList().ForEach(row => 
            {
                row[2] = Convert.ToDateTime(row[2]).ToLocalTime();
                row[3] = Convert.ToDateTime(row[3]).ToLocalTime();
            });
            // LAMBDA 2 END

            dgvUser.DataSource = appointmentsdt;
            dgvUser.Columns["title"].HeaderText = "Title";
            dgvUser.Columns["location"].HeaderText = "Location";
            dgvUser.Columns["start"].HeaderText = "Start";
            dgvUser.Columns["end"].HeaderText = "End";
        }

        //REPORT 3 Custom Report
        private void btnReport3_Click(object sender, EventArgs e)
        {
            string customerInfo = cmbCustomer.Text;
            string[] customerID = customerInfo.Split(new[] { ". " }, StringSplitOptions.None);
            int appointmentCount = 0;
            List<dynamic> appointmentList = new List<dynamic>();

            if (customerID.Length > 1)
            {
                customerInfo = (customerID[0]);
            }
            else
            {
                MessageBox.Show("Error: Please select a customer.");
                return;
            }
            Console.WriteLine(customerInfo);
            string customersSQL = "SELECT customerId FROM appointment";
            var customersCommand = new MySqlCommand(customersSQL, DBConnection.conn);


            try
            {
                DBConnection.openConnection();
                MySqlDataReader customersData = customersCommand.ExecuteReader();
                while (customersData.Read())
                {
                    appointmentList.Add(new {ID = customersData.GetInt32("customerId")});
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBConnection.closeConnection();
            }

            appointmentCount = appointmentList.Count( a => a.ID == int.Parse(customerInfo)); // LAMBDA 3

            if (appointmentCount == 1) {
                lblCustomer.Text = "There is 1 appointment associated with this customer";
            }
            else
            {
                lblCustomer.Text = "There are " + appointmentCount + " appointments associated with this customer";
            }

        }
    }
}
