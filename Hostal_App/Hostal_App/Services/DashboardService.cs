using Hostal_App.Models;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
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


    }
}
