
namespace VallezHotels
{
    partial class FrmListagemTipoQuarto
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
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNovoTipo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgTiposQuarto = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTiposQuarto)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtPesquisa);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 66);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pesquisa";
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPesquisa.Location = new System.Drawing.Point(6, 32);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(326, 22);
            this.txtPesquisa.TabIndex = 3;
            this.txtPesquisa.TextChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nome";
            // 
            // btnNovoTipo
            // 
            this.btnNovoTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovoTipo.Image = global::VallezHotels.Properties.Resources.add;
            this.btnNovoTipo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNovoTipo.Location = new System.Drawing.Point(356, 22);
            this.btnNovoTipo.Name = "btnNovoTipo";
            this.btnNovoTipo.Size = new System.Drawing.Size(136, 52);
            this.btnNovoTipo.TabIndex = 1;
            this.btnNovoTipo.Text = "Novo Tipo Quarto";
            this.btnNovoTipo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNovoTipo.UseVisualStyleBackColor = true;
            this.btnNovoTipo.Click += new System.EventHandler(this.btnNovoTipo_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgTiposQuarto);
            this.groupBox2.Location = new System.Drawing.Point(12, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(475, 232);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipos de Quarto";
            // 
            // dgTiposQuarto
            // 
            this.dgTiposQuarto.AllowUserToAddRows = false;
            this.dgTiposQuarto.AllowUserToDeleteRows = false;
            this.dgTiposQuarto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgTiposQuarto.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgTiposQuarto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTiposQuarto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTiposQuarto.Location = new System.Drawing.Point(3, 16);
            this.dgTiposQuarto.Name = "dgTiposQuarto";
            this.dgTiposQuarto.ReadOnly = true;
            this.dgTiposQuarto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTiposQuarto.Size = new System.Drawing.Size(469, 213);
            this.dgTiposQuarto.TabIndex = 0;
            this.dgTiposQuarto.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dgTiposQuarto.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTiposQuarto_CellDoubleClick);
            // 
            // FrmListagemTipoQuarto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 328);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnNovoTipo);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmListagemTipoQuarto";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Listagem Tipo de Quarto";
            this.Load += new System.EventHandler(this.FrmListagemTipoQuarto_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTiposQuarto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnNovoTipo;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgTiposQuarto;
    }
}