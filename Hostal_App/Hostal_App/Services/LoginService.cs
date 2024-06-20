using Hostal_App.Helper;
using MySql.Data.MySqlClient;
using System;
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

        public bool AutenticarUsuario(string usuario, string password)
        {

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("sp_autenticar_usuario", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_usuario", usuario);
                command.Parameters.AddWithValue("@p_password", EncryptionHelper.EncryptPassword(password)); // Utilizar la contraseña encriptada

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

