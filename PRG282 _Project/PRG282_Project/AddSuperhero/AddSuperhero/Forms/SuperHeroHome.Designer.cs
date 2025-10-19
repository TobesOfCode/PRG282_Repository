namespace AddSuperhero
{
    partial class SuperHeroHome
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
            this.btnAddHero = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnViewSuper = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlWelcome = new System.Windows.Forms.Panel();
            this.btnSummary = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlWelcome.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddHero
            // 
            this.btnAddHero.Location = new System.Drawing.Point(6, 6);
            this.btnAddHero.Name = "btnAddHero";
            this.btnAddHero.Size = new System.Drawing.Size(117, 42);
            this.btnAddHero.TabIndex = 0;
            this.btnAddHero.Text = "Add a Superhero";
            this.btnAddHero.UseVisualStyleBackColor = true;
            this.btnAddHero.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(3, 3);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(378, 76);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "WELCOME";
            // 
            // btnViewSuper
            // 
            this.btnViewSuper.Location = new System.Drawing.Point(129, 6);
            this.btnViewSuper.Name = "btnViewSuper";
            this.btnViewSuper.Size = new System.Drawing.Size(111, 42);
            this.btnViewSuper.TabIndex = 2;
            this.btnViewSuper.Text = "View All Records";
            this.btnViewSuper.UseVisualStyleBackColor = true;
            this.btnViewSuper.Click += new System.EventHandler(this.btnViewSuper_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSummary);
            this.panel1.Controls.Add(this.btnAddHero);
            this.panel1.Controls.Add(this.btnViewSuper);
            this.panel1.Location = new System.Drawing.Point(44, 355);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(718, 56);
            this.panel1.TabIndex = 3;
            // 
            // pnlWelcome
            // 
            this.pnlWelcome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlWelcome.BackColor = System.Drawing.SystemColors.MenuBar;
            this.pnlWelcome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlWelcome.Controls.Add(this.lblWelcome);
            this.pnlWelcome.Location = new System.Drawing.Point(211, 12);
            this.pnlWelcome.Name = "pnlWelcome";
            this.pnlWelcome.Size = new System.Drawing.Size(386, 84);
            this.pnlWelcome.TabIndex = 5;
            // 
            // btnSummary
            // 
            this.btnSummary.Location = new System.Drawing.Point(246, 6);
            this.btnSummary.Name = "btnSummary";
            this.btnSummary.Size = new System.Drawing.Size(111, 42);
            this.btnSummary.TabIndex = 3;
            this.btnSummary.Text = "Summary Report";
            this.btnSummary.UseVisualStyleBackColor = true;
            this.btnSummary.Click += new System.EventHandler(this.btnSummary_Click);
            // 
            // SuperHeroHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlWelcome);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SuperHeroHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.SuperHeroHome_Resize);
            this.panel1.ResumeLayout(false);
            this.pnlWelcome.ResumeLayout(false);
            this.pnlWelcome.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddHero;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnViewSuper;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlWelcome;
        private System.Windows.Forms.Button btnSummary;
    }
}