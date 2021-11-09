using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Biblioteca2
{
    public class Conexion
    {
        public static MySqlConnection conexion()
        {

            string cadenaConexion = "server=127.0.0.1;port=3306;userid=root;password='';database=bd_Biblioteca";

            try
            {
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

                return conexionBD;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                return null;
            }
        }
    }
    }
