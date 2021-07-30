
namespace VallezHotels
{
    partial class FrmListagemQuartos
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
            this.txtPesquisaNumero = new System.Windows.Forms.TextBox();
            this.txtPesquisaBloco = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNovoQuarto = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgQuartos = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgQuartos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtPesquisaNumero);
            this.groupBox1.Controls.Add(this.txtPesquisaBloco);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 66);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pesquisa";
            // 
            // txtPesquisaNumero
            // 
            this.txtPesquisaNumero.Location = new System.Drawing.Point(112, 32);
            this.txtPesquisaNumero.Name = "txtPesquisaNumero";
            this.txtPesquisaNumero.Size = new System.Drawing.Size(100, 20);
            this.txtPesquisaNumero.TabIndex = 2;
            this.txtPesquisaNumero.TextChanged += new System.EventHandler(this.txtPesquisaNumero_TextChanged);
            // 
            // txtPesquisaBloco
            // 
            this.txtPesquisaBloco.Location = new System.Drawing.Point(6, 32);
            this.txtPesquisaBloco.Name = "txtPesquisaBloco";
            this.txtPesquisaBloco.Size = new System.Drawing.Size(100, 20);
            this.txtPesquisaBloco.TabIndex = 1;
            this.txtPesquisaBloco.TextChanged += new System.EventHandler(this.txtPesquisaBloco_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Numero";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bloco";
            // 
            // btnNovoQuarto
            // 
            this.btnNovoQuarto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovoQuarto.Image = global::VallezHotels.Properties.Resources.add;
            this.btnNovoQuarto.Location = new System.Drawing.Point(240, 23);
            this.btnNovoQuarto.Name = "btnNovoQuarto";
            this.btnNovoQuarto.Size = new System.Drawing.Size(124, 44);
            this.btnNovoQuarto.TabIndex = 3;
            this.btnNovoQuarto.Text = "Novo Quarto";
            this.btnNovoQuarto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNovoQuarto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNovoQuarto.UseVisualStyleBackColor = true;
            this.btnNovoQuarto.Click += new System.EventHandler(this.btnNovoQuarto_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgQuartos);
            this.groupBox2.Location = new System.Drawing.Point(12, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(352, 428);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Quartos";
            // 
            // dgQuartos
            // 
            this.dgQuartos.AllowUserToAddRows = false;
            this.dgQuartos.AllowUserToDeleteRows = false;
            this.dgQuartos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgQuartos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgQuartos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgQuartos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgQuartos.Location = new System.Drawing.Point(3, 16);
            this.dgQuartos.Name = "dgQuartos";
            this.dgQuartos.ReadOnly = true;
            this.dgQuartos.Size = new System.Drawing.Size(346, 409);
            this.dgQuartos.TabIndex = 0;
            this.dgQuartos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgQuartos_CellDoubleClick);
            // 
            // FrmListagemQuartos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 524);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnNovoQuarto);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(393, 563);
            this.Name = "FrmListagemQuartos";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Listagem Quartos";
            this.Load += new System.EventHandler(this.FrmListagemQuartos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgQuartos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPesquisaNumero;
        private System.Windows.Forms.TextBox txtPesquisaBloco;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNovoQuarto;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgQuartos;
    }
}