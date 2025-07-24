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
    public partial class LoginForm : Form
    {
        //Login code
        private static string config = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection con = new SqlConnection(config);
        public LoginForm()
        {
            InitializeComponent();
            try
            {
                con.Open();
            }catch(Exception e) 
            {
                MessageBox.Show("Error Connecting to database (Contact Developer) : "+e,"Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text)))
            {
                MessageBox.Show("Please Fill all the details");
            }
            else
            {
                loginAttempt();
            }
        }
        private void loginAttempt()
        {
            try
            {
                //con.Open();
                string query = "SELECT * FROM [user] WHERE userName='" + username.Text + "' and userPass='" + userpass.Text + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    MessageBox.Show("User Found!!");
                    Dashboard dd = new Dashboard();
                    dd.Show();
                }
                else
                {
                    MessageBox.Show("No User Found,Please Try Again!");
                }
            }catch(Exception e) 
            {
                
                MessageBox.Show("Error Connecting to database (Contact Developer) : "+e,"Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
