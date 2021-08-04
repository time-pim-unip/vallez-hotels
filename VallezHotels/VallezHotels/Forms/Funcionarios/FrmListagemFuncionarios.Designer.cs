
namespace VallezHotels
{
    partial class FrmListagemFuncionarios
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgFuncionarios = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkSomenteAtivos = new System.Windows.Forms.CheckBox();
            this.txtPesquisaNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNovoFuncionario = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFuncionarios)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgFuncionarios);
            this.groupBox1.Location = new System.Drawing.Point(12, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 351);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hospedes";
            // 
            // dgFuncionarios
            // 
            this.dgFuncionarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgFuncionarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgFuncionarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgFuncionarios.Location = new System.Drawing.Point(3, 16);
            this.dgFuncionarios.Name = "dgFuncionarios";
            this.dgFuncionarios.ReadOnly = true;
            this.dgFuncionarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFuncionarios.Size = new System.Drawing.Size(770, 332);
            this.dgFuncionarios.TabIndex = 0;
            this.dgFuncionarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFuncionarios_CellContentClick);
            this.dgFuncionarios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFuncionarios_CellDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chkSomenteAtivos);
            this.groupBox2.Controls.Add(this.txtPesquisaNome);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(630, 69);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pesquisa";
            // 
            // chkSomenteAtivos
            // 
            this.chkSomenteAtivos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSomenteAtivos.AutoSize = true;
            this.chkSomenteAtivos.Checked = true;
            this.chkSomenteAtivos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSomenteAtivos.Location = new System.Drawing.Point(524, 12);
            this.chkSomenteAtivos.Name = "chkSomenteAtivos";
            this.chkSomenteAtivos.Size = new System.Drawing.Size(100, 17);
            this.chkSomenteAtivos.TabIndex = 2;
            this.chkSomenteAtivos.Text = "Somente Ativos";
            this.chkSomenteAtivos.UseVisualStyleBackColor = true;
            this.chkSomenteAtivos.CheckedChanged += new System.EventHandler(this.chkSomenteAtivos_CheckedChanged);
            // 
            // txtPesquisaNome
            // 
            this.txtPesquisaNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPesquisaNome.Location = new System.Drawing.Point(6, 32);
            this.txtPesquisaNome.Name = "txtPesquisaNome";
            this.txtPesquisaNome.Size = new System.Drawing.Size(618, 20);
            this.txtPesquisaNome.TabIndex = 1;
            this.txtPesquisaNome.TextChanged += new System.EventHandler(this.txtPesquisaNome_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // btnNovoFuncionario
            // 
            this.btnNovoFuncionario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovoFuncionario.Image = global::VallezHotels.Properties.Resources.add;
            this.btnNovoFuncionario.Location = new System.Drawing.Point(661, 20);
            this.btnNovoFuncionario.Name = "btnNovoFuncionario";
            this.btnNovoFuncionario.Size = new System.Drawing.Size(124, 44);
            this.btnNovoFuncionario.TabIndex = 2;
            this.btnNovoFuncionario.Text = "Novo Funcionário";
            this.btnNovoFuncionario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNovoFuncionario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNovoFuncionario.UseVisualStyleBackColor = true;
            this.btnNovoFuncionario.Click += new System.EventHandler(this.btnNovoFuncionario_Click);
            // 
            // FrmListagemFuncionarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnNovoFuncionario);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmListagemFuncionarios";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Listagem Funcionarios";
            this.Load += new System.EventHandler(this.FrmListagemFuncionarios_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgFuncionarios)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkSomenteAtivos;
        private System.Windows.Forms.TextBox txtPesquisaNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNovoFuncionario;
        private System.Windows.Forms.DataGridView dgFuncionarios;
    }
}