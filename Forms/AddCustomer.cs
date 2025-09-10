using Conner_Henrie_C969.Database;
using MySql.Data.MySqlClient;
using System;
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
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();

            int customerID = 0;
            try
            {
                DBConnection.openConnection();

                var getNextIDSQL = "SELECT MAX(customerId) FROM customer";
                var getNextID = new MySqlCommand(getNextIDSQL, DBConnection.conn);
                object data = getNextID.ExecuteScalar();
                if (data != DBNull.Value)
                {
                    customerID = Convert.ToInt32(data) + 1;
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

            txtAddCustomerID.Text = customerID.ToString();

        }
        private void btnAddCustomerCreate_Click(object sender, EventArgs e)
        {
            int customerID = int.Parse(txtAddCustomerID.Text);
            string customerName = txtAddCustomerName.Text.TrimEnd();
            string phoneNumber = txtAddCustomerPhoneNumber.Text.TrimEnd();
            string address = txtAddCustomerAddress.Text.TrimEnd();
            string address2 = txtAddCustomerAddress2.Text.TrimEnd();
            string postalCode = txtAddCustomerPostalCode.Text.TrimEnd();
            string cityName = txtAddCustomerCityName.Text.TrimEnd();
            string countryName = txtAddCustomerCountry.Text.TrimEnd();

            int isActive = 1;
            if (rbtnAddCustomerInactive.Checked)
            {
                isActive = 0;
            }

            if (customerName == "")
            {
                MessageBox.Show("Please enter a customer name");
                return;
            }

            if (phoneNumber == "")
            {
                MessageBox.Show("Please enter a phone number");
                return;
            }

            foreach (char c in phoneNumber)
            {
                if (c != '-' && !char.IsDigit(c))
                {
                    MessageBox.Show("Please ensure phone number is only numbers and '-'");
                    return;
                }              
            }

            if(address == "")
            {
                MessageBox.Show("Please enter an address");
                return;
            }

            if (postalCode == "")
            {
                MessageBox.Show("Please enter a postal code");
                return;
            }

            if (cityName == "")
            {
                MessageBox.Show("Please enter a city");
                return;
            }

            if (countryName == "")
            {
                MessageBox.Show("Please enter a country");
                return;
            }


            int addressID = 0;
            int cityID = 0;
            int countryID = 0;
            try
            {
                DBConnection.openConnection();

                var getaddressIDSQL = "SELECT MAX(addressId) FROM address";
                var getaddressID = new MySqlCommand(getaddressIDSQL, DBConnection.conn);
                object addressdata = getaddressID.ExecuteScalar();
                if (addressdata != DBNull.Value)
                {
                    addressID = Convert.ToInt32(addressdata) + 1;
                }

                var getcityIDSQL = "SELECT MAX(cityId) FROM city";
                var getcityID = new MySqlCommand(getcityIDSQL, DBConnection.conn);
                object citydata = getcityID.ExecuteScalar();
                if (citydata != DBNull.Value)
                {
                    cityID = Convert.ToInt32(citydata) + 1;
                }

                var getcountryIDSQL = "SELECT MAX(countryId) FROM country";
                var getcountryID = new MySqlCommand(getcountryIDSQL, DBConnection.conn);
                object countrydata = getcountryID.ExecuteScalar();
                if (countrydata != DBNull.Value)
                {
                    countryID = Convert.ToInt32(countrydata) + 1;
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

            string createDate = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss");
            string createdBy = Program.currentUser;
            string lastUpdate = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss");
            string updatedBy = Program.currentUser;

            var addCountrySQL = "INSERT INTO country (countryId, country, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                $"VALUES ({countryID}, '{countryName}', '{createDate}', '{createdBy}','{lastUpdate}','{updatedBy}')";
            var addCountryCommand = new MySqlCommand(addCountrySQL, DBConnection.conn);

            var addCitySQL = "INSERT INTO city (cityId, city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                $"VALUES ({cityID}, '{cityName}', {countryID}, '{createDate}', '{createdBy}','{lastUpdate}','{updatedBy}') ";
            var addCityCommand = new MySqlCommand(addCitySQL, DBConnection.conn);

            var addAddressSQL = "INSERT INTO address (addressId, address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                $"VALUES ({addressID}, '{address}', '{address2}', {cityID}, '{postalCode}', '{phoneNumber}','{createDate}', '{createdBy}','{lastUpdate}','{updatedBy}') ";
            var addAddressCommand = new MySqlCommand(addAddressSQL, DBConnection.conn);

            var addCustomerSQL = "INSERT INTO customer (customerId, customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) "+
                $"VALUES ({customerID}, '{customerName}', {addressID}, {isActive}, '{createDate}', '{createdBy}','{lastUpdate}','{updatedBy}')";
            var addCustomerCommand = new MySqlCommand(addCustomerSQL, DBConnection.conn);

            try
            {
                DBConnection.openConnection();
 
                addCountryCommand.ExecuteNonQuery();
                addCityCommand.ExecuteNonQuery();
                addAddressCommand.ExecuteNonQuery();
                addCustomerCommand.ExecuteNonQuery();

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

        private void btnAddCustomerCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
