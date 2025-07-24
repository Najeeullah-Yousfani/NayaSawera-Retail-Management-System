using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NayaSawera
{
    public partial class Dashboard : Form
    {
        static Dashboard _obj;
        public static Dashboard Instance
        {
            get 
            {
                if (_obj == null)
                {
                    _obj = new Dashboard();
                }
                return _obj;
            }
        }
        public Panel PnlContainer
        {
            get { return panel3; }
            set { panel3 = value; }
        }
        public Dashboard()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            _obj = this;

            UC_maincontrol uc = new UC_maincontrol();
            uc.Dock = DockStyle.Fill;
            panel3.Controls.Add(uc);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            _obj = this;

            //UC_maincontrol uc = new UC_maincontrol();
            UC_ManageSale uc_mgs =new UC_ManageSale();
            uc_mgs.Dock = DockStyle.Fill;
            panel3.Controls.Add(uc_mgs);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            //_obj = this;

            //UC_maincontrol uc = new UC_maincontrol();
            //uc.Dock = DockStyle.Fill;
            //panel3.Controls.Add(uc);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            _obj = this;


            Manage_Product mgp = new Manage_Product();
            mgp.Dock = DockStyle.Fill;
            panel3.Controls.Add(mgp);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            _obj = this;


            UC_ManageCategories mc = new UC_ManageCategories();
            mc.Dock = DockStyle.Fill;
            panel3.Controls.Add(mc);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            _obj = this;


            UC_ManageBrands mb = new UC_ManageBrands();
            mb.Dock = DockStyle.Fill;
            panel3.Controls.Add(mb);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            _obj = this;


            Records rc = new Records();
            rc.Dock = DockStyle.Fill;
            panel3.Controls.Add(rc);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            _obj = this;

            UC_ManageCustomers mc = new UC_ManageCustomers();
            mc.Dock = DockStyle.Fill;
            panel3.Controls.Add(mc);
        }
    }
}
