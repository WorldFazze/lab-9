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
    public partial class Form3 : Form
    {
        public SqlConnection sqlConnection = null;

        SqlDataReader sqlDataReader = null;
        public Form3()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\arsen\source\repos\lab-9\lab-9\Database2.mdf;Integrated Security=True");
            sqlConnection.Open();

            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string command = string.Empty;
            SqlCommand sqlcommand = new SqlCommand($"EXEC [SELECT] {DataBank.Id}", sqlConnection);

            sqlDataReader = sqlcommand.ExecuteReader();


            while (sqlDataReader.Read())
            {
                textBox2.Text = ($"{sqlDataReader["Имя"]}");
                textBox4.Text = ($"{sqlDataReader["Телефон"]}");
                textBox1.Text = ($"{sqlDataReader["Фамлия"]}");
                textBox3.Text = ($"{sqlDataReader["Отчество"]}");
            }

            if (sqlDataReader != null)
            {
                sqlDataReader.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double  f;

            bool result1number = double.TryParse(textBox4.Text, out f);
            bool resultSName = double.TryParse(textBox1.Text, out f);
            bool resultName = double.TryParse(textBox2.Text, out f);
            bool resultMName = double.TryParse(textBox3.Text, out f);




            if ((String.IsNullOrWhiteSpace(textBox1.Text)) || (String.IsNullOrWhiteSpace(textBox2.Text)) || (String.IsNullOrWhiteSpace(textBox4.Text)))
            {
                if (String.IsNullOrWhiteSpace(textBox1.Text))
                {
                    textBox5.BackColor = Color.Red;
                }
                else
                {
                    textBox5.BackColor = Color.White;
                }
                if (String.IsNullOrWhiteSpace(textBox2.Text))
                {
                    textBox6.BackColor = Color.Red;
                }
                else
                {
                    textBox6.BackColor = Color.White;
                }
                if (String.IsNullOrWhiteSpace(textBox4.Text))
                {
                    textBox7.BackColor = Color.Red;
                }
                else
                {
                    textBox7.BackColor = Color.White;
                }
            }
            else
            {
                if (result1number == true)
                {
                    textBox7.BackColor = Color.White;

                    if (resultSName == false)
                    {
                        textBox5.BackColor = Color.White;

                        if (resultName == false)
                        {
                            textBox6.BackColor = Color.White;

                            if (resultMName == false)
                            {
                                textBox8.BackColor = Color.White;


                                if (String.IsNullOrWhiteSpace(textBox3.Text))
                                {
                                    SqlCommand sqlcommandupdate = new SqlCommand($"EXEC [UPDATE] {DataBank.Id},{textBox2.Text}, {textBox1.Text},' ', {textBox4.Text}"
                                            , sqlConnection);

                                    sqlcommandupdate.ExecuteNonQuery();
                                    sqlConnection.Close();
                                    Close();

                                }
                                else
                                {


                                    SqlCommand sqlcommandupdate = new SqlCommand($"EXEC [UPDATE] {DataBank.Id},{textBox2.Text},{textBox1.Text},{textBox3.Text},{textBox4.Text}"
                                            , sqlConnection);

                                    sqlcommandupdate.ExecuteNonQuery();
                                    sqlConnection.Close();
                                    Close();
                                }
                            }
                            else
                            {
                                textBox8.BackColor = Color.Red;
                                textBox7.BackColor = Color.White;
                                textBox6.BackColor = Color.White;
                                textBox5.BackColor = Color.White;
                            }




                        }
                        else
                        {
                            textBox6.BackColor = Color.Red;

                        }



                    }
                    else

                    {
                        textBox5.BackColor = Color.Red;
                    }
                }
                else
                {
                    textBox7.BackColor = Color.Red;
                }







            }




        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

