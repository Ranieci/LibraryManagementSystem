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
    public partial class dashboard : Form
    {
        public dashboard(string val)
        {
            InitializeComponent();
            name.Text = val;
        }
        SqlConnection cnnc = new SqlConnection("Data Source=yourservername;Initial Catalog=Library;Integrated Security=True");
        void list()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From libraryy", cnnc);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm1 = new Form1();
            frm1.Show();
        }

        private void btnlist_Click(object sender, EventArgs e)
        {
            list();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cnnc.Open();
            SqlCommand cmd2 = new SqlCommand("Delete From libraryy where Bookid=@p1", cnnc);
            cmd2.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd2.ExecuteNonQuery();
            cnnc.Close();
            MessageBox.Show("Book Deleted!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            list();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            
            

        }

        private void button6_Click(object sender, EventArgs e)
        {
            cnnc.Open();
            SqlCommand cmd = new SqlCommand("insert into libraryy(Bookname,Author,Kind,Pages) values(@p1,@p2,@p3,@p4)", cnnc);
            cmd.Parameters.AddWithValue("@p1", textBox2.Text);
            cmd.Parameters.AddWithValue("@p2", textBox3.Text);
            cmd.Parameters.AddWithValue("@p3", textBox4.Text);
            cmd.Parameters.AddWithValue("@p4", comboBox1.Text);
            cmd.ExecuteNonQuery();
            cnnc.Close();
            MessageBox.Show("Book Added");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cnnc.Open();
            SqlCommand cmd3 = new SqlCommand("update libraryy set BookName=@p1,Author=@p2,Kind=@p3,Pages=@p4 where Bookid=@p5",cnnc);
            cmd3.Parameters.AddWithValue("@p1", textBox2.Text);
            cmd3.Parameters.AddWithValue("@p2", textBox3.Text);
            cmd3.Parameters.AddWithValue("@p3", comboBox1.Text);
            cmd3.Parameters.AddWithValue("@p4", textBox4.Text);
            cmd3.Parameters.AddWithValue("@p5", textBox1.Text);
            cmd3.ExecuteNonQuery();
            cnnc.Close();
            MessageBox.Show("Record Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            list();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlCommand cmd4 = new SqlCommand("Select * From libraryy Where BookName=@p1", cnnc);
            cmd4.Parameters.AddWithValue("@p1", textBox5.Text);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd4);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            memberlist frm = new memberlist();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            issuedb frm = new issuedb();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            returnb frm = new returnb();
            frm.Show();
        }
    }
}
