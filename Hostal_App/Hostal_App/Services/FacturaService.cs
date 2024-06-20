using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace Hostal_App.Services
{
    public class FacturaService
    {
        private readonly string connectionString;

        public FacturaService()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        }

        // Método para crear una nueva factura
        public bool CrearFactura(DateTime fechaEmision, decimal total, string detalleServicios, long reservaId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_create_factura", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_fecha_emision", fechaEmision);
                command.Parameters.AddWithValue("@p_total", total);
                command.Parameters.AddWithValue("@p_detalle_servicios", detalleServicios);
                command.Parameters.AddWithValue("@p_reserva_id", reservaId);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Método para obtener todas las facturas
        public DataTable ObtenerFacturas()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_read_factura", connection);
                command.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        // Método para actualizar una factura existente
        public bool ActualizarFactura(long id, DateTime fechaEmision, decimal total, string detalleServicios, long reservaId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_update_factura", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_id", id);
                command.Parameters.AddWithValue("@p_fecha_emision", fechaEmision);
                command.Parameters.AddWithValue("@p_total", total);
                command.Parameters.AddWithValue("@p_detalle_servicios", detalleServicios);
                command.Parameters.AddWithValue("@p_reserva_id", reservaId);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Método para eliminar una factura
        public bool EliminarFactura(long id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_delete_factura", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_id", id);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Método para obtener facturas filtradas por algún criterio
        public DataTable ObtenerFacturaFiltrada(DateTime fechaInicio, DateTime fechaFin, decimal totalMinimo, decimal totalMaximo)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_search_factura", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_fecha_inicio", fechaInicio);
                command.Parameters.AddWithValue("@p_fecha_fin", fechaFin);
                command.Parameters.AddWithValue("@p_total_minimo", totalMinimo);
                command.Parameters.AddWithValue("@p_total_maximo", totalMaximo);

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

    }
}
