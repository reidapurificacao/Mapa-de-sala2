using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using model.entidades;
using System.Data;

namespace MapaSala.DAO
{
    public class ProfessorDAO
    {
        // "LS05MPF" servidor em rede; "Localhost" próprio PC
        private string LinhaConexao = "Server=LS05MPF;Database=AULA_DS;User Id=sa;Password=admsasql;";
        private SqlConnection Conexao;
        public ProfessorDAO()
        {
            Conexao = new SqlConnection(LinhaConexao);
        }

        public void Inserir(ProfessoresEntidade professor)
        {
            Conexao.Open();
            string query = "Insert into Professores (Nome, Apelido) Values (@nome,@apelido)";
            SqlCommand comando = new SqlCommand(query, Conexao);
            SqlParameter parametro1 = new SqlParameter("@nome", professor.Nome);
            SqlParameter parametro2 = new SqlParameter("@apelido", professor.Apelido);
            comando.Parameters.Add(parametro1);
            comando.Parameters.Add(parametro2);
            comando.ExecuteNonQuery();
            Conexao.Close();
        }
        public DataTable PreencherComboBox()
        {
            DataTable dataTable = new DataTable();

            string query = "SELECT Id, Nome FROM Salas";

            using (SqlConnection connection = new SqlConnection(LinhaConexao))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                try
                {
                    // Preenche o DataTable com os dados da consulta
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    // Lida com erros, se necessário
                    throw new Exception("Erro ao acessar os dados: " + ex.Message);
                }
            }

            return dataTable;
        }
        public DataTable obterProfessor()
        {
            DataTable dt = new DataTable();
            Conexao.Open();
            string query = "Select * From Professores Order BY Id desc";
            SqlCommand comando = new SqlCommand(query, Conexao);
            
            SqlDataReader leitura = comando.ExecuteReader();
            foreach (var atributos in typeof(ProfessoresEntidade).GetProperties())
            {
                dt.Columns.Add(atributos.Name);
            }
            if (leitura.HasRows)
            {
                while (leitura.Read())
                {
                    ProfessoresEntidade professores = new ProfessoresEntidade();
                    professores.Id = Convert.ToInt32(leitura[0]);
                    professores.Nome = leitura[1].ToString();
                    professores.Apelido = leitura[2].ToString();
                    dt.Rows.Add(professores.Linha());

                   
                }
                
            }
            Conexao.Close();
            return dt;

        }
        public DataTable pesquisar(string pesquisar)
        {
            DataTable dt = new DataTable();
            Conexao.Open();
            string query = "";
            
            
            if (string.IsNullOrEmpty(pesquisar))
            {
                query = "SELECT Id,Nome,Apelido FROM Professores order by Id desc";
            }
            else
            {
                query = "SELECT Id,Nome,Apelido FROM Professores where Nome LIKE '%" + pesquisar + "%' Order by Id desc";
            }
            
            SqlCommand comando = new SqlCommand(query, Conexao);
            
            SqlDataReader leitura = comando.ExecuteReader();
            foreach (var atributos in typeof(ProfessoresEntidade).GetProperties())
            {
                dt.Columns.Add(atributos.Name);
            }
            if (leitura.HasRows)
            {
                while (leitura.Read())
                {
                    ProfessoresEntidade professores = new ProfessoresEntidade();
                    professores.Id = Convert.ToInt32(leitura[0]);
                    professores.Nome = leitura[1].ToString();
                    professores.Apelido = leitura[2].ToString();
                    dt.Rows.Add(professores.Linha());

                   
                }
            }
            Conexao.Close();
            return dt;
            
        }

        


    }
}


