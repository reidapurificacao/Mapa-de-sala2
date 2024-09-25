using System;
using Model.Entidades;
using System.Data.SqlClient;
using System.Data;

namespace MapaSala.DAO
{
    public class UsuariosDAO
    {
        private string LinhaConexao = "Server=LS05MPF;Database=AULA_DS;User Id=sa;Password=admsasql;";
        private SqlConnection Conexao;
        private object usuarios;

        public UsuariosDAO()
        {
            Conexao = new SqlConnection(LinhaConexao);
        }
        public void Inserir(UsuariosEntidade usuarios)
        {
            Conexao.Open();
            string query = "insert into Salas (Id, Login, Senha, Nome, Ativo) values (@, @) ";
            SqlCommand comando = new SqlCommand(query, Conexao);
            SqlParameter parametro1 = new SqlParameter("@Id", usuarios.Id);
            SqlParameter parametro2 = new SqlParameter("@Login", usuarios.Login);
            SqlParameter parametro3 = new SqlParameter("@Senha", usuarios.Senha);
            SqlParameter parametro4 = new SqlParameter("@Nome", usuarios.Nome);
            SqlParameter parametro5 = new SqlParameter("@Ativo", usuarios.Ativo);
            comando.Parameters.Add(parametro1);
            comando.Parameters.Add(parametro2);
            comando.Parameters.Add(parametro3);
            comando.Parameters.Add(parametro4);
            comando.Parameters.Add(parametro5);
            comando.ExecuteNonQuery();
            Conexao.Close();
        }
        public DataTable ObterProfessores()
        {

            DataTable dt = new DataTable();
            Conexao.Open();
            string query = "SELECT Id, Login, Senha, Nome, Ativo  FROM Salas order by Id desc";
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
                    UsuariosEntidade p = new UsuariosEntidade();
                    p.Id = Convert.ToInt32(Leitura[0]);
                    p.Login = Leitura[1].ToString();
                    p.Senha = Leitura[2].ToString();
                    p.Nome = Leitura[3].ToString();
                    p.Ativo = Convert.ToBoolean(Leitura[4].ToString());

                    dt.Rows.Add(p.Linha());
                }
            }
            Conexao.Close();
            return dt;
        }

    }
}
