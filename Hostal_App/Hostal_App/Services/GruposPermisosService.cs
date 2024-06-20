using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace Hostal_App.Services
{
    public class GruposPermisosService
    {
        private readonly string connectionString;

        public GruposPermisosService() => this.connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        // Método para asignar un permiso a un grupo
        public bool AsignarPermisoAGrupo(int grupoId, int permisoId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_assign_permiso_to_grupo", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_grupo_id", grupoId);
                command.Parameters.AddWithValue("@p_permiso_id", permisoId);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Método para revocar un permiso de un grupo
        public bool RevocarPermisoDeGrupo(int grupoId, int permisoId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_revoke_permiso_from_grupo", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_grupo_id", grupoId);
                command.Parameters.AddWithValue("@p_permiso_id", permisoId);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }


        // Método para obtener grupos de permisos filtrados por nombre
        public DataTable ObtenerGruposPermisosFiltrados(string filtroNombre)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_search_grupo_permisos", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_nombre", "%" + filtroNombre + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

    }
}
