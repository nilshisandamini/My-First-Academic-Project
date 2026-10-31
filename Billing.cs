using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace MRMS
{
    public partial class Billing : Form
    {
        
        SqlConnection con = new SqlConnection("Data Source=msi\\sqlexpress;Initial Catalog=mobileDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

      
        DataTable cartTable = new DataTable();

        public Billing()
        {
            InitializeComponent();
            SetupCart();
        }

        private void SetupCart()
        {
           
            if (cartTable.Columns.Count == 0)
            {
                cartTable.Columns.Add("Part Name");
                cartTable.Columns.Add("Price", typeof(double));
                cartTable.Columns.Add("Qty", typeof(int));
                cartTable.Columns.Add("Total", typeof(double));
            }
            
            dataGridView1.DataSource = cartTable;
        }

        private void Billing_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            LoadParts();
        }

        private void LoadCustomers()
        {
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();
                cmbcustomer.Items.Clear();

                string query = "SELECT customer_name FROM customertable";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    cmbcustomer.Items.Add(rd["customer_name"].ToString());
                }
                rd.Close();
            }
            catch (Exception ex) { MessageBox.Show("Error loading customers: " + ex.Message); }
            finally { con.Close(); }
        }

        private void LoadParts()
        {
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();
                cmbParts.Items.Clear();

                string query = "SELECT part_name FROM itemtable";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    cmbParts.Items.Add(rd["part_name"].ToString());
                }
                rd.Close();
            }
            catch (Exception ex) { MessageBox.Show("Error loading parts: " + ex.Message); }
            finally { con.Close(); }
        }

        private void cmbcustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbcustomer.SelectedItem != null)
            {
                string selectedCustomer = cmbcustomer.SelectedItem.ToString();
                LoadDevices(selectedCustomer);
            }
        }

        private void LoadDevices(string customerName)
        {
            try
            {
                cmbdevice.Items.Clear();
                if (con.State == ConnectionState.Closed) con.Open();

                string query = "SELECT device_name FROM devicetable WHERE customer_name = @customer";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@customer", customerName);

                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    cmbdevice.Items.Add(rd["device_name"].ToString());
                }
                rd.Close();
            }
            catch (Exception ex) { MessageBox.Show("Error loading devices: " + ex.Message); }
            finally { con.Close(); }
        }

        private void btnAddtocart_Click(object sender, EventArgs e)
        {
          
            if (cmbParts.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtQty.Text))
            {
                MessageBox.Show("Please select a part and quantity.");
                return;
            }

            try
            {
                if (con.State == ConnectionState.Closed) con.Open();

               
                SqlCommand cmd = new SqlCommand("SELECT sell_price FROM itemtable WHERE part_name = @name", con);
                cmd.Parameters.AddWithValue("@name", cmbParts.Text);

                object result = cmd.ExecuteScalar();
                if (result == null) { MessageBox.Show("Price not found for this part."); return; }

                double price = Convert.ToDouble(result);
                int qty = int.Parse(txtQty.Text);
                double total = price * qty;

         
                cartTable.Rows.Add(cmbParts.Text, price, qty, total);

                CalculateFullTotal();
            }
            catch (Exception ex) { MessageBox.Show("Error adding to cart: " + ex.Message); }
            finally { con.Close(); }
        }

        private void CalculateFullTotal()
        {
            double sum = 0;
         
            foreach (DataRow row in cartTable.Rows)
            {
                sum += Convert.ToDouble(row["Total"]);
            }

            txtTotal.Text = sum.ToString("0.00");

            double discountPercent = 0;
            double.TryParse(txtDis.Text, out discountPercent);

            double discountAmount = sum * (discountPercent / 100);
            double grandTotal = sum - discountAmount;

            txtGrandTotal.Text = grandTotal.ToString("0.00");
        }

        private void btnGenarateBiil_Click(object sender, EventArgs e)
        {
            if (cartTable.Rows.Count == 0)
            {
                MessageBox.Show("Cart is empty!");
                return;
            }

           
            printPreviewDialog1.Document = printDocument1;

         
            printPreviewDialog1.ShowDialog();

      
            MessageBox.Show("Bill Generated Successfully!");

            cartTable.Clear();
            txtTotal.Clear();
            txtGrandTotal.Clear();
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
          
            Font titleFont = new Font("Arial", 18, FontStyle.Bold);
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font bodyFont = new Font("Arial", 10, FontStyle.Regular);
            Brush brush = Brushes.Black;

            int startX = 50;
            int startY = 50;
            int offset = 40;

       
            e.Graphics.DrawString("MOBILE REPAIR MANAGEMENT SYSTEM", titleFont, brush, startX, startY);
            e.Graphics.DrawString("Customer: " + cmbcustomer.Text, bodyFont, brush, startX, startY + offset);
            e.Graphics.DrawString("Device: " + cmbdevice.Text, bodyFont, brush, startX, startY + (offset * 2));
            e.Graphics.DrawString("Date: " + DateTime.Now.ToString(), bodyFont, brush, startX, startY + (offset * 3));

            e.Graphics.DrawString("------------------------------------------------------------------", bodyFont, brush, startX, startY + (offset * 4));


            int tableY = startY + (offset * 5);
            e.Graphics.DrawString("Part Name", headerFont, brush, startX, tableY);
            e.Graphics.DrawString("Price", headerFont, brush, startX + 250, tableY);
            e.Graphics.DrawString("Qty", headerFont, brush, startX + 350, tableY);
            e.Graphics.DrawString("Total", headerFont, brush, startX + 450, tableY);

            int itemY = tableY + 30;
            foreach (DataRow row in cartTable.Rows)
            {
                e.Graphics.DrawString(row["Part Name"].ToString(), bodyFont, brush, startX, itemY);
                e.Graphics.DrawString(row["Price"].ToString(), bodyFont, brush, startX + 250, itemY);
                e.Graphics.DrawString(row["Qty"].ToString(), bodyFont, brush, startX + 350, itemY);
                e.Graphics.DrawString(row["Total"].ToString(), bodyFont, brush, startX + 450, itemY);
                itemY += 25;
            }

      
            int footerY = itemY + 30;
            e.Graphics.DrawString("------------------------------------------------------------------", bodyFont, brush, startX, footerY);
            e.Graphics.DrawString("Subtotal: " + txtTotal.Text, bodyFont, brush, startX + 350, footerY + 30);
            e.Graphics.DrawString("Discount: " + txtDis.Text + "%", bodyFont, brush, startX + 350, footerY + 55);
            e.Graphics.DrawString("GRAND TOTAL: " + txtGrandTotal.Text, headerFont, Brushes.Red, startX + 350, footerY + 85);

            e.Graphics.DrawString("Thank you for your business!", bodyFont, brush, startX + 150, footerY + 150);
        }

        private void cmbcustomer_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void txtGrandTotal_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
