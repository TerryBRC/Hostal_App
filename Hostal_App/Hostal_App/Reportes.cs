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
using Hostal_App.Services;
using ClosedXML.Excel;

namespace Hostal_App
{
    public partial class Reportes : MaterialForm
    {
        private readonly DashboardService dashboardService;
        private readonly TipoHabitacionService tipoHabitacionService;
        public Reportes()
        {
            InitializeComponent();
            dashboardService = new DashboardService();
            tipoHabitacionService = new TipoHabitacionService();
            CargarComboBoxTipoHabitacion();
            CargarComboBoxEstados();
        }

        private void CargarComboBoxTipoHabitacion()
        {
            comboBoxTipoHabitacion.DataSource = tipoHabitacionService.ObtenerTiposHabitacion();
            comboBoxTipoHabitacion.DisplayMember = "Tipo";
            comboBoxTipoHabitacion.ValueMember = "Id";
            comboBoxTipoHabitacion.SelectedIndex = -1;
        }
        private void CargarComboBoxEstados()
        {
            // Asumiendo que tienes una lista predefinida de estados posibles
            List<string> estados = new List<string> { "Activo", "Cancelado", "Pendiente" };
            comboBoxEstado.DataSource = estados;
        }
        private void btnCargar_Click(object sender, EventArgs e)
        {
            dataGridViewReservas.DataSource = dashboardService.ObtenerDatosReservas();
            dataGridViewReservas.RowHeadersVisible = false;
            
        }

        private void ExportarAExcel(DataGridView dataGridView, string filePath, string titulo)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Reporte");
                var currentRow = 1;

                // Título
                worksheet.Cell(currentRow, 1).Value = titulo;
                worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 1).Style.Font.FontSize = 16;
                worksheet.Cell(currentRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Range(currentRow, 1, currentRow, dataGridView.Columns.Count).Merge();
                currentRow += 2;

                // Encabezados
                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    worksheet.Cell(currentRow, i + 1).Value = dataGridView.Columns[i].HeaderText;
                    worksheet.Cell(currentRow, i + 1).Style.Font.Bold = true;
                    worksheet.Cell(currentRow, i + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
                    worksheet.Cell(currentRow, i + 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                }

                currentRow++;

                // Datos
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        var cellValue = row.Cells[i].Value;
                        if (cellValue != null)
                        {
                            worksheet.Cell(currentRow, i + 1).Value = cellValue.ToString();
                        }
                    }
                    currentRow++;
                }

                // Ajustar ancho de columnas
                worksheet.Columns().AdjustToContents();

                // Guardar el archivo
                workbook.SaveAs(filePath);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Guardar archivo Excel";
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.FileName = $"Reporte_{DateTime.Now.ToString("yyyyMMdd")}.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    string titulo = System.IO.Path.GetFileNameWithoutExtension(filePath);

                    // Crear y guardar el archivo Excel
                    ExportarAExcel(dataGridViewReservas, filePath, titulo);
                    MessageBox.Show("Datos exportados exitosamente", "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnCrearInforme_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dateTimePickerInicio.Value;
            DateTime fechaFin = dateTimePickerFin.Value;

            if (fechaInicio > fechaFin)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable reservasFiltradas = dashboardService.ObtenerReservasPorRangoDeFechas(fechaInicio, fechaFin);
            dataGridViewReservas.DataSource = reservasFiltradas;
            dataGridViewReservas.RowHeadersVisible = false;
        }

        private void btnCrearInformeTH_Click(object sender, EventArgs e)
        {
            if (comboBoxTipoHabitacion.SelectedItem != null)
            {
                int tipoHabitacionId = Convert.ToInt32(comboBoxTipoHabitacion.SelectedValue);
                string tipoHabitacion = comboBoxTipoHabitacion.Text;

                // Llamar al método en DashboardService para obtener reservas por tipo de habitación
                DataTable reservasPorTipo = dashboardService.ObtenerReservasPorTipoHabitacion(tipoHabitacionId);

                // Mostrar los datos en el DataGridView u otra lógica para presentar el informe
                dataGridViewReservas.DataSource = reservasPorTipo;
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un tipo de habitación.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnCrearInformeCliente_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dtpFechaInicio.Value;
            DateTime fechaFin = dtpFechaFin.Value;
            int minReservas = (int)numericUpDownMinReservas.Value;
            if (fechaInicio > fechaFin)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dataGridViewReservas.DataSource = dashboardService.ObtenerClientesFrecuentes(fechaInicio, fechaFin, minReservas);
            dataGridViewReservas.RowHeadersVisible = false;
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dtpDPInicio.Value;
            DateTime fechaFin = dtpDPFin.Value;
            if (fechaInicio > fechaFin)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable dt = dashboardService.ObtenerDuracionPromedioEstancia(fechaInicio, fechaFin);

            // Verifica que el DataTable contenga datos
            if (dt.Rows.Count > 0)
            {
                // Asigna el resultado del promedio de estancia al DataGridView
                dataGridViewReservas.DataSource = null; // Limpiar el DataSource antes de asignar nuevo
                dataGridViewReservas.Columns.Clear(); // Limpiar columnas existentes

                // Crear la columna para mostrar el promedio de duración de estancia
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "PromedioEstancia"; // Nombre de la columna en el DataTable
                column.HeaderText = "Promedio Estancia";
                column.DefaultCellStyle.Format = "N2"; // Formato para dos decimales
                dataGridViewReservas.Columns.Add(column);

                // Asignar los datos al DataGridView
                dataGridViewReservas.DataSource = dt;
                dataGridViewReservas.RowHeadersVisible = false;
            }
            else
            {
                MessageBox.Show("No se encontraron datos para el período seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnVerPorEstado_Click(object sender, EventArgs e)
        {
            string estado = comboBoxEstado.SelectedItem.ToString();
            if (string.IsNullOrEmpty(estado))
            {
                MessageBox.Show("Por favor, seleccione un estado de reserva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dataGridViewReservas.DataSource = dashboardService.ObtenerReservasPorEstado(estado);
            dataGridViewReservas.RowHeadersVisible = false;
        }

        private void btnTotalOcupacion_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dtpInicio.Value;
            DateTime fechaFin = dtpFin.Value;

            if (fechaInicio > fechaFin)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Llamar al método para obtener la ocupación de habitaciones con los parámetros ingresados
            dataGridViewReservas.DataSource = dashboardService.ObtenerOcupacionHabitaciones(fechaInicio, fechaFin);
            dataGridViewReservas.RowHeadersVisible = false;
        }
    }
}
