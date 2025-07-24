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
    public partial class Manage_Product : UserControl
    {
        private static string config = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection con = new SqlConnection(config);
        public Manage_Product()
        {
            InitializeComponent();
            try
            {
                con.Open();
            }catch(Exception e) 
            {
                MessageBox.Show("Error connecting to database (Contact developer) : " + e, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void onlaod(object sender, EventArgs e)
        {
            callcategorydropdown();
            callbrandsdropdown();
            callbrandsgridview();
            callcategorygridview();
        }
        private void callbrandsgridview() 
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from [brands]", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "brands");
            brands.DataSource = ds.Tables["brands"].DefaultView;

        }
        private void callcategorygridview() 
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from [category]", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "category");
            categories.DataSource = ds.Tables["category"].DefaultView;

        }
        private void callcategorydropdown() 
        {
            SqlCommand cmd = new SqlCommand("Select * from [category]",con);
            SqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read()) 
            {
                category_select.Items.Add(DR[1]);
            }
            
        }
        private void callbrandsdropdown() 
        {
            SqlCommand cmd = new SqlCommand("Select * from [brands]", con);
            SqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read()) 
            {
                brand_select.Items.Add(DR[1]);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddProduct();
        }
        private void AddProduct() 
        {
            string query = "INSERT INTO [product] VALUES (@name,@slug,@price,@stock,@category,@brand)";
            using (SqlCommand command = new SqlCommand(query,con)) 
            {
                command.Parameters.AddWithValue("@name", product_name.Text);
                command.Parameters.AddWithValue("@slug", product_slug.Text);
                command.Parameters.AddWithValue("@price", product_price.Text);
                command.Parameters.AddWithValue("@stock", stock.Text);
                command.Parameters.AddWithValue("@category", category_select.SelectedItem);
                command.Parameters.AddWithValue("@brand", brand_select.SelectedItem);
                int result = command.ExecuteNonQuery();
                if(result < 0) 
                {
                    MessageBox.Show("Cant add more data");
                }
                else 
                {
                    MessageBox.Show("Data Added Successfully!");
                    product_name.Text = "";
                    product_slug.Text = "";
                    product_price.Text = "";
                    stock.Text = "";
                    category_select.Text = "Select";
                    category_select.Text = "Select";
                }


            }
        }
    }
}
