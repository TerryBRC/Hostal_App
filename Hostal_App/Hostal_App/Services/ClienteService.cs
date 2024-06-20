using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace Hostal_App.Services
{
    public class ClienteService
    {
        private readonly string connectionString;

        public ClienteService()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        }

        // Método para crear un nuevo cliente
        public bool CrearCliente(string nombre, string apellido, string direccion, string telefono, string email)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_create_cliente", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_nombre", nombre);
                command.Parameters.AddWithValue("@p_apellido", apellido);
                command.Parameters.AddWithValue("@p_direccion", direccion);
                command.Parameters.AddWithValue("@p_telefono", telefono);
                command.Parameters.AddWithValue("@p_email", email);
                command.Parameters.AddWithValue("@p_fecha_registro", DateTime.Now);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Método para obtener todos los clientes
        public DataTable ObtenerClientes()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_read_cliente", connection);
                command.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        // Método para actualizar un cliente existente
        public bool ActualizarCliente(int id, string nombre, string apellido, string direccion, string telefono, string email)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_update_cliente", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_id", id);
                command.Parameters.AddWithValue("@p_nombre", nombre);
                command.Parameters.AddWithValue("@p_apellido", apellido);
                command.Parameters.AddWithValue("@p_direccion", direccion);
                command.Parameters.AddWithValue("@p_telefono", telefono);
                command.Parameters.AddWithValue("@p_email", email);
                command.Parameters.AddWithValue("@p_fecha_registro", DateTime.Now);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Método para eliminar un cliente
        public bool EliminarCliente(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_delete_cliente", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_id", id);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Método para obtener clientes filtrados por nombre, apellido, dirección, teléfono o email
        public DataTable ObtenerClientesFiltrados(string filtro)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_search_cliente", connection);
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
