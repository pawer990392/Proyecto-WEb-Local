using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Biblioteca2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id_usuario =txtIdUsuario.Text;
            string nombre = txtNombre.Text;
            string paterno = txtPaterno.Text;
            string materno = txtMaterno.Text;
            char Genero = char.Parse(txtGnero.Text);
            string domicilio = txtDomicilio.Text;


            string sql = "INSERT INTO Usuario (id_usuario,Nombre,Apellido_Paterno,Apellido_Materno,Genero,Domicilio) VALUES ('"+ id_usuario + "','" + nombre + "','" + paterno + "','" + materno + "','" + Genero + "','" + domicilio + "')";

            MySqlConnection conecionDB = Conexion.conexion();
            conecionDB.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conecionDB);
                comando.ExecuteNonQuery();
                MessageBox.Show("REGISTRO EXITOSO");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("NO SE GUARDO REGISTRO " + ex.Message);
            }
            finally
            {
                conecionDB.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string codigo = txtIdUsuario.Text;
            MySqlDataReader reader = null;

            string sql_Buscar = "SELECT id_usuario,Nombre,Apellido_Paterno,Apellido_Materno,Genero,Domicilio FROM Usuario WHERE id_usuario= '" + codigo + "'";
            MySqlConnection conecionDB = Conexion.conexion();
            conecionDB.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql_Buscar, conecionDB);
                reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtIdUsuario.Text = reader.GetString(0);
                        txtNombre.Text = reader.GetString(1);
                        txtPaterno.Text = reader.GetString(2);
                        txtMaterno.Text = reader.GetString(3);
                        txtGnero.Text = reader.GetString(4);
                        txtDomicilio.Text = reader.GetString(5);
                    }
                }
                else
                {
                    MessageBox.Show("NO SE ENCOTRO REGISTRO");
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR AL BUSCAR" + ex.Message);
            }
            finally
            {

                conecionDB.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id_usuario = txtIdUsuario.Text;
            string nombre = txtNombre.Text;
            string paterno = txtPaterno.Text;
            string materno = txtMaterno.Text;
            char Genero = char.Parse(txtGnero.Text);
            string domicilio = txtDomicilio.Text;


            string sql = "UPDATE Usuario SET id_usuario='"+ id_usuario + "',Nombre='"+ nombre + "',Apellido_Paterno='"+ paterno + "',Apellido_Materno='"+ materno + "',Genero='"+ Genero + "',Domicilio='"+ domicilio + "'WHERE id_usuario='"+ id_usuario + "'";

            MySqlConnection conecionDB = Conexion.conexion();
            conecionDB.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conecionDB);
                comando.ExecuteNonQuery();
                MessageBox.Show("REGISTRO ACTUALIZADO");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("NO SE ACTUALIZO CORRECTAMENTE " + ex.Message);
            }
            finally
            {
                conecionDB.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string id_usuario = txtIdUsuario.Text;
            

            string sql = "DELETE FROM WHERE id_usuario='" + id_usuario + "'";

            MySqlConnection conecionDB = Conexion.conexion();
            conecionDB.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conecionDB);
                comando.ExecuteNonQuery();
                MessageBox.Show("REGISTRO ELIMINADO");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR EN ELIMINACION" + ex.Message);
            }
            finally
            {
                conecionDB.Close();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtIdUsuario.Text = "";
            txtNombre.Text = "";
            txtPaterno.Text = "";
            txtMaterno.Text = "";
            txtGnero.Text = "";
            txtDomicilio.Text = "";
        }
    }

}
