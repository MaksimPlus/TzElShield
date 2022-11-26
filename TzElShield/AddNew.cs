using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TzElShield
{
    public partial class AddNew : Form
    {
        private Form1 _form1;
        public SqlConnection sqlconnection;
        public AddNew(Form1 form1)
        {
            _form1 = form1;
            InitializeComponent();
        }

        private void AddNew_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=WIN-KO2SB0F2137\SQLEXPRESS;Initial Catalog=ElShield;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            sqlconnection = new SqlConnection(ConnectionString);
            sqlconnection.Open();
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO [Employees] (TabelId, Name, Gender, DateBirthday, Division, Education, Employment) VALUES" +
                "(@TabelId, @Name, @Gender, @DateBirthday, @Division, @Education, @Employment)", sqlconnection);
            sqlCommand.Parameters.AddWithValue("TabelId", textBox1.Text);
            sqlCommand.Parameters.AddWithValue("Name", textBox2.Text);
            sqlCommand.Parameters.AddWithValue("Gender", CmbBGender.Text);
            sqlCommand.Parameters.AddWithValue("DateBirthday", dateTimePicker1.Value);
            sqlCommand.Parameters.AddWithValue("Division", comboBox2.Text);
            sqlCommand.Parameters.AddWithValue("Education", comboBox3.Text);
            sqlCommand.Parameters.AddWithValue("Employment", dateTimePicker2.Value);
            sqlCommand.ExecuteNonQuery();
            this.Visible = false;
            _form1.Visible = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //char ch = e.KeyChar;
            //if (!Char.IsDigit(ch) && ch != 8)
            //{
            //    e.Handled = true;
            //}
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            //char ch = e.KeyChar;
            //if (!Char.IsLetter(ch) && ch != 8 && !Char.IsWhiteSpace(ch))
            //{
            //    e.Handled = true;
            //}
        }
    }
    }

