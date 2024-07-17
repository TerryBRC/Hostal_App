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
    public partial class Clientes : MaterialForm
    {
        private readonly ClienteService clienteService;
        private readonly List<Permiso> permisosLogin;
        public Clientes(List<Permiso> permisos)
        {
            InitializeComponent();
            this.permisosLogin = permisos;
            clienteService = new ClienteService();
            LoadDataClientes();
            Configurar();
        }
        private void Configurar(bool isRowSelected = false)
        {
            btnActualizarCliente.Enabled = false;
            btnAgregarCliente.Enabled = false;
            btnEliminarCliente.Enabled = false;

            foreach (var permiso in permisosLogin)
            {
                switch (permiso.Nombre)
                {
                    case "c cliente":
                        btnAgregarCliente.Enabled = !isRowSelected;
                        break;
                    case "u cliente":
                        btnActualizarCliente.Enabled = isRowSelected;
                        break;
                    case "d cliente":
                        btnEliminarCliente.Enabled = isRowSelected;
                        break;
                    default:
                        break;
                }
            }

        }
        #region Clientes
        private void LimpiarClientes()
        {
            lblIdCliente.Text = "";
            txtNombreCliente.Clear();
            txtApellidoCliente.Clear();
            txtTelefonoCliente.Clear();
            txtIdentificacion.Clear();
            txtDireccionCliente.Clear();
            txtNombreCliente.Focus();
            Configurar(); // Restablece la configuración a estado inicial
        }
        private void LoadDataClientes()
        {
            dataGridViewClientes.DataSource = clienteService.ObtenerClientes();
            // Ocultar la columna de encabezado de fila
            dataGridViewClientes.RowHeadersVisible = false;
            dataGridViewClientes.Columns["fecha_registro"].Visible = false;
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreCliente.Text;
            string apellido = txtApellidoCliente.Text;
            string telefono = txtTelefonoCliente.Text;
            string identificacion = txtIdentificacion.Text;
            string direccion = txtDireccionCliente.Text;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(telefono) || string.IsNullOrWhiteSpace(identificacion) ||
                string.IsNullOrWhiteSpace(direccion))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clienteService.CrearCliente(nombre, apellido, direccion, telefono, identificacion))
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
            string identificacion = txtIdentificacion.Text;
            string direccion = txtDireccionCliente.Text;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(telefono) || string.IsNullOrWhiteSpace(identificacion) ||
                string.IsNullOrWhiteSpace(direccion))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clienteService.ActualizarCliente(id, nombre, apellido, direccion, telefono, identificacion))
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
                    txtIdentificacion.Text = row.Cells["identificacion"].Value.ToString();
                    txtDireccionCliente.Text = row.Cells["direccion"].Value.ToString();
                    // Habilitar los botones de Actualizar y Eliminar al seleccionar una fila
                    Configurar(true); // Indica que se ha seleccionado una fila

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFilteredDataClientes(string filter)
        {
            dataGridViewClientes.DataSource = clienteService.ObtenerClientesFiltrados(filter);
            // Ocultar la columna de encabezado de fila
            dataGridViewClientes.RowHeadersVisible = false;
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarClientes();

        }
    }
}
