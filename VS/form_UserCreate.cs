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
    public partial class form_UserCreate : Form
    {

        // Creates form_UserCreate
        public form_UserCreate()
        {
            InitializeComponent();
        }

        // Clicking Cancel
        private void btnCancelNewUser_Click(object sender, EventArgs e)
        {
            // Closes the form
            this.Close();
        }

        // Clicking Submit
        private void btnSubmitNewUser_Click(object sender, EventArgs e)
        {
            // Gets the new user information
            string username = createUsernameTextBox.Text;
            string password = createPasswordTextBox.Text;
            string firstName = createFirstNameTextBox.Text;
            string lastName = createLastNameTextBox.Text;
            string phoneNumber = createPhoneNumberTextBox.Text;
            string emailAddress = createEmailAddressTextBox.Text;

            // Connection string to the SQL Server Database
            string connectionString = "Data Source=DESKTOP-1D8S1R9\\MSSQLSERVER01;Initial Catalog=BWUsers;Integrated Security=True;";

            // Creates a new SqlConnection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Opens connection to the database
                    connection.Open();

                    // Creates a SqlCommand to execute CreateNewUser
                    using (SqlCommand cmd = new SqlCommand("CreateNewUser", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Adds parameters to create new user info
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        cmd.Parameters.AddWithValue("@EmailAddress", emailAddress);

                        // Executes the CreateNewUser Procedure
                        cmd.ExecuteNonQuery();

                        // Shows a success message
                        MessageBox.Show("User created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
    }
}
