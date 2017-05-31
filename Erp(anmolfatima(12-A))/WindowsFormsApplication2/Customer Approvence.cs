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
    public partial class Form5 : Form
    {
        MyConnection mc = new MyConnection();
        public Form5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu f3 = new Menu();
            f3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void Form5_Load(object sender, EventArgs e)
        {
            mc.con.Open();
            OleDbCommand cmd = new OleDbCommand("select CID from Customer", mc.con);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["CID"]);

            }
            mc.con.Close();
        }
        

     

        private void button4_Click_1(object sender, EventArgs e)
        {
            mc.con.Open();
            OleDbCommand cmd = new OleDbCommand(" delete from Customer where CID='" + comboBox1.SelectedItem + "'", mc.con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record has been deleted");

            DataTable dt = new DataTable();
            OleDbDataAdapter cmd1 = new OleDbDataAdapter("select * from Customer", mc.con);
            cmd1.Fill(dt);
            dataGridView1.DataSource = dt;
            mc.con.Close();
          
        }

        

      

        private void button1_Click(object sender, EventArgs e)
        {
            mc.con.Open();
            OleDbCommand cmd = new OleDbCommand("update Customer set CStatus='" + comboBox2.SelectedItem + "'where CID ='" + comboBox1.SelectedItem + "'", mc.con);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Record has been updated");


            DataTable dt = new DataTable();
            OleDbDataAdapter cmd1 = new OleDbDataAdapter("select * from Customer", mc.con);
            cmd1.Fill(dt);
            dataGridView1.DataSource = dt;
            mc.con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mc.con.Open();
            DataTable dt = new DataTable();
            OleDbDataAdapter cmd = new OleDbDataAdapter("select * from Customer", mc.con);
            cmd.Fill(dt);
            dataGridView1.DataSource = dt;
            mc.con.Close();
        }
    }
}
