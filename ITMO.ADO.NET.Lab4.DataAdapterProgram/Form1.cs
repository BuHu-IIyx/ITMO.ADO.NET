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

namespace ITMO.ADO.NET.Lab4.DataAdapterProgram
{
    public partial class Form1 : Form
    {
        private SqlConnection NorthwindConnection = 
                new SqlConnection("Data Source=(local);Initial Catalog=ApressFinancial;Integrated Security=True");
        private SqlDataAdapter SqlDataAdapter1;
        private DataSet NorthwindDataset = new DataSet("ApressFinancial");
        private DataTable CustomersTable = new DataTable("CustomerDetails.Customers");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlDataAdapter1 = new SqlDataAdapter("SELECT * FROM CustomerDetails.Customers", NorthwindConnection);
            NorthwindDataset.Tables.Add(CustomersTable);
            SqlDataAdapter1.Fill(NorthwindDataset.Tables["CustomerDetails.Customers"]);
            dataGridView1.DataSource = NorthwindDataset.Tables["CustomerDetails.Customers"];
            SqlCommandBuilder commands = new SqlCommandBuilder(SqlDataAdapter1);
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            NorthwindDataset.EndInit();
            SqlDataAdapter1.Update(NorthwindDataset.Tables["CustomerDetails.Customers"]);

        }
    }
}
