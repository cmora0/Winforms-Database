using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BWUsers
{
    public partial class form_UserEdit : Form
    {
        // Sets up parameters to get and set
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        // Creates form_UserEdit
        public form_UserEdit()
        {
            InitializeComponent();
        }

        // When loading form_UserEdit
        private void form_UserEdit_Load(object sender, EventArgs e)
        {
            // Pre-populates the textboxes with the user's info
            editUsernameTextBox.Text = Username;
            editPasswordTextBox.Text = Password;
            editFirstNameTextBox.Text = FirstName;
            editLastNameTextBox.Text = LastName;
            editPhoneNumberTextBox.Text = PhoneNumber;
            editEmailAddressTextBox.Text = EmailAddress;
        }

        // Clicking Submit
        private void btnSubmitNewUser_Click(object sender, EventArgs e)
        {
            // Gets the updated values from the TextBoxes
            string updatedUsername = editUsernameTextBox.Text;
            string updatedPassword = editPasswordTextBox.Text;
            string updatedFirstName = editFirstNameTextBox.Text;
            string updatedLastName = editLastNameTextBox.Text;
            string updatedPhoneNumber = editPhoneNumberTextBox.Text;
            string updatedEmailAddress = editEmailAddressTextBox.Text;

            // Connection string to the SQL Server Database
            string connectionString = "Data Source=DESKTOP-1D8S1R9\\MSSQLSERVER01;Initial Catalog=BWUsers;Integrated Security=True;";

            // Creates a new SqlConnection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Opens connnection to the database
                    connection.Open();

                    // Creates a SqlCommand to execute UpdateUser
                    using (SqlCommand cmd = new SqlCommand("UpdateUser", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Passes parameters to UpdateUser Procedure
                        cmd.Parameters.AddWithValue("@Username", updatedUsername);
                        cmd.Parameters.AddWithValue("@Password", updatedPassword);
                        cmd.Parameters.AddWithValue("@FirstName", updatedFirstName);
                        cmd.Parameters.AddWithValue("@LastName", updatedLastName);
                        cmd.Parameters.AddWithValue("@PhoneNumber", updatedPhoneNumber);
                        cmd.Parameters.AddWithValue("@EmailAddress", updatedEmailAddress);

                        // Executes the UpdateUser Procedure
                        cmd.ExecuteNonQuery();

                        // Shows a success message
                        MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Closes the form
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    // Handles errors
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
         
        // Clicking Cancel
        private void btnCancelNewUser_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
