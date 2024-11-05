﻿
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace MapaSalaMiguel.Classes
{
    public class Usuarios
    {

        private SqlConnection Conexao = new SqlConnection("Server=LS05MPF;Database=AULA_DS;User Id=sa;Password=admsasql;");
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }

        public void Inserir()
        {
            Conexao.Open();
            string query = "Insert into Usuarios (Login , Senha, Ativo) " +
                "               Values (@login, @senha, @ativo) ";
            SqlCommand comando = new SqlCommand(query, Conexao);

            SqlParameter parametro1 = new SqlParameter("@login", Login);
            SqlParameter parametro2 = new SqlParameter("@senha", Senha);
            SqlParameter parametro3 = new SqlParameter("@ativo", Ativo);

            comando.Parameters.Add(parametro1);
            comando.Parameters.Add(parametro2);
            comando.Parameters.Add(parametro3);
            comando.ExecuteNonQuery();
            Conexao.Close();
        }

        public DataTable PreencherGrid()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT Id, Login, Ativo FROM Usuarios order by Id desc";
            Conexao.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, Conexao);
            try
            {
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao acessar os dados para preencher grid: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Conexao.Close();
            return dataTable;
        }

        public DataTable Pesquisar(string pesquisa)
        {
            DataTable dataTable = new DataTable();
            Conexao.Open();
            string query = "";
            if (string.IsNullOrEmpty(pesquisa))
            {
                query = "SELECT Id, Login, Ativo Nome FROM Usuarios order by Id desc";
            }
            else
            {
                query = "SELECT Id, Login, Ativo Nome FROM Usuarios Where Login like '%" + pesquisa + "%' Order by Id desc";
            }

            SqlDataAdapter adapter = new SqlDataAdapter(query, Conexao);
            try
            {
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao acessar os dados para preencher grid: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Conexao.Close();
            return dataTable;
        }

        public void Editar()
        {
            string query = "update Usuarios set Login = @login, Senha = @senha, Ativo = @ativo WHERE  Id = @id";
            Conexao.Open();
            SqlCommand comando = new SqlCommand(query, Conexao);
            comando.Parameters.Add(new SqlParameter("@login", Login));
            comando.Parameters.Add(new SqlParameter("@senha", Senha));
            comando.Parameters.Add(new SqlParameter("@ativo", Ativo));
            comando.Parameters.Add(new SqlParameter("@id", Id));
            int resposta = comando.ExecuteNonQuery();
            if (resposta == 1)
            {
                MessageBox.Show("Usuário Atualizado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Erro ao atualizar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Excluir()
        {
            string query = "Delete from Usuarios WHERE  Id = @id";
            Conexao.Open();
            SqlCommand comando = new SqlCommand(query, Conexao);
            comando.Parameters.Add(new SqlParameter("@id", Id));
            int resposta = comando.ExecuteNonQuery();
            if (resposta == 1)
            {
                MessageBox.Show("Usuário Excluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Erro ao excluir", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PesquisarPorId(int id)
        {
            DataTable dataTable = new DataTable();
            Conexao.Open();
            string query = "SELECT Id, Login, Senha, Ativo Nome FROM Usuarios Where Id = @id Order by Id desc";
            SqlCommand Comando = new SqlCommand(query, Conexao);
            Comando.Parameters.AddWithValue("@id", id);
            SqlDataReader resultado = Comando.ExecuteReader();

            if (resultado.Read())
            {
                Id = resultado.GetInt32(0);
                Login = resultado.GetString(1);
                Senha = resultado.GetString(2);
                Ativo = resultado.GetBoolean(3);
            }

            Conexao.Close();
        }
    }
}
