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

namespace Hostal_App
{
    public partial class Dashboard : MaterialForm
    {
        private readonly UsuarioService usuarioService;
        private readonly ClienteService clienteService;
        private readonly TipoHabitacionService tipoHabitacionService;
        private readonly PermisoService permisoService;
        private readonly GrupoService grupoService;
        private readonly ConfiguracionSistemaService configuracionSistemaService;

        public Dashboard()
        {
            InitializeComponent();
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
            configuracionSistemaService = new ConfiguracionSistemaService();
            LoadDataConfiguraciones();
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
            chkIsActive.Checked = false;
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

            if (usuarioService.CrearUsuario(password, usuario, nombre, apellido, correo, isActive))
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
            LoadFilteredData(filter);
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
            LoadFilteredDataClientes(filter);
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

            if (tipoHabitacionService.CrearTipoHabitacion(tipo,descripcion))
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

            if (id.Equals("")||string.IsNullOrWhiteSpace(tipo) || string.IsNullOrWhiteSpace(descripcion))
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
            LoadFilteredDataTH(filter);
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
            LoadFilteredDataPermisos(filter);
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
            LoadFilteredDataGrupos(filter);
        }
        #endregion Grupos

        #region Configuraciones
        private void LimpiarConfiguraciones()
        {
            lblIdConfig.Text = "";
            txtClave.Clear();
            txtValor.Clear();
            txtClave.Focus();
        }
        private void LoadDataConfiguraciones()
        {
            dataGridViewConfig.DataSource = configuracionSistemaService.ObtenerConfiguraciones();
            dataGridViewConfig.RowHeadersVisible = false;
        }
        private void LoadFilteredDataConfiguraciones(string filter)
        {
            dataGridViewConfig.DataSource = configuracionSistemaService.ObtenerConfiguracionesFiltradas(filter);
            dataGridViewConfig.RowHeadersVisible = false;
        }

        private void dataGridViewConfiguraciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridViewConfig.Rows[e.RowIndex];
                    lblIdConfig.Text = row.Cells["id"].Value.ToString();
                    txtClave.Text = row.Cells["clave"].Value.ToString();
                    txtValor.Text = row.Cells["valor"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar la configuración: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarConfig_Click(object sender, EventArgs e)
        {
            string clave = txtClave.Text;
            string valor = txtValor.Text;

            if (string.IsNullOrWhiteSpace(clave) || string.IsNullOrWhiteSpace(valor))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (configuracionSistemaService.CrearConfiguracion(clave, valor))
            {
                MessageBox.Show("Configuración guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarConfiguraciones();
                LoadDataConfiguraciones();
            }
            else
            {
                MessageBox.Show("Error al guardar la configuración.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnActualizarConfig_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblIdConfig.Text);
            string clave = txtClave.Text;
            string valor = txtValor.Text;

            if (id.Equals("") || string.IsNullOrWhiteSpace(clave) || string.IsNullOrWhiteSpace(valor))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (configuracionSistemaService.ActualizarConfiguracion(id, clave, valor))
            {
                MessageBox.Show("Configuración actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarConfiguraciones();
                LoadDataConfiguraciones();
            }
            else
            {
                MessageBox.Show("Error al actualizar la configuración.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEliminarConfig_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblIdConfig.Text);

            DialogResult result = MessageBox.Show("¿Estás seguro de eliminar esta configuración?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (configuracionSistemaService.EliminarConfiguracion(id))
                {
                    MessageBox.Show("Configuración eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarConfiguraciones();
                    LoadDataConfiguraciones();
                }
                else
                {
                    MessageBox.Show("Error al eliminar la configuración.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnBuscarConfig_Click(object sender, EventArgs e)
        {
            string filter = txtBuscarConfig.Text;
            if (string.IsNullOrWhiteSpace(filter))
            {
                LoadDataConfiguraciones();
            }
            else {
                LoadFilteredDataConfiguraciones(filter);
            }
            
        }
        #endregion Configuraciones

    }
}
