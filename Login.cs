using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MRMS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = cmbuser.Text;
            string password = txtpass.Text;

            if (username == "Admin" && password == "abc@123")
            {
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Hide();

                MessageBox.Show("Login Successfully.", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (username == "Cashier" && password == "abc@456")
            {
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Hide();

                MessageBox.Show("Login Successfully.", "Welcome ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Invalid password or username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {
          
        }
    }
}
