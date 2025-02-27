﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using PiNaranja.Clases;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace PInaranja.Clases
{
    //Clase Dispositivo. 
    internal class Dispositivo
    {
        #region - Atributos - Propiedades - Constructores -
        private string nombre;
        private bool encendido;
        private double consumoBase;
        private double consumoPrecio;
        private string certificado;
        private string tipo;
        private string estancia;
        private string nomCasa;



        public string Nombre { get => nombre; set => nombre = value; }
        public bool Encendido { get => encendido; set => encendido = value; }
        public double ConsumoBase { get => consumoBase; set => consumoBase = value; }
        public string Estancia { get => estancia; set => estancia = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public double ConsumoPrecio { get => consumoPrecio; set => consumoPrecio = value; }
        public string Certificado { get => certificado; set => certificado = value; }
        public string NomCasa { get => nomCasa; set => nomCasa = value; }

        public Dispositivo(string nombre, bool encendido, string certificado, string tipo, double consumoBase, double precioBase, string estancia, string casa)
        {
            this.nombre = nombre;
            this.encendido = encendido;
            this.certificado = certificado;
            this.tipo = tipo;
            this.consumoBase = consumoBase;
            this.consumoPrecio = precioBase;
            this.estancia = estancia;
            this.nomCasa = casa;
        }
        public Dispositivo(string nombre, bool encendido, string certificado, double consumoBase, double precioBase, string estancia)
        {
            this.nombre = nombre;
            this.encendido = encendido;
            this.certificado = certificado;
            this.consumoBase = consumoBase;
            this.consumoPrecio = precioBase;
            this.estancia = estancia;
        }

        public Dispositivo(string nombre)
        {
            this.nombre = nombre;
        }



        //Constructor para dispositivos que no esten en la base de datos.
        public Dispositivo(string nombre, string tipo, string certificado, string estancia, string nomCasa)
        {
            this.nombre = nombre;
            this.encendido = false;
            this.consumoBase = CalcularConsumo(tipo, certificado);
            this.consumoPrecio = CalcularPrecio(this.consumoBase);
            this.certificado = certificado;
            this.tipo = tipo;
            this.estancia = estancia;
            this.NomCasa = nomCasa;
        }

        //Constuctor que recibe los datos de la base de datos.
        public Dispositivo(string nombre, bool encendido, double consumoBase, string estancia, string nomCasa)
        {
            this.nombre = nombre;
            this.encendido = encendido;
            this.consumoBase = consumoBase;
            this.estancia = estancia;
            this.NomCasa = nomCasa;
        }
        //Constructor por si acaso.
        public Dispositivo()
        {

        }

        #endregion

        #region - Métodos - 

        /// <summary>
        /// Añade un dispositivo
        /// </summary>
        /// <param name="Objeto Dispositivo"></param>
        /// <returns>Número entero (0-1)que determinará si se ha creado el dispositivo o no</returns>
        public static int AgregarDispositivos(Dispositivo disp)
        {
            int retorno;

            string consulta = String.Format("INSERT INTO dispositivo VALUES (@nom,FALSE,@cert,@tipo,@cBa,@preBa,@est,@nCa);");

            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            comando.Parameters.AddWithValue("nom", disp.nombre);
            comando.Parameters.AddWithValue("cert", disp.certificado);
            comando.Parameters.AddWithValue("tipo", disp.tipo);
            comando.Parameters.AddWithValue("cBa", Math.Round(disp.consumoBase, 2));
            comando.Parameters.AddWithValue("preBa", Math.Round(disp.consumoPrecio, 2));
            comando.Parameters.AddWithValue("est", disp.estancia);
            comando.Parameters.AddWithValue("nCa", disp.nomCasa);
            retorno = comando.ExecuteNonQuery();

            Log.Add("Insertado un dispositivo --> Nombre: " + disp.Nombre + " -- Certificado: " + disp.Certificado +
               " -- Tipo: " + disp.Tipo + " -- Consumo Base: " + disp.ConsumoBase + " -- Consumo Precio: " +
               disp.ConsumoPrecio + " -- Estancia: " + disp.Estancia + " -- Nombre Casa: " + disp.NomCasa);

            return retorno;
        }

        /// <summary>
        /// Elimina un dispositivo
        /// </summary>
        /// <param name="Objeto Dispositivo"></param>
        /// <returns>Número entero (0-1)que determinará si se ha eliminado el dispositivo o no</returns>
        public static int EliminarDispositivos(string disp)
        {
            int retorno;

            string consulta = String.Format("DELETE FROM dispositivo WHERE nombreDispo = @nom;");

            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            comando.Parameters.AddWithValue("nom", disp);

            retorno = comando.ExecuteNonQuery();

            Log.Add("Dispositivo eliminado --> Nombre dispositivo: " + disp);

            return retorno;
        }


        /// <summary>
        /// Comprueba si existe el dispositivo.
        /// </summary>
        /// <param name="nombre del dispositivom(campo clave de Dispositivo)"></param>
        /// <returns>Devuelve true si ya existe el dispositivo. false si no existe. </returns>
        public static bool ValidarDispositivos(string nom)
        {
            string consulta = String.Format("Select nombreDispo FROM dispositivo WHERE nombreDispo = @nom;");

            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            comando.Parameters.AddWithValue("nom", nom);
            MySqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                return true;
            }
            reader.Close();
            return false;
        }

        /// <summary>
        /// Edita un dispositivo
        /// </summary>
        /// <param name="disp">Dispositivo</param>
        /// <returns>1 si se ha modificado un registro./returns>
        public static int EditarDispositivo(Dispositivo disp)
        {
            int retorno;

            string consulta = String.Format("UPDATE dispositivo SET certificado = @cert, tipo = @tipo, consumoBase = @cBa, precioBase = @preBa, estancia = @est WHERE nombreDispo = @nom");

            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            comando.Parameters.AddWithValue("cert", disp.certificado);
            comando.Parameters.AddWithValue("tipo", disp.tipo);
            comando.Parameters.AddWithValue("cBa", disp.consumoBase);
            comando.Parameters.AddWithValue("preBa", disp.consumoPrecio);
            comando.Parameters.AddWithValue("est", disp.estancia);
            comando.Parameters.AddWithValue("nom", disp.nombre);
            retorno = comando.ExecuteNonQuery();

            return retorno;
        }

        /// <summary>
        /// Enciende dispositivo.
        /// </summary>
        /// <param name="nombre del dispositivom(campo clave de Dispositivo)"></param>
        /// <returns>Número entero (0-1)que determinará si se ha eliminado el dispositivo o no</returns>
        public static int Encender(string disp)
        {
            int retorno;

            string consulta = String.Format("UPDATE dispositivo SET encendido = TRUE WHERE nombreDispo = '{0}'", disp);

            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            retorno = comando.ExecuteNonQuery();

            Log.Add("Dispositivo encendido --> Nombre: " + disp);

            return retorno;
        }

        /// <summary>
        /// Apaga dispositivo.
        /// </summary>
        /// <param name="nombre del dispositivom(campo clave de Dispositivo)"></param>
        /// <returns>Número entero (0-1)que determinará si se ha eliminado el dispositivo o no.</returns>
        public static int Apagar(string disp)
        {
            int retorno;

            string consulta = String.Format("UPDATE dispositivo SET encendido = FALSE WHERE nombreDispo = '{0}'", disp);

            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            retorno = comando.ExecuteNonQuery();

            Log.Add("Dispositivo apagado --> Nombre: " + disp);

            return retorno;
        }

        /// <summary>
        /// Cambia el estado del dispositivo
        /// </summary>
        /// <param name="nom">Nombre</param>
        /// <param name="enc">Encendido</param>
        /// <returns>1 si ha modificado un registro.</returns>
        public static int AlterarEstado(string nom, bool enc)
        {
            int retorno;
            bool estado;
            string consulta;
            if (enc == false)
            {
                estado = true;
            }
            else
            {
                estado = false;
            }
            consulta = String.Format("UPDATE dispositivo SET encendido = @est WHERE nombreDispo = @nom;");
            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            comando.Parameters.AddWithValue("nom", nom);
            comando.Parameters.AddWithValue("est", estado);
            retorno = comando.ExecuteNonQuery();

            return retorno;
        }

        /// <summary>
        /// Genera el consumo base de los dispositivos
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="certificado"></param>
        /// <returns>Cantidad de consumo base.</returns>
        public static double CalcularConsumo(string tipo, string certificado)
        {
            double consumoBase;
            switch (tipo)
            {
                case "Lavadora":
                    consumoBase = 410;
                    break;
                case "Horno":
                    consumoBase = 860;
                    break;
                case "Lavavajillas":
                    consumoBase = 380;
                    break;
                case "TV":
                    consumoBase = 200;
                    break;
                case "Luces":
                    consumoBase = 10;
                    break;
                case "Persianas":
                    consumoBase = 540;
                    break;
                case "Sistema de Riego":
                    consumoBase = 100;
                    break;
                default:
                    consumoBase = 0;
                    break;
            }
            switch (certificado)
            {
                case "A":
                    consumoBase *= 0.10;
                    break;
                case "B":
                    consumoBase *= 0.25;
                    break;
                case "C":
                    consumoBase *= 0.30;
                    break;
                case "D":
                    consumoBase *= 0.35;
                    break;
                case "E":
                    consumoBase *= 0.47;
                    break;
                case "F":
                    consumoBase *= 0.65;
                    break;
                case "G":
                    consumoBase *= 0.90;
                    break;
            }

            return consumoBase;
        }

        /// <summary>
        /// Calcula el precio del consumo en base al coste de la luz.
        /// </summary>
        /// <param name="consumoBase"></param>
        /// <returns>coste del consumo por hora</returns>

        public static double CalcularPrecio(double consumoBase)
        {
            return consumoBase * 0.2;
        }

        //public static double TotalConsumo()
        //{
        //    double consumo = 0;

        //    return consumo;
        //}

        /// <summary>
        /// Lista los dispositivos
        /// </summary>
        /// <param name="casa"></param>
        /// <returns>lista de dispositivos</returns>
        public static List<Dispositivo> ListaDispositivos1(string casa)
        {
            List<Dispositivo> lista = new List<Dispositivo>();
            String consulta = String.Format("SELECT * FROM dispositivo WHERE nCasa=('{0}');", casa);
            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Dispositivo(reader.GetString(0), reader.GetBoolean(1), reader.GetString(2), reader.GetString(3),
                    reader.GetDouble(4), reader.GetDouble(5), reader.GetString(6), reader.GetString(7)));
            }
            return lista;
        }

        /// <summary>
        /// Otra lista de dispositivo
        /// </summary>
        /// <param name="casa"></param>
        /// <returns>Listea de disposiivo</returns>
        public static List<Dispositivo> ListaDispositivos2(string casa)
        {
            List<Dispositivo> lista = new List<Dispositivo>();
            String consulta = String.Format("SELECT nombreDispo FROM dispositivo WHERE nCasa=('{0}');", casa);
            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Dispositivo(reader.GetString(0)));
            }
            return lista;
        }

        /// <summary>
        /// Obtiene un dispositivo
        /// </summary>
        /// <param name="nom"></param>
        /// <returns>Dispositivo</returns>
        public static Dispositivo ObtenerDatosDispo(string nom)
        {
            Dispositivo dispositivo = new Dispositivo();
            String consulta = String.Format("SELECT * FROM dispositivo WHERE nombreDispo = @nom;");
            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            comando.Parameters.AddWithValue("nom", nom);
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                dispositivo = new Dispositivo(reader.GetString(0), reader.GetBoolean(1),
                reader.GetString(2), reader.GetString(3), reader.GetDouble(4),
                reader.GetDouble(5), reader.GetString(6), reader.GetString(7));
            }
            return dispositivo;
        }

        /// <summary>
        /// Estado de un dispositivo
        /// </summary>
        /// <param name="dispo"></param>
        /// <returns>true si está encendido false si está apagado.</returns>
        public static bool GetEstado(string dispo)
        {
            bool retorno;
            string consulta = String.Format("SELECT encendido from dispositivo Where nombreDispo = '{0}';", dispo);
            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            //comando.Parameters.AddWithValue("@nom", usu);
            retorno = (bool)comando.ExecuteScalar();
            return retorno;
        }


        #endregion

    }
}
