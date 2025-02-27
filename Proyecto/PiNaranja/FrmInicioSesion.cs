﻿using System;
using PInaranja.Clases;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;
using PiNaranja.Resources;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PiNaranja
{
    public partial class FrmInicioSesion : Form
    {

        private string usuario;
        public FrmInicioSesion()
        {
            InitializeComponent();
        }

        private void btnInicioSesion_Click(object sender, EventArgs e)
        {


            if (ConBD.Conexion != null)
            {
                ConBD.AbrirConexion();
                //Comprueba si el usuario ya está registrado
                if (Usuario.UsuarioYaRegistrado(txtUsuario.Text))
                {
                    ConBD.CerrarConexion();
                    if (ConBD.Conexion != null)
                    {
                        ConBD.AbrirConexion();
                        //Si el usuario está registrado, valida contraseña. 
                        if (Usuario.ValidaConstrasenya(txtContrasenya.Text))
                        {

                            ConBD.CerrarConexion();
                            if (ConBD.Conexion != null)
                            {//Comprueba si el usuario está validado. 
                                ConBD.AbrirConexion();
                                bool validado = Usuario.UsuarioValidado(txtUsuario.Text);
                                if (validado == true)
                                {
                                    usuario = txtUsuario.Text;
                                    ConBD.CerrarConexion();
                                    FrmPanelControl frmpc = new FrmPanelControl(usuario);
                                    frmpc.Show();
                                    this.Hide();                                    
                                }
                                else
                                { //Si no está validad te envia al formulario de verificacion. 
                                    usuario = txtUsuario.Text;
                                    ConBD.CerrarConexion();
                                    FrmVerificacion frmv = new FrmVerificacion(usuario);
                                    frmv.Show();
                                    this.Hide();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("La contraseña es erronea");
                            ConBD.CerrarConexion();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El usuario no está registrado");
                    ConBD.CerrarConexion();
                }
            }
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            FrmCreaCuenta frm = new FrmCreaCuenta();
            frm.Show();
            this.Hide();
        }



        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Deseas eliminar la cuenta registrada?", "Avisa", MessageBoxButtons.YesNo);

        }

        private void ptbSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmInicioSesion_Load(object sender, EventArgs e)
        {
            cmbIdioma.Text = "Castellano";
            AplicarIdioma();
        }

        private void AplicarIdioma()
        {
            this.Text = Resources.Idioma.FrmInicioSesion;
            lblUsuario.Text = Resources.Idioma.lblUsuario;
            lblContraseña.Text = Resources.Idioma.lblContraseña;
            lblIdioma.Text = Resources.Idioma.lblIdioma;
            btnInicioSesion.Text = Resources.Idioma.btnInicioSesion;
            btnCrearCuenta.Text = Resources.Idioma.btnCrearCuenta;
            btnRecContr.Text = Resources.Idioma.btnRecuperarCon;
        }

        private void cmbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cultura = "";
            switch (cmbIdioma.Text)
            {
                case "Castellano":
                    {
                        cultura = "ES-ES";
                        break;
                    }
                case "English":
                    {
                        cultura = "EN-GB";
                        break;
                    }
            }
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultura);
            AplicarIdioma();
        }

        private void btnRecContr_Click(object sender, EventArgs e)
        {
            FrmRecuperarCuenta rCuenta = new FrmRecuperarCuenta();
            rCuenta.Show();
            this.Hide();
        }

        private void txtContrasenya_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


    }
}
