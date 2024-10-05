using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormPassword : Form
    {
        public bool Autorizado { get; private set; } = false;  // Bandera para ver si la contraseña es correcta

        public FormPassword()
        {
            InitializeComponent();
        }

        // Método que se llama al presionar el botón "Aceptar"
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string contraseñaCorrecta = "12345";  // Contraseña fija (puedes cambiarla)

            if (txtPassword.Text == contraseñaCorrecta)
            {
                Autorizado = true;
                this.Close();  // Cierra la ventana si la contraseña es correcta
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();  // Limpia el campo de la contraseña si está incorrecta
                txtPassword.Focus();  // Coloca el cursor en el campo de la contraseña
            }
        }
    }
}
