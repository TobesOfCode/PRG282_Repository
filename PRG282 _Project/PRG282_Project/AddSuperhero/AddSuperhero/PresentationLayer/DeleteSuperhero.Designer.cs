namespace AddSuperhero
{
    partial class frmDelete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDelete));
            this.lblHeroID = new System.Windows.Forms.Label();
            this.txtHeroID = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblHeading = new System.Windows.Forms.Label();
            this.lblFound = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.dgvHeroes = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnl1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnl4 = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeroes)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnl1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnl4.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeroID
            // 
            this.lblHeroID.AutoSize = true;
            this.lblHeroID.Location = new System.Drawing.Point(118, 11);
            this.lblHeroID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeroID.Name = "lblHeroID";
            this.lblHeroID.Size = new System.Drawing.Size(125, 20);
            this.lblHeroID.TabIndex = 0;
            this.lblHeroID.Text = "Enter a Hero ID:";
            // 
            // txtHeroID
            // 
            this.txtHeroID.Location = new System.Drawing.Point(296, 11);
            this.txtHeroID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtHeroID.Name = "txtHeroID";
            this.txtHeroID.Size = new System.Drawing.Size(231, 26);
            this.txtHeroID.TabIndex = 1;
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnFind.Location = new System.Drawing.Point(460, 4);
            this.btnFind.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(168, 45);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Find Hero";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.IndianRed;
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(676, 5);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(156, 45);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete Hero";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Modern No. 20", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(203, 11);
            this.lblHeading.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(218, 31);
            this.lblHeading.TabIndex = 4;
            this.lblHeading.Text = "Remove a Hero.";
            this.lblHeading.Click += new System.EventHandler(this.lblHeading_Click);
            // 
            // lblFound
            // 
            this.lblFound.AutoSize = true;
            this.lblFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFound.Location = new System.Drawing.Point(434, 16);
            this.lblFound.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFound.Name = "lblFound";
            this.lblFound.Size = new System.Drawing.Size(211, 20);
            this.lblFound.TabIndex = 5;
            this.lblFound.Text = "No hero have been selected.";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Crimson;
            this.btnBack.Location = new System.Drawing.Point(260, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(152, 45);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dgvHeroes
            // 
            this.dgvHeroes.AllowUserToAddRows = false;
            this.dgvHeroes.AllowUserToDeleteRows = false;
            this.dgvHeroes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHeroes.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvHeroes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHeroes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHeroes.GridColor = System.Drawing.SystemColors.InactiveBorder;
            this.dgvHeroes.Location = new System.Drawing.Point(0, 0);
            this.dgvHeroes.MultiSelect = false;
            this.dgvHeroes.Name = "dgvHeroes";
            this.dgvHeroes.ReadOnly = true;
            this.dgvHeroes.RowHeadersWidth = 51;
            this.dgvHeroes.RowTemplate.Height = 24;
            this.dgvHeroes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHeroes.Size = new System.Drawing.Size(1097, 335);
            this.dgvHeroes.TabIndex = 7;
            this.dgvHeroes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHeroes_CellClick);
            this.dgvHeroes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHeroes_CellContentClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pnlFooter, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.pnl4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.pnl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlHeader, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1103, 569);
            this.tableLayoutPanel1.TabIndex = 9;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlHeader.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlHeader.BackgroundImage")));
            this.pnlHeader.Controls.Add(this.lblHeading);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(3, 3);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1097, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // pnl1
            // 
            this.pnl1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnl1.Controls.Add(this.txtHeroID);
            this.pnl1.Controls.Add(this.lblHeroID);
            this.pnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl1.Location = new System.Drawing.Point(3, 59);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(1097, 50);
            this.pnl1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvHeroes);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 115);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1097, 335);
            this.panel3.TabIndex = 2;
            // 
            // pnl4
            // 
            this.pnl4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnl4.BackgroundImage")));
            this.pnl4.Controls.Add(this.lblFound);
            this.pnl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl4.Location = new System.Drawing.Point(3, 456);
            this.pnl4.Name = "pnl4";
            this.pnl4.Size = new System.Drawing.Size(1097, 50);
            this.pnl4.TabIndex = 3;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlFooter.Controls.Add(this.btnBack);
            this.pnlFooter.Controls.Add(this.btnFind);
            this.pnlFooter.Controls.Add(this.btnDelete);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFooter.Location = new System.Drawing.Point(3, 512);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1097, 54);
            this.pnlFooter.TabIndex = 4;
            // 
            // frmDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1103, 569);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmDelete";
            this.Text = "Delete a Superhero";
            this.Load += new System.EventHandler(this.frmDelete_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeroes)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.pnl4.ResumeLayout(false);
            this.pnl4.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHeroID;
        private System.Windows.Forms.TextBox txtHeroID;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Label lblFound;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dgvHeroes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnl4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlFooter;
    }
}