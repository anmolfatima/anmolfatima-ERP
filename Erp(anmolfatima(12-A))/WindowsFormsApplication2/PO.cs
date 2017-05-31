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
    public partial class PO : Form
    {
        MyConnection mc = new MyConnection();
        string[] prds = new string[50];
        int[] qty = new int[50];
        int counter = 0;
        int id = 001;
        public PO()
        {
            InitializeComponent();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
    
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            mc.con.Open();
            OleDbCommand cmd2 = new OleDbCommand("select VName,VGroup,CPName,CPPH from Vendor where VID ='" + comboBox2.SelectedItem + "'", mc.con);
            OleDbDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                textBox1.Text = dr2["VName"].ToString();
                textBox8.Text = dr2["CPName"].ToString();
                textBox9.Text = dr2["VGroup"].ToString();
                textBox2.Text = dr2["CPPH"].ToString();

            }
            mc.con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            mc.con.Open();
            OleDbCommand cmd2 = new OleDbCommand("select PName,BasePrice from Products where PID ='" + comboBox5.SelectedItem + "'", mc.con);
            OleDbDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                textBox3.Text = dr2["PName"].ToString();
                textBox4.Text = dr2["BasePrice"].ToString();
                

            }
            mc.con.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox10.Text += comboBox1.Text + Environment.NewLine;
            textBox6.Text += comboBox5.Text + Environment.NewLine;
            textBox7.Text += Convert.ToString((Convert.ToInt32(textBox5.Text)) * ((Convert.ToInt32(textBox4.Text)))) +Environment.NewLine;
            prds[counter] = comboBox5.Text;
            qty[counter] = Convert.ToInt32(textBox5.Text);
            counter++; 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
         mc.con.Open(); 	 
	     for (int i = 0; i < counter; i++) 	 
	     { 	 
             ﻿OleDbCommand cmd = new OleDbCommand("insert into POProducts(POID,PModel,PQty) values(@POID,@PModel,@PQty)", mc.con); 	 
              cmd.Parameters.AddWithValue("@POID", comboBox1.Text); 	 
              cmd.Parameters.AddWithValue("@PModel", comboBox5.Text); 	 
              cmd.Parameters.AddWithValue("@PQty", textBox5.Text); 	 
             cmd.ExecuteNonQuery(); 	 
	              } 	 
	
    for (int i = 0; i < counter; i++)
    { 	 
             ﻿OleDbCommand cmd = new OleDbCommand("insert into PO(POID,DCDate,VDept,VName,VID,VContectPerson,VCPPH,TotalAmount) values(@POID,@DCDate,@VDept,@VName,@VID,@VContectPerson,@VCPPH,@TotalAmount)", mc.con);
              cmd.Parameters.AddWithValue("@POID", textBox11.Text);
              cmd.Parameters.AddWithValue("@DCDate",dateTimePicker1.Text);
              cmd.Parameters.AddWithValue("@VDept", textBox9.Text);
              cmd.Parameters.AddWithValue("@VName", textBox1.Text);
              cmd.Parameters.AddWithValue("@VID", comboBox2.Text);
              cmd.Parameters.AddWithValue("@VContectPerson", textBox8.Text);
              cmd.Parameters.AddWithValue("@VCPPH", textBox5.Text);
              cmd.Parameters.AddWithValue("@TotalAmount", textBox7.Text);
              cmd.ExecuteNonQuery();
    }
    mc.con.Close();
    MessageBox.Show("Record has been Inserted ");
	
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

        private void Form7_Load(object sender, EventArgs e)
        {

            mc.con.Open();
            OleDbCommand cmd = new OleDbCommand("select PID from Products", mc.con);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox5.Items.Add(dr["PID"]);
                

            }
            mc.con.Close();

            mc.con.Open();
            OleDbCommand cmd1 = new OleDbCommand("select VID from Vendor", mc.con);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                comboBox2.Items.Add(dr1["VID"]);

            }
            mc.con.Close();
            mc.con.Open();
            OleDbCommand cmd2 = new OleDbCommand("select POID from PO '" + comboBox1.Text + "'", mc.con);
            OleDbDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox1.Text = dr2["POID"].ToString();
                textBox11.Text = "PO-"  + comboBox1.Text;

                id++;
            }
            mc.con.Close();



        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }

}