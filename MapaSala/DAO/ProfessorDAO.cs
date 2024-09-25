using System;
using Model.Entidades;
using System.Data.SqlClient;
using System.Data;

namespace MapaSala.DAO
{
    class ProfessorDAO
    {
        private string LinhaConexao = "Server=LS05MPF;Database=AULA_DS;User Id=sa;Password=admsasql;";
        private SqlConnection Conexao;
        private string query;

        public ProfessorDAO() 
        { 
        Conexao = new SqlConnection(LinhaConexao);
        }
        public void Inserir(CursoEntidade professor)
        {
            Conexao.Open();
            string query = "insert into Professores (Id, Nome, Apelido) values (@nome, @apelido) ";
            SqlCommand comando = new SqlCommand(query, Conexao);
            SqlParameter parametro0 = new SqlParameter("@id", professor.Id);
            SqlParameter parametro1 = new SqlParameter("@nome",professor.Nome);
            SqlParameter parametro2 = new SqlParameter("@apelido",professor.Apelido);
            comando.Parameters.Add(parametro0);
            comando.Parameters.Add(parametro1);
            comando.Parameters.Add(parametro2);
            comando.ExecuteNonQuery();
            Conexao.Close();
        }
        public DataTable ObterProfessores()
        {

            DataTable dt = new DataTable();
            Conexao.Open();
            string query = "SELECT id, Nome, Apelido FROM Professores order by Id desc";
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
                    CursoEntidade p = new CursoEntidade();
                    p.Id = Convert.ToInt32(Leitura[0]);
                    p.Nome = Leitura[1].ToString();
                    p.Apelido = Leitura[2].ToString();
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
                query = "SELECT id, Nome, Apelido FROM Professores order by Id desc";
            }
            else
            {
                query = "SELECT id, Nome, Apelido FROM PROFESSORES WHERE Nome LIKE '%" + pesquisa + "%' OR Apelido LIKE '%" + pesquisa + "%' OR id LIKE '%" + pesquisa + "%' ORDER BY id DESC";

            }
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
                    CursoEntidade p = new CursoEntidade();
                    p.Id = Convert.ToInt32(Leitura[0]);
                    p.Nome = Leitura[1].ToString();
                    p.Apelido = Leitura[2].ToString();
                    dt.Rows.Add(p.Linha());
                }
            }
            Conexao.Close();
            return dt;
        }
    }
}
