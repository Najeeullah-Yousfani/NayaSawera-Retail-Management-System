using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NayaSawera
{
    public partial class UC_maincontrol : UserControl
    {
        private static string config = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection con = new SqlConnection(config);
        public UC_maincontrol()
        {
            InitializeComponent();
            try
            {
                con.Open();
            }catch(Exception e) 
            {
                MessageBox.Show("Error connecting to database (Contact developer) : "+e,"Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void uc_main_load(object sender, EventArgs e)
        {
            fill_chart();
        }
        private void fill_chart()
        {
            countproduct();
            countbrands();
            countcategories();
            //AddXY value in chart1 in series named as Salary  
            sale_data.Series["sale"].Points.AddXY("Day 1", "10");
            sale_data.Series["sale"].Points.AddXY("Day 2", "80");
            sale_data.Series["sale"].Points.AddXY("Day 3", "800");
            sale_data.Series["sale"].Points.AddXY("Day 4", "2");
            sale_data.Series["sale"].Points.AddXY("Day 5", "1500");
            //chart title  
            sale_data.Titles.Add("Weekly Sale Chart");
        }
        private void countproduct() 
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [product]",con);
            string count_new = Convert.ToString(cmd.ExecuteScalar());
            count1.Text = count_new;
        }
        private void countbrands() 
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [brands]", con);
            string count_new = Convert.ToString(cmd.ExecuteScalar());
            count2.Text = count_new;
        }
        private void countcategories() 
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [category]", con);
            string count_new = Convert.ToString(cmd.ExecuteScalar());
            count3.Text = count_new;
        }
    }
}
