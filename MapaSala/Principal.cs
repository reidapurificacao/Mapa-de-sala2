using MapaSala.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MapaSala
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
 
        }

        private void btnCLiqueAqui_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void bntCalc2_Click(object sender, EventArgs e)
        {
    
        }

        private void bntSub_Click(object sender, EventArgs e)
        {
            int Num1 = Convert.ToInt32(numNum1.Value);
            int Num2 = Convert.ToInt32(numNum2.Value);
            int sub = Num1 - Num2;
            MessageBox.Show(sub.ToString());
        }

        private void btnAdi_Click(object sender, EventArgs e)
        {
            int Num1 = Convert.ToInt32(numNum1.Value);
            int Num2 = Convert.ToInt32(numNum2.Value);
            int sub = Num1 + Num2;
            MessageBox.Show(sub.ToString());
        }

        private void bntNum2_Click(object sender, EventArgs e)
        {
            int Num1 = Convert.ToInt32(numNum1.Value);
            int Num2 = Convert.ToInt32(numNum2.Value);
            int sub = Num1 * Num2;
            MessageBox.Show(sub.ToString());
        }

        private void cadastrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalas s = new frmSalas();
            s.ShowDialog();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bntDiv_Click_1(object sender, EventArgs e)
        {
            int Num1 = Convert.ToInt32(numNum1.Value);
            int Num2 = Convert.ToInt32(numNum2.Value);
            int sub = Num1 / Num2;
            MessageBox.Show(sub.ToString());
        }

        private void relatoriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProfessores s = new frmProfessores();
            s.ShowDialog();
        }

        private void disciplinasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDisciplinas s = new frmDisciplinas();
            s.ShowDialog();
        }

        private void horáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCursos s = new frmCursos();
            s.ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios s = new frmUsuarios();
            s.ShowDialog();
        }
        private void limpar()
        {
            numNum1.Value = 0;
            numNum2.Value = 0;

        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void numNum1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cursoDisciplinasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCursoDisciplina s = new FrmCursoDisciplina();
            s.ShowDialog();
        }
    }
}
