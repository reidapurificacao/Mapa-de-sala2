using System;
using Model.Entidades;
using System.Data.SqlClient;
using System.Data;

namespace MapaSala.DAO
{
    class CursoDAO
    {
        private string LinhaConexao = "Server=LS05MPF;Database=AULA_DS;User Id=sa;Password=admsasql;";
        private SqlConnection Conexao;
        private string query;
        public CursoDAO()
        {
            Conexao = new SqlConnection(LinhaConexao);
        }
        public void Inserir(CursoEntidades curso)
        {
            Conexao.Open();
            string query = "insert into Curso (Id, Nome, Sigla, Turno, Ativo) values (@id, @nome, @sigla, @turno, @ativo) ";
            SqlCommand comando = new SqlCommand(query, Conexao);
            SqlParameter parametro0 = new SqlParameter("@id", curso.Id);
            SqlParameter parametro1 = new SqlParameter("@nome", curso.Nome);
            SqlParameter parametro2 = new SqlParameter("@sigla", curso.Turno);
            SqlParameter parametro3 = new SqlParameter("@turno", curso.Sigla);
            SqlParameter parametro4 = new SqlParameter("@ativo", curso.Ativo);
            comando.Parameters.Add(parametro0);
            comando.Parameters.Add(parametro1);
            comando.Parameters.Add(parametro2);
            comando.Parameters.Add(parametro3);
            comando.Parameters.Add(parametro4);
            comando.ExecuteNonQuery();
            Conexao.Close();
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
            Conexao.Open();
            string query = "SELECT id, Nome, Sigla, Turno, Ativo FROM Curso order by Id desc";
            SqlCommand comando = new SqlCommand(query, Conexao);

            SqlDataReader Leitura = comando.ExecuteReader();
            foreach (var atributos in typeof(CursoEntidade).GetProperties())
            {
                dt.Columns.Add(atributos.Name);
            }
            if (Leitura.HasRows)
            {
                while (Leitura.Read())
                {
                    CursoEntidades p = new CursoEntidades();
                    p.Id = Convert.ToInt32(Leitura[0]);
                    p.Nome = Leitura[1].ToString();
                    p.Sigla = Leitura[2].ToString();
                    p.Turno = Leitura[3].ToString();
                    p.Ativo = Convert.ToBoolean(Leitura[4]);

                    dt.Rows.Add(p.Linha());
                }
            }
            Conexao.Close();
            return dt;
        }
        public DataTable Pesquisar(string pesquisa)
        {
            DataTable dt = new DataTable();
            Conexao.Open();
            if (string.IsNullOrEmpty(pesquisa))
            {
                query = "SELECT id, Nome, Sigla,Turno FROM Cursos order by Id desc";
            }
            else
            {
                query = "SELECT id, Nome, Sigla, Turno FROM Cursos WHERE Nome LIKE '%" + pesquisa + "%' OR Sigla LIKE '%" + pesquisa + "%' OR id LIKE '%" + pesquisa + "%' OR Turno LIKE '%" + pesquisa + "%' ORDER BY id DESC";

            }
            SqlCommand comando = new SqlCommand(query, Conexao);

            SqlDataReader Leitura = comando.ExecuteReader();
            foreach (var atributos in typeof(CursoEntidades).GetProperties())
            {
                dt.Columns.Add(atributos.Name);
            }
            if (Leitura.HasRows)
            {
                while (Leitura.Read())
                {
                    CursoEntidades p = new CursoEntidades();
                    p.Id = Convert.ToInt32(Leitura[0]);
                    p.Nome = Leitura[1].ToString();
                    p.Sigla = Leitura[2].ToString();
                    p.Turno = Leitura[3].ToString();


                    dt.Rows.Add(p.Linha());
                }
            }
            Conexao.Close();
            return dt;
        }

    }
}
