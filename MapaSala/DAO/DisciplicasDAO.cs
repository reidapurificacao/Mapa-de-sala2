using System;
using Model.Entidades;
using System.Data.SqlClient;
using System.Data;

namespace MapaSala.DAO
{
    class DisciplinasDAO
    {
        private string LinhaConexao = "Server=LS05MPF;Database=AULA_DS;User Id=sa;Password=admsasql;";
        private SqlConnection Conexao;
        private string query;
        public DisciplinasDAO()
        {
            Conexao = new SqlConnection(LinhaConexao);
        }

 

        public void Inserir(DisciplinasEntidades disciplinas)
        {
            Conexao.Open();
            string query = "INSERT INTO Salas (Id, Nome, Sigla) VALUES (@Id, @Nome, @Sigla)";
            SqlCommand comando = new SqlCommand(query, Conexao);
            SqlParameter parametro0 = new SqlParameter("@Id", disciplinas.Id);
            SqlParameter parametro1 = new SqlParameter("@Nome", disciplinas.Nome);
            SqlParameter parametro2 = new SqlParameter("@Sigla", disciplinas.Sigla);

            comando.Parameters.Add(parametro0);
            comando.Parameters.Add(parametro1);
            comando.Parameters.Add(parametro2);

        }

        public DataTable PreencherComboBox()
        {
            DataTable dataTable = new DataTable();

            string query = "SELECT Id, Nome FROM Disciplinas";

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


        public DataTable ObterDisciplinas()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conexao = new SqlConnection(LinhaConexao))
            {
                conexao.Open();
                string query = "SELECT Id, Nome, Sigla FROM Salas ORDER BY Id DESC";
                using (SqlCommand comando = new SqlCommand(query, conexao))
                {
                    using (SqlDataReader leitura = comando.ExecuteReader())
                    {
                        dt.Columns.Add("Id", typeof(int));
                        dt.Columns.Add("Nome", typeof(string));
                        dt.Columns.Add("Sigla", typeof(string));

                        if (leitura.HasRows)
                        {
                            while (leitura.Read())
                            {
                                DataRow row = dt.NewRow();
                                row["Id"] = Convert.ToInt32(leitura["Id"]);
                                row["Nome"] = leitura["Nome"].ToString();
                                row["Sigla"] = leitura["Sigla"].ToString();
                                dt.Rows.Add(row);
                            }
                        }
                    }
                }
            }
            return dt;
        }
        public DataTable Pesquisar(string pesquisa)
        {
            DataTable dt = new DataTable();
            Conexao.Open();
            if (string.IsNullOrEmpty(pesquisa))
            {
                query = "SELECT id, Nome, Sigla FROM Disciplinas order by Id desc";
            }
            else
            {
                query = "SELECT id, Nome, Sigla FROM Disciplinas WHERE Nome LIKE '%" + pesquisa + "%' OR Sigla LIKE '%" + pesquisa + "%' OR id LIKE '%" + pesquisa + "%' ORDER BY id DESC";

            }
            SqlCommand comando = new SqlCommand(query, Conexao);

            SqlDataReader Leitura = comando.ExecuteReader();
            foreach (var atributos in typeof(DisciplinasEntidades).GetProperties())
            {
                dt.Columns.Add(atributos.Name);
            }
            if (Leitura.HasRows)
            {
                while (Leitura.Read())
                {
                    DisciplinasEntidades p = new DisciplinasEntidades();
                    p.Id = Convert.ToInt32(Leitura[0]);
                    p.Nome = Leitura[1].ToString();
                    p.Sigla = Leitura[2].ToString();
                    dt.Rows.Add(p.Linha());
                }
            }
            Conexao.Close();
            return dt;
        }

    }
}
