using MapaSala.DAO;
using Model.Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace MapaSala.Formularios
{
    public partial class frmCursos : Form
    {
        CursoDAO dao = new CursoDAO();
        DataTable dados;
        int LinhaSelecionada;
        public frmCursos()
        {
            InitializeComponent();
            dados = new DataTable();
            foreach (var atributos in typeof(CursoEntidades).GetProperties())
            {
                dados.Columns.Add(atributos.Name);
            }
            dtGridCursos.DataSource = dados;
        }
        private void LimparCampos()
        {
            txtNome.Text = "";
            numId.Value = 0;
            txtSigla.Text = "";
            txtTurno.Text = "";
            chkAtivo.Checked = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            CursoEntidades curso = new CursoEntidades();
            curso.Id = Convert.ToInt32(numId.Value);
            curso.Nome = txtNome.Text;
            curso.Sigla = txtSigla.Text;
            curso.Turno = txtTurno.Text;
            curso.Ativo = chkAtivo.Checked;

            dados.Rows.Add(curso.Linha());

            LimparCampos();
        }
        private void bntLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void dtGridCursos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LinhaSelecionada = e.RowIndex;
            numId.Value = Convert.ToInt32(dtGridCursos.Rows[LinhaSelecionada].Cells[0].Value);
            txtNome.Text = dtGridCursos.Rows[LinhaSelecionada].Cells[1].Value.ToString();
            txtSigla.Text = dtGridCursos.Rows[LinhaSelecionada].Cells[2].Value.ToString();
            txtTurno.Text = dtGridCursos.Rows[LinhaSelecionada].Cells[3].Value.ToString();
            chkAtivo.Checked = Convert.ToBoolean(dtGridCursos.Rows[LinhaSelecionada].Cells[4].Value);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            dtGridCursos.Rows.RemoveAt(LinhaSelecionada);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DataGridViewRow editar = dtGridCursos.Rows[LinhaSelecionada];
            editar.Cells[0].Value = numId.Value;
            editar.Cells[1].Value = txtNome.Text;
            editar.Cells[2].Value = txtSigla.Text;
            editar.Cells[3].Value = txtTurno.Text;
            editar.Cells[4].Value = chkAtivo.Checked;

        }

        private void dtGridCursos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            dtGridCursos.DataSource = dao.Pesquisar(txtPesquisar.Text);
        }

        private void frmCursos_Load(object sender, EventArgs e)
        {

        }
    }
}
