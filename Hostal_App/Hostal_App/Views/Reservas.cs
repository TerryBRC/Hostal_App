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
    public partial class Reservas : MaterialForm
    {
        private readonly ReservaService reservaService;
        private readonly ClienteService clienteService;
        private readonly HabitacionService habitacionService;
        private readonly List<Permiso> permisosLogin;
        public Reservas(List<Permiso> permisosLogin)
        {
            InitializeComponent();
            reservaService = new ReservaService();
            clienteService = new ClienteService();
            habitacionService = new HabitacionService();
            LoadDataReservas();
            this.permisosLogin = permisosLogin;
            Configurar();
        }
        private void Configurar()
        {
            btnAgregarReserva.Enabled = false;
            btnActualizarReserva.Enabled = false;
            btnEliminarReserva.Enabled = false;
            foreach (var item in permisosLogin)
            {
                switch (item.Nombre)
                {
                    case "c reserva":
                        btnAgregarReserva.Enabled = true;
                        break;
                    case "u reserva":
                        btnActualizarReserva.Enabled = true;
                        break;
                    case "d reserva":
                        btnEliminarReserva.Enabled = true;
                        break;
                    default:
                        break;
                }
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarReserva();
        }

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
            Configurar();
        }

        private void LoadDataReservas()
        {
            dataGridViewReservas.DataSource = reservaService.ObtenerReservas();
            dataGridViewReservas.RowHeadersVisible = false;
            dataGridViewReservas.Columns["cliente_id"].Visible = false;
            dataGridViewReservas.Columns["habitacion_id"].Visible = false;

            // Cargar los ComboBox de clientes y habitaciones
            CargarComboBoxClientes();
            CargarComboBoxHabitaciones();
        }

        private void CargarComboBoxClientes()
        {
            // Obtener la lista de clientes
            DataTable clientes = clienteService.ObtenerClientes();

            // Crear una nueva columna para el nombre completo
            clientes.Columns.Add("NombreCompleto", typeof(string), "nombre + ' ' + apellido");

            // Asignar la lista de clientes al ComboBox de clientes
            cmbClientes.DataSource = clientes;
            cmbClientes.DisplayMember = "NombreCompleto"; 
            cmbClientes.ValueMember = "id"; 
            cmbClientes.SelectedIndex = -1;
        }

        private void CargarComboBoxHabitaciones()
        {
            DataTable habitaciones = habitacionService.ObtenerHabitaciones();
            cmbHabitaciones.DataSource = habitaciones;
            cmbHabitaciones.DisplayMember = "Habitacion"; 
            cmbHabitaciones.ValueMember = "id"; 
            cmbHabitaciones.SelectedIndex = -1; 
        }
        private void dataGridViewReservas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridViewReservas.Rows[e.RowIndex];
                    lblIdReserva.Text = row.Cells["Reserva"].Value.ToString();
                    dtpEntrada.Value = Convert.ToDateTime(row.Cells["Entrada"].Value);
                    dtpSalida.Value = Convert.ToDateTime(row.Cells["Salida"].Value);
                    txtNumeroHuespedes.Text = row.Cells["Cantidad"].Value.ToString();
                    cmbEstado.Text = row.Cells["estado"].Value.ToString();
                    cmbClientes.SelectedValue = row.Cells["cliente_id"].Value;
                    cmbHabitaciones.SelectedValue = row.Cells["habitacion_id"].Value;
                    Configurar();
                    btnAgregarReserva.Enabled = false;

                    //formato de celdas
                    dataGridViewReservas.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridViewReservas_CellFormatting);

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
                string estado = cmbEstado.Text;
                long clienteId = Convert.ToInt64(cmbClientes.SelectedValue);
                long habitacionId = Convert.ToInt64(cmbHabitaciones.SelectedValue);

                // Llamar al método CrearReserva del servicio de reservas
                bool resultado = reservaService.CrearReserva(fechaEntrada, fechaSalida, numeroHuespedes, estado, clienteId, habitacionId);

                if (resultado)
                {
                    LoadDataReservas();
                    LimpiarReserva();
                    MessageBox.Show("Reserva agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Actualizar la disponibilidad de la habitación
                    bool actualizacionExitosa = habitacionService.ActualizarDisponibilidadHabitacion(habitacionId);
                    if (!actualizacionExitosa)
                    {
                        MessageBox.Show("Reserva agregada, pero hubo un problema al actualizar la disponibilidad de la habitación.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Reserva agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
                string estado = cmbEstado.Text;
                long clienteId = Convert.ToInt64(cmbClientes.SelectedValue);
                long habitacionId = Convert.ToInt64(cmbHabitaciones.SelectedValue);

                // Llamar al método ActualizarReserva del servicio de reservas
                bool resultado = reservaService.ActualizarReserva(id, fechaEntrada, fechaSalida, numeroHuespedes, estado, clienteId, habitacionId);

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

        private void dataGridViewReservas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewReservas.Rows[e.RowIndex].Cells["Estado"].Value != null)
            {
                // Verificar si la fecha de salida se ha cumplido
                DateTime fechaSalida = Convert.ToDateTime(dataGridViewReservas.Rows[e.RowIndex].Cells["Salida"].Value);
                if (fechaSalida < DateTime.Now)
                {
                    // Establecer el color de la fila en blanco si la fecha de salida ya se cumplió
                    dataGridViewReservas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    dataGridViewReservas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
                else
                {
                    string estado = dataGridViewReservas.Rows[e.RowIndex].Cells["Estado"].Value.ToString();

                    if (estado.Equals("Activo", StringComparison.OrdinalIgnoreCase))
                    {
                        dataGridViewReservas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
                        dataGridViewReservas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                    }
                    else if (estado.Equals("Pendiente", StringComparison.OrdinalIgnoreCase))
                    {
                        dataGridViewReservas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                        dataGridViewReservas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else if (estado.Equals("Cancelado", StringComparison.OrdinalIgnoreCase))
                    {
                        dataGridViewReservas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                        dataGridViewReservas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                    }
                    else if (estado.Equals("Finalizado", StringComparison.OrdinalIgnoreCase))
                    {
                        dataGridViewReservas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Blue;
                        dataGridViewReservas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                    }
                    else if (estado.Equals("No Presentado", StringComparison.OrdinalIgnoreCase))
                    {
                        dataGridViewReservas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gray;
                        dataGridViewReservas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                    }
                    else if (estado.Equals("En Proceso", StringComparison.OrdinalIgnoreCase))
                    {
                        dataGridViewReservas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Orange;
                        dataGridViewReservas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        dataGridViewReservas.Rows[e.RowIndex].DefaultCellStyle.BackColor = dataGridViewReservas.DefaultCellStyle.BackColor;
                        dataGridViewReservas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = dataGridViewReservas.DefaultCellStyle.ForeColor;
                    }
                }
            }
        }
    }
}
