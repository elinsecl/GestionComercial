namespace Centro_Comercial
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnCliente = new System.Windows.Forms.Button();
            this.btnEncuesta = new System.Windows.Forms.Button();
            this.btnServicio = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(133, 450);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCliente);
            this.groupBox1.Controls.Add(this.btnEncuesta);
            this.groupBox1.Controls.Add(this.btnServicio);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.groupBox1.Location = new System.Drawing.Point(7, 176);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 188);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Accesos Directos";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.pictureBox4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(133, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(660, 67);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(204, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Centro Comercial";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SaddleBrown;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold);
            this.panel3.Location = new System.Drawing.Point(133, 67);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(660, 383);
            this.panel3.TabIndex = 2;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Centro_Comercial.Properties.Resources.bolsas_de_compra;
            this.pictureBox4.Location = new System.Drawing.Point(25, 19);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(37, 31);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Centro_Comercial.Properties.Resources.icons8_logout_481;
            this.pictureBox1.Location = new System.Drawing.Point(607, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 58);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Centro_Comercial.Properties.Resources.carrito_de_compras;
            this.pictureBox3.Location = new System.Drawing.Point(45, 370);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(38, 40);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Centro_Comercial.Properties.Resources._2669591;
            this.pictureBox2.Location = new System.Drawing.Point(3, 39);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(130, 131);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // btnCliente
            // 
            this.btnCliente.Image = global::Centro_Comercial.Properties.Resources.icons8_users_48;
            this.btnCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCliente.Location = new System.Drawing.Point(5, 71);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(109, 46);
            this.btnCliente.TabIndex = 2;
            this.btnCliente.Text = "Clientes";
            this.btnCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click_1);
            // 
            // btnEncuesta
            // 
            this.btnEncuesta.Image = global::Centro_Comercial.Properties.Resources.icons8_catalog_26;
            this.btnEncuesta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEncuesta.Location = new System.Drawing.Point(5, 123);
            this.btnEncuesta.Name = "btnEncuesta";
            this.btnEncuesta.Size = new System.Drawing.Size(108, 46);
            this.btnEncuesta.TabIndex = 1;
            this.btnEncuesta.Text = "Encuestas";
            this.btnEncuesta.UseVisualStyleBackColor = true;
            this.btnEncuesta.Click += new System.EventHandler(this.btnEncuesta_Click);
            // 
            // btnServicio
            // 
            this.btnServicio.Image = global::Centro_Comercial.Properties.Resources.icons8_buy_24;
            this.btnServicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnServicio.Location = new System.Drawing.Point(6, 19);
            this.btnServicio.Name = "btnServicio";
            this.btnServicio.Size = new System.Drawing.Size(108, 46);
            this.btnServicio.TabIndex = 0;
            this.btnServicio.Text = "Servicios";
            this.btnServicio.UseVisualStyleBackColor = true;
            this.btnServicio.Click += new System.EventHandler(this.btnServicio_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmPrincipal";
            this.Text = "FrmPrincipal";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnServicio;
        private System.Windows.Forms.Button btnEncuesta;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}