using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MRMS
{
    public partial class Device : Form
    {
        
        SqlConnection con = new SqlConnection("Data Source=msi\\sqlexpress;Initial Catalog=mobileDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        public Device()
        {
            InitializeComponent();
            LoadData(); 
        }

        private void Device_Load(object sender, EventArgs e)
        {
            
            cmbbrand.Items.AddRange(new string[] { "Apple", "Samsung", "Huawei", "Redmi", "RealMe", "HTC", "Nokia", "Vivo" });
            cmbproblem.Items.AddRange(new string[] { "Touch Screen Cracked", "Tempered Glass Cracked", "Charging Pin Replacement" });

            LoadCustomerList();
        }

        private void LoadCustomerList()
        {
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();
                SqlCommand cmmn = new SqlCommand("SELECT customer_name FROM customertable", con);
                SqlDataReader rd = cmmn.ExecuteReader();
                cmbcustomer.Items.Clear(); 
                while (rd.Read())
                {
                    cmbcustomer.Items.Add(rd["customer_name"].ToString());
                }
                rd.Close();
            }
            catch (Exception ex) { MessageBox.Show("Error loading customers: " + ex.Message); }
            finally { con.Close(); }
        }

        private void LoadData()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM devicetable", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex) { MessageBox.Show("Error loading data: " + ex.Message); }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtdevice.Text) || string.IsNullOrWhiteSpace(txtimei.Text))
            {
                MessageBox.Show("Please fill in Device Name and IMEI.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"INSERT INTO [dbo].[devicetable] ([brand],[imei_number],[device_name],[problem_status])
                                VALUES (@brand,@imei,@name,@status)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@brand", cmbbrand.Text);
                cmd.Parameters.AddWithValue("@imei", txtimei.Text.Trim());
                cmd.Parameters.AddWithValue("@name", txtdevice.Text.Trim());
                cmd.Parameters.AddWithValue("@status", cmbproblem.Text);

                if (con.State == ConnectionState.Closed) con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Device recorded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                btnclear_Click(sender, e);
            }
            catch (Exception ex) { MessageBox.Show("Save Error: " + ex.Message); }
            finally { con.Close(); }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtimei.Text))
            {
                MessageBox.Show("Select a device from the list to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string query = @"UPDATE devicetable SET brand=@brand, device_name=@name, problem_status=@status 
                                 WHERE imei_number=@imei";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@brand", cmbbrand.Text);
                cmd.Parameters.AddWithValue("@name", txtdevice.Text.Trim());
                cmd.Parameters.AddWithValue("@status", cmbproblem.Text);
                cmd.Parameters.AddWithValue("@imei", txtimei.Text.Trim());

                if (con.State == ConnectionState.Closed) con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Device updated successfully.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    btnclear_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Record not found. Ensure IMEI is correct.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) { MessageBox.Show("Update Error: " + ex.Message); }
            finally { con.Close(); }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
              
                dataGridView1.DataSource = null;

        
                if (con.State == ConnectionState.Closed) con.Open();

           
                string query = "SELECT * FROM devicetable WHERE device_name LIKE @search OR imei_number LIKE @search";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                   
                    cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text.Trim() + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("No devices found matching your search.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
               
                cmbbrand.Text = row.Cells["brand"].Value?.ToString();
                txtimei.Text = row.Cells["imei_number"].Value?.ToString();
                txtdevice.Text = row.Cells["device_name"].Value?.ToString();
                cmbproblem.Text = row.Cells["problem_status"].Value?.ToString();
            }
        }

     
        private void btnclear_Click(object sender, EventArgs e)
        {
            txtdevice.Clear();
            txtimei.Clear();
            txtSearch.Clear();
            cmbbrand.SelectedIndex = -1;
            cmbproblem.SelectedIndex = -1;
            cmbcustomer.SelectedIndex = -1;
            LoadData(); 
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
            new Dashboard().Show();
        }
    }
}
