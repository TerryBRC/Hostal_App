using Hostal_App.Helper;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace Hostal_App.Services
{
    public class UsuarioService
    {
        private readonly string connectionString;

        public UsuarioService()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        }

        // Método para crear un nuevo usuario
        public bool CrearUsuario(string password, string usuario, string nombre, string apellido, string email, bool isActive)
        {
            // Encriptar la contraseña antes de almacenarla
            string encryptedPassword = EncryptionHelper.EncryptPassword(password);

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_create_usuario", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_password", password);
                command.Parameters.AddWithValue("@p_usuario", usuario);
                command.Parameters.AddWithValue("@p_nombre", nombre);
                command.Parameters.AddWithValue("@p_apellido", apellido);
                command.Parameters.AddWithValue("@p_email", email);
                command.Parameters.AddWithValue("@p_is_active", Convert.ToInt32(isActive));

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Método para actualizar un usuario existente
        public bool ActualizarUsuario(int id, string password, string usuario, string nombre, string apellido, string email, bool isActive)
        {
            // Encriptar la nueva contraseña antes de actualizarla
            string encryptedPassword = EncryptionHelper.EncryptPassword(password);

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_update_usuario", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_id", id);
                command.Parameters.AddWithValue("@p_password", password);
                command.Parameters.AddWithValue("@p_usuario", usuario);
                command.Parameters.AddWithValue("@p_nombre", nombre);
                command.Parameters.AddWithValue("@p_apellido", apellido);
                command.Parameters.AddWithValue("@p_email", email);
                command.Parameters.AddWithValue("@p_is_active", Convert.ToInt32(isActive));

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Método para eliminar un usuario
        public bool EliminarUsuario(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_delete_usuario", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_id", id);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Método para obtener todos los usuarios
        public DataTable ObtenerUsuarios()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_read_usuario", connection);
                command.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        public DataTable ObtenerUsuariosFiltrados(string filtro)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_search_usuario", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@filter", "%" + filtro + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

    }
}
