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
    public partial class Form2 : Form
    {
        MyConnection mc = new MyConnection();
         int counter = 0;
        int id = 001;
        public Form2()
        {
            InitializeComponent();
   
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
    for (int i = 0; i < counter; i++)
    { 	 
             ﻿
        try
        {
            OleDbCommand cmd = new OleDbCommand("insert into Amount(PayableID,Invoice NO,Produc,InVoice Date,Amount payeable,Comments) values(@PayableID,@Invoice NO,@Product,@InVoice Date,@Amount payeable,Comments)", mc.con);
            cmd.Parameters.AddWithValue("@PayableID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Invoice NO", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Product", textBox2.Text);
            cmd.Parameters.AddWithValue("@InVoice Date", textBox3.Text);
            cmd.Parameters.AddWithValue("@Amount payeable", textBox7.Text);
            cmd.Parameters.AddWithValue("@Comments", textBox4.Text);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            MessageBox.Show("something was wrong");
        }
    }
    mc.con.Close();
    MessageBox.Show(" OK");
    
    this.textBox5.Visible = true;
	
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.textBox5.Visible = false;
                 mc.con.Open();
            OleDbCommand cmd = new OleDbCommand("select InvoiceNo  from Invoice ", mc.con);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["InvoiceNo"]);

            }
           
            mc.con.Close();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
              mc.con.Open();
            OleDbCommand cmd = new OleDbCommand("select * from Invoice where InvoiceNo = '" + comboBox1.Text + "'", mc.con);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr["PModel"].ToString();
                textBox3.Text = dr["RDate"].ToString();
                textBox7.Text = dr["AmountPayable"].ToString();
            }
            {
                {

                    textBox1.Text = "P-" + comboBox1.SelectedItem;
                }
            }
            mc.con.Close();
            
        }
        }
    }

