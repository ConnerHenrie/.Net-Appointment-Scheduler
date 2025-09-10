using Conner_Henrie_C969.Database;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conner_Henrie_C969
{
    public partial class AddAppointment : Form
    {
        public AddAppointment()
        {
            InitializeComponent();
           

            int appointmentID = 0;
                             
            try
            {
                DBConnection.openConnection();

                var getNextIDSQL = "SELECT MAX(appointmentId) FROM appointment";
                var getNextID = new MySqlCommand(getNextIDSQL, DBConnection.conn);
                object data = getNextID.ExecuteScalar();
                if (data != DBNull.Value)
                {
                    appointmentID = Convert.ToInt32(data) + 1;
                }

                var getCustomerIDSQL = "SELECT * FROM customer";
                var getCustomerID = new MySqlCommand(getCustomerIDSQL, DBConnection.conn);
                MySqlDataReader customerID = getCustomerID.ExecuteReader();           
                while (customerID.Read())
                {
                    int id = customerID.GetInt32("customerId");
                    string name = customerID.GetString("customerName");
                    cmbAddAppointmentCustomerID.Items.Add(id + ". " + name);
                }
                customerID.Close();

                var getUserIDSQL = "SELECT * FROM user";
                var getUserID = new MySqlCommand(getUserIDSQL, DBConnection.conn);
                MySqlDataReader userID = getUserID.ExecuteReader();
                while (userID.Read())
                {
                    int id = userID.GetInt32("userId");
                    string name = userID.GetString("userName");
                    cmbAddAppointmentUserID.Items.Add(id + ". " + name);
                }
                userID.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBConnection.closeConnection();
            }
            txtAddAppointmentID.Text = appointmentID.ToString();
        }

        private void btnAddAppointmentCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddAppointmentAdd_Click(object sender, EventArgs e)
        {
            int appointmentID = int.Parse(txtAddAppointmentID.Text);

            string customerID = cmbAddAppointmentCustomerID.Text;
            string[] custID = customerID.Split(new[] { ". " }, StringSplitOptions.None);
            
            if (custID.Length > 1)
            {
                customerID = custID[0];
            }
            else
            {               
                MessageBox.Show("Error: Please Select a customer.");
                return;
            }

            string userInfo = cmbAddAppointmentUserID.Text;
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

            string title = txtAddAppointmentTitle.Text;

            if (title == "")
            {
                MessageBox.Show("Error: Please select a title for the appointment.");
                return;
            }

            string description = txtAddAppointmentDescription.Text;

            if(description == "")
            {
                MessageBox.Show("Error: Please enter a description for the appointment.");
                return;
            }

            string location = txtAddAppointmentLocation.Text;

            if (location == "")
            {
                MessageBox.Show("Error: Please enter a location for the appointment.");
                return;
            }

            string contact = txtAddAppointmentContact.Text;

            if(contact == "")
            {
                MessageBox.Show("Error: Please enter a contact for the appointment.");
                return;
            }

            string type = txtAddAppointmentType.Text;

            if (type == "")
            {
                MessageBox.Show("Error: Please enter a type for the appointment.");
                return;
            }

            string url = txtAddAppointmentURL.Text;

            if (url == "")
            {
                MessageBox.Show("Error: Please enter a URL for the appointment.");
                return;
            }

            DateTime start = dtpAddAppointmentStartTime.Value.ToUniversalTime();
            
            DateTime end = dtpAddAppointmentEndTime.Value.ToUniversalTime();
            

            if (start.CompareTo(end) == 1)
            {
                MessageBox.Show("Error: Start time must be before end time.");
                return;
            }
            if (start.CompareTo(end) == 0)
            {
                MessageBox.Show("Error: Start time cannot be the same as end time.");
                return;
            }

            TimeSpan openTime = new TimeSpan(13, 0, 0);
            TimeSpan closingTime = new TimeSpan(21, 0, 0);
            DayOfWeek[] businessDays = { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };

            if (start.TimeOfDay <= openTime || start.TimeOfDay >= closingTime || !businessDays.Contains(start.DayOfWeek))
            {
                MessageBox.Show("Error: Start time must be during business hours 9AM - 5PM M-F ET.");
                return;
            }

            if (end.TimeOfDay <= openTime || end.TimeOfDay >= closingTime || !businessDays.Contains(end.DayOfWeek))
            {
                MessageBox.Show("Error: End time must be during business hours 9AM - 5PM M-F ET.");
                return;
            }


            var appointmentCheckSQL = "SELECT start, end, appointmentId FROM appointment";
            var appointmentCheckCommand = new MySqlCommand(appointmentCheckSQL, DBConnection.conn);

            try
            {
                DBConnection.openConnection();

                MySqlDataReader appointmentCheckReader = appointmentCheckCommand.ExecuteReader();
                while (appointmentCheckReader.Read())
                {
                    if (start.TimeOfDay < appointmentCheckReader.GetDateTime("end").TimeOfDay && end.TimeOfDay > appointmentCheckReader.GetDateTime("start").TimeOfDay && start.DayOfWeek == appointmentCheckReader.GetDateTime("start").DayOfWeek && appointmentID != appointmentCheckReader.GetInt32("appointmentId"))
                    {
                        TimeSpan startTime = appointmentCheckReader.GetDateTime("start").ToLocalTime().TimeOfDay;
                        TimeSpan endTime = appointmentCheckReader.GetDateTime("end").ToLocalTime().TimeOfDay;
                        MessageBox.Show("Error: There is an existing appointment on this day from " + startTime + " - " + endTime + " Local Time");
                        return;
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


            DateTime createDate = DateTime.Now.ToUniversalTime();

            string createdBy = Program.currentUser;

            DateTime lastUpdate = DateTime.Now.ToUniversalTime();

            string lastUpdateBy = Program.currentUser;

            string formattedend = end.ToString("yyyy-MM-dd HH:mm:ss");
            string formattedstart = start.ToString("yyyy-MM-dd HH:mm:ss");
            string formattedcreateDate = createDate.ToString("yyyy-MM-dd HH:mm:ss");
            string formattedlastUpdate = lastUpdate.ToString("yyyy-MM-dd HH:mm:ss");

            var addAppointmentSQL = "INSERT INTO appointment (appointmentId, customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy)" +
                $"VALUES ('{appointmentID}','{customerID}','{userInfo}','{title}','{description}','{location}','{contact}','{type}','{url}','{formattedstart}','{formattedend}','{formattedcreateDate}','{createdBy}','{formattedlastUpdate}','{lastUpdateBy}')";
            var addAppointmentCommand = new MySqlCommand(addAppointmentSQL, DBConnection.conn);

            try
            {
                DBConnection.openConnection();
                addAppointmentCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBConnection.closeConnection();
                this.Close();
            }


        }
    }
}
