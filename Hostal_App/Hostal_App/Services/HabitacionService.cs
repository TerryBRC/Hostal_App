using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace Hostal_App.Services
{
    public class HabitacionService
    {
        private readonly string connectionString;

        public HabitacionService()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        }

        // Método para crear una nueva habitación
        public bool CrearHabitacion(string numero, int capacidadMaxima, decimal precioPorNoche, bool disponible, long tipoHabitacionId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_create_habitacion", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_numero", numero);
                command.Parameters.AddWithValue("@p_capacidad_maxima", capacidadMaxima);
                command.Parameters.AddWithValue("@p_precio_por_noche", precioPorNoche);
                command.Parameters.AddWithValue("@p_disponible", disponible ? 1 : 0);
                command.Parameters.AddWithValue("@p_tipo_habitacion_id", tipoHabitacionId);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Método para obtener todas las habitaciones
        public DataTable ObtenerHabitaciones()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_read_habitacion", connection);
                command.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        // Método para actualizar una habitación existente
        public bool ActualizarHabitacion(long id, string numero, int capacidadMaxima, decimal precioPorNoche, bool disponible, long tipoHabitacionId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_update_habitacion", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_id", id);
                command.Parameters.AddWithValue("@p_numero", numero);
                command.Parameters.AddWithValue("@p_capacidad_maxima", capacidadMaxima);
                command.Parameters.AddWithValue("@p_precio_por_noche", precioPorNoche);
                command.Parameters.AddWithValue("@p_disponible", disponible ? 1 : 0);
                command.Parameters.AddWithValue("@p_tipo_habitacion_id", tipoHabitacionId);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Método para eliminar una habitación
        public bool EliminarHabitacion(long id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_delete_habitacion", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_id", id);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public DataTable ObtenerHabitacionFiltrada(string filtroNumero)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_search_habitacion", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_numero", "%" + filtroNumero + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }


    }
}
