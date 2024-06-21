using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace Hostal_App.Services
{
    public class ConfiguracionSistemaService
    {
        private readonly string connectionString;

        public ConfiguracionSistemaService()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        }

        // Método para crear una nueva configuración del sistema
        public bool CrearConfiguracion(string clave, string valor)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_create_configuracion_sistema", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_clave", clave);
                command.Parameters.AddWithValue("@p_valor", valor);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Método para obtener la configuración del sistema

        public DataTable ObtenerConfiguraciones()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_read_configuracion_sistema", connection);
                command.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        // Método para actualizar la configuración del sistema
        public bool ActualizarConfiguracion(int id, string clave, string valor)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_update_configuracion_sistema", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_id", id);
                command.Parameters.AddWithValue("@p_clave", clave);
                command.Parameters.AddWithValue("@p_valor", valor);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Método para obtener configuraciones filtradas por clave o valor
        public DataTable ObtenerConfiguracionesFiltradas(string filtro)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_search_config", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_filter", filtro);

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        // Método para obtener la configuración del sistema por clave
        public string ObtenerConfiguracionByClave(string clave)
        {
            string valor = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_read_configuracion_sistema_by_clave", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_clave", clave);

                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    valor = result.ToString();
                }
            }

            return valor;
        }
        public bool EliminarConfiguracion(long id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_delete_configuracion_sistema", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_id", id);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

    }
}
