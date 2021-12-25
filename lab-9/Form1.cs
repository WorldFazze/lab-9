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


namespace lab_9
{
    public partial class Form1 : Form
    {
        public SqlConnection sqlConnection = null;

        public SqlCommandBuilder sqlBuilder = null;

        public SqlDataAdapter sqlDataAdapter = null;

        public DataSet dataSet = null;

        public Form1()
        {
            InitializeComponent();            
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }
       int rowIndex;
       int rowIndex2;
        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;

            rowIndex2 = dataGridView1.Rows.Count - 2;
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
           Form2 newForm = new Form2();
           newForm.ShowDialog();
           ReloadData();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void создатьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.ShowDialog();
            ReloadData();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DataBank.Id = Convert.ToString(dataSet.Tables["Test"].Rows[rowIndex]["id"]);      

            Form3 newForm = new Form3();
             newForm.ShowDialog();
            ReloadData();                           
        }

        private void base__BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
        }

        public void LoadData()
        {
            try
            {
                sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Test", sqlConnection);

                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();

                dataSet = new DataSet();

                sqlDataAdapter.Fill(dataSet, "Test");

                dataGridView1.DataSource = dataSet.Tables["Test"];
            }
            catch(Exception ex)
                {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
        }


        public void ReloadData()
        {
            try
            {
                dataSet.Tables["Test"].Clear();
                sqlDataAdapter.Fill(dataSet, "Test");
                dataGridView1.DataSource = dataSet.Tables["Test"];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void Form1_Load(object sender, EventArgs e)
        {         
            sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\arsen\source\repos\lab-9\lab-9\Database2.mdf;Integrated Security=True");
            sqlConnection.Open();
            LoadData();
            dataGridView1.AutoGenerateColumns = true;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
        }

        private void base__DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {            
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {           
        }


        private void toolStripButton4_Click(object sender, EventArgs e)
        {           
                if (MessageBox.Show("Удалить строку с " + dataSet.Tables["Test"].Rows[rowIndex]["Фамилия"] +" "+ dataSet.Tables["Test"].Rows[rowIndex]["Имя"] + "?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlCommand commanddel = new SqlCommand($"EXEC [Delete] {Convert.ToString(dataSet.Tables["Test"].Rows[rowIndex]["id"])}", sqlConnection);

                commanddel.ExecuteNonQuery();
                    ReloadData();
                }           
        }

        private void удалитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить строку с " + dataSet.Tables["Test"].Rows[rowIndex]["Фамилия"] + " " + dataSet.Tables["Test"].Rows[rowIndex]["Имя"] + "?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlCommand commanddel = new SqlCommand($"EXEC [Delete] {Convert.ToString(dataSet.Tables["Test"].Rows[rowIndex]["id"])}", sqlConnection);
                commanddel.ExecuteNonQuery();
                ReloadData();
            }
        }

        private void изменитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBank.Id = Convert.ToString(dataSet.Tables["Test"].Rows[rowIndex]["id"]); 

            Form3 newForm = new Form3();
            newForm.ShowDialog();
            ReloadData();
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            rowIndex = e.RowIndex;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
//    sqlDataAdapter.Update(dataSet, "Test");