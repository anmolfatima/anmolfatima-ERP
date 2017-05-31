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
    public partial class Form8 : Form
    {
        MyConnection mc = new MyConnection();
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

            mc.con.Open();
            OleDbCommand cmd = new OleDbCommand("select POID from PO", mc.con);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["POID"]);

            }
            mc.con.Close();
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            mc.con.Open();
            OleDbCommand cmd = new OleDbCommand("update PO set Approve='" + comboBox3.SelectedItem + "'where POID ='" + comboBox1.SelectedItem + "'", mc.con);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Record has been updated");


            DataTable dt = new DataTable();
            OleDbDataAdapter cmd1 = new OleDbDataAdapter("select * from PO", mc.con);
            cmd1.Fill(dt);
            dataGridView1.DataSource = dt;
            mc.con.Close();
}


        private void button1_Click(object sender, EventArgs e)
        {
            mc.con.Open();
            OleDbCommand cmd = new OleDbCommand(" delete from PO where POID='" + comboBox1.SelectedItem + "'", mc.con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record has been deleted");

            DataTable dt = new DataTable();
            OleDbDataAdapter cmd1 = new OleDbDataAdapter("select * from PO", mc.con);
            cmd1.Fill(dt);
            dataGridView1.DataSource = dt;
            mc.con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menu f3 = new Menu();
            f3.Show();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            mc.con.Open();
            DataTable dt = new DataTable();
            OleDbDataAdapter cmd = new OleDbDataAdapter("select * from PO", mc.con);
            cmd.Fill(dt);
            dataGridView1.DataSource = dt;
            mc.con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
