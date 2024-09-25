using Model.Entidades;
using System;
using System.Data;
using System.Windows.Forms;
using MapaSala.DAO;
namespace MapaSala.Formularios
{
    public partial class frmDisciplinas : Form
    {
       
        DataTable dados;
        int LinhaSelecionada;
        DisciplinasDAO dao = new DisciplinasDAO();

        public frmDisciplinas()
        {
            InitializeComponent();
            dados = new DataTable();
            
            foreach (var atributos in typeof(DisciplinasEntidades).GetProperties())
            {
                dados.Columns.Add(atributos.Name);
            }
           
            dados.Rows.Add(1, "Matemática", "MAT",true);
            dados.Rows.Add(2, "Português", "PORT", true);
            dados.Rows.Add(3, "Física", "FIS", false);

            dtGridDisciplinas.DataSource = dados;

        }
        private void LimparCampos()
        {
            numId.Value = 0;
            txtSigla.Text = "";
            txtNome.Text = "";
            chkAtivo.Checked = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            DisciplinasEntidades disciplinas = new DisciplinasEntidades();
            disciplinas.Id = Convert.ToInt32(numId.Value);
            disciplinas.Nome = txtNome.Text;
            disciplinas.Sigla = txtSigla.Text;
            disciplinas.Ativo = chkAtivo.Checked;

            dados.Rows.Add( disciplinas.Linha() );

            LimparCampos();
          
        }

        private void bntLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            dtGridDisciplinas.Rows.RemoveAt(LinhaSelecionada);
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            DataGridViewRow editar = dtGridDisciplinas.Rows[LinhaSelecionada];
            editar.Cells[0].Value = numId.Value;
            editar.Cells[1].Value = txtNome.Text;
            editar.Cells[2].Value = txtSigla.Text;
            editar.Cells[3].Value = chkAtivo.Checked;

        }

        private void dtGridDisciplinas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LinhaSelecionada = e.RowIndex;
            numId.Value = Convert.ToInt32(dtGridDisciplinas.Rows[LinhaSelecionada].Cells[0].Value);
            txtNome.Text = dtGridDisciplinas.Rows[LinhaSelecionada].Cells[1].Value.ToString();
            txtSigla.Text = dtGridDisciplinas.Rows[LinhaSelecionada].Cells[2].Value.ToString();
            chkAtivo.Checked = Convert.ToBoolean(dtGridDisciplinas.Rows[LinhaSelecionada].Cells[3].Value);
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            dtGridDisciplinas.DataSource = dao.Pesquisar(txtPesquisar.Text);

        }

        private void frmDisciplinas_Load(object sender, EventArgs e)
        {

        }
    }
}
