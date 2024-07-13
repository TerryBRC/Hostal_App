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
    public partial class GruposPermisos : MaterialForm
    {
        private readonly GruposPermisosService gruposPermisosService;
        private readonly PermisoService permisoService;
        private readonly GrupoService grupoService;
        private readonly List<Permiso> permisosLogin;
        public GruposPermisos(List<Permiso> permisosLogin)
        {
            InitializeComponent();
            gruposPermisosService = new GruposPermisosService();
            grupoService = new GrupoService();
            permisoService = new PermisoService();
            LoadDataGruposPermisos();
            CargarComboBoxGrupos();
            CargarComboBoxPermisos();
            this.permisosLogin = permisosLogin;
            Configurar();
            LimpiarGruposPermisos();
        }
        private void Configurar()
        {
            btnAgregarGrupoPermiso.Enabled = false;            
            btnEliminarGrupoPermiso.Enabled = false;
            foreach (var item in permisosLogin)
            {
                switch (item.Nombre)
                {
                    case "c grupospermisos":
                        btnAgregarGrupoPermiso.Enabled = true;
                        break;
                    case "d grupospermisos":
                        btnEliminarGrupoPermiso.Enabled = true;
                        break;
                    default:
                        break;
                }
            }
        }
        #region Grupos/Permisos
        private void LimpiarGruposPermisos()
        {
            lblIdPermisosGrupos.Text = "";
            cmbPermisos.SelectedIndex = -1;
            cmbGrupos.SelectedIndex = -1;
            cmbGrupos.Focus();
            btnAgregarGrupoPermiso.Enabled = true;
            btnEliminarGrupoPermiso.Enabled = false;
        }
        private void CargarComboBoxPermisos()
        {

            // Obtener los nombres de los permisos
            List<string> nombresPermisos = permisoService.ObtenerNombresPermisos();

            // Limpiar el ComboBox antes de cargar los nuevos datos
            cmbPermisos.Items.Clear();

            // Agregar los nombres de los permisos al ComboBox
            foreach (string nombrePermiso in nombresPermisos)
            {
                cmbPermisos.Items.Add(nombrePermiso);
            }
        }
        private void CargarComboBoxGrupos()
        {
            // Obtener los nombres de los permisos
            List<string> nombresGrupos = grupoService.ObtenerNombresGrupos();

            // Limpiar el ComboBox antes de cargar los nuevos datos
            cmbGrupos.Items.Clear();

            // Agregar los nombres de los permisos al ComboBox
            foreach (string gg in nombresGrupos)
            {
                cmbGrupos.Items.Add(gg);
            }
        }


        private void LoadDataGruposPermisos()
        {
            dataGridViewGruposPermisos.DataSource = gruposPermisosService.ObtenerGruposPermisos();
            dataGridViewGruposPermisos.RowHeadersVisible = false;

            CargarComboBoxPermisos();
            CargarComboBoxGrupos();
        }

        private void dataGridViewGruposPermisos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridViewGruposPermisos.Rows[e.RowIndex];
                    // Obtener datos de la fila seleccionada
                    string idGruposPermisos = row.Cells["Id"].Value.ToString();
                    string nombreGrupo = row.Cells["Grupo"].Value.ToString();
                    string nombrePermiso = row.Cells["Permiso"].Value.ToString();

                    // Mostrar los datos en los ComboBox correspondientes
                    lblIdPermisosGrupos.Text = idGruposPermisos; // Mostrar el ID en un control Label
                    cmbGrupos.SelectedItem = nombreGrupo;
                    cmbPermisos.SelectedItem = nombrePermiso;
                    Configurar();
                    btnAgregarGrupoPermiso.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de la fila seleccionada: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarGrupoPermiso_Click(object sender, EventArgs e)
        {
            string nombreGrupo = cmbGrupos.SelectedItem?.ToString();
            string nombrePermiso = cmbPermisos.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(nombreGrupo) || string.IsNullOrWhiteSpace(nombrePermiso))
            {
                MessageBox.Show("Por favor, seleccione un grupo y un permiso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener los IDs de grupo y permiso
            int grupoId = grupoService.ObtenerIdGrupoPorNombre(nombreGrupo);
            int permisoId = permisoService.ObtenerIdPermisoPorNombre(nombrePermiso);

            if (grupoId == -1 || permisoId == -1)
            {
                MessageBox.Show("No se pudo obtener el ID del grupo o el permiso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lógica para asignar el permiso al grupo utilizando el método AsignarPermisoAGrupo
            bool asignado = gruposPermisosService.AsignarPermisoAGrupo(grupoId, permisoId);

            if (asignado)
            {
                MessageBox.Show("Grupo y permiso agregados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Actualizar datos en el DataGridView y limpiar ComboBoxes
                LoadDataGruposPermisos();
                LimpiarGruposPermisos();
            }
            else
            {
                MessageBox.Show("Hubo un problema al agregar el permiso al grupo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnEliminarGrupoPermiso_Click(object sender, EventArgs e)
        {
            string nombreGrupo = cmbGrupos.SelectedItem?.ToString();
            string nombrePermiso = cmbPermisos.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(nombreGrupo) || string.IsNullOrWhiteSpace(nombrePermiso))
            {
                MessageBox.Show("Por favor, seleccione un grupo y un permiso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener IDs correspondientes a los nombres seleccionados
            int grupoId = grupoService.ObtenerIdGrupoPorNombre(nombreGrupo);
            int permisoId = permisoService.ObtenerIdPermisoPorNombre(nombrePermiso);

            if (grupoId == -1 || permisoId == -1)
            {
                MessageBox.Show("Error al obtener los IDs de grupo y permiso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lógica para eliminar el grupo y permiso seleccionados
            gruposPermisosService.RevocarPermisoDeGrupo(grupoId, permisoId);

            // Actualizar datos en el DataGridView y limpiar ComboBoxes
            LoadDataGruposPermisos();
            LimpiarGruposPermisos();

            MessageBox.Show("Grupo y permiso eliminados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
        private void btnBuscarGrupoPermiso_Click(object sender, EventArgs e)
        {
            string filter = txtBuscarGrupoPermiso.Text;
            if (string.IsNullOrWhiteSpace(filter))
            {
                LoadDataGruposPermisos();
            }
            else
            {
                dataGridViewGruposPermisos.DataSource = gruposPermisosService.ObtenerGruposPermisosFiltrados(filter);
                dataGridViewGruposPermisos.RowHeadersVisible = false;
            }
        }
        #endregion Grupos/permisos

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarGruposPermisos();
        }

        private void GruposPermisos_Load(object sender, EventArgs e)
        {

        }
    }
}
