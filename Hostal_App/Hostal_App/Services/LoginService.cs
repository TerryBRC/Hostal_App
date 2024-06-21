using Hostal_App.Helper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace Hostal_App.Services
{
    public class LoginService
    {
        private readonly string connectionString;

        public LoginService()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        }

        public bool AutenticarUsuario(string usuario, string password, int grupoId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_autenticar_usuario", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_usuario", usuario);
                command.Parameters.AddWithValue("@p_password", EncryptionHelper.EncryptPassword(password));
                command.Parameters.AddWithValue("@p_grupo_id", grupoId);

                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int authenticated = reader.GetInt32("authenticated");
                        return authenticated == 1;
                    }
                }
            }

            return false;

        }
    }
}

