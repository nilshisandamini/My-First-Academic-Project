using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MRMS
{
    public partial class Customer : Form
    {
     
        SqlConnection con = new SqlConnection("Data Source=msi\\sqlexpress;Initial Catalog=mobileDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        public Customer()
        {
            InitializeComponent();
            LoadData(); 
        }

        private void LoadData()
        {
            try
            {
              
                string query = "SELECT * FROM customertable";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtnumber_TextChanged(object sender, EventArgs e) { }
        private void txtnumber_TextChanged_1(object sender, EventArgs e) { }


        private void btnsave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtcustomer.Text) || string.IsNullOrWhiteSpace(txtnumber.Text))
            {
                MessageBox.Show("Customer Name and Mobile Number are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "INSERT INTO customertable (customer_name, address, email, mobilenumber) VALUES (@name, @address, @email, @phone)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", txtcustomer.Text.Trim());
                cmd.Parameters.AddWithValue("@address", txtaddress.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtemail.Text.Trim());
                cmd.Parameters.AddWithValue("@phone", txtnumber.Text.Trim());

                if (con.State == ConnectionState.Closed) con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Customer registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                btnclear_Click(sender, e);
            }
            catch (Exception ex) { MessageBox.Show("Save Error: " + ex.Message); }
            finally { con.Close(); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtnumber.Text))
            {
                MessageBox.Show("Please select a customer from the list to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string query = @"UPDATE customertable SET customer_name=@name, address=@address, email=@email 
                                 WHERE mobilenumber=@phone";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", txtcustomer.Text.Trim());
                cmd.Parameters.AddWithValue("@address", txtaddress.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtemail.Text.Trim());
                cmd.Parameters.AddWithValue("@phone", txtnumber.Text.Trim());

                if (con.State == ConnectionState.Closed) con.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    MessageBox.Show("Customer details updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Update failed. Could not find a record with that phone number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                LoadData();
                btnclear_Click(sender, e);
            }
            catch (Exception ex) { MessageBox.Show("Update Error: " + ex.Message); }
            finally { con.Close(); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM customertable WHERE customer_name LIKE @search OR mobilenumber LIKE @search";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@search", "%" + txtsearch.Text.Trim() + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No results found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            catch (Exception ex) { MessageBox.Show("Search Error: " + ex.Message); }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtaddress.Clear();
            txtcustomer.Clear();
            txtemail.Clear();
            txtnumber.Clear();
            txtsearch.Clear();
            LoadData(); // Reload full list
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
            Dashboard db = new Dashboard();
            db.Show();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtcustomer.Text = row.Cells["customer_name"].Value?.ToString();
                txtaddress.Text = row.Cells["address"].Value?.ToString();
                txtemail.Text = row.Cells["email"].Value?.ToString();
                txtnumber.Text = row.Cells["mobilenumber"].Value?.ToString();
            }
        }
    }
}