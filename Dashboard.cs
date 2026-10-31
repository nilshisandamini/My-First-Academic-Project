using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MRMS
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
      
        private void btncustomer_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btndevice_Click(object sender, EventArgs e)
        {
            Device device = new Device();
            device.Show();
        }

        private void btnitem_Click(object sender, EventArgs e)
        {
            Item item = new Item(); 
            item.Show();
        }

        private void btnbilling_Click(object sender, EventArgs e)
        {
            Billing billing = new Billing();
            billing.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            
            label2.Text = DateTime.Now.ToLongDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Login Back = new Login();
            Back.Show();
        }
    }
}
