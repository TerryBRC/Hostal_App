using Hostal_App.Models;
using Hostal_App.Services;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using LiveCharts;
using LiveCharts.Wpf;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hostal_App.Views;
using System.Diagnostics;
using System.IO;

namespace Hostal_App
{
    public partial class DashboardForm : MaterialForm
    {
        private readonly List<Permiso> permisosLogin;
        private readonly ReservaService reservaService;
        private readonly GrupoService grupoService;
        private readonly int grupoId;

        public DashboardForm(List<Permiso> permisos, int grupo)
        {
            InitializeComponent();
            this.permisosLogin = permisos;
            this.grupoId = grupo;
            ConfigurarMenu();
            cargarPermisos();
            reservaService = new ReservaService();
            grupoService = new GrupoService();
            CargarBotonesBackup();
            CargarGraficoReservasPorMes();
            CargarGraficoReservasPorTipoHabitacion();
        }
        private void CargarBotonesBackup()
        {
            btnBackup.Visible = false;
            btnRestore.Visible = false;
            string gr = grupoService.ObtenerNombreGrupoPorId(grupoId);
            if (gr == "Administrador" || grupoId == 1)
            {
                btnBackup.Visible = true;
                btnRestore.Visible= true;
            }
        }
        private void ConfigurarMenu()
        {
            // Ocultar todos los menús al inicio
            clientesToolStripMenuItem.Visible = false;
            gruposToolStripMenuItem.Visible = false;
            gruposPermisosToolStripMenuItem.Visible = false;
            habitacionesToolStripMenuItem.Visible = false;
            tipoDeHabitacionesToolStripMenuItem.Visible = false;
            permisosToolStripMenuItem.Visible = false;
            reservasToolStripMenuItem.Visible = false;
            usuariosToolStripMenuItem.Visible = false;
            informesToolStripMenuItem.Visible = false;

            // Configurar menús basado en los permisos
            foreach (var permiso in permisosLogin)
            {
                switch (permiso.Nombre)
                {
                    case "r cliente":
                        clientesToolStripMenuItem.Visible = true;
                        break;
                    case "r grupo":
                        gruposToolStripMenuItem.Visible = true;
                        break;
                    case "r grupospermisos":
                        gruposPermisosToolStripMenuItem.Visible = true;
                        break;
                    case "r habitacion":
                        habitacionesToolStripMenuItem.Visible = true;
                        break;
                    case "r permiso":
                        permisosToolStripMenuItem.Visible = true;
                        break;
                    case "r reserva":
                        reservasToolStripMenuItem.Visible = true;
                        informesToolStripMenuItem.Visible= true;
                        cartesianChart2.Visible= true;
                        cartesianChart1.Visible= true;
                        lblrm.Visible= true;
                        lblrth.Visible= true;
                        break;
                    case "r usuario":
                        usuariosToolStripMenuItem.Visible = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private void cargarPermisos()
        {
            // Limpiar la lista antes de cargar los permisos para evitar duplicados
            lbPermisos.Items.Clear();

            // Agregar los permisos al ListBox
            foreach (Permiso permiso in permisosLogin)
            {
                lbPermisos.Items.Add(permiso.Nombre);
            }
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.Clientes cliente = new Views.Clientes(permisosLogin);
            cliente.ShowDialog();
        }

        private void gruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.Grupos grupos = new Views.Grupos(permisosLogin);
            grupos.ShowDialog();
        }

        private void gruposPermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.GruposPermisos gruposP = new Views.GruposPermisos(permisosLogin);
            gruposP.ShowDialog();
        }

        private void habitacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.Habitaciones h = new Views.Habitaciones(permisosLogin);
            h.ShowDialog();
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.Permisos p = new Views.Permisos(permisosLogin);
            p.ShowDialog();
        }

        private void reservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.Reservas reservas = new Views.Reservas(permisosLogin);
            reservas.ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.Usuarios usuarios = new Views.Usuarios(permisosLogin);
            usuarios.ShowDialog();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ocultar el formulario login en lugar de cerrarlo
            this.Hide();

            // Mostrar el formulario de inicio de sesión
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog(); // Usar ShowDialog para esperar hasta que se cierre el formulario de inicio de sesión

        }



