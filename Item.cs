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
    public partial class Item : Form
    {
        SqlConnection con = new SqlConnection("Data Source=msi\\sqlexpress;Initial Catalog=mobileDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        public Item()
        {
            InitializeComponent();
            LoadData(); 
        }

        private void Item_Load(object sender, EventArgs e)
        {
            cmbbrand.Items.AddRange(new string[] { "Apple", "Samsung", "Huawei", "Redmi", "RealMe", "HTC", "Nokia", "Vivo" });
        }

        private void LoadData()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM itemtable", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtdevicename.Text) || string.IsNullOrWhiteSpace(txtpartnum.Text))
            {
                MessageBox.Show("Please fill in Device Name and Part Number.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"INSERT INTO [dbo].[itemtable] ([device_name],[part_number],[part_name],[brand],[qty],[unit_cost],[total_cost],[sell_price])
                             VALUES (@device_name,@part_number,@part_name,@brand,@qty,@unit_cost,@total_cost,@sell_price)";

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@device_name", txtdevicename.Text);
                cmd.Parameters.AddWithValue("@part_number", txtpartnum.Text);
                cmd.Parameters.AddWithValue("@part_name", txtpname.Text);
                cmd.Parameters.AddWithValue("@brand", cmbbrand.Text);
                cmd.Parameters.AddWithValue("@qty", txtqty.Text);
                cmd.Parameters.AddWithValue("@unit_cost", txtunitcost.Text);
                cmd.Parameters.AddWithValue("@total_cost", txttotalcost.Text);
                cmd.Parameters.AddWithValue("@sell_price", txtsellprice.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Item saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); 
                btnclear_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Error: " + ex.Message);
            }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"UPDATE itemtable 
                                 SET device_name=@device_name, part_name=@part_name, brand=@brand, 
                                     qty=@qty, unit_cost=@unit_cost, total_cost=@total_cost, sell_price=@sell_price 
                                 WHERE part_number=@part_number";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@device_name", txtdevicename.Text);
                cmd.Parameters.AddWithValue("@part_name", txtpname.Text);
                cmd.Parameters.AddWithValue("@part_number", txtpartnum.Text);
                cmd.Parameters.AddWithValue("@brand", cmbbrand.Text);
                cmd.Parameters.AddWithValue("@qty", txtqty.Text);
                cmd.Parameters.AddWithValue("@unit_cost", txtunitcost.Text);
                cmd.Parameters.AddWithValue("@total_cost", txttotalcost.Text);
                cmd.Parameters.AddWithValue("@sell_price", txtsellprice.Text);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                con.Close();

                if (rows > 0)
                {
                    MessageBox.Show("Item updated successfully!");
                    LoadData();
                    btnclear_Click(sender, e);
                }
                else { MessageBox.Show("No record found with this Part Number."); }
            }
            catch (Exception ex) { MessageBox.Show("Update Error: " + ex.Message); }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM itemtable WHERE device_name LIKE @search OR part_number LIKE @search";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex) { MessageBox.Show("Search Error: " + ex.Message); }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtdevicename.Text = row.Cells["device_name"].Value.ToString();
                txtpartnum.Text = row.Cells["part_number"].Value.ToString();
                txtpname.Text = row.Cells["part_name"].Value.ToString();
                cmbbrand.Text = row.Cells["brand"].Value.ToString();
                txtqty.Text = row.Cells["qty"].Value.ToString();
                txtunitcost.Text = row.Cells["unit_cost"].Value.ToString();
                txttotalcost.Text = row.Cells["total_cost"].Value.ToString();
                txtsellprice.Text = row.Cells["sell_price"].Value.ToString();
            }
        }
        private void btnclear_Click(object sender, EventArgs e)
        {
            txtdevicename.Clear();
            txtpartnum.Clear();
            txtpname.Clear();
            txtqty.Clear();
            txtunitcost.Clear();
            txttotalcost.Clear();
            txtsellprice.Clear();
            txtSearch.Clear();
            cmbbrand.SelectedIndex = -1; 
            LoadData(); 
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
            new Dashboard().Show();
        }

        private void txtqty_TextChanged(object sender, EventArgs e) { CalculateTotalCost(); }
        private void txtunitcost_TextChanged(object sender, EventArgs e) { CalculateTotalCost(); }

        private void CalculateTotalCost()
        {
            if (double.TryParse(txtqty.Text, out double quantity) && double.TryParse(txtunitcost.Text, out double unitCost))
            {
                txttotalcost.Text = (quantity * unitCost).ToString("0.00");
            }
            else { txttotalcost.Text = ""; }
        }
    }
}
