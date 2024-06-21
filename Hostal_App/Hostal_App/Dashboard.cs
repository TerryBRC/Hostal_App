using Google.Protobuf.WellKnownTypes;
using Hostal_App.Helper;
using Hostal_App.Models;
using Hostal_App.Services;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace Hostal_App
{
    public partial class Dashboard : MaterialForm
    {
        private readonly UsuarioService usuarioService;
        private readonly ClienteService clienteService;
        private readonly TipoHabitacionService tipoHabitacionService;
        private readonly PermisoService permisoService;
        private readonly GrupoService grupoService;
        private readonly GruposPermisosService gruposPermisosService;
        private readonly HabitacionService habitacionService;
        private readonly ReservaService reservaService;


        private readonly List<Permiso> permisosLogin;
        public Dashboard(List<Permiso> permisos)
        {
            InitializeComponent();
            this.permisosLogin = permisos;
            CargarListaPermisos();
            InitializeTimer();
            usuarioService = new UsuarioService();
            LoadData();
            clienteService = new ClienteService();
            LoadDataClientes();
            tipoHabitacionService = new TipoHabitacionService();
            LoadDataTipoHabitacion();
            permisoService = new PermisoService();
            LoadDataPermisos();
            grupoService = new GrupoService();
            LoadDataGrupos();
            gruposPermisosService = new GruposPermisosService();
            LoadDataGruposPermisos();
            habitacionService = new HabitacionService();
            LoadDataHabitacion();
            reservaService = new ReservaService();
            LoadDataReservas();

        }

        private void CargarListaPermisos()
        {
            // Limpiar la lista antes de cargar los permisos para evitar duplicados
            lbPermisos.Items.Clear();

            // Agregar los permisos al ListBox
            foreach (Permiso permiso in permisosLogin)
            {
                lbPermisos.Items.Add(permiso.Nombre);
            }
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
        }
        private void LoadData()
        {
            dataGridViewUsuarios.DataSource = usuarioService.ObtenerUsuarios();
            // Ocultar la columna de encabezado de fila
            dataGridViewUsuarios.RowHeadersVisible = false;
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

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(correo))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string passwordEnc = EncryptionHelper.EncryptPassword(password);

            if (usuarioService.CrearUsuario(passwordEnc, usuario, nombre, apellido, correo, isActive))
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
            int id = int.Parse(lblId.Text);
            string usuario = txtUsuario.Text;
            string password = txtPass.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string correo = txtCorreo.Text;
            bool isActive = chkIsActive.Checked;

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(apellido) || string.IsNullOrWhiteSpace(correo))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (usuarioService.ActualizarUsuario(id, password, usuario, nombre, apellido, correo, isActive))
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

        #region Clientes
        private void LimpiarClientes()
        {
            lblIdCliente.Text = "";
            txtNombreCliente.Clear();
            txtApellidoCliente.Clear();
            txtTelefonoCliente.Clear();
            txtCorreoCliente.Clear();
            txtDireccionCliente.Clear();
            txtNombreCliente.Focus();
        }
        private void LoadDataClientes()
        {
            dataGridViewClientes.DataSource = clienteService.ObtenerClientes();
            // Ocultar la columna de encabezado de fila
            dataGridViewClientes.RowHeadersVisible = false;
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreCliente.Text;
            string apellido = txtApellidoCliente.Text;
            string telefono = txtTelefonoCliente.Text;
            string correo = txtCorreoCliente.Text;
            string direccion = txtDireccionCliente.Text;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(telefono) || string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(direccion))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clienteService.CrearCliente(nombre, apellido, telefono, correo, direccion))
            {
                MessageBox.Show("Cliente guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarClientes();
                LoadDataClientes();
            }
            else
            {
                MessageBox.Show("Error al guardar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizarCliente_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblIdCliente.Text);
            string nombre = txtNombreCliente.Text;
            string apellido = txtApellidoCliente.Text;
            string telefono = txtTelefonoCliente.Text;
            string correo = txtCorreoCliente.Text;
            string direccion = txtDireccionCliente.Text;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(telefono) || string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(direccion))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clienteService.ActualizarCliente(id, nombre, apellido, telefono, correo, direccion))
            {
                MessageBox.Show("Cliente actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarClientes();
                LoadDataClientes();
            }
            else
            {
                MessageBox.Show("Error al actualizar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblIdCliente.Text);

            DialogResult result = MessageBox.Show("¿Estás seguro de eliminar este cliente?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (clienteService.EliminarCliente(id))
                {
                    MessageBox.Show("Cliente eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarClientes();
                    LoadDataClientes();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridViewClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridViewClientes.Rows[e.RowIndex];
                    lblIdCliente.Text = row.Cells["id"].Value.ToString();
                    txtNombreCliente.Text = row.Cells["nombre"].Value.ToString();
                    txtApellidoCliente.Text = row.Cells["apellido"].Value.ToString();
                    txtTelefonoCliente.Text = row.Cells["telefono"].Value.ToString();
                    txtCorreoCliente.Text = row.Cells["email"].Value.ToString();
                    txtDireccionCliente.Text = row.Cells["direccion"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFilteredDataClientes(string filter)
        {
            dataGridViewUsuarios.DataSource = clienteService.ObtenerClientesFiltrados(filter);
            // Ocultar la columna de encabezado de fila
            dataGridViewUsuarios.RowHeadersVisible = false;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string filter = txtBuscarCliente.Text;
            if (string.IsNullOrEmpty(filter))
            {
                LoadDataClientes();
            }
            else
            {
                LoadFilteredDataClientes(filter);
            }
        }
        #endregion Clientes

        #region Tipo_Habitacion
        private void LimpiarTipoHabitacion()
        {
            lblIdTH.Text = "";
            txtTipo.Clear();
            txtDescripcion.Clear();
            txtTipo.Focus();
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

        #region Permisos
        private void LimpiarPermisos()
        {
            lblIdPermiso.Text = "";
            txtNombrePermiso.Clear();
            txtNombrePermiso.Focus();
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

        #region Grupos
        private void LimpiarGrupo()
        {
            lblIdGrupo.Text = "";
            txtNombreGrupo.Clear();
            txtNombreGrupo.Focus();
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

        #region Grupos/Permisos
        private void LimpiarGruposPermisos()
        {
            lblIdPermisosGrupos.Text = "";
            cmbPermisos.SelectedIndex = -1;
            cmbGrupos.SelectedIndex = -1;
            cmbGrupos.Focus();
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
            cmbGrupos.DataSource = grupoService.ObtenerGrupos();
            cmbGrupos.DisplayMember = "nombre";
            cmbGrupos.ValueMember = "Id";
            cmbGrupos.SelectedIndex = -1;
            cmbGrupoUsuario.DataSource = grupoService.ObtenerGrupos();
            cmbGrupoUsuario.DisplayMember = "nombre";
            cmbGrupoUsuario.ValueMember = "Id";
            cmbGrupoUsuario.SelectedIndex = -1;
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
        }

        private void LoadDataHabitacion()
        {
            dataGridViewH.DataSource = habitacionService.ObtenerHabitaciones();
            dataGridViewH.RowHeadersVisible = false;
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
                    // Obtener datos de la fila seleccionada
                    lblIdH.Text = row.Cells["id"].Value.ToString();
                    txtNumero.Text = row.Cells["numero"].Value.ToString();
                    txtCapacidad.Text = row.Cells["capacidad_maxima"].Value.ToString();
                    txtPrecioXNoche.Text = row.Cells["precio_por_noche"].Value.ToString();
                    ckbDisponible.Checked = Convert.ToBoolean(row.Cells["disponible"].Value);
                    cmbTipoHabitacion.SelectedValue = row.Cells["tipo_habitacion_id"].Value.ToString();
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
                int capacidad = int.Parse( txtCapacidad.Text);
                decimal precioXNoche = decimal.Parse( txtPrecioXNoche.Text);
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
            long id =long.Parse( lblIdH.Text);
            string numero = txtNumero.Text;
            int capacidad =int.Parse( txtCapacidad.Text);
            decimal precioXNoche =decimal.Parse( txtPrecioXNoche.Text);
            bool disponible = ckbDisponible.Checked;
            long tipoHabitacionId = (long)cmbTipoHabitacion.SelectedValue;

            // Verificar si los campos obligatorios están vacíos
            if (id<=0 || string.IsNullOrWhiteSpace(numero) || capacidad<=0 || precioXNoche <=0 || tipoHabitacionId == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

                try
                {
                bool resultado = habitacionService.ActualizarHabitacion(id,numero, capacidad, precioXNoche, disponible, tipoHabitacionId);

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
            if(string.IsNullOrWhiteSpace(filter))
            {
                LoadDataHabitacion();
            }
            else {
                dataGridViewH.DataSource = habitacionService.ObtenerHabitacionFiltrada(filter);
                dataGridViewH.RowHeadersVisible = false;
            }
            

        }

        #endregion Habitacion

        #region Reservas
        private void LimpiarReserva()
        {
            lblIdReserva.Text = string.Empty;
            txtNumeroHuespedes.Clear();
            cmbClientes.SelectedIndex = -1;
            cmbHabitaciones.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
            dtpEntrada.Value = DateTime.Today;
            dtpSalida.Value = DateTime.Today;
            dtpEntrada.Focus();
        }

        private void LoadDataReservas()
        {
            dataGridViewReservas.DataSource = reservaService.ObtenerReservas();
            dataGridViewReservas.RowHeadersVisible = false;

            // Cargar los ComboBox de clientes y habitaciones
            CargarComboBoxClientes();
            CargarComboBoxHabitaciones();
        }

        private void CargarComboBoxClientes()
        {
            // Obtener la lista de clientes
            DataTable clientes = clienteService.ObtenerClientes();

            // Asignar la lista de clientes al ComboBox de clientes
            cmbClientes.DataSource = clientes;
            cmbClientes.DisplayMember = "nombre"; // Reemplaza "nombre" con el campo correcto que deseas mostrar en el ComboBox
            cmbClientes.ValueMember = "id"; // Reemplaza "id" con el campo correcto que representa el valor seleccionado del ComboBox
            cmbClientes.SelectedIndex = -1; // Seleccionar el índice -1 para deseleccionar cualquier elemento inicialmente

            // Si deseas mostrar un texto inicial en el ComboBox de clientes, puedes agregar un elemento vacío o predeterminado
            // cmbClientes.Items.Insert(0, new { id = 0, nombre = "Seleccionar Cliente" });
        }

        private void CargarComboBoxHabitaciones()
        {
            // Obtener la lista de habitaciones
            DataTable habitaciones = habitacionService.ObtenerHabitaciones();

            // Asignar la lista de habitaciones al ComboBox de habitaciones
            cmbHabitaciones.DataSource = habitaciones;
            cmbHabitaciones.DisplayMember = "numero"; // Reemplaza "numero" con el campo correcto que deseas mostrar en el ComboBox
            cmbHabitaciones.ValueMember = "id"; // Reemplaza "id" con el campo correcto que representa el valor seleccionado del ComboBox
            cmbHabitaciones.SelectedIndex = -1; // Seleccionar el índice -1 para deseleccionar cualquier elemento inicialmente

            // Si deseas mostrar un texto inicial en el ComboBox de habitaciones, puedes agregar un elemento vacío o predeterminado
            // cmbHabitaciones.Items.Insert(0, new { id = 0, numero = "Seleccionar Habitación" });
        }
        private void dataGridViewReservas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridViewReservas.Rows[e.RowIndex];
                    lblIdReserva.Text = row.Cells["id"].Value.ToString();
                    dtpEntrada.Value = Convert.ToDateTime(row.Cells["fecha_entrada"].Value);
                    dtpSalida.Value = Convert.ToDateTime(row.Cells["fecha_salida"].Value);
                    txtNumeroHuespedes.Text = row.Cells["numero_huespedes"].Value.ToString();
                    cmbEstado.SelectedValue = row.Cells["estado"].Value.ToString();
                    cmbClientes.SelectedValue = row.Cells["cliente_id"].Value;
                    cmbHabitaciones.SelectedValue = row.Cells["habitacion_id"].Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnBuscarReserva_Click(object sender, EventArgs e)
        {
            string filter = txtBuscarReserva.Text;
            if (string.IsNullOrWhiteSpace(filter))
            {
                LoadDataReservas();
            }
            else
            {
                dataGridViewReservas.DataSource = reservaService.ObtenerReservasFiltradas(filter);
                dataGridViewReservas.RowHeadersVisible = false;
            }

        }
        private void btnAgregarReserva_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los datos del formulario
                DateTime fechaEntrada = dtpEntrada.Value;
                DateTime fechaSalida = dtpSalida.Value;
                int numeroHuespedes = Convert.ToInt32(txtNumeroHuespedes.Text);
                long estadoId = Convert.ToInt64(cmbEstado.SelectedValue);
                long clienteId = Convert.ToInt64(cmbClientes.SelectedValue);
                long habitacionId = Convert.ToInt64(cmbHabitaciones.SelectedValue);

                // Llamar al método CrearReserva del servicio de reservas
                bool resultado = reservaService.CrearReserva(fechaEntrada, fechaSalida, numeroHuespedes, estadoId, clienteId, habitacionId);

                if (resultado)
                {
                    LoadDataReservas();
                    LimpiarReserva();
                    MessageBox.Show("Reserva agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al agregar la reserva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la reserva: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnActualizarReserva_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los datos del formulario
                long id = Convert.ToInt64(lblIdReserva.Text);
                DateTime fechaEntrada = dtpEntrada.Value;
                DateTime fechaSalida = dtpSalida.Value;
                int numeroHuespedes = Convert.ToInt32(txtNumeroHuespedes.Text);
                long estadoId = Convert.ToInt64(cmbEstado.SelectedValue);
                long clienteId = Convert.ToInt64(cmbClientes.SelectedValue);
                long habitacionId = Convert.ToInt64(cmbHabitaciones.SelectedValue);

                // Llamar al método ActualizarReserva del servicio de reservas
                bool resultado = reservaService.ActualizarReserva(id, fechaEntrada, fechaSalida, numeroHuespedes, estadoId, clienteId, habitacionId);

                if (resultado)
                {
                    LoadDataReservas();
                    LimpiarReserva();
                    MessageBox.Show("Reserva actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al actualizar la reserva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la reserva: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEliminarReserva_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el ID de la reserva seleccionada
                long id = Convert.ToInt64(lblIdReserva.Text);

                // Llamar al método EliminarReserva del servicio de reservas
                bool resultado = reservaService.EliminarReserva(id);

                if (resultado)
                {
                    LoadDataReservas();
                    LimpiarReserva();
                    MessageBox.Show("Reserva eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al eliminar la reserva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la reserva: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Reservas

        private void InitializeTimer()
        {
            timer1.Interval = 1000; // 1 segundo
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        }
    }
}
