using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtusername.Text=="Alex"&& txtpassword.Text == "123")
            {
                this.Hide();
                string user = txtusername.Text;
                dashboard frm = new dashboard(char.ToUpper(user[0]) + user.Substring(1));
                frm.Show();
            }
            else
            {
                MessageBox.Show("Login Incorrect");
            }
        }
    }
}
