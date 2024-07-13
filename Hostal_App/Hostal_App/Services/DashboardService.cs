using Hostal_App.Models;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hostal_App.Services
{
    public class DashboardService
    {
        private readonly string connectionString;

        public DashboardService()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        }
        public void ApplyPermissions(List<Permiso> permisosLogin, MaterialTabControl tabControl)
        {
            var permisoDict = new Dictionary<string, bool>();

            // Crear un diccionario con los permisos
            foreach (var permiso in permisosLogin)
            {
                permisoDict[permiso.Nombre.ToLower()] = true;
            }

            // Revisar cada TabPage y establecer su visibilidad según los permisos
            foreach (TabPage tabPage in tabControl.TabPages)
            {
                string tabName = tabPage.Name.Substring(2).ToLower(); // Remover 'tp' del nombre y convertir a minúsculas
                if (permisoDict.ContainsKey($"r {tabName}"))
                {
                    tabPage.Enabled = true;
                }
                else
                {
                    tabPage.Enabled = false;
                }
            }
        }

        public DataTable ObtenerDatosReservas()
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = @"
                SELECT
                    r.id AS ReservaID,
                    r.fecha_creacion AS 'Fecha Reserva',
                    r.fecha_entrada AS 'Fecha Entrada',
                    r.fecha_salida AS 'Fecha Salida',
                    concat(c.nombre,"" "",c.Apellido) AS Cliente,
                    h.numero AS Habitacion,
                    th.tipo AS Tipo,
                    r.estado AS 'Estado Reserva'
                FROM
                    reserva r
                JOIN
                    cliente c ON r.cliente_id = c.id
                JOIN
                    habitacion h ON r.habitacion_id = h.id
                JOIN
                    tipo_habitacion th ON h.tipo_habitacion_id = th.id;";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }
            return dataTable;
        }


        public DataTable ObtenerReservasPorRangoDeFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = @"
        SELECT
            r.id AS ReservaID,
            r.fecha_creacion AS 'Fecha Reserva',
            r.fecha_entrada AS 'Fecha Entrada',
            r.fecha_salida AS 'Fecha Salida',
            CONCAT(c.nombre, ' ', c.Apellido) AS Cliente,
            h.numero AS Habitacion,
            th.tipo AS Tipo,
            r.estado AS 'Estado Reserva'
        FROM
            reserva r
        JOIN
            cliente c ON r.cliente_id = c.id
        JOIN
            habitacion h ON r.habitacion_id = h.id
        JOIN
            tipo_habitacion th ON h.tipo_habitacion_id = th.id
        WHERE
            r.fecha_creacion BETWEEN @fechaInicio AND @fechaFin;";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@fechaFin", fechaFin);

                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }
            return dataTable;
        }

        public DataTable ObtenerReservasPorTipoHabitacion(int tipoHabitacion)
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = @"
                SELECT
                    r.id AS ReservaID,
                    r.fecha_creacion AS 'Fecha Reserva',
                    r.fecha_entrada AS 'Fecha Entrada',
                    r.fecha_salida AS 'Fecha Salida',
                    CONCAT(c.nombre, ' ', c.Apellido) AS Cliente,
                    h.numero AS Habitacion,
                    th.tipo AS Tipo,
                    r.estado AS 'Estado Reserva'
                FROM
                    reserva r
                JOIN
                    cliente c ON r.cliente_id = c.id
                JOIN
                    habitacion h ON r.habitacion_id = h.id
                JOIN
                    tipo_habitacion th ON h.tipo_habitacion_id = th.id
                WHERE
                    th.id = @tipoHabitacion;";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@tipoHabitacion", tipoHabitacion);

                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }
            return dataTable;
        }

        public DataTable ObtenerClientesFrecuentes(DateTime fechaInicio, DateTime fechaFin, int minReservas)
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand("ObtenerClientesFrecuentes", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@fechaFin", fechaFin);
                    command.Parameters.AddWithValue("@minReservas", minReservas);

                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }
            return dataTable;
        }

        public DataTable ObtenerDuracionPromedioEstancia(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dataTable = new DataTable();
            string query = @"
        SELECT AVG(DATEDIFF(fecha_salida, fecha_entrada)) AS 'Promedio Estancia'
        FROM reserva
        WHERE fecha_creacion BETWEEN @fechaInicio AND @fechaFin;
    ";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@fechaFin", fechaFin);

                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader); // Cargar los datos en el DataTable
                    }
                }
            }

            return dataTable;
        }


        public DataTable ObtenerReservasPorEstado(string estado)
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = @"
        SELECT
            r.id AS ReservaID,
            r.fecha_creacion AS 'Fecha Reserva',
            r.fecha_entrada AS 'Fecha Entrada',
            r.fecha_salida AS 'Fecha Salida',
            CONCAT(c.nombre, ' ', c.Apellido) AS Cliente,
            h.numero AS Habitacion,
            r.estado AS 'Estado Reserva'
        FROM
            reserva r
        JOIN
            cliente c ON r.cliente_id = c.id
        JOIN
            habitacion h ON r.habitacion_id = h.id
        WHERE
            r.estado = @estado;";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@estado", estado);

                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader); // Cargar los datos en el DataTable
                    }
                }
            }
            return dataTable;
        }


        public DataTable ObtenerOcupacionHabitaciones(DateTime fechaInicio, DateTime fechaFin)
{
    DataTable dataTable = new DataTable();
    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        string query = @"
        SELECT
            h.numero AS Habitacion,
            COUNT(r.id) AS TotalReservas,
            SUM(DATEDIFF(r.fecha_salida, r.fecha_entrada)) AS TotalDiasOcupada
        FROM
            habitacion h
        LEFT JOIN
            reserva r ON h.id = r.habitacion_id
            AND r.fecha_entrada BETWEEN @fechaInicio AND @fechaFin
            GROUP BY h.numero;";

        using (MySqlCommand command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
            command.Parameters.AddWithValue("@fechaFin", fechaFin);

            connection.Open();
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                dataTable.Load(reader); // Cargar los datos en el DataTable
            }
        }
    }
    return dataTable;
}

    }

}
