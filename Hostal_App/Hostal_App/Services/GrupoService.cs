using Hostal_App.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace Hostal_App.Services
{
    public class GrupoService
    {
        private readonly string connectionString;

        public GrupoService()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        }

        // Método para crear un nuevo grupo
        public bool CrearGrupo(string nombre)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_create_grupo", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_nombre", nombre);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Método para obtener todos los grupos
        public DataTable ObtenerGrupos()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_read_grupo", connection);
                command.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        // Método para actualizar un grupo existente
        public bool ActualizarGrupo(int id, string nombre)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_update_grupo", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_id", id);
                command.Parameters.AddWithValue("@p_nombre", nombre);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Método para eliminar un grupo
        public bool EliminarGrupo(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_delete_grupo", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_id", id);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Método para obtener un grupo filtrado por nombre
        public DataTable ObtenerGrupoFiltrado(string filtro)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_search_grupo", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_filter", "%" + filtro + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        public List<string> ObtenerNombresGrupos()
        {
            List<string> nombresGrupos = new List<string>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_obtener_nombres_grupos", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nombreGrupo = reader["nombre"].ToString();
                        nombresGrupos.Add(nombreGrupo);
                    }
                }
            }

            return nombresGrupos;
        }
 


        public int ObtenerIdGrupoPorNombre(string nombreGrupo)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("SELECT id FROM grupos WHERE nombre = @nombreGrupo", connection);
                command.Parameters.AddWithValue("@nombreGrupo", nombreGrupo);

                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int grupoId))
                {
                    return grupoId;
                }
                return -1; // Valor que indica que no se encontró el grupo
            }
        }
        public string ObtenerNombreGrupoPorId(int idGrupo)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("SELECT nombre FROM grupos WHERE id = @IdGrupo", connection);
                command.Parameters.AddWithValue("@IdGrupo", idGrupo);

                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    return result.ToString(); // Devuelve el nombre del grupo encontrado
                }
                return null; // Si no se encontró ningún grupo con ese ID
            }
        }




        public List<Permiso> ObtenerPermisosPorGrupo(int grupoId)
        {
            List<Permiso> permisos = new List<Permiso>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT p.id, p.nombre FROM Permisos p " +
                               "INNER JOIN grupos_permisos gp ON p.id = gp.permiso_id " +
                               "WHERE gp.grupo_id = @grupoId";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@grupoId", grupoId);

                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Permiso permiso = new Permiso
                        {
                            Id = reader.GetInt32("id"),
                            Nombre = reader.GetString("nombre")
                        };

                        permisos.Add(permiso);
                    }
                }
            }

            return permisos;
        }

    }
}
