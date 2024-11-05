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
using MapaSala.Formularios.Editar;
using MapaSalaMiguel.formularios.Cadastrar;
using MapaSalaMiguel.Formularios.Cadastrar;

namespace MapaSalaMiguel.formularios
{
    public partial class FrmDisciplina : Form
    {
        DataTable dados;
        int LinhaSelecionada;
        disciplinasDAO dao = new disciplinasDAO();
        public FrmDisciplina()
        {
            InitializeComponent();
            dados = new DataTable();
            dtGridDisciplina.DataSource = dados;
            foreach (var atributos in typeof(DisciplinasEntidade).GetProperties())
            {
                dados.Columns.Add(atributos.Name);
            }
            dtGridDisciplina.DataSource = dao.obterDisciplina();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            DisciplinasEntidade disciplina = new DisciplinasEntidade();
            //disciplina.ID = Convert.ToInt32(txtboxId.Text);
            disciplina.nome = txtboxNome.Text;
            disciplina.sigla = txtboxSigla.Text;
            disciplina.ativo = chkboxAtivo.Checked;
            dao.Inserir(disciplina);
            dtGridDisciplina.DataSource = dao.obterDisciplina();
            limpar();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpar();
        }
        private void limpar()
        {
            txtboxNome.Text = "";
            txtboxId.Text = "";
            txtboxSigla.Text = "";
            chkboxAtivo.Checked = false;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            dtGridDisciplina.Rows.RemoveAt(LinhaSelecionada);
        }

        private void dtGridDisciplina_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LinhaSelecionada = e.RowIndex;
            txtboxId.Text = dtGridDisciplina.Rows[LinhaSelecionada].Cells[0].Value.ToString();
            txtboxNome.Text = dtGridDisciplina.Rows[LinhaSelecionada].Cells[1].Value.ToString();
            txtboxSigla.Text = dtGridDisciplina.Rows[LinhaSelecionada].Cells[2].Value.ToString();
            chkboxAtivo.Checked = Convert.ToBoolean(dtGridDisciplina.Rows[LinhaSelecionada].Cells[3].Value);
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            dtGridDisciplina.Rows[LinhaSelecionada].Cells[0].Value = txtboxId.Text;
            dtGridDisciplina.Rows[LinhaSelecionada].Cells[1].Value = txtboxNome.Text;
            dtGridDisciplina.Rows[LinhaSelecionada].Cells[2].Value = txtboxSigla.Text;
            dtGridDisciplina.Rows[LinhaSelecionada].Cells[3].Value = chkboxAtivo.Checked;
        }

        private void FrmDisciplina_Load(object sender, EventArgs e)
        {

        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            dtGridDisciplina.DataSource = dao.pesquisar(txtpesquisa.Text);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
     
        private void Fechou_Editar_FormClosed(object sender, FormClosedEventArgs e)
        {

            dtGridDisciplina.DataSource = dao.obterDisciplina();
        }

        private void dtGridDisciplina_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(
                    dtGridDisciplina.Rows[e.RowIndex].Cells[0].Value);


                frmEditarDisciplina editar = new frmEditarDisciplina(id);

                // Inscreve-se no evento
                editar.FormClosed += Fechou_Editar_FormClosed;

                editar.ShowDialog(); // Abre o formulário como um diálogo modal
            }
        }

        private void btnAdicionarDisciplina_Click(object sender, EventArgs e)
        {
            frmCadastrarDisciplina cadastro = new frmCadastrarDisciplina();
            cadastro.FormClosed += Fechou_Editar_FormClosed;
            cadastro.ShowDialog();
        }
    }
}
