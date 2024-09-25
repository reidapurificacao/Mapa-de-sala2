
namespace MapaSala.Formularios
{
    partial class FrmCursoDisciplina
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbxCursos = new System.Windows.Forms.ComboBox();
            this.dtCursoDisciplina = new System.Windows.Forms.DataGridView();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.txtDisciplinas = new System.Windows.Forms.Label();
            this.txtCursos = new System.Windows.Forms.Label();
            this.cbPeriodo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDisciplina = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtCursoDisciplina)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxCursos
            // 
            this.cbxCursos.FormattingEnabled = true;
            this.cbxCursos.Items.AddRange(new object[] {
            "Zé Coisado",
            "Mermão",
            "Fila",
            "Da "});
            this.cbxCursos.Location = new System.Drawing.Point(195, 36);
            this.cbxCursos.Name = "cbxCursos";
            this.cbxCursos.Size = new System.Drawing.Size(121, 21);
            this.cbxCursos.TabIndex = 1;
            this.cbxCursos.SelectedIndexChanged += new System.EventHandler(this.cbxCursos_SelectedIndexChanged);
            // 
            // dtCursoDisciplina
            // 
            this.dtCursoDisciplina.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtCursoDisciplina.Location = new System.Drawing.Point(343, 36);
            this.dtCursoDisciplina.Name = "dtCursoDisciplina";
            this.dtCursoDisciplina.Size = new System.Drawing.Size(445, 402);
            this.dtCursoDisciplina.TabIndex = 2;
            this.dtCursoDisciplina.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(195, 64);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionar.TabIndex = 3;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // txtDisciplinas
            // 
            this.txtDisciplinas.AutoSize = true;
            this.txtDisciplinas.Location = new System.Drawing.Point(67, 13);
            this.txtDisciplinas.Name = "txtDisciplinas";
            this.txtDisciplinas.Size = new System.Drawing.Size(57, 13);
            this.txtDisciplinas.TabIndex = 4;
            this.txtDisciplinas.Text = "Disciplinas";
            // 
            // txtCursos
            // 
            this.txtCursos.AutoSize = true;
            this.txtCursos.Location = new System.Drawing.Point(195, 12);
            this.txtCursos.Name = "txtCursos";
            this.txtCursos.Size = new System.Drawing.Size(39, 13);
            this.txtCursos.TabIndex = 5;
            this.txtCursos.Text = "Cursos";
            // 
            // cbPeriodo
            // 
            this.cbPeriodo.FormattingEnabled = true;
            this.cbPeriodo.Items.AddRange(new object[] {
            "1° Ano",
            "2° Ano",
            "3° Ano",
            "1° Modulo",
            "2° Modulo",
            "3° Modulo"});
            this.cbPeriodo.Location = new System.Drawing.Point(195, 110);
            this.cbPeriodo.Name = "cbPeriodo";
            this.cbPeriodo.Size = new System.Drawing.Size(121, 21);
            this.cbPeriodo.TabIndex = 6;
            this.cbPeriodo.SelectedIndexChanged += new System.EventHandler(this.cbPeriodo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(195, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Periodo";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbDisciplina
            // 
            this.cbDisciplina.FormattingEnabled = true;
            this.cbDisciplina.Items.AddRange(new object[] {
            "Matemática",
            "Português",
            "Física"});
            this.cbDisciplina.Location = new System.Drawing.Point(31, 36);
            this.cbDisciplina.Name = "cbDisciplina";
            this.cbDisciplina.Size = new System.Drawing.Size(121, 21);
            this.cbDisciplina.TabIndex = 8;
            // 
            // FrmCursoDisciplina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbDisciplina);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPeriodo);
            this.Controls.Add(this.txtCursos);
            this.Controls.Add(this.txtDisciplinas);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.dtCursoDisciplina);
            this.Controls.Add(this.cbxCursos);
            this.Name = "FrmCursoDisciplina";
            this.Text = "FrmCursoDisciplina";
            this.Load += new System.EventHandler(this.FrmCursoDisciplina_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtCursoDisciplina)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbxCursos;
        private System.Windows.Forms.DataGridView dtCursoDisciplina;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Label txtDisciplinas;
        private System.Windows.Forms.Label txtCursos;
        private System.Windows.Forms.ComboBox cbPeriodo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDisciplina;
    }
}