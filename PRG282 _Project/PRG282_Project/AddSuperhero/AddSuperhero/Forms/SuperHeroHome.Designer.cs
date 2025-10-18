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
            this.SuspendLayout();
            // 
            // btnAddHero
            // 
            this.btnAddHero.Location = new System.Drawing.Point(81, 339);
            this.btnAddHero.Name = "btnAddHero";
            this.btnAddHero.Size = new System.Drawing.Size(104, 23);
            this.btnAddHero.TabIndex = 0;
            this.btnAddHero.Text = "Add a Superhero";
            this.btnAddHero.UseVisualStyleBackColor = true;
            this.btnAddHero.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(204, 64);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(378, 76);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "WELCOME";
            // 
            // btnViewSuper
            // 
            this.btnViewSuper.Location = new System.Drawing.Point(268, 339);
            this.btnViewSuper.Name = "btnViewSuper";
            this.btnViewSuper.Size = new System.Drawing.Size(75, 23);
            this.btnViewSuper.TabIndex = 2;
            this.btnViewSuper.Text = "button1";
            this.btnViewSuper.UseVisualStyleBackColor = true;
            this.btnViewSuper.Click += new System.EventHandler(this.btnViewSuper_Click);
            // 
            // SuperHeroHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnViewSuper);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnAddHero);
            this.Name = "SuperHeroHome";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddHero;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnViewSuper;
    }
}