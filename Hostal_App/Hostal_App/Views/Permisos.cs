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
    public partial class Permisos : MaterialForm
    {
        private readonly PermisoService permisoService;
        private readonly List<Permiso> permisosLogin;
        public Permisos(List<Permiso> permisosLogin)
        {
            InitializeComponent();
            permisoService = new PermisoService();
            LoadDataPermisos();
            this.permisosLogin = permisosLogin;
            Configurar();
        }
        private void Configurar()
        {
            btnAgregarPermiso.Enabled = false;
            btnActualizarPermiso.Enabled = false;
            btnEliminarPermiso.Enabled = false;
            foreach (var item in permisosLogin)
            {
                switch (item.Nombre)
                {
                    case "c permiso":
                        btnAgregarPermiso.Enabled = true;
                        break;
                    case "u permiso":
                        btnActualizarPermiso.Enabled = true;
                        break;
                    case "d permiso":
                        btnEliminarPermiso.Enabled = true;
                        break;
                    default:
                        break;
                }
            }
        }
        #region Permisos
        private void LimpiarPermisos()
        {
            lblIdPermiso.Text = "";
            txtNombrePermiso.Clear();
            txtNombrePermiso.Focus();
            Configurar();
        }
        private void LoadDataPermisos()
        {
            dataGridViewPermisos.DataSource = permisoService.ObtenerPermisos();
            dataGridViewPermisos.RowHeadersVisible = false;
        }
        private void LoadFilteredDataPermisos(string filter)
        {
            dataGridViewPermisos.DataSource = permisoService.ObtenerPermisosFiltrados(filter);
            dataGridViewPermisos.RowHeadersVisible = false;
        }
        private void dataGridViewPermisos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridViewPermisos.Rows[e.RowIndex];
                    lblIdPermiso.Text = row.Cells["id"].Value.ToString();
                    txtNombrePermiso.Text = row.Cells["nombre"].Value.ToString();
                    Configurar();
                    btnAgregarPermiso.Enabled = false;
                    btnAgregarPermiso.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el permiso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAgregarPermiso_Click(object sender, EventArgs e)
        {
            string nombrePermiso = txtNombrePermiso.Text;

            if (string.IsNullOrWhiteSpace(nombrePermiso))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (permisoService.CrearPermiso(nombrePermiso))
            {
                MessageBox.Show("Permiso guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarPermisos();
                LoadDataPermisos();
            }
            else
            {
                MessageBox.Show("Error al guardar el permiso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnActualizarPermiso_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblIdPermiso.Text);
            string nombrePermiso = txtNombrePermiso.Text;

            if (id.Equals("") || string.IsNullOrWhiteSpace(nombrePermiso))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (permisoService.ActualizarPermiso(id, nombrePermiso))
            {
                MessageBox.Show("Permiso actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarPermisos();
                LoadDataPermisos();
            }
            else
            {
                MessageBox.Show("Error al actualizar el permiso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarPermiso_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblIdPermiso.Text);

            DialogResult result = MessageBox.Show("¿Estás seguro de eliminar este permiso?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (permisoService.EliminarPermiso(id))
                {
                    MessageBox.Show("Permiso eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarPermisos();
                    LoadDataPermisos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el permiso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnBuscarPermiso_Click(object sender, EventArgs e)
        {
            string filter = txtBuscarPermiso.Text;
            if (string.IsNullOrEmpty(filter))
            {
                LoadDataPermisos();
            }
            else
            {
                LoadFilteredDataPermisos(filter);
            }

        }
        #endregion Permisos

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarPermisos();
        }
    }
}
