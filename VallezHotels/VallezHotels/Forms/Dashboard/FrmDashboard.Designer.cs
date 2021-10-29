
namespace VallezHotels
{
    partial class FrmDashboard
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtLocacao = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblQuartosNãoDisponiveis = new System.Windows.Forms.Label();
            this.lblCheckouts = new System.Windows.Forms.Label();
            this.lblCheckins = new System.Windows.Forms.Label();
            this.lblQuartosOcupados = new System.Windows.Forms.Label();
            this.lblQuartosDisponiveis = new System.Windows.Forms.Label();
            this.pnlExibicaoQuartos = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tmrBuscarQuartos = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtLocacao);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.lblQuartosNãoDisponiveis);
            this.panel1.Controls.Add(this.lblCheckouts);
            this.panel1.Controls.Add(this.lblCheckins);
            this.panel1.Controls.Add(this.lblQuartosOcupados);
            this.panel1.Controls.Add(this.lblQuartosDisponiveis);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1312, 52);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Data Locação";
            // 
            // dtLocacao
            // 
            this.dtLocacao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtLocacao.Location = new System.Drawing.Point(305, 25);
            this.dtLocacao.Name = "dtLocacao";
            this.dtLocacao.Size = new System.Drawing.Size(102, 22);
            this.dtLocacao.TabIndex = 7;
            this.dtLocacao.Value = new System.DateTime(2021, 9, 19, 0, 0, 31, 0);
            this.dtLocacao.ValueChanged += new System.EventHandler(this.dtLocacao_ValueChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(87, 26);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Filtrar Situação";
            // 
            // lblQuartosNãoDisponiveis
            // 
            this.lblQuartosNãoDisponiveis.AutoSize = true;
            this.lblQuartosNãoDisponiveis.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuartosNãoDisponiveis.Location = new System.Drawing.Point(176, 3);
            this.lblQuartosNãoDisponiveis.Name = "lblQuartosNãoDisponiveis";
            this.lblQuartosNãoDisponiveis.Size = new System.Drawing.Size(199, 21);
            this.lblQuartosNãoDisponiveis.TabIndex = 4;
            this.lblQuartosNãoDisponiveis.Text = "Quartos Não Disponiveis: 2";
            // 
            // lblCheckouts
            // 
            this.lblCheckouts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckouts.Image = global::VallezHotels.Properties.Resources.log_out;
            this.lblCheckouts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCheckouts.Location = new System.Drawing.Point(718, 3);
            this.lblCheckouts.Name = "lblCheckouts";
            this.lblCheckouts.Size = new System.Drawing.Size(182, 21);
            this.lblCheckouts.TabIndex = 3;
            this.lblCheckouts.Text = "Check-out para hoje: 0";
            this.lblCheckouts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCheckins
            // 
            this.lblCheckins.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckins.Image = global::VallezHotels.Properties.Resources.log_in;
            this.lblCheckins.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCheckins.Location = new System.Drawing.Point(546, 3);
            this.lblCheckins.Name = "lblCheckins";
            this.lblCheckins.Size = new System.Drawing.Size(174, 21);
            this.lblCheckins.TabIndex = 2;
            this.lblCheckins.Text = "Check-in para hoje: 1";
            this.lblCheckins.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblQuartosOcupados
            // 
            this.lblQuartosOcupados.AutoSize = true;
            this.lblQuartosOcupados.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuartosOcupados.Location = new System.Drawing.Point(393, 3);
            this.lblQuartosOcupados.Name = "lblQuartosOcupados";
            this.lblQuartosOcupados.Size = new System.Drawing.Size(156, 21);
            this.lblQuartosOcupados.TabIndex = 1;
            this.lblQuartosOcupados.Text = "Quartos Ocupados: 1";
            // 
            // lblQuartosDisponiveis
            // 
            this.lblQuartosDisponiveis.AutoSize = true;
            this.lblQuartosDisponiveis.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuartosDisponiveis.Location = new System.Drawing.Point(3, 3);
            this.lblQuartosDisponiveis.Name = "lblQuartosDisponiveis";
            this.lblQuartosDisponiveis.Size = new System.Drawing.Size(166, 21);
            this.lblQuartosDisponiveis.TabIndex = 0;
            this.lblQuartosDisponiveis.Text = "Quartos Disponiveis: 2";
            // 
            // pnlExibicaoQuartos
            // 
            this.pnlExibicaoQuartos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlExibicaoQuartos.AutoScroll = true;
            this.pnlExibicaoQuartos.Location = new System.Drawing.Point(12, 70);
            this.pnlExibicaoQuartos.Name = "pnlExibicaoQuartos";
            this.pnlExibicaoQuartos.Size = new System.Drawing.Size(1312, 554);
            this.pnlExibicaoQuartos.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(12, 630);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1312, 44);
            this.panel2.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "Descrição situações";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(291, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Não Disponivel";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(54)))), ((int)(((byte)(64)))));
            this.panel6.Location = new System.Drawing.Point(269, 20);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(20, 20);
            this.panel6.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(211, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ocupado";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(131)))), ((int)(((byte)(3)))));
            this.panel5.Location = new System.Drawing.Point(189, 20);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(20, 20);
            this.panel5.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(123, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Agendado";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(188)))), ((int)(((byte)(61)))));
            this.panel4.Location = new System.Drawing.Point(101, 20);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(20, 20);
            this.panel4.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Disponivel";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.panel3.Location = new System.Drawing.Point(10, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(20, 20);
            this.panel3.TabIndex = 0;
            // 
            // tmrBuscarQuartos
            // 
            this.tmrBuscarQuartos.Enabled = true;
            this.tmrBuscarQuartos.Interval = 15000;
            this.tmrBuscarQuartos.Tick += new System.EventHandler(this.tmrBuscarQuartos_Tick);
            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 686);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlExibicaoQuartos);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.FrmDashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCheckins;
        private System.Windows.Forms.Label lblQuartosOcupados;
        private System.Windows.Forms.Label lblQuartosDisponiveis;
        private System.Windows.Forms.FlowLayoutPanel pnlExibicaoQuartos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblQuartosNãoDisponiveis;
        private System.Windows.Forms.Label lblCheckouts;
        private System.Windows.Forms.Timer tmrBuscarQuartos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtLocacao;
    }
}