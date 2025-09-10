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
    public partial class UpdateAppointment : Form
    {

        public UpdateAppointment(int apptID)
        {
            InitializeComponent();

            int appointmentID = 0;
            int customerID = 0;
            int userID = 0;
            string title = "";
            string description = "";
            string location = "";
            string contact = "";
            string type = "";
            string url = "";
            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;       

            try
            {
                DBConnection.openConnection();



                string initialSQL = "SELECT * FROM appointment WHERE appointmentID = " + apptID;
                var getinitialSQL = new MySqlCommand(initialSQL, DBConnection.conn);
                MySqlDataReader initialData = getinitialSQL.ExecuteReader();

                if (initialData.Read())
                {
                    appointmentID = initialData.GetInt32("appointmentId");
                    customerID = initialData.GetInt32("customerId");
                    userID = initialData.GetInt32("userId");
                    title = initialData.GetString("title");
                    description = initialData.GetString("description");
                    location = initialData.GetString("location");
                    contact = initialData.GetString("contact");
                    type = initialData.GetString("type");
                    url = initialData.GetString("url");
                    start = initialData.GetDateTime("start").ToLocalTime();
                    end = initialData.GetDateTime("end").ToLocalTime();
                }
                initialData.Close();

                var getCustomerIDSQL = "SELECT * FROM customer";
                var getCustomerID = new MySqlCommand(getCustomerIDSQL, DBConnection.conn);
                MySqlDataReader getcustomerdata = getCustomerID.ExecuteReader();
                while (getcustomerdata.Read())
                {
                    int id = getcustomerdata.GetInt32("customerId");

                    string name = getcustomerdata.GetString("customerName");
                    cmbUpdateAppointmentCustomerID.Items.Add(id + ". " + name);
                    if (id == customerID)
                    {
                        cmbUpdateAppointmentCustomerID.SelectedIndex = cmbUpdateAppointmentCustomerID.Items.Count - 1;
                    }
                }
                getcustomerdata.Close();

                var getUserIDSQL = "SELECT * FROM user";
                var getUserID = new MySqlCommand(getUserIDSQL, DBConnection.conn);
                MySqlDataReader getUserData = getUserID.ExecuteReader();
                while (getUserData.Read())
                {
                    int id = getUserData.GetInt32("userId");
                    string name = getUserData.GetString("userName");
                    cmbUpdateAppointmentUserID.Items.Add(id + ". " + name);

                    if (id == userID)
                    {
                        cmbUpdateAppointmentUserID.SelectedIndex = cmbUpdateAppointmentUserID.Items.Count - 1;
                    }
                }
                getUserData.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBConnection.closeConnection();
            }

            txtUpdateAppointmentID.Text = appointmentID.ToString();
            txtUpdateAppointmentTitle.Text = title;
            txtUpdateAppointmentDescription.Text = description;
            txtUpdateAppointmentLocation.Text = location;
            txtUpdateAppointmentContact.Text = contact;
            txtUpdateAppointmentType.Text = type;
            txtUpdateAppointmentURL.Text = url;
            dtpUpdateAppointmentStartTime.Value = start;
            dtpUpdateAppointmentEndTime.Value = end;
        }

        private void btnUpdateAppointmentCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdateAppointmentUpdate_Click(object sender, EventArgs e)
        {
            int appointmentID = int.Parse(txtUpdateAppointmentID.Text);

            string customerID = cmbUpdateAppointmentCustomerID.Text;
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

            string userInfo = cmbUpdateAppointmentUserID.Text;
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

            string title = txtUpdateAppointmentTitle.Text;

            if (title == "")
            {
                MessageBox.Show("Error: Please select a title for the appointment.");
                return;
            }

            string description = txtUpdateAppointmentDescription.Text;

            if (description == "")
            {
                MessageBox.Show("Error: Please enter a description for the appointment.");
                return;
            }

            string location = txtUpdateAppointmentLocation.Text;

            if (location == "")
            {
                MessageBox.Show("Error: Please enter a location for the appointment.");
                return;
            }

            string contact = txtUpdateAppointmentContact.Text;

            if (contact == "")
            {
                MessageBox.Show("Error: Please enter a contact for the appointment.");
                return;
            }

            string type = txtUpdateAppointmentType.Text;

            if (type == "")
            {
                MessageBox.Show("Error: Please enter a type for the appointment.");
                return;
            }

            string url = txtUpdateAppointmentURL.Text;

            if (url == "")
            {
                MessageBox.Show("Error: Please enter a URL for the appointment.");
                return;
            }

            DateTime start = dtpUpdateAppointmentStartTime.Value.ToUniversalTime();
            DateTime end = dtpUpdateAppointmentEndTime.Value.ToUniversalTime();

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
                        MessageBox.Show("Error: There is an existing appointment on this day from " + startTime + " - " + endTime +" Local Time");
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



            DateTime lastUpdate = DateTime.Now.ToUniversalTime();
            string lastUpdateBy = Program.currentUser;

            string formattedend = end.ToString("yyyy-MM-dd HH:mm:ss");
            string formattedstart = start.ToString("yyyy-MM-dd HH:mm:ss");
            string formattedlastUpdate = lastUpdate.ToString("yyyy-MM-dd HH:mm:ss");

            var UpdateAppointmentSQL = "UPDATE appointment " +
                $"SET customerId = {customerID}, userId = {userInfo}, title = '{title}', description = '{description}', location = '{location}', contact = '{contact}', type = '{type}', url = '{url}', start = '{formattedstart}', end = '{formattedend}', lastUpdate = '{formattedlastUpdate}', lastUpdateBy = '{lastUpdateBy}'" +
                $"WHERE appointmentId = {appointmentID}";

            var UpdateAppointmentCommand = new MySqlCommand(UpdateAppointmentSQL, DBConnection.conn);

            try
            {
                DBConnection.openConnection();
                UpdateAppointmentCommand.ExecuteNonQuery();
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