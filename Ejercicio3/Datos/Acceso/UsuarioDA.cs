using Datos.Entidad;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Acceso
{
    public class UsuarioDA
    {
        readonly string cadena = "Server=localhost; Port=3306; Database=ejercicio3; Uid=root; Pwd=;";

        MySqlConnection conn;
        MySqlCommand cmd;

        public Usuario Login(string codigo, string clave)
        {
            Usuario user = null;

            try
            {
                string sql = "SELECT * FROM usuario WHERE Codigo = @Codigo AND Clave = @Clave";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql,conn);

                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.Parameters.AddWithValue("@Clave", clave);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    user = new Usuario();

                    user.Codigo = reader[0].ToString();
                    user.Nombre = reader[1].ToString();
                    user.Edad = Convert.ToInt32(reader[2]);
                    user.Clave = reader[3].ToString();
                    user.EstaActivo = Convert.ToBoolean(reader[4]);

                    reader.Close();
                    conn.Close();

                }
            }
            catch (Exception)
            {

            }
            return user;
        }

        public DataTable MostrarUsuarios()
        {
            DataTable mostrarUsuario = new DataTable();

            try
            {
                string sql = "SELECT * FROM usuario;";
                conn=new MySqlConnection(cadena);
                conn.Open();

                cmd=new MySqlCommand(sql,conn);

                MySqlDataReader reader = cmd.ExecuteReader();

                mostrarUsuario.Load(reader);    

            }
            catch (Exception)
            {

            }
            return mostrarUsuario;
        }

        public bool AgregarUsuario(Usuario usuario)
        {
            bool agregar = false;

            try
            {
                string sql = "INSERT INTO usuario VALUES(@Codigo, @Nombre, @Edad, @Clave, @EstaActivo);";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Codigo", usuario.Codigo);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Edad", usuario.Edad);
                cmd.Parameters.AddWithValue("@Clave", usuario.Clave);
                cmd.Parameters.AddWithValue("@EstaActivo", usuario.EstaActivo);

                cmd.ExecuteNonQuery();
                agregar = true;
            }
            catch (Exception)
            {

            }
            return agregar;
        }
    }
}
