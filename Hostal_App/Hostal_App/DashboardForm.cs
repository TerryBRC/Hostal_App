using Hostal_App.Services;
using MaterialSkin;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace Hostal_App
{
    public partial class DashboardForm : MaterialForm
    {
        private readonly string connectionString;        
        private readonly UsuarioService usuarioService;
        private readonly ClienteService clienteService;
        private readonly ConfiguracionSistemaService configuracionSistemaService;
        private readonly FacturaService facturaService;
        private readonly GrupoService grupoService;
        private readonly GruposPermisosService gruposPermisosService;
        private readonly HabitacionService habitacionService;
        private readonly PermisoService permisoService;
        private readonly ReservaService reservaService;
        private readonly TipoHabitacionService tipoHabitacionService;
        public DashboardForm()
        {
            connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            InitializeComponent();
            usuarioService = new UsuarioService();
            LoadData();
            clienteService = new ClienteService();
            LoadDataClientes();
            facturaService = new FacturaService();
            LoadDataFactura();
            configuracionSistemaService = new ConfiguracionSistemaService();
            LoadDataConfig();
            grupoService = new GrupoService();
            LoadDataGrupo();
            gruposPermisosService = new GruposPermisosService();
            LoadDataGruposPermisos();
            habitacionService = new HabitacionService();
            LoadDataHabitacion();
            permisoService = new PermisoService();
            LoadDataPermiso();
            reservaService = new ReservaService();
            LoadDataReserva();
            tipoHabitacionService = new TipoHabitacionService();
            LoadDataTipoHabitacion();

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
        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreCliente.Text;
            string apellido = txtApellidoCliente.Text;
            string direccion = txtDireccionCliente.Text;
            string telefono = txtTelefonoCliente.Text;
            string email = txtCorreoCliente.Text;
            string fecha_registro = DateTime.Now.Date.ToString("yyyy-MM-dd");

            // Verificar si los campos obligatorios están vacíos
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(direccion) || string.IsNullOrWhiteSpace(telefono) ||
                string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "CALL sp_create_cliente(@p_nombre, @p_apellido, @p_direccion, @p_telefono, @p_email, @p_fecha_registro)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@p_nombre", nombre);
                    command.Parameters.AddWithValue("@p_apellido", apellido);
                    command.Parameters.AddWithValue("@p_direccion", direccion);
                    command.Parameters.AddWithValue("@p_telefono", telefono);
                    command.Parameters.AddWithValue("@p_email", email);
                    command.Parameters.AddWithValue("@p_fecha_registro", fecha_registro);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Cliente guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar los campos después de guardar
                    LimpiarClientes();

                    // Actualizar el DataGridView de clientes
                    LoadDataClientes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LimpiarClientes()
        {
            txtNombreCliente.Clear();
            txtApellidoCliente.Clear();
            txtDireccionCliente.Clear();
            txtTelefonoCliente.Clear();
            txtCorreoCliente.Clear();
        }

        private void LoadDataClientes()
        {
            dataGridViewUsuarios.DataSource = clienteService.ObtenerClientes();
            // Ocultar la columna de encabezado de fila
            dataGridViewUsuarios.RowHeadersVisible = false;
        }

        private void btnActualizarCliente_Click(object sender, EventArgs e)
        {
            string id = lblIdCliente.Text;
            string nombre = txtNombreCliente.Text;
            string apellido = txtApellidoCliente.Text;
            string direccion = txtDireccionCliente.Text;
            string telefono = txtTelefonoCliente.Text;
            string email = txtCorreoCliente.Text;

            // Verificar si los campos obligatorios están vacíos
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(apellido) || string.IsNullOrWhiteSpace(direccion) ||
                string.IsNullOrWhiteSpace(telefono) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "CALL sp_update_cliente(@p_id, @p_nombre, @p_apellido, @p_direccion, @p_telefono, @p_email)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@p_id", id);
                    command.Parameters.AddWithValue("@p_nombre", nombre);
                    command.Parameters.AddWithValue("@p_apellido", apellido);
                    command.Parameters.AddWithValue("@p_direccion", direccion);
                    command.Parameters.AddWithValue("@p_telefono", telefono);
                    command.Parameters.AddWithValue("@p_email", email);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Cliente actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar los campos después de guardar
                    LimpiarClientes();

                    // Actualizar el DataGridView de clientes
                    LoadDataClientes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una fila en el DataGridView
            if (dataGridViewClientes.SelectedRows.Count > 0)
            {
                // Obtener el ID del cliente seleccionado
                int idCliente = Convert.ToInt32(dataGridViewClientes.SelectedRows[0].Cells["id"].Value);

                // Confirmar la eliminación con el usuario
                DialogResult result = MessageBox.Show("¿Estás seguro de eliminar este cliente?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            string query = "CALL sp_delete_cliente(@p_id)";
                            MySqlCommand command = new MySqlCommand(query, connection);
                            command.Parameters.AddWithValue("@p_id", idCliente);

                            command.ExecuteNonQuery();
                            MessageBox.Show("Cliente eliminado correctamente.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Actualizar el DataGridView de clientes
                            LoadDataClientes();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al eliminar el cliente: " + ex.Message, "Error de Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente para eliminar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void LoadFilteredDataClientes(string filter)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "CALL  sp_search_cliente(@filter)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@filter", "%" + filter + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridViewClientes.DataSource = dataTable;
                // Ocultar la columna de encabezado de fila
                dataGridViewClientes.RowHeadersVisible = false;
            }
        }
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string filter = txtBuscarCliente.Text;
            LoadFilteredDataClientes(filter);
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
                    txtDireccionCliente.Text = row.Cells["direccion"].Value.ToString();
                    txtTelefonoCliente.Text = row.Cells["telefono"].Value.ToString();
                    txtCorreoCliente.Text = row.Cells["email"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion Clientes

        #region Configuraciones
        private void LimpiarConfig()
        {
            txtClave.Clear();
            txtValor.Clear();
        }
        private void LoadDataConfig()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("CALL sp_read_configuracion_sistema()", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridViewConfig.DataSource = dataTable;
                // Ocultar la columna de encabezado de fila
                dataGridViewConfig.RowHeadersVisible = false;
            }
        }
        private void btnAgregarConfig_Click(object sender, EventArgs e)
        {
            string clave = txtClave.Text;
            string valor = txtValor.Text;

            // Verificar si los campos obligatorios están vacíos
            if (string.IsNullOrWhiteSpace(clave) || string.IsNullOrWhiteSpace(valor))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "CALL sp_create_configuracion(@p_clave, @p_valor)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@p_clave", clave);
                    command.Parameters.AddWithValue("@p_valor", valor);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Configuración guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar los campos después de guardar
                    LimpiarConfig();

                    // Actualizar el DataGridView de configuraciones
                    LoadDataConfig();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar la configuración: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnActualizarConfig_Click(object sender, EventArgs e)
        {
            string id = lblIdConfig.Text;
            string clave = txtClave.Text;
            string valor = txtValor.Text;

            // Verificar si los campos obligatorios están vacíos
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(clave) || string.IsNullOrWhiteSpace(valor))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "CALL sp_update_configuracion(@p_id, @p_clave, @p_valor)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@p_id", id);
                    command.Parameters.AddWithValue("@p_clave", clave);
                    command.Parameters.AddWithValue("@p_valor", valor);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Configuración actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar los campos después de actualizar
                    LimpiarConfig();

                    // Actualizar el DataGridView de configuraciones
                    LoadDataConfig();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar la configuración: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminarConfig_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una fila en el DataGridView
            if (dataGridViewConfig.SelectedRows.Count > 0)
            {
                // Obtener el ID de la configuración seleccionada
                int idConfig = Convert.ToInt32(dataGridViewConfig.SelectedRows[0].Cells["id"].Value);

                // Confirmar la eliminación con el usuario
                DialogResult result = MessageBox.Show("¿Estás seguro de eliminar esta configuración?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            string query = "CALL sp_delete_configuracion(@p_id)";
                            MySqlCommand command = new MySqlCommand(query, connection);
                            command.Parameters.AddWithValue("@p_id", idConfig);

                            command.ExecuteNonQuery();
                            MessageBox.Show("Configuración eliminada correctamente.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Actualizar el DataGridView de configuraciones
                            LoadDataConfig();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al eliminar la configuración: " + ex.Message, "Error de Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una configuración para eliminar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadFilteredDataConfig(string filter)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "CALL sp_search_configuracion(@filter)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@filter", "%" + filter + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridViewConfig.DataSource = dataTable;
                // Ocultar la columna de encabezado de fila
                dataGridViewConfig.RowHeadersVisible = false;
            }
        }

        private void btnBuscarConfig_Click(object sender, EventArgs e)
        {
            string filter = txtBuscarConfig.Text;
            LoadFilteredDataConfig(filter);
        }

        private void dataGridViewConfig_CellClick(object sender, DataGridViewCellEventArgs e)
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

        #endregion Configuraciones

        #region Permisos

        private void LimpiarPermiso()
        {
            txtNombrePermiso.Clear();
            txtNombrePermiso.Focus();
        }

        private void LoadDataPermiso()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("CALL sp_read_permisos()", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridViewPermisos.DataSource = dataTable;
                // Ocultar la columna de encabezado de fila
                dataGridViewPermisos.RowHeadersVisible = false;
            }
        }


       

        private void btnAgregarPermiso_Click(object sender, EventArgs e)
        {
            string nombre = txtNombrePermiso.Text;

            // Verificar si los campos obligatorios están vacíos
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "CALL sp_create_permiso(@p_nombre)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@p_nombre", nombre);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Permiso guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar los campos después de guardar
                    LimpiarPermiso();

                    // Actualizar el DataGridView de permisos
                    LoadDataPermiso();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el permiso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnActualizarPermiso_Click(object sender, EventArgs e)
        {
            string id = lblIdPermiso.Text;
            string nombre = txtNombrePermiso.Text;

            // Verificar si los campos obligatorios están vacíos
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "CALL sp_update_permiso(@p_id, @p_nombre)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@p_id", id);
                    command.Parameters.AddWithValue("@p_nombre", nombre);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Permiso actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar los campos después de actualizar
                    LimpiarPermiso();

                    // Actualizar el DataGridView de permisos
                    LoadDataPermiso();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el permiso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminarPermiso_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una fila en el DataGridView
            if (dataGridViewPermisos.SelectedRows.Count > 0)
            {
                // Obtener el ID del permiso seleccionado
                int idPermiso = Convert.ToInt32(dataGridViewPermisos.SelectedRows[0].Cells["id"].Value);

                // Confirmar la eliminación con el usuario
                DialogResult result = MessageBox.Show("¿Estás seguro de eliminar este permiso?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            string query = "CALL sp_delete_permiso(@p_id)";
                            MySqlCommand command = new MySqlCommand(query, connection);
                            command.Parameters.AddWithValue("@p_id", idPermiso);

                            command.ExecuteNonQuery();
                            MessageBox.Show("Permiso eliminado correctamente.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Actualizar el DataGridView de permisos
                            LoadDataPermiso();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al eliminar el permiso: " + ex.Message, "Error de Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un permiso para eliminar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadFilteredDataPermiso(string filter)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "CALL sp_search_permiso(@filter)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@filter", "%" + filter + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridViewPermisos.DataSource = dataTable;
                // Ocultar la columna de encabezado de fila
                dataGridViewPermisos.RowHeadersVisible = false;
            }
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

        #endregion Permisos

        #region Grupos
        private void LimpiarGrupo()
        {
            txtNombreGrupo.Clear();
            txtNombreGrupo.Focus();
        }
        private void LoadDataGrupo()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("CALL sp_read_grupos()", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridViewGrupos.DataSource = dataTable;
                // Ocultar la columna de encabezado de fila
                dataGridViewGrupos.RowHeadersVisible = false;
            }
        }
        private void btnAgregarGrupo_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreGrupo.Text;

            // Verificar si los campos obligatorios están vacíos
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "CALL sp_create_grupo(@p_nombre)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@p_nombre", nombre);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Grupo guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar los campos después de guardar
                    LimpiarGrupo();

                    // Actualizar el DataGridView de grupos
                    LoadDataGrupo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el grupo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnActualizarGrupo_Click(object sender, EventArgs e)
        {
            string id = lblIdGrupo.Text;
            string nombre = txtNombreGrupo.Text;

            // Verificar si los campos obligatorios están vacíos
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "CALL sp_update_grupo(@p_id, @p_nombre)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@p_id", id);
                    command.Parameters.AddWithValue("@p_nombre", nombre);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Grupo actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar los campos después de actualizar
                    LimpiarGrupo();

                    // Actualizar el DataGridView de grupos
                    LoadDataGrupo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el grupo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminarGrupo_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una fila en el DataGridView
            if (dataGridViewGrupos.SelectedRows.Count > 0)
            {
                // Obtener el ID del grupo seleccionado
                int idGrupo = Convert.ToInt32(dataGridViewGrupos.SelectedRows[0].Cells["id"].Value);

                // Confirmar la eliminación con el usuario
                DialogResult result = MessageBox.Show("¿Estás seguro de eliminar este grupo?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            string query = "CALL sp_delete_grupo(@p_id)";
                            MySqlCommand command = new MySqlCommand(query, connection);
                            command.Parameters.AddWithValue("@p_id", idGrupo);

                            command.ExecuteNonQuery();
                            MessageBox.Show("Grupo eliminado correctamente.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Actualizar el DataGridView de grupos
                            LoadDataGrupo();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al eliminar el grupo: " + ex.Message, "Error de Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un grupo para eliminar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadFilteredDataGrupo(string filter)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "CALL sp_search_grupo(@filter)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@filter", "%" + filter + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridViewGrupos.DataSource = dataTable;
                // Ocultar la columna de encabezado de fila
                dataGridViewGrupos.RowHeadersVisible = false;
            }
        }

        private void btnBuscarGrupo_Click(object sender, EventArgs e)
        {
            string filter = txtBuscarGrupo.Text;
            LoadFilteredDataGrupo(filter);
        }

        private void dataGridViewGrupo_CellClick(object sender, DataGridViewCellEventArgs e)
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
        #endregion Grupos

        #region TipoHabitacion
        private void LimpiarTipoHabitacion()
        {
            txtTipo.Clear();
            txtDescripcion.Clear();
            lblIdTH.Text = string.Empty;
        }
        private void LoadDataTipoHabitacion()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("CALL sp_read_tipo_habitacion()", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridViewTH.DataSource = dataTable;
                // Ocultar la columna de encabezado de fila
                dataGridViewTH.RowHeadersVisible = false;
            }
        }
        private void btnAgregarTH_Click(object sender, EventArgs e)
        {
            string tipo = txtTipo.Text;
            string descripcion = txtDescripcion.Text;

            // Verificar si los campos obligatorios están vacíos
            if (string.IsNullOrWhiteSpace(tipo) || string.IsNullOrWhiteSpace(descripcion))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "CALL sp_create_tipo_habitacion(@p_tipo, @p_descripcion)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@p_tipo", tipo);
                    command.Parameters.AddWithValue("@p_descripcion", descripcion);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Tipo de habitación guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar los campos después de guardar
                    LimpiarTipoHabitacion();

                    // Actualizar el DataGridView de tipos de habitación
                    LoadDataTipoHabitacion();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el tipo de habitación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnActualizarTH_Click(object sender, EventArgs e)
        {
            string id = lblIdTH.Text;
            string tipo = txtTipo.Text;
            string descripcion = txtDescripcion.Text;

            // Verificar si los campos obligatorios están vacíos
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(tipo) || string.IsNullOrWhiteSpace(descripcion))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "CALL sp_update_tipo_habitacion(@p_id, @p_tipo, @p_descripcion)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@p_id", id);
                    command.Parameters.AddWithValue("@p_tipo", tipo);
                    command.Parameters.AddWithValue("@p_descripcion", descripcion);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Tipo de habitación actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar los campos después de actualizar
                    LimpiarTipoHabitacion();

                    // Actualizar el DataGridView de tipos de habitación
                    LoadDataTipoHabitacion();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el tipo de habitación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminarTH_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una fila en el DataGridView
            if (dataGridViewTH.SelectedRows.Count > 0)
            {
                // Obtener el ID del tipo de habitación seleccionado
                int idTipoHabitacion = Convert.ToInt32(dataGridViewTH.SelectedRows[0].Cells["id"].Value);

                // Confirmar la eliminación con el usuario
                DialogResult result = MessageBox.Show("¿Estás seguro de eliminar este tipo de habitación?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            string query = "CALL sp_delete_tipo_habitacion(@p_id)";
                            MySqlCommand command = new MySqlCommand(query, connection);
                            command.Parameters.AddWithValue("@p_id", idTipoHabitacion);

                            command.ExecuteNonQuery();
                            MessageBox.Show("Tipo de habitación eliminado correctamente.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Actualizar el DataGridView de tipos de habitación
                            LoadDataTipoHabitacion();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al eliminar el tipo de habitación: " + ex.Message, "Error de Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un tipo de habitación para eliminar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadFilteredDataTipoHabitacion(string filter)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "CALL sp_search_tipo_habitacion(@filter)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@filter", "%" + filter + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridViewTH.DataSource = dataTable;
                // Ocultar la columna de encabezado de fila
                dataGridViewTH.RowHeadersVisible = false;
            }
        }

        private void btnBuscarTH_Click(object sender, EventArgs e)
        {
            string filter = txtBuscarTH.Text;
            LoadFilteredDataTipoHabitacion(filter);
        }

        private void dataGridViewTipoHabitacion_CellClick(object sender, DataGridViewCellEventArgs e)
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
        #endregion TipoHabitacion

        #region Habitacion

        private void LimpiarHabitacion()
        {
            txtNumero.Clear();
            txtCapacidad.Clear();
            txtPrecioXNoche.Clear();
            ckbDisponible.Checked = false;
            cmbTipoHabitacion.SelectedIndex = -1;
            lblIdH.Text = string.Empty;
            txtNumero.Focus();
        }

        private void LoadDataHabitacion()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("CALL sp_read_habitacion()", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridViewH.DataSource = dataTable;
                // Ocultar la columna de encabezado de fila
                dataGridViewH.RowHeadersVisible = false;
            }
        }

        private void LoadTipoHabitacionComboBox()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("CALL sp_read_tipo_habitacion()", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                cmbTipoHabitacion.DataSource = dataTable;
                cmbTipoHabitacion.DisplayMember = "tipo";
                cmbTipoHabitacion.ValueMember = "id";
                cmbTipoHabitacion.SelectedIndex = -1;
            }
        }

        private void btnAgregarHabitacion_Click(object sender, EventArgs e)
        {
            string numero = txtNumero.Text;
            string capacidad = txtCapacidad.Text;
            string precioXNoche = txtPrecioXNoche.Text;
            bool disponible = ckbDisponible.Checked;
            int tipoHabitacionId = (int)cmbTipoHabitacion.SelectedValue;

            // Verificar si los campos obligatorios están vacíos
            if (string.IsNullOrWhiteSpace(numero) || string.IsNullOrWhiteSpace(capacidad) || string.IsNullOrWhiteSpace(precioXNoche) || tipoHabitacionId == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "CALL sp_create_habitacion(@p_numero, @p_capacidad, @p_precio_x_noche, @p_disponible, @p_tipo_habitacion_id)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@p_numero", numero);
                    command.Parameters.AddWithValue("@p_capacidad", capacidad);
                    command.Parameters.AddWithValue("@p_precio_x_noche", precioXNoche);
                    command.Parameters.AddWithValue("@p_disponible", disponible);
                    command.Parameters.AddWithValue("@p_tipo_habitacion_id", tipoHabitacionId);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Habitación guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar los campos después de guardar
                    LimpiarHabitacion();

                    // Actualizar el DataGridView de habitaciones
                    LoadDataHabitacion();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar la habitación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnActualizarHabitacion_Click(object sender, EventArgs e)
        {
            string id = lblIdH.Text;
            string numero = txtNumero.Text;
            string capacidad = txtCapacidad.Text;
            string precioXNoche = txtPrecioXNoche.Text;
            bool disponible = ckbDisponible.Checked;
            int tipoHabitacionId = (int)cmbTipoHabitacion.SelectedValue;

            // Verificar si los campos obligatorios están vacíos
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(numero) || string.IsNullOrWhiteSpace(capacidad) || string.IsNullOrWhiteSpace(precioXNoche) || tipoHabitacionId == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "CALL sp_update_habitacion(@p_id, @p_numero, @p_capacidad, @p_precio_x_noche, @p_disponible, @p_tipo_habitacion_id)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@p_id", id);
                    command.Parameters.AddWithValue("@p_numero", numero);
                    command.Parameters.AddWithValue("@p_capacidad", capacidad);
                    command.Parameters.AddWithValue("@p_precio_x_noche", precioXNoche);
                    command.Parameters.AddWithValue("@p_disponible", disponible);
                    command.Parameters.AddWithValue("@p_tipo_habitacion_id", tipoHabitacionId);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Habitación actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar los campos después de actualizar
                    LimpiarHabitacion();

                    // Actualizar el DataGridView de habitaciones
                    LoadDataHabitacion();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar la habitación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminarHabitacion_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una fila en el DataGridView
            if (dataGridViewH.SelectedRows.Count > 0)
            {
                // Obtener el ID de la habitación seleccionada
                int idHabitacion = Convert.ToInt32(dataGridViewH.SelectedRows[0].Cells["id"].Value);

                // Confirmar la eliminación con el usuario
                DialogResult result = MessageBox.Show("¿Estás seguro de eliminar esta habitación?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            string query = "CALL sp_delete_habitacion(@p_id)";
                            MySqlCommand command = new MySqlCommand(query, connection);
                            command.Parameters.AddWithValue("@p_id", idHabitacion);

                            command.ExecuteNonQuery();
                            MessageBox.Show("Habitación eliminada correctamente.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Actualizar el DataGridView de habitaciones
                            LoadDataHabitacion();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al eliminar la habitación: " + ex.Message, "Error de Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una habitación para eliminar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadFilteredDataHabitacion(string filter)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "CALL sp_search_habitacion(@filter)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@filter", "%" + filter + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridViewH.DataSource = dataTable;
                // Ocultar la columna de encabezado de fila
                dataGridViewH.RowHeadersVisible = false;
            }
        }

        private void btnBuscarH_Click(object sender, EventArgs e)
        {
            string filter = txtBuscarH.Text;
            LoadFilteredDataHabitacion(filter);
        }

        private void dataGridViewHabitacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridViewH.Rows[e.RowIndex];
                    lblIdH.Text = row.Cells["id"].Value.ToString();
                    txtNumero.Text = row.Cells["numero"].Value.ToString();
                    txtCapacidad.Text = row.Cells["capacidad"].Value.ToString();
                    txtPrecioXNoche.Text = row.Cells["precio_x_noche"].Value.ToString();
                    ckbDisponible.Checked = Convert.ToBoolean(row.Cells["disponible"].Value);
                    cmbTipoHabitacion.SelectedValue = row.Cells["tipo_habitacion_id"].Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar la habitación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion Habitacion

        #region Reserva

        private void LimpiarReserva()
        {
            lblIdReserva.Text = string.Empty;
            txtNumeroHuespedes.Clear();
            cmbClientes.SelectedIndex = -1;
            cmbHabitaciones.SelectedIndex = -1;
            dtpEntrada.Value = DateTime.Today;
            dtpSalida.Value = DateTime.Today;  
            dtpEntrada.Focus();
        }

        private void LoadDataReserva()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("CALL sp_read_reserva()", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridViewReservas.DataSource = dataTable;
                // Ocultar la columna de encabezado de fila
                dataGridViewReservas.RowHeadersVisible = false;
            }
        }

        private void LoadClientesComboBox()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("CALL sp_read_cliente()", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                cmbClientes.DataSource = dataTable;
                cmbClientes.DisplayMember = "nombre_completo";
                cmbClientes.ValueMember = "id";
                cmbClientes.SelectedIndex = -1;
            }
        }

        private void LoadHabitacionesComboBox()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("CALL sp_read_habitacion()", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                cmbHabitaciones.DataSource = dataTable;
                cmbHabitaciones.DisplayMember = "numero";
                cmbHabitaciones.ValueMember = "id";
                cmbHabitaciones.SelectedIndex = -1;
            }
        }

        private void btnAgregarReserva_Click(object sender, EventArgs e)
        {
            DateTime entrada = dtpEntrada.Value;
            DateTime salida = dtpSalida.Value;
            string numeroHuespedes = txtNumeroHuespedes.Text;
            int clienteId = (int)cmbClientes.SelectedValue;
            int habitacionId = (int)cmbHabitaciones.SelectedValue;

            // Verificar si los campos obligatorios están vacíos
            if (string.IsNullOrWhiteSpace(numeroHuespedes) || clienteId == -1 || habitacionId == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "CALL sp_create_reserva(@p_entrada, @p_salida, @p_numero_huespedes, @p_cliente_id, @p_habitacion_id)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@p_entrada", entrada);
                    command.Parameters.AddWithValue("@p_salida", salida);
                    command.Parameters.AddWithValue("@p_numero_huespedes", numeroHuespedes);
                    command.Parameters.AddWithValue("@p_cliente_id", clienteId);
                    command.Parameters.AddWithValue("@p_habitacion_id", habitacionId);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Reserva guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar los campos después de guardar
                    LimpiarReserva();

                    // Actualizar el DataGridView de reservas
                    LoadDataReserva();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar la reserva: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnActualizarReserva_Click(object sender, EventArgs e)
        {
            string id = lblIdReserva.Text;
            DateTime entrada = dtpEntrada.Value;
            DateTime salida = dtpSalida.Value;
            string numeroHuespedes = txtNumeroHuespedes.Text;
            int clienteId = (int)cmbClientes.SelectedValue;
            int habitacionId = (int)cmbHabitaciones.SelectedValue;

            // Verificar si los campos obligatorios están vacíos
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(numeroHuespedes) || clienteId == -1 || habitacionId == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "CALL sp_update_reserva(@p_id, @p_entrada, @p_salida, @p_numero_huespedes, @p_cliente_id, @p_habitacion_id)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@p_id", id);
                    command.Parameters.AddWithValue("@p_entrada", entrada);
                    command.Parameters.AddWithValue("@p_salida", salida);
                    command.Parameters.AddWithValue("@p_numero_huespedes", numeroHuespedes);
                    command.Parameters.AddWithValue("@p_cliente_id", clienteId);
                    command.Parameters.AddWithValue("@p_habitacion_id", habitacionId);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Reserva actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar los campos después de actualizar
                    LimpiarReserva();

                    // Actualizar el DataGridView de reservas
                    LoadDataReserva();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar la reserva: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminarReserva_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una fila en el DataGridView
            if (dataGridViewReservas.SelectedRows.Count > 0)
            {
                // Obtener el ID de la reserva seleccionada
                int idReserva = Convert.ToInt32(dataGridViewReservas.SelectedRows[0].Cells["id"].Value);

                // Confirmar la eliminación con el usuario
                DialogResult result = MessageBox.Show("¿Estás seguro de eliminar esta reserva?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            string query = "CALL sp_delete_reserva(@p_id)";
                            MySqlCommand command = new MySqlCommand(query, connection);
                            command.Parameters.AddWithValue("@p_id", idReserva);

                            command.ExecuteNonQuery();
                            MessageBox.Show("Reserva eliminada correctamente.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Actualizar el DataGridView de reservas
                            LoadDataReserva();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al eliminar la reserva: " + ex.Message, "Error de Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una reserva para eliminar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadFilteredDataReserva(string filter)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "CALL sp_search_reserva(@filter)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@filter", "%" + filter + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridViewReservas.DataSource = dataTable;
                // Ocultar la columna de encabezado de fila
                dataGridViewReservas.RowHeadersVisible = false;
            }
        }

        private void btnBuscarReserva_Click(object sender, EventArgs e)
        {
            string filter = txtBuscarReserva.Text;
            LoadFilteredDataReserva(filter);
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
                    cmbClientes.SelectedValue = row.Cells["cliente_id"].Value;
                    cmbHabitaciones.SelectedValue = row.Cells["habitacion_id"].Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar la reserva: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion Reserva

        #region Factura

        private void LimpiarFactura()
        {
            lblIdFactura.Text = string.Empty;
            txtTotalFactura.Clear();
            txtDetalles.Clear();
            cmbReservas.SelectedIndex = -1;
            dtpFactura.Value = DateTime.Today;
            txtTotalFactura.Focus();
        }

        private void LoadDataFactura()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("CALL sp_read_factura()", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridViewFacturas.DataSource = dataTable;
                // Ocultar la columna de encabezado de fila
                dataGridViewFacturas.RowHeadersVisible = false;
            }
        }

        private void LoadReservasComboBoxFactura()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("CALL sp_read_reserva()", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                cmbReservas.DataSource = dataTable;
                cmbReservas.DisplayMember = "id";
                cmbReservas.ValueMember = "id";
                cmbReservas.SelectedIndex = -1;
            }
        }

        private void btnAgregarFact_Click(object sender, EventArgs e)
        {
            DateTime fechaFactura = dtpFactura.Value;
            string totalFactura = txtTotalFactura.Text;
            string detalles = txtDetalles.Text;
            int reservaId = (int)cmbReservas.SelectedValue;

            // Verificar si los campos obligatorios están vacíos
            if (string.IsNullOrWhiteSpace(totalFactura) || reservaId == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "CALL sp_create_factura(@p_fecha_factura, @p_total_factura, @p_detalles, @p_reserva_id)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@p_fecha_factura", fechaFactura);
                    command.Parameters.AddWithValue("@p_total_factura", totalFactura);
                    command.Parameters.AddWithValue("@p_detalles", detalles);
                    command.Parameters.AddWithValue("@p_reserva_id", reservaId);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Factura guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar los campos después de guardar
                    LimpiarFactura();

                    // Actualizar el DataGridView de facturas
                    LoadDataFactura();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar la factura: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnActualizarFact_Click(object sender, EventArgs e)
        {
            string id = lblIdFactura.Text;
            DateTime fechaFactura = dtpFactura.Value;
            string totalFactura = txtTotalFactura.Text;
            string detalles = txtDetalles.Text;
            int reservaId = (int)cmbReservas.SelectedValue;

            // Verificar si los campos obligatorios están vacíos
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(totalFactura) || reservaId == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "CALL sp_update_factura(@p_id, @p_fecha_factura, @p_total_factura, @p_detalles, @p_reserva_id)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@p_id", id);
                    command.Parameters.AddWithValue("@p_fecha_factura", fechaFactura);
                    command.Parameters.AddWithValue("@p_total_factura", totalFactura);
                    command.Parameters.AddWithValue("@p_detalles", detalles);
                    command.Parameters.AddWithValue("@p_reserva_id", reservaId);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Factura actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar los campos después de actualizar
                    LimpiarFactura();

                    // Actualizar el DataGridView de facturas
                    LoadDataFactura();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar la factura: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminarFact_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una fila en el DataGridView
            if (dataGridViewFacturas.SelectedRows.Count > 0)
            {
                // Obtener el ID de la factura seleccionada
                int idFactura = Convert.ToInt32(dataGridViewFacturas.SelectedRows[0].Cells["id"].Value);

                // Confirmar la eliminación con el usuario
                DialogResult result = MessageBox.Show("¿Estás seguro de eliminar esta factura?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            string query = "CALL sp_delete_factura(@p_id)";
                            MySqlCommand command = new MySqlCommand(query, connection);
                            command.Parameters.AddWithValue("@p_id", idFactura);

                            command.ExecuteNonQuery();
                            MessageBox.Show("Factura eliminada correctamente.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Actualizar el DataGridView de facturas
                            LoadDataFactura();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al eliminar la factura: " + ex.Message, "Error de Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una factura para eliminar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadFilteredDataFactura(string filter)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "CALL sp_search_factura(@filter)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@filter", "%" + filter + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridViewFacturas.DataSource = dataTable;
                // Ocultar la columna de encabezado de fila
                dataGridViewFacturas.RowHeadersVisible = false;
            }
        }

        private void btnBuscarFact_Click(object sender, EventArgs e)
        {
            string filter = txtBuscarFactura.Text;
            LoadFilteredDataFactura(filter);
        }

        private void dataGridViewFacturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridViewFacturas.Rows[e.RowIndex];
                    lblIdFactura.Text = row.Cells["id"].Value.ToString();
                    dtpFactura.Value = Convert.ToDateTime(row.Cells["fecha_factura"].Value);
                    txtTotalFactura.Text = row.Cells["total_factura"].Value.ToString();
                    txtDetalles.Text = row.Cells["detalles"].Value.ToString();
                    cmbReservas.SelectedValue = row.Cells["reserva_id"].Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar la factura: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion Factura

        #region Grupos_Permisos

        private void LimpiarGruposPermisos()
        {
            lblIdPermisosGrupos.Text = string.Empty;
            cmbPermisos.SelectedIndex = -1;
            cmbGrupos.SelectedIndex = -1;
        }

        private void LoadDataGruposPermisos()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("CALL sp_read_grupos_permisos()", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridViewGruposPermisos.DataSource = dataTable;
                dataGridViewGruposPermisos.RowHeadersVisible = false;
            }
        }

        private void LoadPermisosComboBox()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("CALL sp_read_permisos()", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                cmbPermisos.DataSource = dataTable;
                cmbPermisos.DisplayMember = "nombre";
                cmbPermisos.ValueMember = "id";
                cmbPermisos.SelectedIndex = -1;
            }
        }

        private void LoadGruposComboBox()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("CALL sp_read_grupos()", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                cmbGrupos.DataSource = dataTable;
                cmbGrupos.DisplayMember = "nombre";
                cmbGrupos.ValueMember = "id";
                cmbGrupos.SelectedIndex = -1;
            }
        }

        private void btnAgregarGrupoPermiso_Click(object sender, EventArgs e)
        {
            int idPermiso = (int)cmbPermisos.SelectedValue;
            int idGrupo = (int)cmbGrupos.SelectedValue;

            if (idPermiso == -1 || idGrupo == -1)
            {
                MessageBox.Show("Por favor, seleccione un permiso y un grupo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "CALL sp_assign_permiso_to_grupo(@p_permiso_id, @p_grupo_id)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@p_permiso_id", idPermiso);
                    command.Parameters.AddWithValue("@p_grupo_id", idGrupo);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Permiso asignado al grupo correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarGruposPermisos();
                    LoadDataGruposPermisos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al asignar permiso al grupo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminarGrupoPermiso_Click(object sender, EventArgs e)
        {
            int idGrupoPermiso = Convert.ToInt32(lblIdPermisosGrupos.Text);
            int idPermiso = (int)cmbPermisos.SelectedValue;
            int idGrupo = (int)cmbGrupos.SelectedValue;

            if (idGrupoPermiso == 0)
            {
                MessageBox.Show("Por favor, seleccione un grupo-permiso existente para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("¿Estás seguro de eliminar este grupo-permiso?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "CALL sp_revoke_permiso_from_grupo(@p_grupo_id, @p_permiso_id)";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@p_grupo_id", idGrupo);
                        command.Parameters.AddWithValue("@p_permiso_id", idPermiso);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Permiso revocado del grupo correctamente.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimpiarGruposPermisos();
                        LoadDataGruposPermisos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al revocar permiso del grupo: " + ex.Message, "Error de Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void btnBuscarGrupoPermiso_Click(object sender, EventArgs e)
        {
            string filter = txtBuscarGrupoPermiso.Text;
            LoadFilteredDataGruposPermisos(filter);
        }

        private void LoadFilteredDataGruposPermisos(string filter)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "CALL sp_search_grupos_permisos(@filter)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@filter", "%" + filter + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridViewGruposPermisos.DataSource = dataTable;
                dataGridViewGruposPermisos.RowHeadersVisible = false;
            }
        }

        private void dataGridViewGruposPermisos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridViewGruposPermisos.Rows[e.RowIndex];
                    lblIdPermisosGrupos.Text = row.Cells["id_grupo_permiso"].Value.ToString();
                    cmbPermisos.SelectedValue = row.Cells["id_permiso"].Value;
                    cmbGrupos.SelectedValue = row.Cells["id_grupo"].Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar grupo-permiso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Grupos_Permisos



    }
}
