﻿namespace PiNaranja
{
    partial class FrmInicioSesion
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInicioSesion));
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContrasenya = new System.Windows.Forms.TextBox();
            this.btnInicioSesion = new System.Windows.Forms.Button();
            this.btnCrearCuenta = new System.Windows.Forms.Button();
            this.lblIdioma = new System.Windows.Forms.Label();
            this.cmbIdioma = new System.Windows.Forms.ComboBox();
            this.ptbSalir = new System.Windows.Forms.PictureBox();
            this.ptblogo = new System.Windows.Forms.PictureBox();
            this.btnRecContr = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptblogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(324, 304);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(102, 25);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "USUARIO";
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContraseña.Location = new System.Drawing.Point(303, 391);
            this.lblContraseña.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(152, 25);
            this.lblContraseña.TabIndex = 2;
            this.lblContraseña.Text = "CONTRASEÑA";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(233, 342);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(297, 36);
            this.txtUsuario.TabIndex = 3;
            // 
            // txtContrasenya
            // 
            this.txtContrasenya.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasenya.Location = new System.Drawing.Point(233, 428);
            this.txtContrasenya.Margin = new System.Windows.Forms.Padding(4);
            this.txtContrasenya.Name = "txtContrasenya";
            this.txtContrasenya.PasswordChar = '*';
            this.txtContrasenya.Size = new System.Drawing.Size(297, 36);
            this.txtContrasenya.TabIndex = 4;
            this.txtContrasenya.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContrasenya_KeyPress);
            // 
            // btnInicioSesion
            // 
            this.btnInicioSesion.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnInicioSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicioSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicioSesion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnInicioSesion.Location = new System.Drawing.Point(281, 518);
            this.btnInicioSesion.Margin = new System.Windows.Forms.Padding(4);
            this.btnInicioSesion.Name = "btnInicioSesion";
            this.btnInicioSesion.Size = new System.Drawing.Size(205, 53);
            this.btnInicioSesion.TabIndex = 5;
            this.btnInicioSesion.Text = "INICIO SESION";
            this.btnInicioSesion.UseVisualStyleBackColor = false;
            this.btnInicioSesion.Click += new System.EventHandler(this.btnInicioSesion_Click);
            // 
            // btnCrearCuenta
            // 
            this.btnCrearCuenta.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCrearCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearCuenta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCrearCuenta.Location = new System.Drawing.Point(264, 578);
            this.btnCrearCuenta.Margin = new System.Windows.Forms.Padding(4);
            this.btnCrearCuenta.Name = "btnCrearCuenta";
            this.btnCrearCuenta.Size = new System.Drawing.Size(244, 53);
            this.btnCrearCuenta.TabIndex = 6;
            this.btnCrearCuenta.Text = "CREAR CUENTA";
            this.btnCrearCuenta.UseVisualStyleBackColor = false;
            this.btnCrearCuenta.Click += new System.EventHandler(this.btnCrearCuenta_Click);
            // 
            // lblIdioma
            // 
            this.lblIdioma.AutoSize = true;
            this.lblIdioma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdioma.Location = new System.Drawing.Point(488, 251);
            this.lblIdioma.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdioma.Name = "lblIdioma";
            this.lblIdioma.Size = new System.Drawing.Size(76, 25);
            this.lblIdioma.TabIndex = 9;
            this.lblIdioma.Text = "Idioma:";
            // 
            // cmbIdioma
            // 
            this.cmbIdioma.FormattingEnabled = true;
            this.cmbIdioma.Items.AddRange(new object[] {
            "Castellano",
            "English"});
            this.cmbIdioma.Location = new System.Drawing.Point(597, 251);
            this.cmbIdioma.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbIdioma.Name = "cmbIdioma";
            this.cmbIdioma.Size = new System.Drawing.Size(121, 24);
            this.cmbIdioma.TabIndex = 10;
            this.cmbIdioma.SelectedIndexChanged += new System.EventHandler(this.cmbIdioma_SelectedIndexChanged);
            // 
            // ptbSalir
            // 
            this.ptbSalir.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ptbSalir.Image = ((System.Drawing.Image)(resources.GetObject("ptbSalir.Image")));
            this.ptbSalir.Location = new System.Drawing.Point(684, 623);
            this.ptbSalir.Margin = new System.Windows.Forms.Padding(4);
            this.ptbSalir.Name = "ptbSalir";
            this.ptbSalir.Size = new System.Drawing.Size(57, 57);
            this.ptbSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbSalir.TabIndex = 7;
            this.ptbSalir.TabStop = false;
            this.ptbSalir.Click += new System.EventHandler(this.ptbSalir_Click);
            // 
            // ptblogo
            // 
            this.ptblogo.Image = ((System.Drawing.Image)(resources.GetObject("ptblogo.Image")));
            this.ptblogo.Location = new System.Drawing.Point(68, 53);
            this.ptblogo.Margin = new System.Windows.Forms.Padding(4);
            this.ptblogo.Name = "ptblogo";
            this.ptblogo.Size = new System.Drawing.Size(651, 178);
            this.ptblogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptblogo.TabIndex = 0;
            this.ptblogo.TabStop = false;
            // 
            // btnRecContr
            // 
            this.btnRecContr.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnRecContr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecContr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRecContr.Location = new System.Drawing.Point(296, 482);
            this.btnRecContr.Margin = new System.Windows.Forms.Padding(4);
            this.btnRecContr.Name = "btnRecContr";
            this.btnRecContr.Size = new System.Drawing.Size(177, 28);
            this.btnRecContr.TabIndex = 11;
            this.btnRecContr.Text = "Recuperar Contraseña";
            this.btnRecContr.UseVisualStyleBackColor = false;
            this.btnRecContr.Click += new System.EventHandler(this.btnRecContr_Click);
            // 
            // FrmInicioSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(779, 723);
            this.ControlBox = false;
            this.Controls.Add(this.btnRecContr);
            this.Controls.Add(this.cmbIdioma);
            this.Controls.Add(this.lblIdioma);
            this.Controls.Add(this.ptbSalir);
            this.Controls.Add(this.btnCrearCuenta);
            this.Controls.Add(this.btnInicioSesion);
            this.Controls.Add(this.txtContrasenya);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblContraseña);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.ptblogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmInicioSesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio Sesion";
            this.Load += new System.EventHandler(this.FrmInicioSesion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptblogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptblogo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContrasenya;
        private System.Windows.Forms.Button btnInicioSesion;
        private System.Windows.Forms.Button btnCrearCuenta;
        private System.Windows.Forms.PictureBox ptbSalir;
        private System.Windows.Forms.Label lblIdioma;
        private System.Windows.Forms.ComboBox cmbIdioma;
        private System.Windows.Forms.Button btnRecContr;
    }
}

