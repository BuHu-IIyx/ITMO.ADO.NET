using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITMO.ADO.NET.Lab5.DataGridViewExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void personBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.personBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.adventureWorks2019DataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'adventureWorks2019DataSet.Person' table. You can move, or remove it, as needed.
            this.personTableAdapter.Fill(this.adventureWorks2019DataSet.Person);
            DataColumn Location = new DataColumn("Location");
            Location.Expression = "FirstName + ',' + LastName";
            adventureWorks2019DataSet.Person.Columns.Add(Location);

        }

        private void AddColumnButton_Click(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn LocationColumn = new DataGridViewTextBoxColumn();
            LocationColumn.Name = "LocationColumn";
            LocationColumn.HeaderText = "Location";
            LocationColumn.DataPropertyName = "Location";
            personDataGridView.Columns.Add(LocationColumn);

        }

        private void DeleteColumnButton_Click(object sender, EventArgs e)
        {
            try
            {
                personDataGridView.Columns.Remove("LocationColumn");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void GetClickedCellButton_Click(object sender, EventArgs e)
        {
            string CurrentCellInfo;
            CurrentCellInfo = personDataGridView.CurrentCell.Value.ToString() + Environment.NewLine;
            CurrentCellInfo += "Column: " +
                personDataGridView.CurrentCell.OwningColumn.DataPropertyName + Environment.NewLine;
            CurrentCellInfo += "Column Index: " +
                personDataGridView.CurrentCell.ColumnIndex.ToString() + Environment.NewLine;
            CurrentCellInfo += "Row Index: " +
                personDataGridView.CurrentCell.RowIndex.ToString() + Environment.NewLine;
            label1.Text = CurrentCellInfo;
        }

        private void personDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (personDataGridView.Columns[e.ColumnIndex].DataPropertyName == "FirstName")
            {
                if (e.FormattedValue.ToString() == "")
                {
                    personDataGridView.Rows[e.RowIndex].ErrorText =
                        "ContactName is a required field";
                    e.Cancel = true;
                }
                else
                    personDataGridView.Rows[e.RowIndex].ErrorText = "";
            }

        }

        private void ApplyStyleButton_Click(object sender, EventArgs e)
        {
            personDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
        }
    }
}
