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
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Globalization;

namespace TzElShield
{


    using Excel = Microsoft.Office.Interop.Excel;
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlCommandBuilder sqlBuilder = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private SqlDataAdapter da = null;
        private DataSet Dataset = null;
        private SqlCommandBuilder sqlCommand = null;
        private DataSet dataSet = null;
        private bool newRowAdding = false;

        private AddNew Addnew;
        public Form1()
        {
            InitializeComponent();
            Addnew = new AddNew(this) { Visible = false };
        }
        private void LoadData()
        {
            try
            {
                sqlDataAdapter = new SqlDataAdapter("SELECT Id AS [Id], TabelId AS [Табельный номер], Name AS [ФИО], Gender AS [Пол], DateBirthday AS [Дата рождения], Division AS [Подразделение], Education AS [Образование], Employment AS [Дата трудоустройства], Dismissals [Дата увольнения], 'Delete' AS [Command] FROM Employees", sqlConnection);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();

                dataSet = new DataSet();

                sqlDataAdapter.Fill(dataSet, "Employees");
                dataGridView1.DataSource = dataSet.Tables["Employees"];
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[9, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ReloadData()
        {
            try
            {
                dataSet.Tables["Employees"].Clear();
                sqlDataAdapter.Fill(dataSet, "Employees");
                dataGridView1.DataSource = dataSet.Tables["Employees"];
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell cell = new DataGridViewLinkCell();
                    dataGridView1[9, i] = cell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(@"Data Source=WIN-KO2SB0F2137\SQLEXPRESS;Initial Catalog=ElShield;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            sqlConnection.Open();
            LoadData();
            LoadData2();
            LoadData3();

        }

        private void TsLUpdate_Click(object sender, EventArgs e)
        {
            ReloadData();
            ReloadData2();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 9)
                {
                    string task = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                    if (task == "Delete")
                    {
                        if (MessageBox.Show("Удалить этого пользователя?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            dataGridView1.Rows.RemoveAt(rowIndex);
                            dataSet.Tables["Employees"].Rows[rowIndex].Delete();
                            sqlDataAdapter.Update(dataSet, "Employees");

                        }
                    }
                    else if (task == "Update")
                    {
                        int r = e.RowIndex;
                        dataSet.Tables["Employees"].Rows[r]["Name"] = dataGridView1.Rows[r].Cells["Name"].Value;
                        dataSet.Tables["Employees"].Rows[r]["TabelId"] = dataGridView1.Rows[r].Cells["TabelId"].Value;
                        dataSet.Tables["Employees"].Rows[r]["Gender"] = dataGridView1.Rows[r].Cells["Gender"].Value;
                        dataSet.Tables["Employees"].Rows[r]["DateBirthday"] = dataGridView1.Rows[r].Cells["DateBirthday"].Value;
                        dataSet.Tables["Employees"].Rows[r]["Division"] = dataGridView1.Rows[r].Cells["Division"].Value;
                        dataSet.Tables["Employees"].Rows[r]["Education"] = dataGridView1.Rows[r].Cells["Education"].Value;
                        dataSet.Tables["Employees"].Rows[r]["Employment"] = dataGridView1.Rows[r].Cells["Employment"].Value;
                        //dataSet.Tables["Dismissals"].Rows[r]["Dismissals"] = dataGridView1.Rows[r].Cells["Employment"].Value;
                        sqlDataAdapter.Update(dataSet, "Employees");
                        dataGridView1.Rows[e.RowIndex].Cells[9].Value = "Delete";
                    }
                    ReloadData();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Addnew.Visible = true;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow editingRow = dataGridView1.Rows[rowIndex];
                    DataGridViewLinkCell cell = new DataGridViewLinkCell();
                    dataGridView1[9, rowIndex] = cell;
                    editingRow.Cells["Command"].Value = "Update";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);
            if (dataGridView1.CurrentCell.ColumnIndex == 2)
            {
                DateTimePicker dateTimePicker = e.Control as DateTimePicker;
                if (dateTimePicker != null)
                {
                    dateTimePicker.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
        }
        private void Column_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void LoadData2()
        {
            try
            {
                da = new SqlDataAdapter("SELECT TabelId, Name, Division,'20%' AS [Salary] FROM Employees WHERE Employment > '01.01.2019'", sqlConnection);
                sqlCommand = new SqlCommandBuilder(da);

                Dataset = new DataSet();

                da.Fill(Dataset, "Employees");
                dataGridView2.DataSource = Dataset.Tables["Employees"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ReloadData2()
        {
            try
            {
                Dataset.Tables["Employees"].Clear();
                da.Fill(Dataset, "Employees");
                dataGridView2.DataSource = Dataset.Tables["Employees"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

            Excel.Application xlapp = null;
            Excel.Workbooks workbooks = null;
            Excel.Workbook workbook = null;
                xlapp = new Excel.Application();
                xlapp.Visible = true;
                workbooks = xlapp.Workbooks;
                workbook = workbooks.Add();
                xlapp.Interactive = true;
                xlapp.EnableEvents = true;
                Excel.Worksheet ws = new Excel.Worksheet();
                ws = (Excel.Worksheet)xlapp.Sheets[1];
                ws.Name = "Повышение зарплаты";
                for (int i = 0; i <= dataGridView2.RowCount - 2; i++)
                {
                for (int j = 0; j <= dataGridView2.ColumnCount - 1; j++)
                    {
                        ws.Cells[i + 1, j + 1] = dataGridView2[j, i].Value.ToString();
                    }
                 }
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void образованиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Education education = new Education();
            education.Show();
        }

        private void подразделенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Division division = new Division();
            division.Show();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadData3()
        {
            try
            {
                da = new SqlDataAdapter("SELECT * FROM Employees WHERE Employment < '01.01.2019'", sqlConnection);
                sqlCommand = new SqlCommandBuilder(da);

                Dataset = new DataSet();

                da.Fill(Dataset, "Employees");
                dataGridView3.DataSource = Dataset.Tables["Employees"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
