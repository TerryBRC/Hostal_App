using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace Hostal_App.Services
{
    public class TipoHabitacionService
    {
        private readonly string connectionString;

        public TipoHabitacionService()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        }

        // Método para crear un nuevo tipo de habitación
        public bool CrearTipoHabitacion(string tipo, string descripcion)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_create_tipo_habitacion", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_tipo", tipo);
                command.Parameters.AddWithValue("@p_descripcion", descripcion);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Método para obtener todos los tipos de habitación
        public DataTable ObtenerTiposHabitacion()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_read_tipo_habitacion", connection);
                command.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        // Método para actualizar un tipo de habitación existente
        public bool ActualizarTipoHabitacion(long id, string tipo, string descripcion)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_update_tipo_habitacion", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_id", id);
                command.Parameters.AddWithValue("@p_tipo", tipo);
                command.Parameters.AddWithValue("@p_descripcion", descripcion);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Método para eliminar un tipo de habitación
        public bool EliminarTipoHabitacion(long id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_delete_tipo_habitacion", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_id", id);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public DataTable ObtenerTipoHabitacionFiltrados(string filtro)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_search_tipo_habitacion", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@filter", "%" + filtro + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        public List<string> ObtenerNombresTH()
        {
            List<string> nombresTH = new List<string>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_obtener_tipos_h", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string tipo = reader["Tipo"].ToString();
                        nombresTH.Add(tipo);
                    }
                }
            }

            return nombresTH;
        }


    }
}
