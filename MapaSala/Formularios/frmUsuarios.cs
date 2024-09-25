using Model.Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace MapaSala.Formularios
{
    public partial class frmUsuarios : Form
    {
        DataTable dados;
        int LinhaSelecionada;
        public frmUsuarios()
        {
            InitializeComponent();
            dados = new DataTable();
            foreach (var atributos in typeof(UsuariosEntidade).GetProperties())
            {
                dados.Columns.Add(atributos.Name);
            }
            dtGridUsuarios.DataSource = dados;
        }
            private void LimparCampos()
        {
            numId.Value = 0;
            txtLogin.Text = "";
            txtSenha.Text = "";
            txtNome.Text = "";
            chkAtivo.Checked = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            UsuariosEntidade usuarios = new UsuariosEntidade();
            usuarios.Id = Convert.ToInt32(numId.Value);
            usuarios.Login = txtLogin.Text;
            usuarios.Senha = txtSenha.Text;
            usuarios.Nome = txtNome.Text;
            usuarios.Ativo = chkAtivo.Checked;

            dados.Rows.Add(usuarios.Linha());

            LimparCampos();
        }


        private void bntLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            dtGridUsuarios.Rows.RemoveAt(LinhaSelecionada);
        }

        private void dtGridUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LinhaSelecionada = e.RowIndex;
            numId.Value = Convert.ToInt32(dtGridUsuarios.Rows[LinhaSelecionada].Cells[0].Value);
            txtLogin.Text = dtGridUsuarios.Rows[LinhaSelecionada].Cells[1].Value.ToString();
            txtSenha.Text = dtGridUsuarios.Rows[LinhaSelecionada].Cells[2].Value.ToString();
            txtNome.Text = dtGridUsuarios.Rows[LinhaSelecionada].Cells[3].Value.ToString();
            chkAtivo.Checked = Convert.ToBoolean(dtGridUsuarios.Rows[LinhaSelecionada].Cells[4].Value);
            
        }

        private void tbnEditar_Click(object sender, EventArgs e)
        {
            DataGridViewRow editar = dtGridUsuarios.Rows[LinhaSelecionada];
            editar.Cells[0].Value = numId.Value;
            editar.Cells[1].Value = txtLogin.Text;
            editar.Cells[2].Value = txtSenha.Text;
            editar.Cells[3].Value = txtNome.Text;
            editar.Cells[4].Value = chkAtivo.Checked;
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
