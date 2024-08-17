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
    public partial class form_UserDelete : Form
    {
        // Stores the username of the user to be deleted
        private string _username;

        // Create form_UserDelete
        public form_UserDelete(string username)
        {
            InitializeComponent();

            // Assigns the username to be deleted
            _username = username;
        }

        // Clicking Submit
        private void btnDeleteUserSubmit_Click(object sender, EventArgs e)
        {
            // Deletes user
            DeleteUser(_username);

            // Closes the form after deletion
            this.DialogResult = DialogResult.OK;
            this.Close();           
        }

        // Clicking Cancel
        private void btnDeleteUserCancel_Click(object sender, EventArgs e)
        {
            // Close the form without making any changes
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Deletes the user from the database
        private void DeleteUser(string username)
        {
            // Connection string to the SQL Server Database
            string connectionString = "Data Source=DESKTOP-1D8S1R9\\MSSQLSERVER01;Initial Catalog=BWUsers;Integrated Security=True;";

            // Creates a new SqlConnection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Opens connnection to the database
                    connection.Open();

                    // Creates a SqlCommand to execute DeleteUser
                    using (SqlCommand cmd = new SqlCommand("DeleteUser", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Passes the username of the user to be deleted
                        cmd.Parameters.AddWithValue("@Username", username);

                        // Executes the DeleteUser Procedure
                        cmd.ExecuteNonQuery();
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
