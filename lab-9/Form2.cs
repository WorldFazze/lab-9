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
    public partial class Form2 : Form
    {
        public SqlConnection sqlConnection = null;

        public Form2()
        {
            InitializeComponent();

           sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\arsen\source\repos\lab-9\lab-9\Database2.mdf;Integrated Security=True");
           sqlConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
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
                    
                    if (resultSName == false)
                    {
                        
                        if (resultName == false)
                        {
                            
                            if (resultMName == false)
                            {


                                if (String.IsNullOrWhiteSpace(textBox3.Text))
                                {
                                    SqlCommand command = new SqlCommand($"EXEC [INSERT] {textBox2.Text},{textBox1.Text},' ',{textBox4.Text}", sqlConnection);
                                    command.ExecuteNonQuery();
                                    sqlConnection.Close();
                                    Close();

                                }
                                else
                                {

                                    SqlCommand command = new SqlCommand($"EXEC [INSERT] {textBox2.Text},{textBox1.Text},{textBox3.Text},{textBox4.Text}", sqlConnection);
                                    command.ExecuteNonQuery();
                                    sqlConnection.Close();
                                    Close();
                                }
                            } else
                            {
                                textBox8.BackColor = Color.Red;
                                textBox7.BackColor = Color.White;
                                textBox6.BackColor = Color.White;
                                textBox5.BackColor = Color.White;
                            }




                        }else
                        {
                            textBox6.BackColor = Color.Red;

                        }



                    }else

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

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}

