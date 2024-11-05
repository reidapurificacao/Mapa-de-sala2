using model.entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapaSala.DAO;

namespace MapaSalaMiguel.formularios
{
    public partial class FrmCursos : Form
    {
        DataTable dados;
        int LinhaSelecionada;
        CursosDAO dao = new CursosDAO();
        public FrmCursos()
        {
            InitializeComponent();
            dados = new DataTable();
            dtGridCursos.DataSource = dados;
            foreach (var atributos in typeof(CursosEntidade).GetProperties())
            {
                dados.Columns.Add(atributos.Name);
            }
            dtGridCursos.DataSource = dao.ObterCursos();


        }

        private void chkboxVagas_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            CursosEntidade cursos = new CursosEntidade(); // arumar 
            //cursos.Id = Convert.ToInt32(txtboxId.Text);
            cursos.Nome = txtboxNome.Text;
            cursos.Turno = txtboxturno.Text;
            cursos.Sigla = txtboxsigla.Text;
            cursos.Ativo = chkboxativo.Checked;
            dao.Inserir(cursos);
            dtGridCursos.DataSource = dao.ObterCursos();
            limpar();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpar();
        }
        private void limpar()
        {
            txtboxId.Text = "";
            txtboxNome.Text = "";
            txtboxturno.Text = "";
            
            txtboxsigla.Text = "";
            chkboxativo.Checked = false;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            dtGridCursos.Rows.RemoveAt(LinhaSelecionada);

        }

        private void dtGridCursos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LinhaSelecionada = e.RowIndex;
            txtboxId.Text = dtGridCursos.Rows[LinhaSelecionada].Cells[0].Value.ToString();
            txtboxNome.Text = dtGridCursos.Rows[LinhaSelecionada].Cells[1].Value.ToString();
            txtboxturno.Text = dtGridCursos.Rows[LinhaSelecionada].Cells[2].Value.ToString();
            txtboxsigla.Text = dtGridCursos.Rows[LinhaSelecionada].Cells[3].Value.ToString();
            chkboxativo.Checked = Convert.ToBoolean(dtGridCursos.Rows[LinhaSelecionada].Cells[4].Value);
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            dtGridCursos.Rows[LinhaSelecionada].Cells[0].Value = txtboxId.Text;
            dtGridCursos.Rows[LinhaSelecionada].Cells[1].Value = txtboxNome.Text;
            dtGridCursos.Rows[LinhaSelecionada].Cells[2].Value = txtboxturno.Text;
            dtGridCursos.Rows[LinhaSelecionada].Cells[3].Value = txtboxsigla.Text;
            dtGridCursos.Rows[LinhaSelecionada].Cells[4].Value = chkboxativo.Checked;

        }

        private void FrmCursos_Load(object sender, EventArgs e)
        {

        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            dtGridCursos.DataSource = dao.Pesquisar(txtpesquisa.Text);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
