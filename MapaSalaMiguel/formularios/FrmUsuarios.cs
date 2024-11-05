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
using MapaSalaMiguel.formularios.Cadastrar;
using MapaSala.Formularios.Editar;
using MapaSala.Formularios.Cadastrar;
using MapaSalaMiguel.formularios.Editar;
using MapaSalaMiguel.Classes;

namespace MapaSalaMiguel.formularios
{
    public partial class FrmUsuarios : Form
    {
        DataTable dados;
        int LinhaSelecionada;
        usuarioDAO dao = new usuarioDAO();

        public FrmUsuarios()
        {
            InitializeComponent();
            dados = new DataTable();
            dtGridUsuarios.DataSource = dados;
            foreach (var atributos in typeof(UsuariosEntidade).GetProperties())
            {
                dados.Columns.Add(atributos.Name);
            }
            dtGridUsuarios.DataSource = dao.obterusuario();
        }
        private void FecharForm(object sender, FormClosedEventArgs e)
        {
            Usuarios u = new Usuarios();
            dtGridUsuarios.DataSource = u.PreencherGrid();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            UsuariosEntidade usuario = new UsuariosEntidade();
            usuario.Id = Convert.ToInt32(txtboxId.Text);
            usuario.Login = txtboxLogin.Text;
            usuario.Senha = txtboxSenha.Text;
            usuario.Nome = txtboxNome.Text;
            usuario.Ativo = chkboxAtivo.Checked;
            dao.Inserir(usuario); // Insere o usuário na base de dados
            dtGridUsuarios.DataSource = dao.obterusuario(); // Atualiza o DataGrid
            limpar();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void limpar()
        {
            txtboxId.Text = "";
            txtboxLogin.Text = "";
            txtboxNome.Text = "";
            txtboxSenha.Text = "";
            chkboxAtivo.Checked = false;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            dtGridUsuarios.Rows.RemoveAt(LinhaSelecionada);
        }

        private void dtGridUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LinhaSelecionada = e.RowIndex;
            txtboxId.Text = dtGridUsuarios.Rows[LinhaSelecionada].Cells[0].Value.ToString();
            txtboxLogin.Text = dtGridUsuarios.Rows[LinhaSelecionada].Cells[1].Value.ToString();
            txtboxNome.Text = dtGridUsuarios.Rows[LinhaSelecionada].Cells[2].Value.ToString();
            txtboxSenha.Text = dtGridUsuarios.Rows[LinhaSelecionada].Cells[3].Value.ToString();
            chkboxAtivo.Checked = Convert.ToBoolean(dtGridUsuarios.Rows[LinhaSelecionada].Cells[4].Value);
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            dtGridUsuarios.Rows[LinhaSelecionada].Cells[0].Value = txtboxId.Text;
            dtGridUsuarios.Rows[LinhaSelecionada].Cells[1].Value = txtboxLogin.Text;
            dtGridUsuarios.Rows[LinhaSelecionada].Cells[2].Value = txtboxNome.Text;
            dtGridUsuarios.Rows[LinhaSelecionada].Cells[3].Value = txtboxSenha.Text;
            dtGridUsuarios.Rows[LinhaSelecionada].Cells[4].Value = chkboxAtivo.Checked;
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            dtGridUsuarios.DataSource = dao.pesquisar(txtpesquisa.Text);
        }

        private void Fechou_Editar_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtGridUsuarios.DataSource = dao.obterusuario(); // Atualiza o DataGrid após fechamento do formulário de edição
        }

        private void dtGridDisciplina_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dtGridUsuarios.Rows[e.RowIndex].Cells[0].Value);
                frmEditarDisciplina editar = new frmEditarDisciplina(id);

                editar.FormClosed += Fechou_Editar_FormClosed;
                editar.ShowDialog();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCadastrarUsuario frm = new frmCadastrarUsuario();
            frm.FormClosed += Fechou_Editar_FormClosed;
            frm.ShowDialog();
        }

        private void dtGridUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(
                    dtGridUsuarios.Rows[e.RowIndex].Cells[0].Value);

                frmEditarUsuarios editar = new frmEditarUsuarios(id);

                // Inscreve-se no evento
                editar.FormClosed += FecharForm;
                editar.ShowDialog();
            }
        }
    }
}