        private void CargarGraficoReservasPorMes()
        {
            List<ReservaPorMes> reservasPorMes = reservaService.ObtenerReservasPorMes();

            // Crear las listas para el gráfico
            List<string> meses = new List<string>();
            List<int> cantidadReservas = new List<int>();

            foreach (var reserva in reservasPorMes)
            {
                meses.Add(reserva.Mes);
                cantidadReservas.Add(reserva.CantidadReservas);
            }

            // Configurar el gráfico
            cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Reservas",
                    Values = new ChartValues<int>(cantidadReservas)
                }
            };

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Mes",
                Labels = meses
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Cantidad de Reservas por Mes"
            });
        }


        private void CargarGraficoReservasPorTipoHabitacion()
        {
            List<ReservaPorTipoH> reservasPorTipo = reservaService.GetReservasPorTipoHabitacion();

            // Crear las listas para el gráfico
            List<string> tiposHabitacion = new List<string>();
            List<int> cantidadReservas = new List<int>();

            foreach (var reserva in reservasPorTipo)
            {
                tiposHabitacion.Add(reserva.TipoHabitacion);
                cantidadReservas.Add(reserva.CantidadReservas);
            }

            // Configurar el gráfico
            cartesianChart2.Series = new SeriesCollection
    {
        new ColumnSeries
        {
            Title = "Reservas",
            Values = new ChartValues<int>(cantidadReservas)
        }
    };

            cartesianChart2.AxisX.Add(new Axis
            {
                Title = "Tipo de Habitación",
                Labels = tiposHabitacion
            });

            cartesianChart2.AxisY.Add(new Axis
            {
                Title = "Cantidad de Reservas por Tipo de Habitación"
            });
        }
    

        private void tipoDeHabitacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.TipoHabitaciones th = new Views.TipoHabitaciones(permisosLogin);
            th.ShowDialog();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            // Crear y configurar el SaveFileDialog
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Guardar respaldo de la base de datos";
                saveFileDialog.Filter = "SQL Files|*.sql";
                saveFileDialog.FileName = $"backup_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.sql";

                // Mostrar el SaveFileDialog y verificar si el usuario seleccionó una ubicación
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fullPath = saveFileDialog.FileName;

                    // Definir los detalles de conexión de MySQL
                    string server = "localhost"; // Cambia esto por tu servidor MySQL
                    string database = "hostal_db"; // Cambia esto por tu base de datos
                    string user = "root"; // Cambia esto por tu usuario MySQL
                    string password = "root"; // Cambia esto por tu contraseña MySQL

                    // Construir el comando mysqldump
                    string mysqldumpPath = @"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysqldump.exe"; // Cambia esto a la ruta de mysqldump en tu sistema
                    string arguments = $"--host={server} --user={user} --password={password} {database} --result-file=\"{fullPath}\"";

                    try
                    {
                        // Crear el proceso para ejecutar mysqldump
                        ProcessStartInfo psi = new ProcessStartInfo
                        {
                            FileName = mysqldumpPath,
                            Arguments = arguments,
                            RedirectStandardOutput = true,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        };

                        using (Process process = Process.Start(psi))
                        {
                            using (StreamReader reader = process.StandardOutput)
                            {
                                string result = reader.ReadToEnd();
                                MessageBox.Show("Respaldo completado con éxito", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al realizar el respaldo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
    }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            // Crear y configurar el OpenFileDialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Seleccionar archivo de respaldo SQL";
                openFileDialog.Filter = "SQL Files|*.sql";

                // Mostrar el OpenFileDialog y verificar si el usuario seleccionó un archivo
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string backupFilePath = openFileDialog.FileName;

                    // Definir los detalles de conexión de MySQL
                    string server = "localhost"; // Cambia esto por tu servidor MySQL
                    string database = "hostal_db"; // Cambia esto por tu base de datos
                    string user = "root"; // Cambia esto por tu usuario MySQL
                    string password = "root"; // Cambia esto por tu contraseña MySQL

                    // Construir el comando mysql
                    string mysqlPath = @"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysql.exe"; // Ruta de mysql en tu sistema
                    string arguments = $"--host={server} --user={user} --password={password} {database} < \"{backupFilePath}\"";

                    try
                    {
                        // Crear el proceso para ejecutar mysql
                        ProcessStartInfo psi = new ProcessStartInfo
                        {
                            FileName = mysqlPath,
                            Arguments = arguments,
                            RedirectStandardInput = true,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        };

                        using (Process process = Process.Start(psi))
                        {
                            process.StandardInput.Close(); // Cerrar la entrada estándar después de iniciar el proceso

                            // Esperar a que el proceso termine
                            process.WaitForExit();

                            MessageBox.Show("Restauración completada con éxito", "Restauración", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al restaurar la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void informesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reportes infor = new Reportes();
            infor.ShowDialog();
        }
    }

    public class Permiso
    {
        public int Id { get; set; }
        public string Nombre { get; set; } // Nombre del permiso
        public bool PuedeCrear { get; set; }
        public bool PuedeLeer { get; set; }
        public bool PuedeActualizar { get; set; }
        public bool PuedeEliminar { get; set; }
    }
}
