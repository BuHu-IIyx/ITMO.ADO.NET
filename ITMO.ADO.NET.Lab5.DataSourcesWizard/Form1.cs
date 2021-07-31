using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITMO.ADO.NET.Lab5.DataSourcesWizard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.apressFinancialDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'apressFinancialDataSet.CustomerProducts' table. You can move, or remove it, as needed.
            this.customerProductsTableAdapter.Fill(this.apressFinancialDataSet.CustomerProducts);
            // TODO: This line of code loads data into the 'apressFinancialDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.apressFinancialDataSet.Customers);
            // TODO: This line of code loads data into the 'apressFinancialDataSet.CustomerProducts' table. You can move, or remove it, as needed.
            this.customerProductsTableAdapter.Fill(this.apressFinancialDataSet.CustomerProducts);
            // TODO: This line of code loads data into the 'apressFinancialDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.apressFinancialDataSet.Customers);

        }

        private void customersBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.apressFinancialDataSet);

        }
    }
}
