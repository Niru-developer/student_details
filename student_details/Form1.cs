using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace student_details
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("server=localhost;database=student;user=root;password=");
        string gender;


        private void button1_Click(object sender, EventArgs e)
        {
            
           try
            {

                if (txtid.Text == null)
                {
                    MessageBox.Show("plese fill youer id");


                }
                else
                {
                    con.Open();
                    if (radm.Checked)
                    {
                        gender = "male";
                    }
                    if (radf.Checked)
                    {
                        gender = "female";

                    }
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO sud(id,name,adderess,gender)VALUES('" + txtid.Text + "','" + txtname.Text + "','" + txtadd.Text + "','" + gender + "')", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("insret data");
                    con.Close();


                }

            }
            catch (Exception ex) { }

            
          
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            con.Open();
            if (radm.Checked)
            {
                gender = "male";
            }
            if (radf.Checked)
            {
                gender = "female";

            }
            MySqlCommand cmd = new MySqlCommand("UPDATE sud SET name='" + txtname.Text + "',adderess='" + txtadd.Text + "',gender='" + gender + "'  WHERE id='" + txtid.Text + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("updata  data");


            con.Close();
        }

        private void btndele_Click(object sender, EventArgs e)
        {
            con.Open();
            if (radm.Checked)
            {
                gender = "male";
            }
            if (radf.Checked)
            {
                gender = "female";

            }
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `sud` WHERE `sud`.`id` ='" + txtid.Text + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("delete  data");
            
            con.Close();
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            string query = "select * from sud";
            MySqlDataAdapter adt = new MySqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            con.Open();
            adt.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }
    }
}
