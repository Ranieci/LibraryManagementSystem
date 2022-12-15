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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem
{
    public partial class memberlist : Form
    {
        public memberlist()
        {
            InitializeComponent();
        }

        SqlConnection cnc = new SqlConnection("Data Source=yourservername;Initial Catalog=Library;Integrated Security=True");

        void list()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From member", cnc);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
        }

        private void btnlist_Click(object sender, EventArgs e)
        {
            list();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cnc.Open();
            SqlCommand cmd = new SqlCommand("insert into member(MemberName,MemberLastName) values(@p1,@p2)", cnc);
            cmd.Parameters.AddWithValue("@p1", textBox2.Text);
            cmd.Parameters.AddWithValue("@p2", textBox3.Text);
            cmd.ExecuteNonQuery();
            cnc.Close();
            MessageBox.Show("Member Added");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cnc.Open();
            SqlCommand cmd2 = new SqlCommand("Delete From member where Memberid=@p1", cnc);
            cmd2.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd2.ExecuteNonQuery();
            cnc.Close();
            MessageBox.Show("Member Deleted!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            list();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cnc.Open();
            SqlCommand cmd3 = new SqlCommand("update member set MemberName=@p1,MemberLastName=@p2 where Memberid=@p3", cnc);
            cmd3.Parameters.AddWithValue("@p1", textBox2.Text);
            cmd3.Parameters.AddWithValue("@p2", textBox3.Text);
            cmd3.Parameters.AddWithValue("@p3", textBox1.Text);
            cmd3.ExecuteNonQuery();
            cnc.Close();
            MessageBox.Show("Record Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            list();
        }
    }
}
