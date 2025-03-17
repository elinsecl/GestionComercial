namespace Centro_Comercial
{
    partial class FrmGestionClientes
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pictureBoxSalir = new System.Windows.Forms.PictureBox();
            this.pbFoto = new System.Windows.Forms.PictureBox();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaRegistro = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtCorreoElectronico = new System.Windows.Forms.TextBox();
            this.txtNombreCompleto = new System.Windows.Forms.TextBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbEditar = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEditar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnAceptar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.pictureBoxSalir);
            this.panel1.Controls.Add(this.pbFoto);
            this.panel1.Controls.Add(this.dtpFechaNacimiento);
            this.panel1.Controls.Add(this.dtpFechaRegistro);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.labelId);
            this.panel1.Controls.Add(this.cmbEstado);
            this.panel1.Controls.Add(this.txtDireccion);
            this.panel1.Controls.Add(this.txtTelefono);
            this.panel1.Controls.Add(this.txtCorreoElectronico);
            this.panel1.Controls.Add(this.txtNombreCompleto);
            this.panel1.Controls.Add(this.txtIdCliente);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 355);
            this.panel1.TabIndex = 1;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAceptar.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnAceptar.Location = new System.Drawing.Point(20, 296);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(118, 28);
            this.btnAceptar.TabIndex = 77;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btn_Aceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnCancelar.Location = new System.Drawing.Point(165, 296);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(118, 28);
            this.btnCancelar.TabIndex = 76;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // pictureBoxSalir
            // 
            this.pictureBoxSalir.BackColor = System.Drawing.Color.Snow;
            this.pictureBoxSalir.Image = global::Centro_Comercial.Properties.Resources.icons8_logout_48;
            this.pictureBoxSalir.Location = new System.Drawing.Point(257, 15);
            this.pictureBoxSalir.Name = "pictureBoxSalir";
            this.pictureBoxSalir.Size = new System.Drawing.Size(57, 54);
            this.pictureBoxSalir.TabIndex = 74;
            this.pictureBoxSalir.TabStop = false;
            this.pictureBoxSalir.Click += new System.EventHandler(this.pictureBoxSalir_Click);
            // 
            // pbFoto
            // 
            this.pbFoto.BackColor = System.Drawing.Color.Snow;
            this.pbFoto.Image = global::Centro_Comercial.Properties.Resources.perfil;
            this.pbFoto.Location = new System.Drawing.Point(129, 23);
            this.pbFoto.Name = "pbFoto";
            this.pbFoto.Size = new System.Drawing.Size(54, 46);
            this.pbFoto.TabIndex = 72;
            this.pbFoto.TabStop = false;
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaNacimiento.Font = new System.Drawing.Font("Times New Roman", 7.25F, System.Drawing.FontStyle.Bold);
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(129, 256);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(185, 19);
            this.dtpFechaNacimiento.TabIndex = 47;
            // 
            // dtpFechaRegistro
            // 
            this.dtpFechaRegistro.Font = new System.Drawing.Font("Times New Roman", 7.25F, System.Drawing.FontStyle.Bold);
            this.dtpFechaRegistro.Location = new System.Drawing.Point(129, 205);
            this.dtpFechaRegistro.Name = "dtpFechaRegistro";
            this.dtpFechaRegistro.Size = new System.Drawing.Size(185, 19);
            this.dtpFechaRegistro.TabIndex = 44;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Snow;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label7.Location = new System.Drawing.Point(17, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 43;
            this.label7.Text = "FechaRegistro:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Snow;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label8.Location = new System.Drawing.Point(17, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 40;
            this.label8.Text = "Estado:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Snow;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label6.Location = new System.Drawing.Point(17, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Direccion:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Snow;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label3.Location = new System.Drawing.Point(17, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Telefono:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Snow;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label4.Location = new System.Drawing.Point(17, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Correo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Snow;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label2.Location = new System.Drawing.Point(17, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "NombreCompleto:";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.BackColor = System.Drawing.Color.Snow;
            this.labelId.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelId.ForeColor = System.Drawing.Color.SaddleBrown;
            this.labelId.Location = new System.Drawing.Point(17, 75);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(61, 13);
            this.labelId.TabIndex = 35;
            this.labelId.Text = "IdCliente:";
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(129, 232);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(185, 21);
            this.cmbEstado.TabIndex = 34;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(129, 179);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(185, 20);
            this.txtDireccion.TabIndex = 33;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(129, 153);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(185, 20);
            this.txtTelefono.TabIndex = 32;
            // 
            // txtCorreoElectronico
            // 
            this.txtCorreoElectronico.Location = new System.Drawing.Point(129, 127);
            this.txtCorreoElectronico.Name = "txtCorreoElectronico";
            this.txtCorreoElectronico.Size = new System.Drawing.Size(185, 20);
            this.txtCorreoElectronico.TabIndex = 31;
            // 
            // txtNombreCompleto
            // 
            this.txtNombreCompleto.Location = new System.Drawing.Point(129, 101);
            this.txtNombreCompleto.Name = "txtNombreCompleto";
            this.txtNombreCompleto.Size = new System.Drawing.Size(185, 20);
            this.txtNombreCompleto.TabIndex = 30;
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Location = new System.Drawing.Point(129, 75);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(185, 20);
            this.txtIdCliente.TabIndex = 29;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Snow;
            this.groupBox1.Controls.Add(this.pbEditar);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 321);
            this.groupBox1.TabIndex = 78;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gestion Cliente";
            // 
            // pbEditar
            // 
            this.pbEditar.BackColor = System.Drawing.Color.Snow;
            this.pbEditar.Image = global::Centro_Comercial.Properties.Resources.icons8_edit_ios_17_outlined_16;
            this.pbEditar.Location = new System.Drawing.Point(177, 41);
            this.pbEditar.Name = "pbEditar";
            this.pbEditar.Size = new System.Drawing.Size(27, 25);
            this.pbEditar.TabIndex = 73;
            this.pbEditar.TabStop = false;
            this.pbEditar.Click += new System.EventHandler(this.pb_Editar_Imag_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Snow;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label5.Location = new System.Drawing.Point(0, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "Fecha de Nacimiento:";
            // 
            // FrmGestionClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 355);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Name = "FrmGestionClientes";
            this.Text = "FrmGestionClientes";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEditar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFechaRegistro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtCorreoElectronico;
        private System.Windows.Forms.TextBox txtNombreCompleto;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.PictureBox pictureBoxSalir;
        private System.Windows.Forms.PictureBox pbEditar;
        private System.Windows.Forms.PictureBox pbFoto;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}