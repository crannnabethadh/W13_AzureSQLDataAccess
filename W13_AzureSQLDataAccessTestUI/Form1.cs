using System;
using System.Configuration;
using System.Windows.Forms;
using W13_AzureSQLDataAccess;

namespace W13_AzureSQLDataAccessTestUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = DataAccess.GetUsers();
            listBox1.DisplayMember = "FullUserInfo";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataAccess.InitConnectionString(ConfigurationManager.ConnectionStrings["ClickyCrates2020DbConnectionString"].ConnectionString);
        }
    }
}
