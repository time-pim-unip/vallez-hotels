
namespace VallezHotels
{
    partial class FrmDescricaoQuarto
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
            this.lblNumQuarto = new System.Windows.Forms.Label();
            this.lblHospedes = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblBloco = new System.Windows.Forms.Label();
            this.lblTipoQuarto = new System.Windows.Forms.Label();
            this.lblSituacao = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNumQuarto
            // 
            this.lblNumQuarto.AutoSize = true;
            this.lblNumQuarto.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumQuarto.Location = new System.Drawing.Point(116, 26);
            this.lblNumQuarto.Name = "lblNumQuarto";
            this.lblNumQuarto.Size = new System.Drawing.Size(106, 30);
            this.lblNumQuarto.TabIndex = 0;
            this.lblNumQuarto.Text = "Numero: ";
            // 
            // lblHospedes
            // 
            this.lblHospedes.AutoSize = true;
            this.lblHospedes.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHospedes.Location = new System.Drawing.Point(12, 102);
            this.lblHospedes.Name = "lblHospedes";
            this.lblHospedes.Size = new System.Drawing.Size(155, 17);
            this.lblHospedes.TabIndex = 1;
            this.lblHospedes.Text = "Quantidade hospedes: 0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Data Entrada: 01/01/2021";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Data Saída: 07/01/2021";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Check-out: 07/01/2021";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Check-in: 02/01/2021";
            // 
            // lblBloco
            // 
            this.lblBloco.AutoSize = true;
            this.lblBloco.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBloco.Location = new System.Drawing.Point(12, 26);
            this.lblBloco.Name = "lblBloco";
            this.lblBloco.Size = new System.Drawing.Size(74, 30);
            this.lblBloco.TabIndex = 6;
            this.lblBloco.Text = "Bloco:";
            // 
            // lblTipoQuarto
            // 
            this.lblTipoQuarto.AutoSize = true;
            this.lblTipoQuarto.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoQuarto.Location = new System.Drawing.Point(14, 56);
            this.lblTipoQuarto.Name = "lblTipoQuarto";
            this.lblTipoQuarto.Size = new System.Drawing.Size(39, 17);
            this.lblTipoQuarto.TabIndex = 7;
            this.lblTipoQuarto.Text = "Suite";
            // 
            // lblSituacao
            // 
            this.lblSituacao.AutoSize = true;
            this.lblSituacao.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSituacao.Location = new System.Drawing.Point(14, 73);
            this.lblSituacao.Name = "lblSituacao";
            this.lblSituacao.Size = new System.Drawing.Size(129, 17);
            this.lblSituacao.TabIndex = 8;
            this.lblSituacao.Text = "Situação: Disponivel";
            // 
            // FrmDescricaoQuarto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(296, 188);
            this.Controls.Add(this.lblSituacao);
            this.Controls.Add(this.lblTipoQuarto);
            this.Controls.Add(this.lblBloco);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblHospedes);
            this.Controls.Add(this.lblNumQuarto);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDescricaoQuarto";
            this.Text = "FrmDescricaoQuarto";
            this.Load += new System.EventHandler(this.FrmDescricaoQuarto_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FrmDescricaoQuarto_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FrmDescricaoQuarto_MouseDoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumQuarto;
        private System.Windows.Forms.Label lblHospedes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblBloco;
        private System.Windows.Forms.Label lblTipoQuarto;
        private System.Windows.Forms.Label lblSituacao;
    }
}