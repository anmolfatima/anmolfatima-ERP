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
    public partial class Form4 : Form
    {
        MyConnection mc = new MyConnection();
       int counter = 0;
        int id = 001;
        

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {        
      
            mc.con.Open();
            OleDbCommand cmd1 = new OleDbCommand("select  CID from Customer;", mc.con);
            OleDbDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
               textBox10.Text=dr["CID"].ToString();
                id++;
 

            }
            mc.con.Close();
            mc.con.Open();
            OleDbCommand cmd = new OleDbCommand("select  GrpName from CusGroup ;", mc.con);
            OleDbDataReader dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                comboBox1.Items.Add(dr1["GrpName"]);

            }
            mc.con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu f3 = new Menu();
            f3.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if
                   (textBox1.Text == "" || textBox2.Text == "" || comboBox3.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("ALL filed Required Must be filled");
            }

            else
            {
                mc.con.Open();
                for (int i = 0; i < counter; i++)
             
                {
                    try
                    {
                    OleDbCommand cmd = new OleDbCommand("insert into Customer (CID,Cname,CAddress,City,PH1,PH2,ContectPerson,CPPH,CEmail,CreditLimit,CStatus,CGroup)values(@CID,@Cname,@CAddress,@City,@PH1,@PH2,@ContectPerson,@CPPH,@CEmail,@CreditLimit,@CStatus,@CGroup);", mc.con);
                    cmd.Parameters.AddWithValue("@CID", "C" + id + "C/2017");
                    cmd.Parameters.AddWithValue("@Cname", textBox1.Text);
                    cmd.Parameters.AddWithValue("@CAddress", textBox2.Text);
                    cmd.Parameters.AddWithValue("@City", comboBox3.SelectedItem);
                    cmd.Parameters.AddWithValue("@PH1", textBox3.Text);
                    cmd.Parameters.AddWithValue("@PH2", textBox4.Text);
                    cmd.Parameters.AddWithValue("@ContectPerson", textBox5.Text);
                    cmd.Parameters.AddWithValue("@CPPH", textBox6.Text);
                    cmd.Parameters.AddWithValue("@CEmail", textBox7.Text);
                    cmd.Parameters.AddWithValue("@CreditLimit", textBox8.Text);
                    cmd.Parameters.AddWithValue("@CStatus", textBox9.Text);
                    cmd.Parameters.AddWithValue("@CGroup", comboBox1.SelectedItem);
                    cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("something was wrong");
                    }
                }
                mc.con.Close();
                MessageBox.Show("Record has been Inserted ");
        }

       


        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }
    }
}
