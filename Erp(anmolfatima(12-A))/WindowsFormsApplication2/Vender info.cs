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
     
    public partial class Form6 : Form
    {
         MyConnection mc = new MyConnection();
         int counter = 0;
         int id = 001;
        public Form6()
        {
            InitializeComponent();
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            mc.con.Open();
            OleDbCommand cmd = new OleDbCommand("select  VID from Vendor;", mc.con);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox11.Text = dr["VID"].ToString();
                id++;


            }
            mc.con.Close();
            mc.con.Open();
            OleDbCommand cmd1 = new OleDbCommand("select  GrpName from CusGroup ;", mc.con);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                comboBox3.Items.Add(dr1["GrpName"]);

            }
            mc.con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if
                (textBox1.Text == "" || textBox2.Text == "" || comboBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || comboBox2.Text == "" || textBox9.Text == "" ||textBox10.Text == "")
            {
                MessageBox.Show("ALL filed Required Must be filled");
            }

            else
            {
                mc.con.Open();
                for (int i = 0; i < counter; i++)
                {
                    OleDbCommand cmd = new OleDbCommand("insert into Vendor (VID,VName,VCode,VCity,PH1,PH2,VAddress,CPName,CPPH,VEmail,VFax,VGroup,VStatus)values(@VID,@VName,@VCode,@VCity,@PH1,@PH2,@VAddress,@CPName,@CPPH,@VEmail,@VFax,@VGroup,@VStatus);", mc.con);
                    cmd.Parameters.AddWithValue("@VID", "V" + id + "V/2017");
                    cmd.Parameters.AddWithValue("@VName", textBox1.Text);
                    cmd.Parameters.AddWithValue("@VCode", textBox2.Text);
                    cmd.Parameters.AddWithValue("@VCity", comboBox2.SelectedItem);
                    cmd.Parameters.AddWithValue("@PH1", textBox4.Text);
                    cmd.Parameters.AddWithValue("@PH2", textBox5.Text);
                    cmd.Parameters.AddWithValue("@VAddress", textBox3.Text);
                    cmd.Parameters.AddWithValue("@CPName", textBox6.Text);
                    cmd.Parameters.AddWithValue("@CPPH", textBox7.Text);
                    cmd.Parameters.AddWithValue("@VEmail", textBox8.Text);
                    cmd.Parameters.AddWithValue("@VFax", textBox9.Text);
                    cmd.Parameters.AddWithValue("@VGroup", comboBox3.SelectedItem);
                    cmd.Parameters.AddWithValue("@VStatus", textBox10.Text);
                    cmd.ExecuteNonQuery();
                }
                mc.con.Close();
                MessageBox.Show("Record has been Inserted ");
            }
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

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
