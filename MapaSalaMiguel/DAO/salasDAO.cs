using System;
using System.Data;
using System.Data.SqlClient;
using model.entidades;

namespace MapaSala.DAO
{
    public class salasDAO
    {
        private readonly string LinhaConexao = "Server=LS05MPF;Database=AULA_DS;User Id=sa;Password=admsasql;";

        public void Inserir(SalasEntidades salas)
        {
            using (var conexao = new SqlConnection(LinhaConexao))
            {
                conexao.Open();
                string query = "INSERT INTO Salas (Nome, IsLab, NumeroComputadores, NumeroCadeiras, Disponivel) VALUES (@Nome, @IsLab, @NumeroComputadores, @NumeroCadeiras, @Disponivel)";

                using (var comando = new SqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@Nome", salas.Nome);
                    comando.Parameters.AddWithValue("@IsLab", salas.IsLab);
                    comando.Parameters.AddWithValue("@NumeroComputadores", salas.NumeroComputadores);
                    comando.Parameters.AddWithValue("@NumeroCadeiras", salas.NumeroCadeiras);
                    comando.Parameters.AddWithValue("@Disponivel", salas.Disponivel);

                    comando.ExecuteNonQuery();
                }
            }
        }

        public DataTable PreencherComboBox()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT Id, Nome FROM Salas";

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

        public DataTable obtersala()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Salas ORDER BY Id DESC";

            var conexao = new SqlConnection(LinhaConexao);
            conexao.Open();
            SqlCommand comando = new SqlCommand(query, conexao);
            var reader = comando.ExecuteReader();
            dt.Load(reader);
            reader.Close();
            conexao.Close();

            

            return dt;
        }

        public DataTable pesquisar(string pesquisar)
        {
            DataTable dt = new DataTable();
            string query = string.IsNullOrEmpty(pesquisar) ?
                "SELECT Id, Nome,  NumeroComputadores, IsLab, NumeroCadeiras, Disponivel FROM Salas ORDER BY Id DESC" :
                "SELECT Id,  Nome, NumeroComputadores, IsLab, NumeroCadeiras, Disponivel FROM Salas WHERE Nome LIKE @pesquisar ORDER BY Id DESC";

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
                        foreach (var atributos in typeof(SalasEntidades).GetProperties())
                        {
                            dt.Columns.Add(atributos.Name);
                        }

                        if (leitura.HasRows)
                        {
                            while (leitura.Read())
                            {
                                SalasEntidades salas = new SalasEntidades
                                {
                                    
                                    
                                    Nome = leitura["Nome"].ToString(),
                                   
                                    NumeroComputadores = Convert.ToInt32(leitura["NumeroComputadores"]),
                                    IsLab = Convert.ToBoolean(leitura["IsLab"]),
                                    NumeroCadeiras = Convert.ToInt32(leitura["NumeroCadeiras"]),
                                    Disponivel = Convert.ToBoolean(leitura["Disponivel"])
                                };

                                dt.Rows.Add(salas.Linha());
                            }
                        }
                    }
                }
            }

            return dt;
        }
    }
}
