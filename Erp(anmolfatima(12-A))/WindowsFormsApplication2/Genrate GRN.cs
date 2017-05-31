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
    public partial class Form10 : Form
    {
        MyConnection mc = new MyConnection();
        int id = 001;
        int counter = 0;
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
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
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mc.con.Open();
            OleDbCommand cmd = new OleDbCommand("select * from POProducts where   POID = '" + comboBox1.Text + "'", mc.con);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr["PModel"].ToString();
                textBox3.Text = dr["PQty"].ToString();

            }
            {
                OleDbCommand cmd1 = new OleDbCommand("select * from PO where   POID = '" + comboBox1.Text + "'", mc.con);
                OleDbDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.Read())
                {
                    textBox4.Text = dr1["VName"].ToString();
                    textBox5.Text = dr1["DCDate"].ToString();

                    textBox8.Text = dr1["VContectPerson"].ToString();
                    textBox7.Text = dr1["TotalAmount"].ToString();

                }
            }
            {
                textBox1.Text = "GRN -" + comboBox1.SelectedItem;
            }
            mc.con.Close();

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

        private void button2_Click(object sender, EventArgs e)
        {
            mc.con.Open();
           
            {
       	     try
             {
             ﻿OleDbCommand cmd1 = new OleDbCommand("insert into GRN(GRNID,BaseDocument,VName,DCDate,PModel,PQty,GRDate,Status,ContectPerson,TotalAmount) values(@GRNID,@BaseDocument,@VName,@DCDate,@PModel,@PQty,@GRDate,@Status,@ContectPerson,TotalAmount)", mc.con);
              cmd1.Parameters.AddWithValue("@GRNID", textBox1.Text);
              cmd1.Parameters.AddWithValue("@BaseDocument", comboBox1.Text);
              cmd1.Parameters.AddWithValue("@VName", textBox4.Text);
              cmd1.Parameters.AddWithValue("@DCDate", textBox5.Text);
              cmd1.Parameters.AddWithValue("@PModel", textBox2.Text);
              cmd1.Parameters.AddWithValue("@PQty", textBox3.Text);
              cmd1.Parameters.AddWithValue("@GRDate", dateTimePicker1.Text);
              cmd1.Parameters.AddWithValue("@Status", textBox6.Text);
              cmd1.Parameters.AddWithValue("@ContectPerson", textBox8.Text);
              cmd1.Parameters.AddWithValue("@TotalAmount", textBox3.Text);

              cmd1.ExecuteNonQuery();
             }
             catch (Exception ex)
             {
                 MessageBox.Show("something was wrong");
             }
                }
            
            mc.con.Close();

            MessageBox.Show("GRN has been Inserted ");
            mc.con.Open();
            OleDbCommand cmd = new OleDbCommand("update PO set Status='" +textBox9.Text + "'where POID ='" + comboBox1.SelectedItem + "'", mc.con);
            cmd.ExecuteNonQuery();
            
            mc.con.Close();
           
             ﻿
         
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
