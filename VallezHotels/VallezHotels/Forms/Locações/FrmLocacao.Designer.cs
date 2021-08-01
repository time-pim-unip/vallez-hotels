
namespace VallezHotels
{
    partial class FrmLocacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLocacao));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtCheckout = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtCheckin = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtSaida = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtEntrada = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtQuarto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detentor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidadeSolic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button5 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBloco = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtNumero);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtBloco);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.dtCheckout);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtCheckin);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtSaida);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtEntrada);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtQuarto);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnPesquisar);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(744, 108);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Descrição Locação";
            // 
            // dtCheckout
            // 
            this.dtCheckout.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtCheckout.Location = new System.Drawing.Point(427, 34);
            this.dtCheckout.Name = "dtCheckout";
            this.dtCheckout.Size = new System.Drawing.Size(101, 22);
            this.dtCheckout.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(424, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Check-out";
            // 
            // dtCheckin
            // 
            this.dtCheckin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtCheckin.Location = new System.Drawing.Point(320, 34);
            this.dtCheckin.Name = "dtCheckin";
            this.dtCheckin.Size = new System.Drawing.Size(101, 22);
            this.dtCheckin.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(317, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Check-in";
            // 
            // dtSaida
            // 
            this.dtSaida.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtSaida.Location = new System.Drawing.Point(213, 34);
            this.dtSaida.Name = "dtSaida";
            this.dtSaida.Size = new System.Drawing.Size(101, 22);
            this.dtSaida.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(210, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Saida Prevista";
            // 
            // dtEntrada
            // 
            this.dtEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEntrada.Location = new System.Drawing.Point(106, 34);
            this.dtEntrada.Name = "dtEntrada";
            this.dtEntrada.Size = new System.Drawing.Size(101, 22);
            this.dtEntrada.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(103, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Entrada Prevista";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(67, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 22);
            this.button1.TabIndex = 20;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtQuarto
            // 
            this.txtQuarto.Enabled = false;
            this.txtQuarto.Location = new System.Drawing.Point(6, 76);
            this.txtQuarto.Name = "txtQuarto";
            this.txtQuarto.Size = new System.Drawing.Size(55, 22);
            this.txtQuarto.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Quarto";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.Location = new System.Drawing.Point(67, 32);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(30, 22);
            this.btnPesquisar.TabIndex = 17;
            this.btnPesquisar.UseVisualStyleBackColor = true;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(6, 34);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(55, 22);
            this.txtCodigo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(12, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(744, 169);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hospedes";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.nome,
            this.detentor});
            this.dataGridView1.Location = new System.Drawing.Point(6, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(730, 102);
            this.dataGridView1.TabIndex = 2;
            // 
            // codigo
            // 
            this.codigo.HeaderText = "Código";
            this.codigo.Name = "codigo";
            // 
            // nome
            // 
            this.nome.HeaderText = "Nome";
            this.nome.Name = "nome";
            // 
            // detentor
            // 
            this.detentor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.detentor.HeaderText = "Detentor";
            this.detentor.Name = "detentor";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(573, 14);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 17);
            this.checkBox1.TabIndex = 35;
            this.checkBox1.Text = "Detentor";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Image = global::VallezHotels.Properties.Resources.add;
            this.button3.Location = new System.Drawing.Point(656, 31);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 25);
            this.button3.TabIndex = 34;
            this.button3.Text = "Adicionar";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(103, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Hospede";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(103, 34);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(547, 21);
            this.comboBox1.TabIndex = 32;
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(67, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 22);
            this.button2.TabIndex = 31;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 34);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(55, 22);
            this.textBox2.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Código";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dataGridView2);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.textBox5);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.textBox3);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(12, 301);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(744, 140);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Serviços Adicionais";
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.descricao,
            this.quantidadeSolic,
            this.valorTotal});
            this.dataGridView2.Location = new System.Drawing.Point(6, 62);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(730, 72);
            this.dataGridView2.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Código";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // descricao
            // 
            this.descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            // 
            // quantidadeSolic
            // 
            this.quantidadeSolic.HeaderText = "Qtde. Solicitada";
            this.quantidadeSolic.Name = "quantidadeSolic";
            // 
            // valorTotal
            // 
            this.valorTotal.HeaderText = "ValorTotal";
            this.valorTotal.Name = "valorTotal";
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Image = global::VallezHotels.Properties.Resources.add;
            this.button5.Location = new System.Drawing.Point(656, 33);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(80, 25);
            this.button5.TabIndex = 36;
            this.button5.Text = "Adicionar";
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(588, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 42;
            this.label11.Text = "Quantidade";
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.Location = new System.Drawing.Point(588, 36);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(62, 22);
            this.textBox5.TabIndex = 41;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(103, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 40;
            this.label10.Text = "Descrição";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(103, 36);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(479, 22);
            this.textBox4.TabIndex = 39;
            // 
            // button4
            // 
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(67, 34);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(30, 22);
            this.button4.TabIndex = 38;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(6, 36);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(55, 22);
            this.textBox3.TabIndex = 37;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Código";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Image = global::VallezHotels.Properties.Resources.cancel;
            this.btnCancelar.Location = new System.Drawing.Point(668, 520);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 38);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.Location = new System.Drawing.Point(572, 520);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 38);
            this.btnSalvar.TabIndex = 20;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label12);
            this.panel1.Location = new System.Drawing.Point(572, 445);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 67);
            this.panel1.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(7, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 30);
            this.label12.TabIndex = 0;
            this.label12.Text = "R$ 0.000,00";
            // 
            // txtBloco
            // 
            this.txtBloco.Enabled = false;
            this.txtBloco.Location = new System.Drawing.Point(106, 76);
            this.txtBloco.Name = "txtBloco";
            this.txtBloco.Size = new System.Drawing.Size(55, 22);
            this.txtBloco.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(103, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Bloco";
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(167, 76);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(55, 22);
            this.txtNumero.TabIndex = 32;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(164, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "Numero";
            // 
            // FrmLocacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 570);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(784, 609);
            this.Name = "FrmLocacao";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Manutenção Locação";
            this.Load += new System.EventHandler(this.FrmLocacao_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.DateTimePicker dtCheckout;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtCheckin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtSaida;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtEntrada;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtQuarto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn detentor;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidadeSolic;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorTotal;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtBloco;
        private System.Windows.Forms.Label label13;
    }
}