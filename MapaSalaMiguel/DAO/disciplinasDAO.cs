using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using model.entidades;
using System.Data;

namespace MapaSala.DAO
{
    public class disciplinasDAO
    {
        private string LinhaConexao = "Server=LS05MPF;Database=AULA_DS;User Id=sa;Password=admsasql;";
        private SqlConnection Conexao;

        public disciplinasDAO()
        {
            Conexao = new SqlConnection(LinhaConexao);
        }

        public void Inserir(DisciplinasEntidade disciplina)
        {
            using (var conexao = new SqlConnection(LinhaConexao))
            {
                conexao.Open();
                string query = "INSERT INTO Disciplinas (Nome, Sigla, Ativo) VALUES (@nome, @sigla, @ativo)";
                using (var comando = new SqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@nome", disciplina.nome);
                    comando.Parameters.AddWithValue("@sigla", disciplina.sigla);
                    comando.Parameters.AddWithValue("@ativo", disciplina.ativo);

                    comando.ExecuteNonQuery();
                }
            }
        }


        public DataTable PreencherComboBox()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT Id, Nome FROM Disciplinas";

            using (var connection = new SqlConnection(LinhaConexao))
            {
                using (var adapter = new SqlDataAdapter(query, connection))
                {
                    try
                    {
                        adapter.Fill(dataTable);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erro ao acessar os dados: " + ex.Message);
                    }
                }
            }

            return dataTable;
        }

        public DataTable obterDisciplina()
        {
            DataTable dt = new DataTable();
            string query = "SELECT Id, Nome, Sigla, Ativo FROM Disciplinas ORDER BY Id DESC";

            using (var conexao = new SqlConnection(LinhaConexao))
            {
                conexao.Open();
                using (var comando = new SqlCommand(query, conexao))
                {
                    using (var leitura = comando.ExecuteReader())
                    {
                        foreach (var atributos in typeof(DisciplinasEntidade).GetProperties())
                        {
                            dt.Columns.Add(atributos.Name);
                        }

                        if (leitura.HasRows)
                        {
                            while (leitura.Read())
                            {
                                DisciplinasEntidade d = new DisciplinasEntidade();

                                d.ID = Convert.ToInt32(leitura[0]);
                                d.nome = leitura[1].ToString();
                                d.sigla = leitura[2].ToString();
                                d.ativo = Convert.ToBoolean( leitura[3]   );
                                

                                dt.Rows.Add(d.Linha());
                            }
                        }
                    }
                }
                conexao.Close();
            }

            return dt;
        }

        public DataTable pesquisar(string pesquisar)
        {
            DataTable dt = new DataTable();
            string query;

            if (string.IsNullOrEmpty(pesquisar))
            {
                query = "SELECT ID, nome, sigla, ativo FROM Disciplinas ORDER BY Id DESC";
            }
            else
            {
                query = "SELECT ID, nome, sigla, ativo FROM Disciplinas WHERE Nome LIKE @pesquisar ORDER BY Id DESC";
            }

            using (var conexao = new SqlConnection(LinhaConexao))
            {
                conexao.Open();
                using (var comando = new SqlCommand(query, conexao))
                {
                    if (!string.IsNullOrEmpty(pesquisar))
                    {
                        comando.Parameters.AddWithValue("@pesquisar", "%" + pesquisar + "%");
                    }

                    using (var leitura = comando.ExecuteReader())
                    {
                        foreach (var atributos in typeof(DisciplinasEntidade).GetProperties())
                        {
                            dt.Columns.Add(atributos.Name);
                        }

                        if (leitura.HasRows)
                        {
                            while (leitura.Read())
                            {
                                DisciplinasEntidade disciplinas = new DisciplinasEntidade
                                {
                                    ID = Convert.ToInt32(leitura["Id"]),
                                    nome = leitura["Nome"].ToString(),
                                    sigla = leitura["Sigla"].ToString(),
                                    ativo = Convert.ToBoolean(leitura["Ativo"])
                                };

                                dt.Rows.Add(disciplinas.Linha());
                            }
                        }
                    }
                }
            }

            return dt;
        }
    }
}
