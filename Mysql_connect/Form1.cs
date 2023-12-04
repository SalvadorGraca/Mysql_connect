using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Mysql_connect
{
    public partial class Form1 : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;Username=root;password=");
        MySqlCommand command;
        MySqlDataReader mdr;
        ClassAcedreBD acedreBD = new ClassAcedreBD();
        public Form1()
        {
            InitializeComponent();
            acedreBD.AbrirBD();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult resposta;
            resposta = MessageBox.Show("certeza que queres sair?", "SAIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("por favor introduz um username", "Erro");
            }
            else
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Clientes.Clientes WHERE Username = '" + textBox1.Text + "'AND password = '" + textBox2.Text + "';";
                command = new MySqlCommand(selectQuery, connection);
                mdr = command.ExecuteReader();
                if (mdr.Read())
                {
                    string Myconnection2 = "server=localhost;port=3306;Username=root;password=";

                    MySqlConnection MyConn2 = new MySqlConnection(Myconnection2);
                    try
                    {
                        MyConn2.Open();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        if (MyConn2.State == ConnectionState.Open)
                        {
                            MyConn2.Close();
                        }
                    }
                    MessageBox.Show("Login Successful!");
                    this.Hide();
                    Form2 frm2 = new Form2();
                    frm2.ShowDialog();

                }
                else
                {

                    MessageBox.Show("Incorrect Login Information! Try again.");
                }

                connection.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please input Username and Password", "Error");
            }

            else
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Clientes.Clientes WHERE Username = '" + textBox1.Text + "';";
                command = new MySqlCommand(selectQuery, connection);
                mdr = command.ExecuteReader();
                if (mdr.Read())
                {
                    MessageBox.Show("Ja esta a ser utilizado");

                }
                else
                {

                    string connectionString = "server=127.0.0.1;port=3306;username=root;password=;database=loginform;";

                    MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                    try
                    {
                        databaseConnection.Open();
                        databaseConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        // Show any error message.
                        MessageBox.Show(ex.Message);
                    }

                    MessageBox.Show("Account Successfully Created!");
                }

                connection.Close();
            }
        }
    }
}

