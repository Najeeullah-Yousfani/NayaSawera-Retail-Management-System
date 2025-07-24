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
    public partial class UC_ManageCategories : UserControl
    {
        private static string config = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection con = new SqlConnection(config);
        public UC_ManageCategories()
        {
            InitializeComponent();
            con.Open();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddCategory();
        }
        private void AddCategory()
        {
            string query = "INSERT INTO [category] VALUES (@CategoryName,@CategorySlug)";
            using (SqlCommand command = new SqlCommand(query, con)) 
            {
                command.Parameters.AddWithValue("@CategoryName", categoryname.Text);
                command.Parameters.AddWithValue("@CategorySlug",categoryslug.Text);
                int result = command.ExecuteNonQuery();
                if(result < 0) 
                {
                    MessageBox.Show("Error Inserting into database!");
                }
                else 
                {
                    MessageBox.Show("Data Inserted successfully");
                    categoryname.Text = "";
                    categoryslug.Text = "";
                    callcategorydata();
                }
            }
        }

        private void onload(object sender, EventArgs e)
        {
            callcategorydata();
        }
        private void callcategorydata() 
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from [category]", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "category");
            dataGridView1.DataSource = ds.Tables["category"].DefaultView;
        }
    }
}
