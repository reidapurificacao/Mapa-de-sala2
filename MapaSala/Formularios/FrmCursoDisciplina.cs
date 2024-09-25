using MapaSala.DAO;
using Model.Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace MapaSala.Formularios
{
    public partial class FrmCursoDisciplina : Form
    {
        DisciplinasDAO disciplinasDAO = new DisciplinasDAO(); // Cria uma instância da classe DisciplinasDAO
        CursoDAO cursoDAO = new CursoDAO();
        CursoDisciplinaDAO dao = new CursoDisciplinaDAO();

        private void AtualizaGrid(DataTable dados)
        {
            dtCursoDisciplina.DataSource = dados;
        }

        public FrmCursoDisciplina()
        {
            InitializeComponent();

            cbDisciplina.DataSource = disciplinasDAO.PreencherComboBox();
            cbDisciplina.DisplayMember = "Nome";
            cbDisciplina.ValueMember = "Id";

            cbxCursos.DataSource = cursoDAO.PreencherComboBox();
            cbxCursos.DisplayMember = "Nome";
            cbxCursos.ValueMember = "Id";

            AtualizaGrid(dao.ObterCursoDisciplina());
        }

        private void cbxCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            CursoDisciplinaDAO cursoDisciplinaDAO = new CursoDisciplinaDAO();
            CursoDisciplinaEntidade entidade = new CursoDisciplinaEntidade();
            entidade.CursoId = Convert.ToInt32(cbxCursos.SelectedValue);
            // entidade.DisciplinaID = Convert.ToInt32(cbDisciplina.SelectedValue);
            entidade.Periodo = cbPeriodo.SelectedItem.ToString();
            cursoDisciplinaDAO.Inserir(entidade);

            AtualizaGrid(dao.ObterCursoDisciplina());
        }

        private void label1_Click(object sender, EventArgs e)
        {
   
        }

        private void cbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void FrmCursoDisciplina_Load(object sender, EventArgs e)
        {

        }

    }
}
