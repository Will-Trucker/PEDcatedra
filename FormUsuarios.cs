using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PEDcatedra
{
    public partial class FormUsuarios: Form
    {
        BaseDeDatos bd1 = new BaseDeDatos();
        int valorEntero;
        public FormUsuarios()
        {
            InitializeComponent();      
            dataGridView1.DataSource = bd1.mostrarUsuarios();
            txtEdad.Text = "0";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (txtID.Text != "")
            {
                bd1.crearUsuario(validarInt(txtID.Text), txtNombre.Text, txtApellido.Text, validarInt(txtEdad.Text));
                dataGridView1.DataSource = bd1.mostrarUsuarios();
            }
            else
            {
                MessageBox.Show("Error ID vacio");
            }

        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                bd1.ActualizarUsuario(validarInt(txtID.Text), txtNombre.Text, txtApellido.Text, validarInt(txtEdad.Text));
                dataGridView1.DataSource = bd1.mostrarUsuarios();
            }
            else
            {
                MessageBox.Show("Error ID vacio");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                bd1.EliminarrUsuario(validarInt(txtID.Text));
                dataGridView1.DataSource = bd1.mostrarUsuarios();
            }
            else
            {
                MessageBox.Show("Error ID vacio");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dataGridView1.Rows[e.RowIndex];

                // Asignar valores de las celdas a los TextBox
                txtID.Text = filaSeleccionada.Cells["id"].Value.ToString();
                txtNombre.Text = filaSeleccionada.Cells["nombre"].Value.ToString();
                txtApellido.Text = filaSeleccionada.Cells["apellidos"].Value.ToString();
                txtEdad.Text = filaSeleccionada.Cells["edad"].Value.ToString();                
            }

        }

        private int validarInt(string valor)
        {
            try
            {
                valorEntero = Int32.Parse(valor);
                return valorEntero;
            }catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                MessageBox.Show("Error al convertir:" + valor + " a entero");
                return -1;
            }
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtEdad_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
