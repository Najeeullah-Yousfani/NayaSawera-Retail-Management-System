using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NayaSawera
{
    public partial class UC_ManageSale : UserControl
    {
        private static string config = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection con = new SqlConnection(config);
        public UC_ManageSale()
        {
            InitializeComponent();
            try {
                con.Open();
            }
            catch(Exception e) {
                MessageBox.Show("Error connecting to database (Contact developer) : " + e, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void onload(object sender, EventArgs e)
        {
            calldropdowndata();
            callbranddropdown();
            callproductgridview();
        }
        private void calldropdowndata() 
        {
            SqlCommand cmd = new SqlCommand("Select * from [category]", con);
            SqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                salecategory.Items.Add(DR[1]);
            }

        }
        private void callbranddropdown() 
        {
            SqlCommand cmd = new SqlCommand("Select * from [brands]", con);
            SqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                brandselect.Items.Add(DR[1]);
            }
        }
        private void callproductgridview() 
        {
            productview.DefaultCellStyle.ForeColor = Color.Black;
            SqlDataAdapter da = new SqlDataAdapter("Select * from [product]", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "product");
            productview.DataSource = ds.Tables["product"].DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                productview.DefaultCellStyle.ForeColor = Color.Black;
                SqlDataAdapter da = new SqlDataAdapter("Select * from [product] where ProductName like '%'+'"+searchbox.Text+ "'+'%' or productCategory = '" + salecategory.SelectedItem + "' or productBrand = '" + brandselect.SelectedItem + "'", con);
                DataSet ds = new DataSet();
                da.Fill(ds, "product");
                productview.DataSource = ds.Tables["product"].DefaultView;
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            this.Controls.Clear();
            CustomerCart cc = new CustomerCart();
            cc.Dock = DockStyle.Fill;
            this.Controls.Add(cc);

        }
    }
}
