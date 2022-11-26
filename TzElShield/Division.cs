using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TzElShield
{
    public partial class Division : Form
    {
        private SqlConnection conn = null;
        private SqlCommandBuilder Builder = null;
        private SqlDataAdapter adapter = null;
        private DataSet dataSet = null;
        public Division()
        {
            conn = new SqlConnection(@"Data Source=WIN-KO2SB0F2137\SQLEXPRESS;Initial Catalog=ElShield;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            conn.Open();
            InitializeComponent();
            LoadDataDivision();
        }

        private void Division_Load(object sender, EventArgs e)
        {
            InitializeComponent();

        }
        private void LoadDataDivision()
        {
            try
            {
                adapter = new SqlDataAdapter("SELECT Id, Name, Division FROM Employees", conn);
                Builder = new SqlCommandBuilder(adapter);

                dataSet = new DataSet();

                adapter.Fill(dataSet, "Employees");
                dGVDivision.DataSource = dataSet.Tables["Employees"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
