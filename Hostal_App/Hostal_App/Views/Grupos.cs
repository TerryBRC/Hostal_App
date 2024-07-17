using Hostal_App.Models;
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
    public partial class Grupos : MaterialForm
    {
        private readonly GrupoService grupoService;
        private readonly List<Permiso> permisosLogin;
        public Grupos(List<Permiso> permisosLogin)
        {
            InitializeComponent();
            grupoService = new GrupoService();
            LoadDataGrupos();
            this.permisosLogin = permisosLogin;
            Configurar();
        }

        private void Configurar(bool isRowSelected = false)
        {
            btnAgregarGrupo.Enabled = false;
            btnActualizarGrupo.Enabled = false;
            btnEliminarGrupo.Enabled = false;

            foreach (var item in permisosLogin)
            {
                switch (item.Nombre)
                {
                    case "c cliente":
                        btnAgregarGrupo.Enabled = !isRowSelected;
                        break;
                    case "u cliente":
                        btnActualizarGrupo.Enabled = isRowSelected;
                        break;
                    case "d cliente":
                        btnEliminarGrupo.Enabled = isRowSelected;
                        break;
                    default:
                        break;
                }
            }
        }
        #region Grupos
        private void LimpiarGrupo()
        {
            lblIdGrupo.Text = "";
            txtNombreGrupo.Clear();
            txtNombreGrupo.Focus();
            Configurar();
        }
        private void LoadDataGrupos()
        {
            dataGridViewGrupos.DataSource = grupoService.ObtenerGrupos();
            dataGridViewGrupos.RowHeadersVisible = false;
        }
        private void LoadFilteredDataGrupos(string filter)
        {
            dataGridViewGrupos.DataSource = grupoService.ObtenerGrupoFiltrado(filter);
            dataGridViewGrupos.RowHeadersVisible = false;
        }
        private void dataGridViewGrupos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridViewGrupos.Rows[e.RowIndex];
                    lblIdGrupo.Text = row.Cells["id"].Value.ToString();
                    txtNombreGrupo.Text = row.Cells["nombre"].Value.ToString();
                    Configurar(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el grupo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAgregarGrupo_Click(object sender, EventArgs e)
        {
            string nombreGrupo = txtNombreGrupo.Text;

            if (string.IsNullOrWhiteSpace(nombreGrupo))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (grupoService.CrearGrupo(nombreGrupo))
            {
                MessageBox.Show("Grupo guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarGrupo();
                LoadDataGrupos();
            }
            else
            {
                MessageBox.Show("Error al guardar el grupo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnActualizarGrupo_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblIdGrupo.Text);
            string nombreGrupo = txtNombreGrupo.Text;

            if (id.Equals("") || string.IsNullOrWhiteSpace(nombreGrupo))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (grupoService.ActualizarGrupo(id, nombreGrupo))
            {
                MessageBox.Show("Grupo actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarGrupo();
                LoadDataGrupos();
            }
            else
            {
                MessageBox.Show("Error al actualizar el grupo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEliminarGrupo_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblIdGrupo.Text);

            DialogResult result = MessageBox.Show("¿Estás seguro de eliminar este grupo?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (grupoService.EliminarGrupo(id))
                {
                    MessageBox.Show("Grupo eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarGrupo();
                    LoadDataGrupos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el grupo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnBuscarGrupo_Click(object sender, EventArgs e)
        {
            string filter = txtBuscarGrupo.Text;
            if (string.IsNullOrEmpty(filter))
            {
                LoadDataGrupos();
            }
            else
            {
                LoadFilteredDataGrupos(filter);
            }
        }
        #endregion Grupos

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarGrupo();
        }
    }
}
