namespace LivePerformanceFerdyCusters
{
    partial class HomePagina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePagina));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLogUit = new System.Windows.Forms.Button();
            this.btnMetingen = new System.Windows.Forms.Button();
            this.btnAccounts = new System.Windows.Forms.Button();
            this.btnMissie = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welkom op de Homepagina van GreenShark!";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(325, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(390, 223);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnLogUit
            // 
            this.btnLogUit.Location = new System.Drawing.Point(90, 155);
            this.btnLogUit.Name = "btnLogUit";
            this.btnLogUit.Size = new System.Drawing.Size(122, 23);
            this.btnLogUit.TabIndex = 4;
            this.btnLogUit.Text = "Log Uit";
            this.btnLogUit.UseVisualStyleBackColor = true;
            this.btnLogUit.Click += new System.EventHandler(this.btnLogUit_Click);
            // 
            // btnMetingen
            // 
            this.btnMetingen.Enabled = false;
            this.btnMetingen.Location = new System.Drawing.Point(90, 97);
            this.btnMetingen.Name = "btnMetingen";
            this.btnMetingen.Size = new System.Drawing.Size(122, 23);
            this.btnMetingen.TabIndex = 5;
            this.btnMetingen.Text = "Beheer Metingen";
            this.btnMetingen.UseVisualStyleBackColor = true;
            this.btnMetingen.Click += new System.EventHandler(this.btnMetingen_Click);
            // 
            // btnAccounts
            // 
            this.btnAccounts.Enabled = false;
            this.btnAccounts.Location = new System.Drawing.Point(90, 68);
            this.btnAccounts.Name = "btnAccounts";
            this.btnAccounts.Size = new System.Drawing.Size(122, 23);
            this.btnAccounts.TabIndex = 6;
            this.btnAccounts.Text = "Beheer Accounts";
            this.btnAccounts.UseVisualStyleBackColor = true;
            this.btnAccounts.Click += new System.EventHandler(this.btnAccounts_Click);
            // 
            // btnMissie
            // 
            this.btnMissie.Location = new System.Drawing.Point(90, 126);
            this.btnMissie.Name = "btnMissie";
            this.btnMissie.Size = new System.Drawing.Size(122, 23);
            this.btnMissie.TabIndex = 7;
            this.btnMissie.Text = "Wijzig/Nieuwe Missie!";
            this.btnMissie.UseVisualStyleBackColor = true;
            this.btnMissie.Click += new System.EventHandler(this.btnMissie_Click);
            // 
            // HomePagina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 267);
            this.Controls.Add(this.btnMissie);
            this.Controls.Add(this.btnAccounts);
            this.Controls.Add(this.btnMetingen);
            this.Controls.Add(this.btnLogUit);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "HomePagina";
            this.Text = "HomePagina";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLogUit;
        private System.Windows.Forms.Button btnMetingen;
        private System.Windows.Forms.Button btnAccounts;
        private System.Windows.Forms.Button btnMissie;
    }
}