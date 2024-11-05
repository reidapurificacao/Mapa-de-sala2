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

namespace MapaSala.Formularios
{
    public partial class frmSalas : Form
    {
        DataTable dados;
        int LinhaSelecionada;
        salasDAO dao = new salasDAO();
        public frmSalas()
        {
            InitializeComponent();
            dados = new DataTable();
            dtGridSalas.DataSource = dados;
            foreach (var atributos in typeof(SalasEntidades).GetProperties())
            {
                //return new object[] { Id, Periodo, periodo, Nome,NumeroComputador,IsLab,  NumeroCadeiras,Disponivel };
                dados.Columns.Add(atributos.Name);
            }
            dtGridSalas.DataSource = dao.obtersala();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SalasEntidades sala = new SalasEntidades();
            //sala.Id = Convert.ToInt32(txtboxId.Text);
           
            sala.Nome = txtnomesala.Text;
            
            sala.NumeroCadeiras = Convert.ToInt32(numCadeiras.Value);
            sala.Disponivel = chkDisponivel.Checked;
            sala.NumeroComputadores = Convert.ToInt32(numComputadores.Value);
            
            sala.IsLab = chkLaboratorio.Checked;

            dao.Inserir(sala);
            dtGridSalas.DataSource = dao.obtersala();
            limpar();

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpar();
        }
        private void limpar()
        {
         
            txtnomesala.Text = "";
            numCadeiras.Text = "";
            numComputadores.Text = "";
            chkDisponivel.Checked = false;
            chkLaboratorio.Checked = false;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            dtGridSalas.Rows.RemoveAt(LinhaSelecionada);
        }

        private void dtGridSalas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LinhaSelecionada = e.RowIndex;
            
            
            txtnomesala.Text = dtGridSalas.Rows[LinhaSelecionada].Cells[3].Value.ToString();
            numComputadores.Text = dtGridSalas.Rows[LinhaSelecionada].Cells[4].Value.ToString();
            chkDisponivel.Checked = Convert.ToBoolean(dtGridSalas.Rows[LinhaSelecionada].Cells[7].Value);
            numCadeiras.Text = dtGridSalas.Rows[LinhaSelecionada].Cells[6].Value.ToString();
            chkLaboratorio.Checked = Convert.ToBoolean(dtGridSalas.Rows[LinhaSelecionada].Cells[5].Value);
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
          
            dtGridSalas.Rows[LinhaSelecionada].Cells[3].Value = txtnomesala.Text;
            dtGridSalas.Rows[LinhaSelecionada].Cells[4].Value = numComputadores.Value.ToString(); 
            dtGridSalas.Rows[LinhaSelecionada].Cells[7].Value = chkDisponivel.Checked;
            dtGridSalas.Rows[LinhaSelecionada].Cells[6].Value = numCadeiras.Value.ToString(); 
            dtGridSalas.Rows[LinhaSelecionada].Cells[5].Value = chkLaboratorio.Checked;
        }

        private void frmSalas_Load(object sender, EventArgs e)
        {

        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            dtGridSalas.DataSource = dao.pesquisar(txtpesquisa.Text);

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
