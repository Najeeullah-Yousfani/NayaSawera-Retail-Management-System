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
    public partial class CustomerCart : UserControl
    {
        private static string config = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection con = new SqlConnection(config);
        public CustomerCart()
        {
            InitializeComponent();
            try
            {
                con.Open();
            }catch(Exception e) 
            {
            MessageBox.Show("Database Connection Error ( Contact Developer ) :"+e, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            UC_ManageSale ms = new UC_ManageSale();
            this.Controls.Add(ms);
        }

        private void onload(object sender, EventArgs e)
        {
            callcustomerdata();
        }
        private void callcustomerdata() 
        {
            customerview.DefaultCellStyle.ForeColor = Color.Black;
            SqlDataAdapter da = new SqlDataAdapter("Select CustomerName,CustomerFatherName from [customer]", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "brands");
            customerview.DataSource = ds.Tables["brands"].DefaultView;
        }
    }
}
