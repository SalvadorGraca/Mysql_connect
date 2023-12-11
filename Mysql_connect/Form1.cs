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

        ClassAcedreBD acederBD = new ClassAcedreBD();
        DataTable dt = new DataTable();
        Form2 form2 = new Form2();
        public Form1()
        {
            InitializeComponent();
            acederBD.AbrirBD();
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
                acederBD.FecharBD();
                acederBD.AbrirBD();
                string login = "SELECT * FROM clientes.clientes WHERE Username like '" + textBox1.Text + "' AND password like '" + textBox2.Text + "';";
                dt = acederBD.ConsultarDados(login);
                if(dt.Rows.Count == 0)
                {
                    MessageBox.Show("Não existe na nossa base de dados", "ERRO");
                }
                else
                {
                    this.Hide();
                    Form2 form2 = new Form2();
                    form2.ShowDialog();
                }
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Introduz um Nome e uma password", "Error");
            }
            else
            {
                acederBD.FecharBD();
                acederBD.AbrirBD();
                string registar = "INSERT INTO clientes (Username,password) VALUES ('" + textBox1.Text + "','"+textBox2.Text+"');";
                acederBD.InserirDados(registar);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
           
        }
    }
}

