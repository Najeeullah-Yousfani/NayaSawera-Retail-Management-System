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
    public partial class UC_ManageCustomers : UserControl
    {
        private static string config = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection con = new SqlConnection(config);
        public UC_ManageCustomers()
        {
            InitializeComponent();
            try
            {
                con.Open();
            }catch(Exception e) 
            {
                MessageBox.Show("Database Connection Error : Try Contacting Developer" + e, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO [customer] VALUES (@Name,@father,@cnic,@mobile,@address)";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@Name", name.Text);
                command.Parameters.AddWithValue("@father", father.Text);
                command.Parameters.AddWithValue("@cnic",cnic.Text);
                command.Parameters.AddWithValue("@mobile", mobile.Text);
                command.Parameters.AddWithValue("@address", address.Text);
                int result = command.ExecuteNonQuery();
                if (result < 0)
                {
                    MessageBox.Show("Error Inserting into database!");
                }
                else
                {
                    MessageBox.Show("Data Inserted successfully");
                    cnic.Text = "";
                    name.Text = "";
                    father.Text = "";
                    address.Text = "";
                    mobile.Text = "";
                    callcustomerdata();
                }
            }
        }

        private void onload(object sender, EventArgs e)
        {
            callcustomerdata();
        }
        private void callcustomerdata() 
        {
            SqlDataAdapter da = new SqlDataAdapter("Select CustomerName,CustomerFatherName from [customer]", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "brands");
            dataGridView1.DataSource = ds.Tables["brands"].DefaultView;
        }
    }
}
