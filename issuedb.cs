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

namespace LibraryManagementSystem
{
    public partial class issuedb : Form
    {
        public issuedb()
        {
            InitializeComponent();
        }
        SqlConnection cnc = new SqlConnection("Data Source=yourservername;Initial Catalog=Library;Integrated Security=True");
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void list()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From IssuedB", cnc);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnlist_Click(object sender, EventArgs e)
        {
            list();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cnc.Open();
            SqlCommand cmd = new SqlCommand("insert into IssuedB(IssuedBdate,IssuedBName) values(@p1,@p2)", cnc);
            cmd.Parameters.AddWithValue("@p1", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            cmd.ExecuteNonQuery();
            cnc.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cnc.Open();
            SqlCommand cmd2 = new SqlCommand("Delete From IssuedB where IssuedBid=@p1", cnc);
            cmd2.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd2.ExecuteNonQuery();
            cnc.Close();
            list();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cnc.Open();
            SqlCommand cmd3 = new SqlCommand("update IssuedB set IssuedBdate=@p1,IssuedBName=@p2 where IssuedBid=@p3", cnc);
            cmd3.Parameters.AddWithValue("@p1", dateTimePicker1.Value);
            cmd3.Parameters.AddWithValue("@p2", textBox2.Text);
            cmd3.Parameters.AddWithValue("@p3", textBox1.Text);
            cmd3.ExecuteNonQuery();
            cnc.Close();
            list();
        }
    }
}
