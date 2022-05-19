﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiNaranja.Clases;

namespace PInaranja.Clases
{
    class Casa
    {
        private string nombreCasa;
        private string propietario;

        public string NombreCasa { get { return nombreCasa; } set { nombreCasa = value; } }
        public string Propietario { get { return propietario; } set { propietario = value; } }
        public Casa(string nomCasa, string prop)
        {
            this.nombreCasa = nomCasa;
            this.propietario = prop;
        }

        public Casa() { }


<<<<<<< HEAD
        /// <summary>
        ///Agrega la casa del usuario
        /// </summary>
        /// <param casa="Cas">Objeto casa</param>
        /// <returns>Devuelve numero de control para determinar si se ha creado una casa 1 o no 0.</returns>
=======
>>>>>>> 19e1441a09eab5b4558e68b0970ce930aec73bd9
        public static int AgregaCasa(Casa cas)
        {
            int retorno;

            string consulta = String.Format("INSERT INTO casa (nombrecasa,propietario) VALUES ('{0}','{1}')", cas.nombreCasa, cas.propietario);

            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            //comando.Parameters.AddWithValue("nomCasa", cas.nombreCasa);
            //comando.Parameters.AddWithValue("prop", cas.propietario);
            retorno = comando.ExecuteNonQuery();

            return retorno;
        }

<<<<<<< HEAD

        /// <summary>
        ///Elimina casa
        /// </summary>
        /// <param string="prop">nombre del propietario</param>
        /// <returns>Devuelve numero de control para determinar si se ha eliminado una casa 1 o no 0.</returns>
        public static int EliminaCasa(string prop)
        {
            //se tiene que rehacer esta parte para que se elimine todo lo registrao para el usuario
            int retorno;
            string consulta = String.Format("DELETE FROM casa WHERE propietario='{0}';", prop);
=======
        public static int EliminaUsuario(string nomCasa, string prop)
        {
            //se tiene que rehacer esta parte para que se elimine todo lo registrao para el usuario
            int retorno;
            string consulta = String.Format("DELETE FROM casa WHERE nombrecasa='{0}' AND propietario='{1}', ON" +
                "DELETE CASCADE", nomCasa, prop);
>>>>>>> 19e1441a09eab5b4558e68b0970ce930aec73bd9
            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
<<<<<<< HEAD


        /// <summary>
        ///Comprueba si casa existe. 
        /// </summary>
        /// <param String="usu">Nombre del propietario de casa</param>
        /// <returns>Devuelve el nombre del propietario de la casa.</returns>
        public static string ObtenerCasa(string usu)
        {
            string consulta = string.Format("SELECT nombreCasa from casa Where propietario = '{0}';",usu);
            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            //comando.Parameters.AddWithValue("@nom", usu);
            string reader = (string)comando.ExecuteScalar();
            return reader.ToString();
        }


        /// <summary>
        ///Obtiene toda la informacion de casa. 
        /// </summary>
        /// <param string="casa">nombre de la casa</param>
        /// <returns>Devuelve true si la casa existe y false si no existe. </returns>
        public static bool CasaYaRegistrada(string casa)
        {
            string consulta = String.Format("SELECT * FROM casa WHERE nombreCasa='{0}'", casa);

=======
        
        public static string ObtenerCasa(string usu)
        {
            string consulta = string.Format("SELECT nombreCasa from casa Where propietario = '{0}';",usu);
>>>>>>> 19e1441a09eab5b4558e68b0970ce930aec73bd9
            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            //comando.Parameters.AddWithValue("@nom", usu);
            string reader = (string)comando.ExecuteScalar();
            return reader.ToString();
        }
<<<<<<< HEAD


=======
>>>>>>> 19e1441a09eab5b4558e68b0970ce930aec73bd9
    }
}
