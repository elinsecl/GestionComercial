namespace Centro_Comercial
{
    partial class FrmGestionEncuestas
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pictureBoxSalir = new System.Windows.Forms.PictureBox();
            this.cmbEstadoEncuesta = new System.Windows.Forms.ComboBox();
            this.dtpFechaEncuesta = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipoEncuesta = new System.Windows.Forms.ComboBox();
            this.cmbCalificacionEncuesta = new System.Windows.Forms.ComboBox();
            this.txtComentarios = new System.Windows.Forms.TextBox();
            this.txtServicio = new System.Windows.Forms.TextBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.txtIdEncuesta = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSalir)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 348);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Snow;
            this.groupBox1.Controls.Add(this.btnAceptar);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.pictureBoxSalir);
            this.groupBox1.Controls.Add(this.cmbEstadoEncuesta);
            this.groupBox1.Controls.Add(this.dtpFechaEncuesta);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbTipoEncuesta);
            this.groupBox1.Controls.Add(this.cmbCalificacionEncuesta);
            this.groupBox1.Controls.Add(this.txtComentarios);
            this.groupBox1.Controls.Add(this.txtServicio);
            this.groupBox1.Controls.Add(this.txtIdCliente);
            this.groupBox1.Controls.Add(this.txtIdEncuesta);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 325);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gestión Encuestas";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(6, 290);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(118, 28);
            this.btnAceptar.TabIndex = 69;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(166, 291);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(118, 28);
            this.btnCancelar.TabIndex = 70;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pictureBoxSalir
            // 
            this.pictureBoxSalir.BackColor = System.Drawing.Color.Snow;
            this.pictureBoxSalir.Image = global::Centro_Comercial.Properties.Resources.icons8_logout_48;
            this.pictureBoxSalir.Location = new System.Drawing.Point(234, 10);
            this.pictureBoxSalir.Name = "pictureBoxSalir";
            this.pictureBoxSalir.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxSalir.TabIndex = 66;
            this.pictureBoxSalir.TabStop = false;
            this.pictureBoxSalir.Click += new System.EventHandler(this.pictureBoxSalir_Click);
            // 
            // cmbEstadoEncuesta
            // 
            this.cmbEstadoEncuesta.FormattingEnabled = true;
            this.cmbEstadoEncuesta.Location = new System.Drawing.Point(128, 261);
            this.cmbEstadoEncuesta.Name = "cmbEstadoEncuesta";
            this.cmbEstadoEncuesta.Size = new System.Drawing.Size(156, 21);
            this.cmbEstadoEncuesta.TabIndex = 65;
            // 
            // dtpFechaEncuesta
            // 
            this.dtpFechaEncuesta.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaEncuesta.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaEncuesta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaEncuesta.Location = new System.Drawing.Point(128, 182);
            this.dtpFechaEncuesta.Name = "dtpFechaEncuesta";
            this.dtpFechaEncuesta.Size = new System.Drawing.Size(156, 20);
            this.dtpFechaEncuesta.TabIndex = 64;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 182);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 13);
            this.label9.TabIndex = 63;
            this.label9.Text = "Fecha de Encuesta:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 264);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 62;
            this.label7.Text = "Estado Encuesta:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 235);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 61;
            this.label8.Text = "TipoEncuesta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 13);
            this.label5.TabIndex = 60;
            this.label5.Text = "Calificacion Encuesta:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 59;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 58;
            this.label3.Text = "Comentarios:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "IdServicio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 56;
            this.label2.Text = "IdCliente:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "IdEncuesta:";
            // 
            // cmbTipoEncuesta
            // 
            this.cmbTipoEncuesta.FormattingEnabled = true;
            this.cmbTipoEncuesta.Location = new System.Drawing.Point(128, 235);
            this.cmbTipoEncuesta.Name = "cmbTipoEncuesta";
            this.cmbTipoEncuesta.Size = new System.Drawing.Size(156, 21);
            this.cmbTipoEncuesta.TabIndex = 54;
            // 
            // cmbCalificacionEncuesta
            // 
            this.cmbCalificacionEncuesta.FormattingEnabled = true;
            this.cmbCalificacionEncuesta.Location = new System.Drawing.Point(128, 208);
            this.cmbCalificacionEncuesta.Name = "cmbCalificacionEncuesta";
            this.cmbCalificacionEncuesta.Size = new System.Drawing.Size(156, 21);
            this.cmbCalificacionEncuesta.TabIndex = 53;
            // 
            // txtComentarios
            // 
            this.txtComentarios.Location = new System.Drawing.Point(128, 156);
            this.txtComentarios.Name = "txtComentarios";
            this.txtComentarios.Size = new System.Drawing.Size(156, 20);
            this.txtComentarios.TabIndex = 52;
            // 
            // txtServicio
            // 
            this.txtServicio.Location = new System.Drawing.Point(128, 130);
            this.txtServicio.Name = "txtServicio";
            this.txtServicio.Size = new System.Drawing.Size(156, 20);
            this.txtServicio.TabIndex = 51;
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Location = new System.Drawing.Point(128, 104);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(156, 20);
            this.txtIdCliente.TabIndex = 50;
            // 
            // txtIdEncuesta
            // 
            this.txtIdEncuesta.Location = new System.Drawing.Point(128, 78);
            this.txtIdEncuesta.Name = "txtIdEncuesta";
            this.txtIdEncuesta.Size = new System.Drawing.Size(156, 20);
            this.txtIdEncuesta.TabIndex = 49;
            // 
            // FrmGestionEncuestas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(314, 348);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Name = "FrmGestionEncuestas";
            this.Text = "FrmGestionEncuestas";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSalir)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBoxSalir;
        private System.Windows.Forms.ComboBox cmbEstadoEncuesta;
        private System.Windows.Forms.DateTimePicker dtpFechaEncuesta;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoEncuesta;
        private System.Windows.Forms.ComboBox cmbCalificacionEncuesta;
        private System.Windows.Forms.TextBox txtComentarios;
        private System.Windows.Forms.TextBox txtServicio;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.TextBox txtIdEncuesta;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}