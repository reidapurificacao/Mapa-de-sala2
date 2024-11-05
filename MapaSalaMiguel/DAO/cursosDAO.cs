using System;
using System.Data;
using System.Data.SqlClient;
using model.entidades;

namespace MapaSala.DAO
{
    public class CursosDAO
    {
        private string LinhaConexao = "Server=LS05MPF;Database=AULA_DS;User Id=sa;Password=admsasql;";

        public void Inserir(CursosEntidade curso)
        {
            using (SqlConnection conexao = new SqlConnection(LinhaConexao))
            {
                string query = "INSERT INTO Cursos (Nome, Turno, Sigla, Ativo) VALUES (@Nome, @Turno, @Sigla, @Ativo)";
                SqlCommand comando = new SqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@Nome", curso.Nome);
                comando.Parameters.AddWithValue("@Turno", curso.Turno);
                comando.Parameters.AddWithValue("@Sigla", curso.Sigla);
                comando.Parameters.AddWithValue("@Ativo", curso.Ativo);

                conexao.Open();
                comando.ExecuteNonQuery();
            }
        }

        public DataTable PreencherComboBox()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT Id, Nome FROM Cursos";

            using (SqlConnection connection = new SqlConnection(LinhaConexao))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                try
                {
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao acessar os dados: " + ex.Message);
                }
            }

            return dataTable;
        }

        public DataTable ObterCursos()
        {
            DataTable dt = new DataTable();
            string query = "SELECT Id, Nome, Turno, Sigla, Ativo FROM Cursos ORDER BY Id DESC";

            using (SqlConnection conexao = new SqlConnection(LinhaConexao))
            {
                SqlCommand comando = new SqlCommand(query, conexao);
                conexao.Open();
                SqlDataReader leitura = comando.ExecuteReader();

                foreach (var atributo in typeof(CursosEntidade).GetProperties())
                {
                    dt.Columns.Add(atributo.Name);
                }

                if (leitura.HasRows)
                {
                    while (leitura.Read())
                    {
                        CursosEntidade curso = new CursosEntidade
                        {
                            Id = Convert.ToInt32(leitura["Id"]),
                            Nome = leitura["Nome"].ToString(),
                            Turno = leitura["Turno"].ToString(),
                            Sigla = leitura["Sigla"].ToString(),
                            Ativo = Convert.ToBoolean(leitura["Ativo"])
                        };
                        dt.Rows.Add(curso.Linha());
                    }
                }
            }

            return dt;
        }

        public DataTable Pesquisar(string pesquisar)
        {
            DataTable dt = new DataTable();
            string query;

            if (string.IsNullOrEmpty(pesquisar))
            {
                query = "SELECT Id, Nome, Turno, Sigla, Ativo FROM Cursos ORDER BY Id DESC";
            }
            else
            {
                query = "SELECT Id, Nome, Turno, Sigla, Ativo FROM Cursos WHERE Nome LIKE @Pesquisar ORDER BY Id DESC";
            }

            using (SqlConnection conexao = new SqlConnection(LinhaConexao))
            {
                SqlCommand comando = new SqlCommand(query, conexao);
                if (!string.IsNullOrEmpty(pesquisar))
                {
                    comando.Parameters.AddWithValue("@Pesquisar", "%" + pesquisar + "%");
                }
                conexao.Open();
                SqlDataReader leitura = comando.ExecuteReader();

                foreach (var atributo in typeof(CursosEntidade).GetProperties())
                {
                    dt.Columns.Add(atributo.Name);
                }

                if (leitura.HasRows)
                {
                    while (leitura.Read())
                    {
                        CursosEntidade curso = new CursosEntidade
                        {
                            Id = Convert.ToInt32(leitura["Id"]),
                            Nome = leitura["Nome"].ToString(),
                            Turno = leitura["Turno"].ToString(),
                            Sigla = leitura["Sigla"].ToString(),
                            Ativo = Convert.ToBoolean(leitura["Ativo"])
                        };
                        dt.Rows.Add(curso.Linha());
                    }
                }
            }

            return dt;
        }
    }
}
