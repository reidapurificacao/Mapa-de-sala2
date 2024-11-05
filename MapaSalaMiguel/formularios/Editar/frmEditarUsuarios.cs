using MapaSalaMiguel.Classes;
using MapaSalaMiguel.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MapaSalaMiguel.formularios.Editar
{
    public partial class frmEditarUsuarios : Form
    {
        public frmEditarUsuarios(int Id)
        {
            InitializeComponent();
            Usuarios usuarios = new Usuarios();
            usuarios.PesquisarPorId(Id);
            txtId.Text = usuarios.Id.ToString();
            txtLogin.Text = usuarios.Login;
            txtSenha.Text = usuarios.Senha;
            chkAtivo.Checked = usuarios.Ativo;
            usuarios = null;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            usuarios.Id = Convert.ToInt32(txtId.Text);
            usuarios.Login = txtLogin.Text;
            usuarios.Senha = txtSenha.Text;
            usuarios.Ativo = chkAtivo.Checked;
            usuarios.Editar();
            usuarios = null;
            this.Close();

        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            usuarios.Id = Convert.ToInt32(txtId.Text);
            usuarios.Excluir();
            this.Close();
        }

        private void frmEditarUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void btn_excluir_Click_1(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            usuarios.Id = Convert.ToInt32(txtId.Text);
            usuarios.Excluir();
            this.Close();
        }

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {

            Usuarios usuarios = new Usuarios();
            usuarios.Id = Convert.ToInt32(txtId.Text);
            usuarios.Login = txtLogin.Text;
            usuarios.Senha = txtSenha.Text;
            usuarios.Ativo = chkAtivo.Checked;
            usuarios.Editar();
            usuarios = null;
            this.Close();
        }
    }
}
