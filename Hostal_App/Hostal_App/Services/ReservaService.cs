using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace Hostal_App.Services
{
    internal class ReservaService
    {
        private readonly string connectionString;

        public ReservaService()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        }

        // Método para crear una nueva reserva
        public bool CrearReserva(DateTime fechaEntrada, DateTime fechaSalida, int numeroHuespedes, long estadoId, long clienteId, long habitacionId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_create_reserva", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_fecha_entrada", fechaEntrada);
                command.Parameters.AddWithValue("@p_fecha_salida", fechaSalida);
                command.Parameters.AddWithValue("@p_numero_huespedes", numeroHuespedes);
                command.Parameters.AddWithValue("@p_estado_id", estadoId);
                command.Parameters.AddWithValue("@p_cliente_id", clienteId);
                command.Parameters.AddWithValue("@p_habitacion_id", habitacionId);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Método para obtener todas las reservas
        public DataTable ObtenerReservas()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_read_reserva", connection);
                command.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        // Método para actualizar una reserva existente
        public bool ActualizarReserva(long id, DateTime fechaEntrada, DateTime fechaSalida, int numeroHuespedes, long estadoId, long clienteId, long habitacionId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_update_reserva", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_id", id);
                command.Parameters.AddWithValue("@p_fecha_entrada", fechaEntrada);
                command.Parameters.AddWithValue("@p_fecha_salida", fechaSalida);
                command.Parameters.AddWithValue("@p_numero_huespedes", numeroHuespedes);
                command.Parameters.AddWithValue("@p_estado_id", estadoId);
                command.Parameters.AddWithValue("@p_cliente_id", clienteId);
                command.Parameters.AddWithValue("@p_habitacion_id", habitacionId);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Método para eliminar una reserva
        public bool EliminarReserva(long id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_delete_reserva", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_id", id);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public DataTable ObtenerReservasFiltradas(string filtro)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_search_reserva", connection);
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
