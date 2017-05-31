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
    public partial class Invoice : Form
    {
        MyConnection mc = new MyConnection();
        public Invoice()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
           
        }

       
        

        private void Form12_Load(object sender, EventArgs e)
        {
            mc.con.Open();
            OleDbCommand cmd = new OleDbCommand("select GRNID from GRN", mc.con);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["GRNID"]);

            }
            mc.con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mc.con.Open();
            OleDbCommand cmd = new OleDbCommand("select * from GRN where   GRNID = '" + comboBox1.Text + "'", mc.con);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr["BaseDocument"].ToString();
                textBox3.Text = dr["PModel"].ToString();
                textBox4.Text = dr["PQty"].ToString();
                textBox5.Text = dr["TotalAmount"].ToString();
                textBox7.Text = dr["VName"].ToString();
                textBox8.Text = dr["ContectPerson"].ToString();
                textBox9.Text = dr["DCDate"].ToString();


            }
            {
                textBox1.Text = "INVoice -" + comboBox1.SelectedItem;
            }
            
            mc.con.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menu f3 = new Menu();
            f3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox5.Text);
            int c = a * 100 / 17;
            textBox11.Text = c.ToString();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
            mc.con.Open();
            OleDbCommand cmd = new OleDbCommand("update GRN set Status='" +  textBox6.Text + "'where GRNID ='" +comboBox1.SelectedItem  + "'", mc.con);
            cmd.ExecuteNonQuery();
        }

            {
                try
                {
             ﻿OleDbCommand cmd1 = new OleDbCommand("insert into Invoice(InvoiceNo,PModel,VendorName,ContectPerson,DCDate,RDate,AmountPayable,GRNID,PQty) values(@InvoiceNo,@PModel,@VendorName,@ContectPerson,@DCDate,@RDate,@AmountPayable,@GRNID,@PQty)", mc.con);
              cmd1.Parameters.AddWithValue("@InvoiceNo", textBox1.Text);
              cmd1.Parameters.AddWithValue("@PModel", textBox3.Text);
              cmd1.Parameters.AddWithValue("@VendorName", textBox8.Text);
              cmd1.Parameters.AddWithValue("@ContectPerson", textBox9.Text);
              cmd1.Parameters.AddWithValue("@DCDate", textBox9.Text);
              cmd1.Parameters.AddWithValue("@RDate", dateTimePicker3.Text);
              cmd1.Parameters.AddWithValue("@AmountPayable", textBox11.Text);
              cmd1.Parameters.AddWithValue("@GRNID", comboBox1.Text);
              cmd1.Parameters.AddWithValue("@PQty", textBox4.Text);
              cmd1.ExecuteNonQuery();
                }
                  
        catch (Exception ex)
        {
            MessageBox.Show("something was wrong");
        }
            }

            mc.con.Close();

            MessageBox.Show("GRN has been Inserted ");
             
           
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            
        
        }
    }
}
