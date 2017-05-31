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
    public partial class Form11 : Form
    {
        MyConnection mc = new MyConnection();
        public Form11()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mc.con.Open();
            OleDbCommand cmd = new OleDbCommand("select * from Invoice where InvoiceNo = '" + comboBox1.Text + "'", mc.con);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox3.Text = dr["PModel"].ToString();
                textBox8.Text = dr["VendorName"].ToString();
                textBox11.Text = dr["AmountPayable"].ToString();
            }
            {
                {

                    textBox1.Text = "Recive -" + comboBox1.SelectedItem;
                }
            }
            mc.con.Close();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            mc.con.Open();
            OleDbCommand cmd = new OleDbCommand("select InvoiceNo  from Invoice ", mc.con);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["InvoiceNo"]);

            }
           
            mc.con.Close();
        }

        

        

        private void button4_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Menu F3 = new Menu();
            F3.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            mc.con.Open();

            {
                try
                {
             ﻿OleDbCommand cmd1 = new OleDbCommand("insert into Recive(ReciveID,Invoice,Vender_Name,PModel,Amount,Po_recive) values(@ReciveID,@Invoice,@Vender_Name,@PModel,@Amount,@Po_recive)", mc.con);
              cmd1.Parameters.AddWithValue("@ReciveID", textBox1.Text);
              cmd1.Parameters.AddWithValue("@Invoice", comboBox1.Text);
              cmd1.Parameters.AddWithValue("@Vender_Name", textBox8.Text);
              cmd1.Parameters.AddWithValue("@PModel", textBox3.Text);
              cmd1.Parameters.AddWithValue("@Amount", textBox11.Text);
              cmd1.Parameters.AddWithValue("@Po_recive", comboBox2.Text);
              cmd1.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("something wrong!!");
                }
                
            }
            mc.con.Close();
            MessageBox.Show("PO has been Recived");
            

        }
    }
}
