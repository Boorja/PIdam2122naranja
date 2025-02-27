﻿using MySql.Data.MySqlClient;
using System;
using PiNaranja.Clases;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PInaranja.Clases
{
    class Usuario
    {
        #region - Atributos - Propiedades - Constructores -
        private string nombre;
        private string correo;
        private string contrasenya;
        private bool conectado = false;
        private int codigo;
        private bool validado;

        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Correo { get { return correo; } set { correo = value; } }
        public string Contrasenya { get { return contrasenya; } set { contrasenya = value; } }
        private bool Conectado { get { return conectado; } set { conectado = value; } }
        public int Codigo { get => codigo; set => codigo = value; }
        public bool Validado { get => validado; set => validado = value; }


        //parametrizamos todos los atributos
        //Hace falta pasarle conectado? Cuando se crea automaticamente está en desconectado. 
        public Usuario(string nom, string email, string contra, bool con)
        {
            this.nombre = nom;
            this.correo = email;
            this.contrasenya = contra;
            this.conectado = con;
        }
        public Usuario(string nom, string email, string contra)
        {
            this.nombre = nom;
            this.correo = email;
            this.contrasenya = contra;
            this.conectado = false;
        }

        //Constructor sobrecargado sin parámetros
        public Usuario() { }
        #endregion

        #region - Métodos - 

        /// <summary>
        /// Agrega usuario
        /// </summary>
        /// <param name="usu">Usuario</param>
        /// <returns>1 si ha insertado el usuario 0  si no lo ha insertado.</returns>
        public static int AgregarUsuario(Usuario usu)
        {
            int retorno;

            string consulta = String.Format("INSERT INTO cuenta (nombreUsu,correo,contrasenya,conectado,codigo,validado) VALUES " +
                "(@nom,@cor,@con,@conx,9999999,false)");

            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            comando.Parameters.AddWithValue("nom", usu.nombre);
            comando.Parameters.AddWithValue("cor", usu.correo);
            comando.Parameters.AddWithValue("con", usu.contrasenya);
            comando.Parameters.AddWithValue("conx", usu.conectado);
            retorno = comando.ExecuteNonQuery();

            Log.Add("Insertado un usuario en myHomy --> Nombre: " + usu.Nombre + " -- Correo: " + usu.Correo);

            return retorno;
        }
        /// <summary>
        /// Elimina usuario.
        /// </summary>
        /// <param name="nombre">String con nombre de usuario</param>
        /// <returns>Número de control para determinar si se ha modificado una columna.</returns>
        public static int EliminaUsuario(string nombre)
        {
            int retorno;
            string consulta = String.Format("DELETE FROM cuenta WHERE nombreUsu='{0}';", nombre);
            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            retorno = comando.ExecuteNonQuery();

            Log.Add("Usuario eliminado de myHomy --> Nombre: " + nombre);
            return retorno;
        }

        /// <summary>
        /// Valida la contraseña
        /// </summary>
        /// <param name="contra">String con la contraseña del usuario</param>
        /// <returns>Devuelve un valor booleano verdadero si existe </returns>
        public static bool ValidaConstrasenya(string contra)
        {

            string consulta = String.Format("SELECT correo FROM cuenta WHERE contrasenya='{0}'", contra);

            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                return true;
            }
            else
            {
                reader.Close();
                return false;
            }

        }


        /// <summary>
        ///Comprueba si cuenta existe
        /// </summary>
        /// <param string="usu">Nombre del usuario</param>
        /// <returns>Devuelve true si existe la cuenta y false si no existe.</returns>
        public static bool UsuarioYaRegistrado(string usu)
        {
            string consulta = String.Format("SELECT * FROM cuenta" +
            " WHERE nombreUsu='{0}'", usu);

            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                return true;
            }
            else
            {
                reader.Close();
                return false;
            }
        }

        /// <summary>
        ///Comprueba si el correo existe. 
        /// </summary>
        /// <param string="correo">Correo del usuario</param>
        /// <returns>Devuelve true si existe y false si no existe.</returns>
        public static bool CorreoYaRegistrado(string correo)
        {
            string consulta = string.Format("SELECT * from cuenta" +
                "Where correo='@cor'");
            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            comando.Parameters.AddWithValue("@cor", correo);
            MySqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                return true;
            }
            else
            {
                reader.Close();
                return false;
            }
        }


        /// <summary>
        ///Obtiene el código de confirmación del usuario. 
        /// </summary>
        /// <param string="usu">Nombre del usuario</param>
        /// <returns>Devuelve el código si existe.</returns>
        public static int GetCodigo(string usu)
        {
            int retorno = 0;
            string consulta = String.Format("SELECT codigo from cuenta Where nombreUsu = '{0}';", usu);
            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            //comando.Parameters.AddWithValue("@nom", usu);
            retorno = (int)comando.ExecuteScalar();
            return retorno;
        }

        /// <summary>
        /// Selecciona un correo en base a un usuario.
        /// </summary>
        /// <param name="usu">Nombre usuario</param>
        /// <returns>devuelve el correo del usuario</returns>
        public static string GetCorreo(string usu)
        {
            string retorno;
            string consulta = String.Format("SELECT correo from cuenta Where nombreUsu = '{0}';", usu);
            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            //comando.Parameters.AddWithValue("@nom", usu);
            retorno = (string)comando.ExecuteScalar();
            return retorno;
        }

        /// <summary>
        ///Cambiar código
        /// </summary>
        /// <param string="nom">Objeto casa</param>
        /// <param int = "vCode" > Objeto casa</param>
        /// <returns>Devuelve numero de control para determinar si se ha creado una casa 1 o no 0.</returns>
        public static int CambiaCodigo(string nom, int vCode)
        {
            int retorno = 0;

            string consulta = String.Format("UPDATE cuenta SET codigo = @vCode WHERE nombreUsu = @nom;");

            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            comando.Parameters.AddWithValue("@nom", nom);
            comando.Parameters.AddWithValue("vCode", vCode);
            retorno = comando.ExecuteNonQuery();

            return retorno;
        }


        public static int ActivarVerificacion(string nom)
        {
            int retorno;

            string consulta = String.Format("UPDATE cuenta SET validado = 1 WHERE nombreUsu = @nom;");

            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            comando.Parameters.AddWithValue("@nom", nom);
            retorno = comando.ExecuteNonQuery();

            return retorno;
        }
        /// <summary>
        /// Comprueba si el usuario ha validad su cuenta antes de iniciar sesión por primera vez. 
        /// </summary>
        /// <param name="usu">Nombre usuario</param>
        /// <returns>Devuelve true si el usuario está validad y false si no</returns>
        public static bool UsuarioValidado(string usu)
        {
            string consulta = String.Format("SELECT * FROM cuenta WHERE nombreUsu='{0}' AND validado=TRUE;", usu);

            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            //comando.Parameters.AddWithValue("@nom", usu);
            MySqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                return true;
            }
            else
            {
                reader.Close();
                return false;
            }
        }

        /// <summary>
        /// Cambia contraseña de usuario. 
        /// </summary>
        /// <param name="nom">nombre del usuario</param>
        /// <param name="con">contraseña del usuario</param>
        /// <returns>devuelve 1 si se ha modificado la contraseña del usuario. </returns>
        public static int CambiarContrasenya(string nom, string con)
        {
            int retorno;

            string consulta = String.Format("UPDATE cuenta SET contrasenya = @con WHERE nombreUsu = @nom;");

            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            comando.Parameters.AddWithValue("@nom", nom);
            comando.Parameters.AddWithValue("@con", con);
            retorno = comando.ExecuteNonQuery();

            return retorno;
        }



    }
    #endregion
}
