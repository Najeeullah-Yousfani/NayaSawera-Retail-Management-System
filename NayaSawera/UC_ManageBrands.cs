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
    public partial class UC_ManageBrands : UserControl
    {
        private static string config = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection con = new SqlConnection(config);
        public UC_ManageBrands()
        {
            InitializeComponent();
            con.Open();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddBrands();
        }
        private void AddBrands() 
        {
            string query = "INSERT INTO [brands] VALUES (@BrandName,@BrandSlug)";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@BrandName", brandname.Text);
                command.Parameters.AddWithValue("@BrandSlug", brandslug.Text);
                int result = command.ExecuteNonQuery();
                if (result < 0)
                {
                    MessageBox.Show("Error Inserting into database!");
                }
                else
                {
                    MessageBox.Show("Data Inserted successfully");
                    brandslug.Text = "";
                    brandname.Text = "";
                    calldatagridview();
                }
            }
        }

        private void onload(object sender, EventArgs e)
        {
            calldatagridview();
            
        }
        private void calldatagridview() 
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from [brands]", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "brands");
            dataGridView1.DataSource = ds.Tables["brands"].DefaultView;
        }
    }
}
