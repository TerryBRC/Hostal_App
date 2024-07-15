using Hostal_App.Services;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hostal_App.Views
{
    public partial class Habitaciones : MaterialForm
    {
        private readonly HabitacionService habitacionService;
        private readonly TipoHabitacionService tipoHabitacionService;
        private readonly GrupoService grupoService;
        private readonly List<Permiso> permisosLogin;
        public Habitaciones(List<Permiso> permisos)
        {
            InitializeComponent();
            this.permisosLogin = permisos;
            habitacionService = new HabitacionService();
            tipoHabitacionService = new TipoHabitacionService();
            grupoService = new GrupoService();
            ConfigurarAccesos();
            LoadDataHabitacion();
            CargarComboBoxTipoHabitacion();
        }
        private void ConfigurarAccesos()
        {
            btnAgregarHabitacion.Enabled = false;
            btnActualizarHabitacion.Enabled = false;
            btnEliminarHabitacion.Enabled = false;

            // Configurar menús basado en los permisos
            foreach (var permiso in permisosLogin)
            {
                switch (permiso.Nombre)
                {
                    case "c habitacion":
                        btnAgregarHabitacion.Enabled = true;
                        break;
                    case "u habitacion":
                        btnActualizarHabitacion.Enabled =true;
                        break;
                    case "d habitacion":
                        btnEliminarHabitacion.Enabled = true;
                        break;
                    default:
                        break;
                }
            }
        }


        #region Habitacion
        private void LimpiarHabitacion()
        {
            lblIdH.Text = "";
            txtNumero.Clear();
            txtCapacidad.Clear();
            txtPrecioXNoche.Clear();
            ckbDisponible.Checked = true;
            cmbTipoHabitacion.SelectedIndex = -1;
            txtNumero.Focus();
            ConfigurarAccesos();
        }

        private void LoadDataHabitacion()
        {
            dataGridViewH.DataSource = habitacionService.ObtenerHabitaciones();
            dataGridViewH.RowHeadersVisible = false;
            // Ocultar la última columna (suponiendo que es la columna del Id)
            dataGridViewH.Columns[dataGridViewH.Columns.Count - 1].Visible = false;
            ckbDisponible.Checked = true;
            CargarComboBoxTipoHabitacion();
        }

        private void CargarComboBoxTipoHabitacion()
        {
            cmbTipoHabitacion.DataSource = tipoHabitacionService.ObtenerTiposHabitacion();
            cmbTipoHabitacion.DisplayMember = "Tipo";
            cmbTipoHabitacion.ValueMember = "Id";
            cmbTipoHabitacion.SelectedIndex = -1;
        }
        private void dataGridViewH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridViewH.Rows[e.RowIndex];
                    lblIdH.Text = row.Cells["Id"].Value.ToString();
                    txtNumero.Text = row.Cells["Habitacion"].Value.ToString();
                    txtCapacidad.Text = row.Cells["Capacidad"].Value.ToString();
                    txtPrecioXNoche.Text = row.Cells["Precio"].Value.ToString();
                    ckbDisponible.Checked = Convert.ToBoolean(row.Cells["Disponible"].Value);
                    cmbTipoHabitacion.SelectedValue = row.Cells["idTipo"].Value;
                    ConfigurarAccesos();
                    btnAgregarHabitacion.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de la fila seleccionada: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAgregarHabitacion_Click(object sender, EventArgs e)
        {
            string numero = txtNumero.Text;
            int capacidad = int.Parse(txtCapacidad.Text);
            decimal precioXNoche = decimal.Parse(txtPrecioXNoche.Text);
            bool disponible = ckbDisponible.Checked;
            long tipoHabitacionId = (long)cmbTipoHabitacion.SelectedValue;
            if (string.IsNullOrWhiteSpace(numero) || capacidad <= 0 || precioXNoche <= 0 || tipoHabitacionId <= 0)
            {
                MessageBox.Show("Por favor, complete todos los campos correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {


                bool resultado = habitacionService.CrearHabitacion(numero, capacidad, precioXNoche, disponible, tipoHabitacionId);

                if (resultado)
                {
                    LoadDataHabitacion();
                    LimpiarHabitacion();
                    MessageBox.Show("Habitación agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al agregar la habitación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la habitación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnActualizarHabitacion_Click(object sender, EventArgs e)
        {
            // Ejemplo de conversión segura usando TryParse

            long id;
            if (!long.TryParse(lblIdH.Text, out id) || id <= 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string numero = txtNumero.Text;
            int capacidad = int.Parse(txtCapacidad.Text);
            decimal precioXNoche = decimal.Parse(txtPrecioXNoche.Text);
            bool disponible = ckbDisponible.Checked;
            long tipoHabitacionId = (long)cmbTipoHabitacion.SelectedValue;

            // Verificar si los campos obligatorios están vacíos
            if (id <= 0 || string.IsNullOrWhiteSpace(numero) || capacidad <= 0 ||  precioXNoche <= 0 || tipoHabitacionId == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                bool resultado = habitacionService.ActualizarHabitacion(id, numero, capacidad, precioXNoche, disponible, tipoHabitacionId);

                if (resultado)
                {
                    LoadDataHabitacion();
                    LimpiarHabitacion();
                    MessageBox.Show("Habitación actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al actualizada la habitación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la habitación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnEliminarHabitacion_Click(object sender, EventArgs e)
        {
            try
            {
                long id = Convert.ToInt64(lblIdH.Text);

                if (id <= 0)
                {
                    MessageBox.Show("Por favor, seleccione una habitación válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool resultado = habitacionService.EliminarHabitacion(id);

                if (resultado)
                {
                    LoadDataHabitacion();
                    LimpiarHabitacion();
                    MessageBox.Show("Habitación eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al eliminar la habitación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la habitación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarHabitacion_Click(object sender, EventArgs e)
        {
            string filter = txtBuscarH.Text;
            if (string.IsNullOrWhiteSpace(filter))
            {
                LoadDataHabitacion();
            }
            else
            {
                dataGridViewH.DataSource = habitacionService.ObtenerHabitacionFiltrada(filter);
                dataGridViewH.RowHeadersVisible = false;
            }


        }

        #endregion Habitacion

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarHabitacion();
        }
    }
}
