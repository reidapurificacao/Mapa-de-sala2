using System;
using Model.Entidades;
using System.Data.SqlClient;
using System.Data;

namespace MapaSala.DAO
{
    class SalasDAO
    {
        private string LinhaConexao = "Server=LS05MPF;Database=AULA_DS;User Id=sa;Password=admsasql;";
        private SqlConnection Conexao;
        private string query;
        public SalasDAO()
        {
            Conexao = new SqlConnection(LinhaConexao);
        }
        public void Inserir(SalasEntidades Salas)
        {
            Conexao.Open();
            string query = "insert into Salas (Id, Nome, NumComputadores, NumCadeiras, Disponivel, IsLab) values (@Nome, @NumeroComputadores,@NumeroCadeiras) ";
            SqlCommand comando = new SqlCommand(query, Conexao);
            SqlParameter parametro1 = new SqlParameter("@id", Salas.Id);
            SqlParameter parametro2 = new SqlParameter("@Nome", Salas.Nome);
            SqlParameter parametro3 = new SqlParameter("@NumeroComputadores", Salas.NumComputadores);
            SqlParameter parametro4 = new SqlParameter("@NumeroCadeiras", Salas.NumCadeiras);

            comando.Parameters.Add(parametro1);
            comando.Parameters.Add(parametro2);
            comando.Parameters.Add(parametro3);
            comando.Parameters.Add(parametro4);
            comando.ExecuteNonQuery();
            Conexao.Close();
        }
        public DataTable ObterSalas()
        {

            DataTable dt = new DataTable();
            Conexao.Open();
            string query = "SELECT Id, Nome, NumeroComputadores, NumeroCadeiras FROM Salas order by Id desc";
            SqlCommand comando = new SqlCommand(query, Conexao);

            SqlDataReader Leitura = comando.ExecuteReader();
            foreach (var atributos in typeof(SalasEntidades).GetProperties())
            {
                dt.Columns.Add(atributos.Name);
            }
            if (Leitura.HasRows)
            {
                while (Leitura.Read())
                {
                    SalasEntidades p = new SalasEntidades();
                    p.Id = Convert.ToInt32(Leitura[0]);
                    p.Nome= Leitura[1].ToString();
                    p.NumComputadores= Convert.ToInt32(Leitura[2]);
                    p.NumCadeiras = Convert.ToInt32(Leitura[3]);

                    dt.Rows.Add(p.Linha());
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
                query = "SELECT Id, Nome, NumeroComputadores, NumeroCadeiras FROM Salas order by Id desc";
            }
            else
            {
                query = "SELECT Id, Nome, NumeroComputadores, NumeroCadeiras FROM Salas WHERE Nome LIKE '%" + pesquisa + "%' OR NumeroComputadores LIKE '%" + pesquisa + "%' OR Id LIKE '%" + pesquisa + "%' OR NumeroCadeiras LIKE '%" + pesquisa + "%' ORDER BY id DESC";

            }
            SqlCommand comando = new SqlCommand(query, Conexao);

            SqlDataReader Leitura = comando.ExecuteReader();
            foreach (var atributos in typeof(SalasEntidades).GetProperties())
            {
                dt.Columns.Add(atributos.Name);
            }
            if (Leitura.HasRows)
            {
                while (Leitura.Read())
                {
                    SalasEntidades p = new SalasEntidades();
                    p.Id = Convert.ToInt32(Leitura[0]);
                    p.Nome = Leitura[1].ToString();
                    p.NumCadeiras = Convert.ToInt32(Leitura[2]);
                    p.NumComputadores = Convert.ToInt32(Leitura[3]);



                    dt.Rows.Add(p.Linha());
                }
            }
            Conexao.Close();
            return dt;
        }
    }
}
