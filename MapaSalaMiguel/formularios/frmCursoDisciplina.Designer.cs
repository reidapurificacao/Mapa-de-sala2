
namespace MapaSalaMiguel.formularios
{
    partial class frmCursoDisciplina
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
            this.cbDisciplinas = new System.Windows.Forms.ComboBox();
            this.dtCursoDisciplina = new System.Windows.Forms.DataGridView();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxCursos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboperiodo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtCursoDisciplina)).BeginInit();
            this.SuspendLayout();
            // 
            // cbDisciplinas
            // 
            this.cbDisciplinas.FormattingEnabled = true;
            this.cbDisciplinas.Location = new System.Drawing.Point(178, 110);
            this.cbDisciplinas.Name = "cbDisciplinas";
            this.cbDisciplinas.Size = new System.Drawing.Size(121, 21);
            this.cbDisciplinas.TabIndex = 12;
            this.cbDisciplinas.SelectedIndexChanged += new System.EventHandler(this.cbDisciplinas_SelectedIndexChanged);
            // 
            // dtCursoDisciplina
            // 
            this.dtCursoDisciplina.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtCursoDisciplina.Location = new System.Drawing.Point(124, 170);
            this.dtCursoDisciplina.Name = "dtCursoDisciplina";
            this.dtCursoDisciplina.Size = new System.Drawing.Size(453, 150);
            this.dtCursoDisciplina.TabIndex = 11;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(307, 108);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionar.TabIndex = 10;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(388, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Cursos";
            // 
            // cbxCursos
            // 
            this.cbxCursos.FormattingEnabled = true;
            this.cbxCursos.Location = new System.Drawing.Point(391, 110);
            this.cbxCursos.Name = "cbxCursos";
            this.cbxCursos.Size = new System.Drawing.Size(121, 21);
            this.cbxCursos.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Disciplinas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(542, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Periodo";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // comboperiodo
            // 
            this.comboperiodo.FormattingEnabled = true;
            this.comboperiodo.Items.AddRange(new object[] {
            "1º MÓDULO IN",
            "2º MÓDULO IN",
            "3º MÓDULO ",
            "1º MÓDULO TARDE",
            "2º MÓDULO TARDE",
            "3º MÓDULO TARDE",
            "1º MÓDULO NOITE",
            "2º MÓDULO NOITE"});
            this.comboperiodo.Location = new System.Drawing.Point(545, 110);
            this.comboperiodo.Name = "comboperiodo";
            this.comboperiodo.Size = new System.Drawing.Size(121, 21);
            this.comboperiodo.TabIndex = 14;
            // 
            // frmCursoDisciplina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboperiodo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbDisciplinas);
            this.Controls.Add(this.dtCursoDisciplina);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxCursos);
            this.Controls.Add(this.label1);
            this.Name = "frmCursoDisciplina";
            this.Text = "frmCursoDisciplina";
            this.Load += new System.EventHandler(this.frmCursoDisciplina_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtCursoDisciplina)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDisciplinas;
        private System.Windows.Forms.DataGridView dtCursoDisciplina;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxCursos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboperiodo;
    }
}