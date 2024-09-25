using MapaSala.DAO;
using Model.Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace MapaSala.Formularios
{
    public partial class frmSalas : Form
    {

        DataTable dados;
        int LinhaSelecionada;
        SalasDAO dao = new SalasDAO();
        public frmSalas()
        {
            InitializeComponent();
            dados = new DataTable();
            foreach (var atributos in typeof(SalasEntidades).GetProperties())
            {
                dados.Columns.Add(atributos.Name);
            }
            dtGridSalas.DataSource = dados;
        }
        private void LimparCampos()
        {
            numId.Value = 0;
            TxtNomeSala.Text = "";
            NumComputadores.Value = 0;
            numCadeiras.Value = 0;
            chkDisponivel.Checked = false;
            chkIsLab.Checked = false;
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SalasEntidades sala = new SalasEntidades();
            sala.Id = Convert.ToInt32(numId.Value);
            sala.Nome = TxtNomeSala.Text;
            sala.NumComputadores = Convert.ToInt32(NumComputadores.Value);
            sala.NumCadeiras = Convert.ToInt32(numCadeiras.Value);        
            sala.Disponivel = chkDisponivel.Checked;
            sala.IsLab = chkIsLab.Checked;

            dados.Rows.Add(sala.Linha());

            LimparCampos();
        }


        private void dtGridSalas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LinhaSelecionada = e.RowIndex;
            numId.Value = Convert.ToInt32(dtGridSalas.Rows[LinhaSelecionada].Cells[0].Value);
            TxtNomeSala.Text = dtGridSalas.Rows[LinhaSelecionada].Cells[1].Value.ToString();
            NumComputadores.Value = Convert.ToInt32(dtGridSalas.Rows[LinhaSelecionada].Cells[2].Value);
            numCadeiras.Value = Convert.ToInt32(dtGridSalas.Rows[LinhaSelecionada].Cells[3].Value);
            chkDisponivel.Checked = Convert.ToBoolean(dtGridSalas.Rows[LinhaSelecionada].Cells[4].Value);
            chkIsLab.Checked = Convert.ToBoolean(dtGridSalas.Rows[LinhaSelecionada].Cells[5].Value);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DataGridViewRow editar = dtGridSalas.Rows[LinhaSelecionada];
            editar.Cells[0].Value = numId.Value;
            editar.Cells[1].Value = TxtNomeSala.Text;
            editar.Cells[2].Value = NumComputadores.Value;
            editar.Cells[3].Value = numCadeiras.Value;
            editar.Cells[4].Value = chkDisponivel.Checked;
            editar.Cells[5].Value = chkIsLab.Checked;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            dtGridSalas.Rows.RemoveAt(LinhaSelecionada);
        }

        private void bntLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            dtGridSalas.DataSource = dao.Pesquisar(txtPesquisar.Text);
        }

        private void dtGridSalas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
