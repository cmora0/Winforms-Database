using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BWUsers
{
    public partial class form_Login : Form
    {
        // Creates form_Login
        public form_Login()
        {
            InitializeComponent();
        }

        // Clicking Submit
        private void loginSubmitButton_Click(object sender, EventArgs e)
        {
            // Grabs user input
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            // Connection string to the SQL Server Database
            string connectionString = "Data Source=DESKTOP-1D8S1R9\\MSSQLSERVER01;Initial Catalog=BWUsers;Integrated Security=True;";

            // Creates a new SqlConnection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Opens connnection to the database
                    connection.Open();

                    // Creates a SqlCommand to execute ValidateUser
                    using (SqlCommand cmd = new SqlCommand("ValidateUser", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Adds username and password to check with cmdUser
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        // Executes ValidateUser and gets resulting int
                        int result = (int)cmd.ExecuteScalar();

                        // if successful
                        if (result == 1)
                        {
                            // Shows successful message box
                            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Hides Login form
                            this.Hide();

                            // Creates and shows Users form
                            form_Users usersForm = new form_Users();
                            usersForm.Show();
                        }
                        // if not successful
                        else
                        {
                            // Shows error message
                            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }


                }
                catch (Exception ex)
                {
                    // Handles errors                
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // When a key (Enter) is pressed while in the passwordTextBox
        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Checks if the Enter key was pressed
            if (e.KeyCode == Keys.Enter)
            {
                // Prevents the default action of the Enter key
                e.SuppressKeyPress = true;

                // Triggers Submit button
                loginSubmitButton_Click(sender, e);
            }
        }
    }
}