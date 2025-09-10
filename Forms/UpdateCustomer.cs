using Conner_Henrie_C969.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace Conner_Henrie_C969
{
    public partial class UpdateCustomer: Form
    {
        public UpdateCustomer(int custID)
        {
            InitializeComponent();

            int customerID = custID;
            int addressID = 0;
            int cityID = 0;
            int countryID = 0;
            int isActive = 1;
            string customerName = "";
            string phoneNumber = "";
            string address = "";
            string address2 = "";
            string postalCode = "";
            string cityName = "";
            string countryName = "";


            try
            {
                DBConnection.openConnection();
                var getCustomerSQL = $"SELECT * FROM customer WHERE customerId = {customerID}";
                var getCustomerCommand = new MySqlCommand(getCustomerSQL, DBConnection.conn);
                MySqlDataReader getCustomerData = getCustomerCommand.ExecuteReader();

                if (getCustomerData.Read())
                {
                    customerName = getCustomerData.GetString("customerName");
                    addressID = getCustomerData.GetInt32("addressId");
                    isActive = getCustomerData.GetInt32("active");
                }
                getCustomerData.Close();

                var getAddressSQL = $"SELECT * FROM address WHERE addressId = {addressID}";
                var getAddressCommand = new MySqlCommand(getAddressSQL, DBConnection.conn);
                MySqlDataReader getAddressData = getAddressCommand.ExecuteReader();

                if (getAddressData.Read())
                {
                    
                    address = getAddressData.GetString("address");
                    address2 = getAddressData.GetString("address2");
                    cityID = getAddressData.GetInt32("cityID");
                    postalCode = getAddressData.GetString("postalCode");
                    phoneNumber = getAddressData.GetString("phone");
                }
                getAddressData.Close();

                var getCitySQL = $"SELECT * FROM city WHERE cityId = {cityID}";
                var getCityCommand = new MySqlCommand(getCitySQL, DBConnection.conn);
                MySqlDataReader getCityData = getCityCommand.ExecuteReader();

                if (getCityData.Read())
                {
                    cityName = getCityData.GetString("city");
                    countryID = getCityData.GetInt32("countryId");
                }
                getCityData.Close();

                var getCountrySQL = $"SELECT * FROM country WHERE countryId = {countryID}";
                var getCountryCommand = new MySqlCommand(getCountrySQL, DBConnection.conn);
                MySqlDataReader getCountryData = getCountryCommand.ExecuteReader();

                if (getCountryData.Read())
                {
                    countryName = getCountryData.GetString("country");
                }
                getCountryData.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBConnection.closeConnection();
            }

            txtUpdateCustomerID.Text = customerID.ToString();
            txtUpdateCustomerName.Text = customerName;
            txtUpdateCustomerPhoneNumber.Text = phoneNumber;
            txtUpdateCustomerAddress.Text = address;
            txtUpdateCustomerAddress2.Text = address2;
            txtUpdateCustomerPostalCode.Text = postalCode;
            txtUpdateCustomerCityName.Text = cityName;
            txtUpdateCustomerCountry.Text = countryName;

            if (isActive == 1)
            {
                rbtnUpdateCustomerActive.Checked = true;
            }
            else
            {
                rbtnUpdateCustomerInactive.Checked = true;
            }
        }
        private void btnUpdateCustomerCreate_Click(object sender, EventArgs e)
        {
            int customerID = int.Parse(txtUpdateCustomerID.Text);
            int addressID = 0;
            int cityID = 0;
            int countryID = 0;
            string customerName = txtUpdateCustomerName.Text.TrimEnd();
            string phoneNumber = txtUpdateCustomerPhoneNumber.Text.TrimEnd();
            string address = txtUpdateCustomerAddress.Text.TrimEnd();
            string address2 = txtUpdateCustomerAddress2.Text.TrimEnd();
            string postalCode = txtUpdateCustomerPostalCode.Text.TrimEnd();
            string cityName = txtUpdateCustomerCityName.Text.TrimEnd();
            string countryName = txtUpdateCustomerCountry.Text.TrimEnd();

            int isActive = 1;

            if (rbtnUpdateCustomerInactive.Checked)
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

            if (address == "")
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

            try
            {
                DBConnection.openConnection();

                var getaddressIDSQL = $"SELECT addressId FROM customer WHERE customerId = {customerID}";
                var getaddressID = new MySqlCommand(getaddressIDSQL, DBConnection.conn);
                object addressData = getaddressID.ExecuteScalar();
                if (addressData != DBNull.Value)
                {
                    addressID = Convert.ToInt32(addressData);
                }

                var getcityIDSQL = $"SELECT cityId FROM address WHERE addressId = {addressID}";
                var getcityID = new MySqlCommand(getcityIDSQL, DBConnection.conn);
                object cityData = getcityID.ExecuteScalar();
                if (cityData != DBNull.Value)
                {
                    cityID = Convert.ToInt32(cityData);
                }

                var getcountryIDSQL = $"SELECT countryId FROM city WHERE cityId = {cityID}";
                var getcountryID = new MySqlCommand(getcountryIDSQL, DBConnection.conn);
                object countryData = getcountryID.ExecuteScalar();
                if (countryData != DBNull.Value)
                {
                    countryID = Convert.ToInt32(countryData);
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

            string lastUpdate = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss");
            string lastUpdateBy = Program.currentUser;



            var UpdateCountrySQL = "UPDATE country " +
                $"SET country = '{countryName}', lastUpdate = '{lastUpdate}', lastUpdateBy = '{lastUpdateBy}' " +
                $"WHERE countryId = {countryID}";
            var UpdateCountryCommand = new MySqlCommand(UpdateCountrySQL, DBConnection.conn);

            var UpdateCitySQL = "UPDATE city " +
                $"SET city = '{cityName}', lastUpdate = '{lastUpdate}', lastUpdateBy = '{lastUpdateBy}' " +
                $"WHERE cityId = {cityID}";
            var UpdateCityCommand = new MySqlCommand(UpdateCitySQL, DBConnection.conn);

            var UpdateAddressSQL = "UPDATE address " +
                $"SET address = '{address}', address2 = '{address2}', postalCode = '{postalCode}', phone = '{phoneNumber}', lastUpdate = '{lastUpdate}', lastUpdateBy = '{lastUpdateBy}' " +
                $"WHERE addressId = {addressID}";
            var UpdateAddressCommand = new MySqlCommand(UpdateAddressSQL, DBConnection.conn);

            var UpdateCustomerSQL = "UPDATE customer " +
                $"SET customerName = '{customerName}', active = {isActive}, lastUpdate = '{lastUpdate}', lastUpdateBy = '{lastUpdateBy}' " +
                $"WHERE customerId = {customerID}";
            var UpdateCustomerCommand = new MySqlCommand(UpdateCustomerSQL, DBConnection.conn);

            try
            {
                DBConnection.openConnection();

                UpdateCountryCommand.ExecuteNonQuery();
                UpdateCityCommand.ExecuteNonQuery();
                UpdateAddressCommand.ExecuteNonQuery();
                UpdateCustomerCommand.ExecuteNonQuery();
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

        private void btnUpdateCustomerCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
