using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Mysql_connect
{
    internal class ClassAcedreBD
    {
        String caminho = "server=localhost;uid=root;pwd='';database=clientes";
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader reader;
        MySqlDataAdapter adapter;
        public ClassAcedreBD()
        {
            conn = new MySqlConnection(caminho);

        }
        public void AbrirBD()
        {
            try
            {
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro na abertura da base de dados, " + ex.Message, "Erro");
                Application.Exit();

            }
           
        }
        public void InserirDados(String sql)
        {
            try
            {
                cmd = new MySqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                MessageBox.Show("Dados inseridos com sucesso", "INSERIR");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERRO na execução:" + ex.Message);
            }

        }
        public void ElminarDados(String sql)
        {
            try
            {
                cmd = new MySqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                MessageBox.Show("Dados elminados com sucesso", "INSERIR");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERRO na execução:" + ex.Message);
            }

        }
        public void AlterarDados(String sql)
        {
            try
            {
                cmd = new MySqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                MessageBox.Show("Dados alterados com sucesso", "INSERIR");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERRO na execução:" + ex.Message);
            }

        }
        public DataTable ConsultarDados(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new MySqlCommand(sql, conn);
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERRO na execução:" + ex.Message);
            }
            return dt;

        }
    }
}

