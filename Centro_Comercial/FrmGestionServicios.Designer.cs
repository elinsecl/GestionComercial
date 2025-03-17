namespace Centro_Comercial
{
    partial class FrmGestionServicios
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
            this.GestionServicio = new System.Windows.Forms.GroupBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pictureBoxSalir = new System.Windows.Forms.PictureBox();
            this.pbFoto = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpFechaCreacion = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.pbEditar = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIdServicio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.txtNombreServicio = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtDuracion = new System.Windows.Forms.TextBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.GestionServicio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEditar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.GestionServicio);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 358);
            this.panel1.TabIndex = 0;
            // 
            // GestionServicio
            // 
            this.GestionServicio.BackColor = System.Drawing.Color.Snow;
            this.GestionServicio.Controls.Add(this.btnAceptar);
            this.GestionServicio.Controls.Add(this.btnCancelar);
            this.GestionServicio.Controls.Add(this.pictureBoxSalir);
            this.GestionServicio.Controls.Add(this.pbFoto);
            this.GestionServicio.Controls.Add(this.label7);
            this.GestionServicio.Controls.Add(this.dtpFechaCreacion);
            this.GestionServicio.Controls.Add(this.label8);
            this.GestionServicio.Controls.Add(this.pbEditar);
            this.GestionServicio.Controls.Add(this.label5);
            this.GestionServicio.Controls.Add(this.txtIdServicio);
            this.GestionServicio.Controls.Add(this.label6);
            this.GestionServicio.Controls.Add(this.label4);
            this.GestionServicio.Controls.Add(this.label3);
            this.GestionServicio.Controls.Add(this.labelId);
            this.GestionServicio.Controls.Add(this.txtNombreServicio);
            this.GestionServicio.Controls.Add(this.txtDescripcion);
            this.GestionServicio.Controls.Add(this.txtPrecio);
            this.GestionServicio.Controls.Add(this.txtDuracion);
            this.GestionServicio.Controls.Add(this.cmbCategoria);
            this.GestionServicio.Controls.Add(this.cmbEstado);
            this.GestionServicio.Controls.Add(this.label2);
            this.GestionServicio.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GestionServicio.ForeColor = System.Drawing.Color.SaddleBrown;
            this.GestionServicio.Location = new System.Drawing.Point(12, 18);
            this.GestionServicio.Name = "GestionServicio";
            this.GestionServicio.Size = new System.Drawing.Size(303, 328);
            this.GestionServicio.TabIndex = 72;
            this.GestionServicio.TabStop = false;
            this.GestionServicio.Text = "GestionServicio";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(6, 276);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(118, 28);
            this.btnAceptar.TabIndex = 67;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btn_Aceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(175, 276);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(118, 28);
            this.btnCancelar.TabIndex = 68;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // pictureBoxSalir
            // 
            this.pictureBoxSalir.BackColor = System.Drawing.Color.Snow;
            this.pictureBoxSalir.Image = global::Centro_Comercial.Properties.Resources.icons8_logout_48;
            this.pictureBoxSalir.Location = new System.Drawing.Point(236, 9);
            this.pictureBoxSalir.Name = "pictureBoxSalir";
            this.pictureBoxSalir.Size = new System.Drawing.Size(57, 51);
            this.pictureBoxSalir.TabIndex = 71;
            this.pictureBoxSalir.TabStop = false;
            this.pictureBoxSalir.Click += new System.EventHandler(this.pictureBoxSalir_Click);
            // 
            // pbFoto
            // 
            this.pbFoto.BackColor = System.Drawing.Color.Snow;
            this.pbFoto.Image = global::Centro_Comercial.Properties.Resources.perfil;
            this.pbFoto.Location = new System.Drawing.Point(132, 9);
            this.pbFoto.Name = "pbFoto";
            this.pbFoto.Size = new System.Drawing.Size(54, 46);
            this.pbFoto.TabIndex = 64;
            this.pbFoto.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Snow;
            this.label7.Location = new System.Drawing.Point(3, 250);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 62;
            this.label7.Text = "FechaCreacion:";
            // 
            // dtpFechaCreacion
            // 
            this.dtpFechaCreacion.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpFechaCreacion.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.dtpFechaCreacion.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaCreacion.Font = new System.Drawing.Font("Times New Roman", 7.25F, System.Drawing.FontStyle.Bold);
            this.dtpFechaCreacion.Location = new System.Drawing.Point(93, 250);
            this.dtpFechaCreacion.Name = "dtpFechaCreacion";
            this.dtpFechaCreacion.Size = new System.Drawing.Size(200, 19);
            this.dtpFechaCreacion.TabIndex = 63;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Snow;
            this.label8.Location = new System.Drawing.Point(3, 223);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 61;
            this.label8.Text = "Estado:";
            // 
            // pbEditar
            // 
            this.pbEditar.BackColor = System.Drawing.Color.Snow;
            this.pbEditar.Image = global::Centro_Comercial.Properties.Resources.icons8_edit_ios_17_outlined_16;
            this.pbEditar.Location = new System.Drawing.Point(192, 30);
            this.pbEditar.Name = "pbEditar";
            this.pbEditar.Size = new System.Drawing.Size(19, 25);
            this.pbEditar.TabIndex = 65;
            this.pbEditar.TabStop = false;
            this.pbEditar.Click += new System.EventHandler(this.pb_Editar_Imag_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Snow;
            this.label5.Location = new System.Drawing.Point(3, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 60;
            this.label5.Text = "Categoria:";
            // 
            // txtIdServicio
            // 
            this.txtIdServicio.Location = new System.Drawing.Point(93, 66);
            this.txtIdServicio.Name = "txtIdServicio";
            this.txtIdServicio.Size = new System.Drawing.Size(200, 20);
            this.txtIdServicio.TabIndex = 48;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Snow;
            this.label6.Location = new System.Drawing.Point(3, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 59;
            this.label6.Text = "Duracion:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Snow;
            this.label4.Location = new System.Drawing.Point(3, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Descripcion:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Snow;
            this.label3.Location = new System.Drawing.Point(3, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 58;
            this.label3.Text = "Precio:";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.BackColor = System.Drawing.Color.Snow;
            this.labelId.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelId.Location = new System.Drawing.Point(3, 66);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(63, 13);
            this.labelId.TabIndex = 55;
            this.labelId.Text = "IdServicio:";
            // 
            // txtNombreServicio
            // 
            this.txtNombreServicio.Location = new System.Drawing.Point(93, 92);
            this.txtNombreServicio.Name = "txtNombreServicio";
            this.txtNombreServicio.Size = new System.Drawing.Size(200, 20);
            this.txtNombreServicio.TabIndex = 49;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(93, 118);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(200, 20);
            this.txtDescripcion.TabIndex = 50;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(93, 144);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(200, 20);
            this.txtPrecio.TabIndex = 51;
            // 
            // txtDuracion
            // 
            this.txtDuracion.Location = new System.Drawing.Point(93, 170);
            this.txtDuracion.Name = "txtDuracion";
            this.txtDuracion.Size = new System.Drawing.Size(200, 20);
            this.txtDuracion.TabIndex = 52;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(93, 196);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(200, 21);
            this.cmbCategoria.TabIndex = 53;
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(93, 223);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(200, 21);
            this.cmbEstado.TabIndex = 54;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Snow;
            this.label2.Location = new System.Drawing.Point(3, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 56;
            this.label2.Text = "NombreServicio:";
            // 
            // FrmGestionServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 358);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Name = "FrmGestionServicios";
            this.Text = "FrmGestionServicios";
            this.panel1.ResumeLayout(false);
            this.GestionServicio.ResumeLayout(false);
            this.GestionServicio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEditar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.PictureBox pbEditar;
        private System.Windows.Forms.PictureBox pbFoto;
        private System.Windows.Forms.DateTimePicker dtpFechaCreacion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.TextBox txtDuracion;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtNombreServicio;
        private System.Windows.Forms.TextBox txtIdServicio;
        private System.Windows.Forms.PictureBox pictureBoxSalir;
        private System.Windows.Forms.GroupBox GestionServicio;
    }
}