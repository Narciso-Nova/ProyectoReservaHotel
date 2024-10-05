using System;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        private GestorReservas gestorReservas = new GestorReservas();

        public Form1()
        {
            InitializeComponent();
            CargarReservas();
        }

        // Método para cargar las reservas en el DataGridView
        private void CargarReservas()
        {
            dataGridViewReservas.DataSource = gestorReservas.ObtenerReservas();
        }

        // Método para validar si los campos están completos
        private bool ValidarCampos()
        {
            return !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                   !string.IsNullOrWhiteSpace(txtHabitacion.Text) &&
                   cmbEstado.SelectedItem != null;  // Verificar que se haya seleccionado un estado
        }

        // Método para limpiar los campos después de guardar o actualizar
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtHabitacion.Clear();
            cmbEstado.SelectedIndex = -1;  // Restablecer el ComboBox
            dtpEntrada.Value = DateTime.Now;
            dtpSalida.Value = DateTime.Now;
        }

        // Evento del botón Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                gestorReservas.CrearReserva(
                    txtNombre.Text,
                    dtpEntrada.Value,
                    dtpSalida.Value,
                    int.Parse(txtHabitacion.Text),
                    cmbEstado.SelectedItem.ToString()  // Obtener el estado seleccionado del ComboBox
                );
                CargarReservas();  // Refresca la lista después de guardar
                LimpiarCampos();   // Limpiar los campos después de guardar
            }
            else
            {
                MessageBox.Show("Por favor, completa todos los campos.");
            }
        }

        // Evento del botón Actualizar
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (dataGridViewReservas.SelectedRows.Count > 0)
                {
                    // Obtener los datos actuales del formulario
                    string nombre = txtNombre.Text;
                    DateTime fechaEntrada = dtpEntrada.Value;
                    DateTime fechaSalida = dtpSalida.Value;
                    int numeroHabitacion = int.Parse(txtHabitacion.Text);
                    string estado = cmbEstado.SelectedItem.ToString();  // Obtener el estado del ComboBox
                    int reservaId = Convert.ToInt32(dataGridViewReservas.SelectedRows[0].Cells[0].Value);

                    gestorReservas.ActualizarReserva(reservaId, nombre, fechaEntrada, fechaSalida, numeroHabitacion, estado);

                    CargarReservas();  // Refresca la lista después de actualizar
                    LimpiarCampos();   // Limpiar los campos después de actualizar
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona una reserva para actualizar.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, completa todos los campos.");
            }
        }

        // Evento del botón Eliminar con confirmación
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewReservas.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("¿Estás seguro de que deseas eliminar esta reserva?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    int reservaId = Convert.ToInt32(dataGridViewReservas.SelectedRows[0].Cells[0].Value);
                    gestorReservas.EliminarReserva(reservaId);  // Llamada al método corregido
                    CargarReservas();  // Refresca la lista después de eliminar
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una reserva para eliminar.");
            }
        }

        // Evento del botón Listar
        private void btnListar_Click(object sender, EventArgs e)
        {
            CargarReservas();  // Refresca la lista manualmente
        }
    }
}
