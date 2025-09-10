using Conner_Henrie_C969.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conner_Henrie_C969
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            LoadData();

            string appointmentCheckSQL = $"SELECT * FROM appointment WHERE userId = {Program.currentUserID}";
            var appointmentCheckCommand = new MySqlCommand(appointmentCheckSQL, DBConnection.conn);

            bool hasAppointment = false;
            TimeSpan startTime = TimeSpan.Zero;
            TimeSpan endTime = TimeSpan.Zero;
            string title = "";

            try
            {
                DBConnection.openConnection();

                MySqlDataReader appointmentCheckReader = appointmentCheckCommand.ExecuteReader();

                while (appointmentCheckReader.Read())
                {

                    if (appointmentCheckReader.GetDateTime("start").Month == DateTime.Now.ToUniversalTime().Month && appointmentCheckReader.GetDateTime("start").Year == DateTime.Now.ToUniversalTime().Year)
                    {
                        if (appointmentCheckReader.GetDateTime("start").TimeOfDay >= DateTime.Now.ToUniversalTime().TimeOfDay &&
                        (appointmentCheckReader.GetDateTime("start").TimeOfDay - TimeSpan.FromMinutes(15)) <= DateTime.Now.ToUniversalTime().TimeOfDay ||
                        appointmentCheckReader.GetDateTime("start").TimeOfDay <= DateTime.Now.ToUniversalTime().TimeOfDay &&
                        appointmentCheckReader.GetDateTime("end").TimeOfDay >= DateTime.Now.ToUniversalTime().TimeOfDay)
                        {
                            hasAppointment = true;
                            startTime = appointmentCheckReader.GetDateTime("start").ToLocalTime().TimeOfDay;
                            endTime = appointmentCheckReader.GetDateTime("end").ToLocalTime().TimeOfDay;
                            title = appointmentCheckReader.GetString("title");
                        }
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

            if (hasAppointment && Program.currentLocale == "en")
            {
                MessageBox.Show("You have an upcoming appointment " + title + " from " + startTime + " - " + endTime + " Local Time");
            }
            if (hasAppointment && Program.currentLocale == "de")
            {
                MessageBox.Show("Sie haben einen bevorstehenden Termin " + title + " aus " + startTime + " - " + endTime + " Ortszeit");
            }




        }

        private void LoadData()
        {
            string appointmentsql = "SELECT * FROM  appointment";
            var appointmentdataadapter = new MySqlDataAdapter(appointmentsql, DBConnection.conn);
            DataTable appointmentdt = new DataTable();
            appointmentdataadapter.Fill(appointmentdt);
            foreach (DataRow row in appointmentdt.Rows)
            {
                DateTime start = Convert.ToDateTime(row[9]).ToLocalTime();
                row[9] = start;

                DateTime end = Convert.ToDateTime(row[10]).ToLocalTime();
                row[10] = end;

                DateTime create = Convert.ToDateTime(row[11]).ToLocalTime();
                row[11] = create;

                DateTime last = Convert.ToDateTime(row[13]).ToLocalTime();
                row[13] = last;

            }

            if (rbtnMainAppointmentsMonth.Checked)
            {
                DateTime month = mcMain.SelectionStart;

                foreach (DataRow row in appointmentdt.Rows)
                {

                    if (Convert.ToDateTime(row[9]).ToLocalTime().Month != month.Month)
                    {
                        row.Delete();
                    }
                }
                appointmentdt.AcceptChanges();

            }

            if (rbtnMainAppointmentsDay.Checked)
            {
                DateTime day = mcMain.SelectionStart;

                foreach (DataRow row in appointmentdt.Rows)
                {

                    if (Convert.ToDateTime(row[9]).ToLocalTime().Date != day.Date)
                    {
                        row.Delete();
                    }
                }
                appointmentdt.AcceptChanges();
            }


            dgvAppointments.DataSource = appointmentdt;
            dgvAppointments.Columns["appointmentID"].HeaderText = "Appointment ID";
            dgvAppointments.Columns["customerID"].HeaderText = "Customer ID";
            dgvAppointments.Columns["userID"].HeaderText = "User ID";
            dgvAppointments.Columns["title"].HeaderText = "Title";
            dgvAppointments.Columns["description"].HeaderText = "Description";
            dgvAppointments.Columns["location"].HeaderText = "Location";
            dgvAppointments.Columns["contact"].HeaderText = "Contact";
            dgvAppointments.Columns["type"].HeaderText = "Type";
            dgvAppointments.Columns["url"].HeaderText = "URL";
            dgvAppointments.Columns["start"].HeaderText = "Start Date";
            dgvAppointments.Columns["end"].HeaderText = "End Date";
            dgvAppointments.Columns["createDate"].HeaderText = "Create Date";
            dgvAppointments.Columns["createdBy"].HeaderText = "Created By";
            dgvAppointments.Columns["lastUpdate"].HeaderText = "Last Update";
            dgvAppointments.Columns["LastUpdateBy"].HeaderText = "Last Update By";

            var customersql = "SELECT * FROM customer";
            var customerdataadapter = new MySqlDataAdapter(customersql, DBConnection.conn);
            DataTable customerdt = new DataTable();
            customerdataadapter.Fill(customerdt);
            foreach (DataRow row in customerdt.Rows)
            {
                DateTime create = Convert.ToDateTime(row[4]).ToLocalTime();
                row[4] = create;

                DateTime last = Convert.ToDateTime(row[6]).ToLocalTime();
                row[6] = last;
            }
            dgvCustomers.DataSource = customerdt;
            dgvCustomers.Columns["customerId"].HeaderText = "Customer ID";
            dgvCustomers.Columns["customerName"].HeaderText = "Customer Name";
            dgvCustomers.Columns["addressID"].HeaderText = "Address ID";
            dgvCustomers.Columns["active"].HeaderText = "Active";
            dgvCustomers.Columns["createDate"].HeaderText = "Create Date";
            dgvCustomers.Columns["createdBy"].HeaderText = "Created By";
            dgvCustomers.Columns["lastUpdate"].HeaderText = "Last Update";
            dgvCustomers.Columns["LastUpdateBy"].HeaderText = "Last Update By";
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnMainReporting_Click(object sender, EventArgs e)
        {
            new Reports().ShowDialog();
        }

        private void btnMainLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().ShowDialog();
            
        }

        private void btnMainAppointmentAdd_Click(object sender, EventArgs e)
        {
            AddAppointment addAppointment = new AddAppointment();
            addAppointment.FormClosed += AddAppointment_FormClosed;
            addAppointment.ShowDialog();
        }

        private void btnMainAppointmentUpdate_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentCell == null)
            {
                MessageBox.Show("Please select an appointment");
                return;
            }
            int apptID = int.Parse(dgvAppointments.CurrentRow.Cells[0].Value.ToString());
            UpdateAppointment updateAppointment = new UpdateAppointment(apptID);
            updateAppointment.FormClosed += UpdateAppointment_FormClosed;
            updateAppointment.ShowDialog();
        }

        private void btnMainAppointmentDelete_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentCell == null)
            {
                MessageBox.Show("Please select an appointment");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete "+ dgvAppointments.CurrentRow.Cells[3].Value.ToString(), "Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.No)
            {
                return;
            }



            int appointmentID = int.Parse(dgvAppointments.CurrentRow.Cells[0].Value.ToString());
            string appointmentDeleteSQL = "DELETE FROM appointment WHERE appointmentID = " + appointmentID;
            var appointmentDeleteCommand = new MySqlCommand(appointmentDeleteSQL, DBConnection.conn);

            try
            {
                DBConnection.openConnection();
                appointmentDeleteCommand.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBConnection.closeConnection();
                LoadData();
            }
        }

        private void AddAppointment_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadData();
        }

        private void UpdateAppointment_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadData();
        }

        private void btnMainCustomersAdd_Click(object sender, EventArgs e)
        {
            AddCustomer addCustomer = new AddCustomer();
            addCustomer.FormClosed += AddCustomer_FormClosed;
            addCustomer.ShowDialog();
        }

        private void btnMainCustomersUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentCell == null)
            {
                MessageBox.Show("Please select a Customer");
                return;
            }
            int custID = int.Parse(dgvCustomers.CurrentRow.Cells[0].Value.ToString());
            UpdateCustomer updateCustomer = new UpdateCustomer(custID);
            updateCustomer.FormClosed += UpdateCustomer_FormClosed;
            updateCustomer.ShowDialog();
        }

        private void btnMainCustomersDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentCell == null)
            {
                MessageBox.Show("Please select a Customer");
                return;
            }

            int customerID = int.Parse(dgvCustomers.CurrentRow.Cells[0].Value.ToString());

            string appointmentCheck = "";
            string appointmentCheckSQL = "SELECT appointmentID, title FROM appointment WHERE customerId = " + customerID;
            var appointmentCheckCommand = new MySqlCommand(appointmentCheckSQL, DBConnection.conn);

            try
            {
                DBConnection.openConnection();
                MySqlDataReader appointmentCheckData = appointmentCheckCommand.ExecuteReader();

                while (appointmentCheckData.Read())
                {
                    appointmentCheck += "ID: " + appointmentCheckData.GetInt32("appointmentId").ToString() + " Title: " + appointmentCheckData.GetString("title") + "\n";
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

            if (appointmentCheck != "")
            {
                MessageBox.Show("Error: Customer is associated with appointments, please remove association or delete appoinments before deleting customer. \n" + "Associated appointments: \n" + appointmentCheck);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete " + dgvCustomers.CurrentRow.Cells[1].Value.ToString(), "Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.No)
            {
                return;
            }



            string customerDeleteSQL = "DELETE FROM customer WHERE customerID = " + customerID;
            var customerDeleteCommand = new MySqlCommand(customerDeleteSQL, DBConnection.conn);

            try
            {
                DBConnection.openConnection();
                customerDeleteCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBConnection.closeConnection();
                LoadData();
            }
        }

        private void AddCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadData();
        }

        private void UpdateCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadData();
        }

        private void dgvAppointments_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvAppointments.ClearSelection();
            dgvAppointments.CurrentCell = null;
            dgvAppointments.Update();
        }

        private void dgvCustomers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvCustomers.ClearSelection();
            dgvCustomers.CurrentCell = null;
            dgvCustomers.Update();
        }


        private void rbtnMainAppointmentsAll_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        private void rbtnMainAppointmentsMonth_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        
        private void rbtnMainAppointmentsDay_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }


        private void mcMain_DateSelected(object sender, DateRangeEventArgs e)
        {
            Console.WriteLine("Date selected");
            LoadData();
        }
    }
}
