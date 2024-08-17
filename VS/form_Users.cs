using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BWUsers
{
    public partial class form_Users : Form
    {
        // Creates form_Users
        public form_Users()
        {
            InitializeComponent();

            // Attaches the CellClick event handler to the DataGridView
            dataGridViewUsers.CellClick += new DataGridViewCellEventHandler(dataGridViewUsers_CellClick);
        }

        // Loads in Users table
        private void form_Users_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        // Loads in Users table
        private void LoadUsers()
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

                    // Creates a SqlCommand to execute GetUsers
                    using (SqlCommand cmd = new SqlCommand("GetUsers", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Uses a SqlDataAdapter to fill a DataTable with the result of GetUSers
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Bind the DataTable to DataGridViewUsers
                        dataGridViewUsers.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    // Handles errors  
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Clicking Create New User
        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            // Creates and opens Create New User form
            form_UserCreate userCreateForm = new form_UserCreate();
            userCreateForm.ShowDialog();

            // Refreshes the DataGridView after creating a new user
            LoadUsers();
        }

        // Clicking Edit USer
        private void btnEditUser_Click(object sender, EventArgs e)
        {
            // if one row is selected
            if (dataGridViewUsers.SelectedRows.Count == 1)
            {
                // Gets the selected user's data from the DataGridView
                string username = dataGridViewUsers.SelectedRows[0].Cells["Username"].Value.ToString();
                string password = dataGridViewUsers.SelectedRows[0].Cells["Password"].Value.ToString();
                string firstName = dataGridViewUsers.SelectedRows[0].Cells["FirstName"].Value.ToString();
                string lastName = dataGridViewUsers.SelectedRows[0].Cells["LastName"].Value.ToString();
                string phoneNumber = dataGridViewUsers.SelectedRows[0].Cells["PhoneNumber"].Value.ToString();
                string emailAddress = dataGridViewUsers.SelectedRows[0].Cells["EmailAddress"].Value.ToString();

                // Creates an instance of form_UserEdit and pass the user data
                form_UserEdit editForm = new form_UserEdit
                {
                    Username = username,
                    Password = password,
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    EmailAddress = emailAddress
                };

                // Shows the edit form as a dialog
                editForm.ShowDialog();
            }
            // if no rows are selected
            else if (dataGridViewUsers.SelectedRows.Count < 1)
            {
                MessageBox.Show("Please select a user to edit.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // if multiple rows are selected
            else
            {
                MessageBox.Show("Please select only one user to edit.", "Multiple Users Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Refreshes the DataGridView after creating a new user
            LoadUsers();
        }

        private void dataGridViewUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Checks if the cell is in a valid row
            if (e.RowIndex >= 0)
            {
                // Highlights the entire row
                dataGridViewUsers.ClearSelection();
                dataGridViewUsers.Rows[e.RowIndex].Selected = true;
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            // if one row is selected
            if (dataGridViewUsers.SelectedRows.Count == 1)
            {
                // Gets the selected row's data
                DataGridViewRow selectedRow = dataGridViewUsers.SelectedRows[0];
                string username = selectedRow.Cells["Username"].Value.ToString();

                // Creates an instance of form_UserDelete and passes the username
                form_UserDelete deleteForm = new form_UserDelete(username);

                // Shows the delete form as a dialog and check the result
                if (deleteForm.ShowDialog() == DialogResult.OK)
                {
                    // Refresh the DataGridView to reflect changes
                    LoadUsers();
                }
            }
            // if no rows are selected
            else if (dataGridViewUsers.SelectedRows.Count < 1)
            {
                MessageBox.Show("Please select a user to delete.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // if multiple rows are selected
            else
            {
                MessageBox.Show("Please select only one user to delete.", "Multiple Users Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    
        // Form closes
        private void form_Users_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Closes the application
            Application.Exit();
        }
    }
}
