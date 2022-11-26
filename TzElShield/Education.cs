using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TzElShield
{
    public partial class Education : Form
    {
        private SqlConnection conn = null;
        private SqlCommandBuilder Builder = null;
        private SqlDataAdapter adapter = null;
        private DataSet dataSet = null;
        public Education()
        {
            conn = new SqlConnection(@"Data Source=WIN-KO2SB0F2137\SQLEXPRESS;Initial Catalog=ElShield;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            conn.Open();
            InitializeComponent();
            LoadDataEducation();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Education_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=WIN-KO2SB0F2137\SQLEXPRESS;Initial Catalog=ElShield;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            conn.Open();
            InitializeComponent();
            LoadDataEducation();
        }
        private void LoadDataEducation()
        {
            try
            {
                adapter = new SqlDataAdapter("SELECT Id, Name, Education FROM Employees", conn);
                Builder = new SqlCommandBuilder(adapter);

                dataSet = new DataSet();

                adapter.Fill(dataSet, "Employees");
                dGVEducation.DataSource = dataSet.Tables["Employees"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
