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
    public partial class TipoHabitaciones : MaterialForm
    {
        private readonly TipoHabitacionService tipoHabitacionService;
        private readonly List<Permiso> permisosLogin;
        public TipoHabitaciones(List<Permiso> permisosLogin)
        {
            InitializeComponent();
            tipoHabitacionService = new TipoHabitacionService();
            this.permisosLogin = permisosLogin;
            LoadDataTipoHabitacion();
            Configurar();
            LimpiarTipoHabitacion();
        }

        private void Configurar()
        {
            btnAgregarTH.Enabled = false;
            btnActualizarTH.Enabled = false;
            btnEliminarTH.Enabled = false;
            foreach (var item in permisosLogin)
            {
                switch (item.Nombre)
                {
                    case "c tipohabitacion":
                        btnAgregarTH.Enabled = true;
                        break;
                    case "u tipohabitacion":
                        btnActualizarTH.Enabled = true;
                        break;
                    case "d tipohabitacion":
                        btnEliminarTH.Enabled = true;
                        break;
                    default:
                        break;
                }
            }
        }
        #region Tipo_Habitacion
        private void LimpiarTipoHabitacion()
        {
            lblIdTH.Text = "";
            txtTipo.Clear();
            txtDescripcion.Clear();
            txtTipo.Focus();
            btnAgregarTH.Enabled = true;
            btnActualizarTH.Enabled = false;
            btnEliminarTH.Enabled = false;
        }

        private void LoadDataTipoHabitacion()
        {
            dataGridViewTH.DataSource = tipoHabitacionService.ObtenerTiposHabitacion();
            dataGridViewTH.RowHeadersVisible = false;
        }

        private void LoadFilteredDataTH(string filter)
        {
            dataGridViewTH.DataSource = tipoHabitacionService.ObtenerTipoHabitacionFiltrados(filter);
            dataGridViewTH.RowHeadersVisible = false;
        }

        private void btnAgregarTH_Click(object sender, EventArgs e)
        {
            string tipo = txtTipo.Text;
            string descripcion = txtDescripcion.Text;

            if (string.IsNullOrWhiteSpace(tipo) || string.IsNullOrWhiteSpace(descripcion))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tipoHabitacionService.CrearTipoHabitacion(tipo, descripcion))
            {
                MessageBox.Show("Tipo de Habitación guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarTipoHabitacion();
                LoadDataTipoHabitacion();
            }
            else
            {
                MessageBox.Show("Error al guardar el tipo de habitación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnActualizarTH_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblIdTH.Text);
            string tipo = txtTipo.Text;
            string descripcion = txtDescripcion.Text;

            if (id.Equals("") || string.IsNullOrWhiteSpace(tipo) || string.IsNullOrWhiteSpace(descripcion))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tipoHabitacionService.ActualizarTipoHabitacion(id, tipo, descripcion))
            {
                MessageBox.Show("Tipo Habitación actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarTipoHabitacion();
                LoadDataTipoHabitacion();
            }
            else
            {
                MessageBox.Show("Error al actualizar el Tipo de Habitación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEliminarTH_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblIdTH.Text);

            DialogResult result = MessageBox.Show("¿Estás seguro de eliminar el tipo de habitación?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (tipoHabitacionService.EliminarTipoHabitacion(id))
                {
                    MessageBox.Show("Tipo de Habiación eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarTipoHabitacion();
                    LoadDataTipoHabitacion();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el tipo de habitación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dataGridViewTH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridViewTH.Rows[e.RowIndex];
                    lblIdTH.Text = row.Cells["id"].Value.ToString();
                    txtTipo.Text = row.Cells["tipo"].Value.ToString();
                    txtDescripcion.Text = row.Cells["descripcion"].Value.ToString();
                    Configurar();
                    btnAgregarTH.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el tipo de habitación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBuscarTH_Click(object sender, EventArgs e)
        {
            string filter = txtBuscarTH.Text;
            if (string.IsNullOrEmpty(filter))
            {
                LoadDataTipoHabitacion();
            }
            else
            {
                LoadFilteredDataTH(filter);
            }
        }
        #endregion Tipo_Habitacion

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarTipoHabitacion();
        }
    }
}
