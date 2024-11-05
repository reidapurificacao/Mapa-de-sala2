using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model.entidades;


namespace MapaSala.DAO
{
    public class CursoDisciplinaDAO
    {
        private string LinhaConexao = "Server=LS05MPF;Database=AULA_DS;User Id=sa;Password=admsasql;";
        private SqlConnection Conexao;
        public CursoDisciplinaDAO()
        {
            Conexao = new SqlConnection(LinhaConexao);
        }

        public void Inserir(CursoDisciplinaEntidade objeto)
        {
            Conexao.Open();
            string query = "Insert into Curso_Disciplina (Curso_Id , Disciplina_Id, Periodo) Values (@Curso_Id, @Disciplina_Id, @Periodo) ";
            SqlCommand comando = new SqlCommand(query, Conexao);

            SqlParameter parametro1 = new SqlParameter("@Curso_Id", objeto.CursoId);
            SqlParameter parametro2 = new SqlParameter("@Disciplina_Id", objeto.DisciplinaId);
            SqlParameter parametro3 = new SqlParameter("@Periodo", objeto.Periodo);

            comando.Parameters.Add(parametro1);
            comando.Parameters.Add(parametro2);
            comando.Parameters.Add(parametro3);
            comando.ExecuteNonQuery();
            Conexao.Close();


        }
        public DataTable ObterCursoDisciplina()
        {
            DataTable dt = new DataTable();
            Conexao.Open();
            string query = "SELECT C.Nome AS NomeCurso, D.Nome AS NomeDisciplina, cd.periodo " +
               "FROM CURSO_DISCIPLINA CD " +
               "INNER JOIN CURSOS C ON C.Id = CD.Curso_Id " +
               "INNER JOIN DISCIPLINAS D ON D.Id = CD.Disciplina_Id " +
               "ORDER BY CD.Id DESC";

            SqlCommand comando = new SqlCommand(query, Conexao);
            SqlDataReader Leitura = comando.ExecuteReader();
            
                dt.Columns.Add("NomeCurso");
                dt.Columns.Add("NomeDisciplina");
                dt.Columns.Add("Periodo");

            if (Leitura.HasRows)
            {
                while (Leitura.Read())
                {
                    CursoDisciplinaEntidade p = new CursoDisciplinaEntidade();
                    
                    p.NomeCurso = Leitura[0].ToString();
                    p.NomeDisciplina = Leitura[1].ToString();
                    p.Periodo = Leitura[2].ToString();
                    dt.Rows.Add(p.Linha());

                }
            }
            Conexao.Close();
            return dt;


        }
    }
}