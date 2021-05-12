
namespace VallezHotels
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnShowQuartos = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnShowHospedes = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(59)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.lblFormTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1048, 48);
            this.panel1.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblFormTitle.Location = new System.Drawing.Point(189, 9);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(0, 30);
            this.lblFormTitle.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(59)))), ((int)(((byte)(82)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.btnShowQuartos);
            this.panel2.Controls.Add(this.btnDashboard);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(194, 465);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(59)))), ((int)(((byte)(82)))));
            this.panel3.Controls.Add(this.btnShowHospedes);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 98);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(194, 367);
            this.panel3.TabIndex = 4;
            // 
            // btnShowQuartos
            // 
            this.btnShowQuartos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnShowQuartos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnShowQuartos.FlatAppearance.BorderSize = 0;
            this.btnShowQuartos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(102)))));
            this.btnShowQuartos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowQuartos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowQuartos.ForeColor = System.Drawing.Color.White;
            this.btnShowQuartos.Location = new System.Drawing.Point(0, 49);
            this.btnShowQuartos.Name = "btnShowQuartos";
            this.btnShowQuartos.Size = new System.Drawing.Size(194, 49);
            this.btnShowQuartos.TabIndex = 3;
            this.btnShowQuartos.Text = "Quartos";
            this.btnShowQuartos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnShowQuartos.UseVisualStyleBackColor = true;
            this.btnShowQuartos.Click += new System.EventHandler(this.btnShowQuartos_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(102)))));
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(0, 0);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(194, 49);
            this.btnDashboard.TabIndex = 2;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.AutoSize = true;
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(102)))));
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(194, 48);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(854, 465);
            this.pnlMain.TabIndex = 2;
            // 
            // btnShowHospedes
            // 
            this.btnShowHospedes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnShowHospedes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnShowHospedes.FlatAppearance.BorderSize = 0;
            this.btnShowHospedes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(78)))), ((int)(((byte)(107)))));
            this.btnShowHospedes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowHospedes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowHospedes.ForeColor = System.Drawing.Color.White;
            this.btnShowHospedes.Location = new System.Drawing.Point(0, 0);
            this.btnShowHospedes.Name = "btnShowHospedes";
            this.btnShowHospedes.Size = new System.Drawing.Size(194, 49);
            this.btnShowHospedes.TabIndex = 2;
            this.btnShowHospedes.Text = "Hospedes";
            this.btnShowHospedes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnShowHospedes.UseVisualStyleBackColor = true;
            this.btnShowHospedes.Click += new System.EventHandler(this.btnShowHospedes_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(102)))));
            this.ClientSize = new System.Drawing.Size(1048, 513);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vallez Hotel\'s";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnShowQuartos;
        private System.Windows.Forms.Button btnShowHospedes;
    }
}