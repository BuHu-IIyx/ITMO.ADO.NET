using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITMO.ADO.NET.Lab4.DataViewExample
{
    public partial class Form1 : Form
    {
        DataView customersDataView;
        DataView customerProductsDataView;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            customersTableAdapter1.Fill(apressFinancialDataSet1.Customers);
            customerProductsTableAdapter1.Fill(apressFinancialDataSet1.CustomerProducts);
            customersDataView = new DataView(apressFinancialDataSet1.Customers);
            customerProductsDataView = new DataView(apressFinancialDataSet1.CustomerProducts);
            customersDataView.Sort = "CustomerID";
            CustomersGrid.DataSource = customersDataView;
        }

        private void SetDataViewPropertiesButton_Click(object sender, EventArgs e)
        {
            customersDataView.Sort = SortTextBox.Text;
            customersDataView.RowFilter = FilterTextBox.Text;
        }

        private void AddRowButton_Click(object sender, EventArgs e)
        {
            DataRowView newCustomRow = customersDataView.AddNew();
            newCustomRow["CustomerID"] = "WINGT";
            newCustomRow["CustomerFirstName"] = "Wing Tip Toys";
            newCustomRow.EndEdit();
        }

        private void GetOrdersButton_Click(object sender, EventArgs e)
        {
            Int64 selectedCustomerID = 
                (Int64)CustomersGrid.SelectedCells[0].OwningRow.Cells["CustomerID"].Value;
            DataRowView selectedRow = 
                customersDataView[customersDataView.Find(selectedCustomerID)];
            customerProductsDataView =
                selectedRow.CreateChildView(apressFinancialDataSet1.Relations["CustomerProducts_Customers"]);
            OrdersGrid.DataSource = customerProductsDataView;
        }
    }
}
