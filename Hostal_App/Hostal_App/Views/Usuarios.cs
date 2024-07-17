using Hostal_App.Helper;
using Hostal_App.Services;
using MaterialSkin.Controls;
using Org.BouncyCastle.Asn1.Ocsp;
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
    public partial class Usuarios : MaterialForm
    {
        private readonly UsuarioService usuarioService;
        private readonly GrupoService grupoService;
        private readonly List<Permiso> permisosLogin;
        public Usuarios(List<Permiso> permisosLogin)
        {
            InitializeComponent();
            usuarioService = new UsuarioService();
            LoadData();
            grupoService = new GrupoService();
            LoadComboBoxGrupo();
            this.permisosLogin = permisosLogin;
            Configurar();
        }
        private void Configurar(bool isRowSelected = false)
        {
            btnAgregar.Enabled = false;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            foreach (var item in permisosLogin)
            {
                switch (item.Nombre)
                {
                    case "c usuario":
                        btnAgregar.Enabled =!isRowSelected;
                        break;
                    case "u usuario":
                        btnActualizar.Enabled = isRowSelected;
                        break;
                    case "d usuario":
                        btnEliminar.Enabled = isRowSelected;
                        break;
                    default:
                        break;
                }
            }
        }

        private void LoadComboBoxGrupo()
        {
            cmbGrupoUsuario.Items.Clear();
            cmbGrupoUsuario.DataSource = grupoService.ObtenerGrupos();
            cmbGrupoUsuario.DisplayMember = "nombre";
            cmbGrupoUsuario.ValueMember = "id";
            cmbGrupoUsuario.SelectedIndex = -1;
        }

        #region Usuarios
        private void Limpiar()
        {
            lblId.Text = "";
            txtUsuario.Clear();
            txtPass.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            cmbGrupoUsuario.SelectedIndex = -1;
            chkIsActive.Checked = true;
            Configurar();
        }
        private void LoadData()
        {
            dataGridViewUsuarios.DataSource = usuarioService.ObtenerUsuarios();
            // Ocultar la columna de encabezado de fila
            dataGridViewUsuarios.RowHeadersVisible = false;
            dataGridViewUsuarios.Columns["grupo_id"].Visible = false;


        }
        private void dataGridViewUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridViewUsuarios.Rows[e.RowIndex];
                    lblId.Text = row.Cells["id"].Value.ToString();
                    txtUsuario.Text = row.Cells["usuario"].Value.ToString();
                    txtNombre.Text = row.Cells["nombre"].Value.ToString();
                    txtApellido.Text = row.Cells["apellido"].Value.ToString();
                    txtCorreo.Text = row.Cells["email"].Value.ToString();
                    cmbGrupoUsuario.SelectedValue = row.Cells["grupo_id"].Value.ToString();
                    chkIsActive.Checked = Convert.ToBoolean(row.Cells["is_active"].Value);
                    Configurar(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtPass.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string correo = txtCorreo.Text;
            bool isActive = chkIsActive.Checked;
            string grupo = cmbGrupoUsuario.SelectedValue.ToString();

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(correo))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string passwordEnc = EncryptionHelper.EncryptPassword(password);
            int grupoId = int.Parse(grupo);
            if (usuarioService.CrearUsuario(passwordEnc, usuario, nombre, apellido, correo, isActive, grupoId))
            {
                MessageBox.Show("Usuario guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                LoadData();
            }
            else
            {
                MessageBox.Show("Error al guardar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(lblId.Text);
                string usuario = txtUsuario.Text;
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string correo = txtCorreo.Text;
                bool isActive = chkIsActive.Checked;
                int grupoID = (int)cmbGrupoUsuario.SelectedValue; // Obtener el grupo_id seleccionado

                string passwordEnc = null;

                // Verificar si se ingresó una nueva contraseña
                if (!string.IsNullOrWhiteSpace(txtPass.Text))
                {
                    passwordEnc = EncryptionHelper.EncryptPassword(txtPass.Text);
                }

                if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(nombre) ||
                    string.IsNullOrWhiteSpace(apellido) || string.IsNullOrWhiteSpace(correo))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Llamar al método ActualizarUsuario correspondiente según la situación de la contraseña
                bool updated = false;
                if (string.IsNullOrEmpty(passwordEnc))
                {
                    updated = usuarioService.ActualizarUsuario(id, usuario, nombre, apellido, correo, isActive, grupoID);
                }
                else
                {
                    updated = usuarioService.ActualizarUsuario(id, passwordEnc, usuario, nombre, apellido, correo, isActive, grupoID);
                }

                if (updated)
                {
                    MessageBox.Show("Usuario actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblId.Text);

            DialogResult result = MessageBox.Show("¿Estás seguro de eliminar este usuario?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (usuarioService.EliminarUsuario(id))
                {
                    MessageBox.Show("Usuario eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadFilteredData(string filter)
        {
            dataGridViewUsuarios.DataSource = usuarioService.ObtenerUsuariosFiltrados(filter);
            // Ocultar la columna de encabezado de fila
            dataGridViewUsuarios.RowHeadersVisible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filter = txtBuscar.Text;
            if (string.IsNullOrEmpty(filter))
            {
                LoadData();
            }
            else
            {
                LoadFilteredData(filter);
            }
        }
        #endregion Usuarios

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
