using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication1
{
    public partial class Form9 : Form
    {
        MyConnection mc = new MyConnection();
        public Form9()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            mc.con.Open();
            OleDbCommand cmd = new OleDbCommand("select VID from Vendor", mc.con);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["VID"]);

            }
            mc.con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mc.con.Open();
            OleDbCommand cmd = new OleDbCommand("update Vendor set VStatus='" + comboBox2.SelectedItem + "'where VID ='" + comboBox1.SelectedItem + "'", mc.con);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Record has been updated");


            DataTable dt = new DataTable();
            OleDbDataAdapter cmd1 = new OleDbDataAdapter("select * from Vendor", mc.con);
            cmd1.Fill(dt);
            dataGridView1.DataSource = dt;
            mc.con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mc.con.Open();
            OleDbCommand cmd = new OleDbCommand(" delete from Vendor where VID='" + comboBox1.SelectedItem + "'", mc.con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record has been deleted");

            DataTable dt = new DataTable();
            OleDbDataAdapter cmd1 = new OleDbDataAdapter("select * from Vendor", mc.con);
            cmd1.Fill(dt);
            dataGridView1.DataSource = dt;
            mc.con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu F3 = new Menu();
            F3.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            mc.con.Open();
            DataTable dt = new DataTable();
            OleDbDataAdapter cmd = new OleDbDataAdapter("select * from Vendor", mc.con);
            cmd.Fill(dt);
            dataGridView1.DataSource = dt;
            mc.con.Close();
        }

    }
}
