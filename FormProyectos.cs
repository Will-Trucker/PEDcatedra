using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PEDcatedra
{
    public partial class FormProyectos: Form
    {
        BaseDeDatos bd1 = new BaseDeDatos();
        int valorEntero;
        public FormProyectos()
        {
            InitializeComponent();
            dataGridView1.DataSource = bd1.MostrarProyectos();
            actualizarCombo();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (txtID.Text != "")
            {

                bd1.CrearProyecto(validarInt(txtID.Text), txtNombre.Text, txtDescripcion.Text,validarInt(txtCantMiembros.Text), (int)((KeyValuePair<int, string>)comboEmpresa.SelectedItem).Key);
                dataGridView1.DataSource = bd1.MostrarProyectos();
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
                bd1.ActualizarProyecto(validarInt(txtID.Text), txtNombre.Text, txtDescripcion.Text, validarInt(txtCantMiembros.Text), (int)((KeyValuePair<int, string>)comboEmpresa.SelectedItem).Key);
                dataGridView1.DataSource = bd1.MostrarProyectos();
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
                bd1.EliminarProyecto(validarInt(txtID.Text));
                dataGridView1.DataSource = bd1.MostrarProyectos();
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

                //Asignar valores de las celdas a los TextBox
                txtID.Text = filaSeleccionada.Cells["id"].Value.ToString();
                txtNombre.Text = filaSeleccionada.Cells["nombre"].Value.ToString();
                txtDescripcion.Text = filaSeleccionada.Cells["descripcion"].Value.ToString();
                txtCantMiembros.Text= filaSeleccionada.Cells["cantMiembros"].Value.ToString();

                foreach (KeyValuePair<int, string> item in comboEmpresa.Items)
                {
                    if (filaSeleccionada.Cells["id_Empresa"].Value.ToString() == item.Key.ToString())
                    {
                        comboEmpresa.SelectedItem = new KeyValuePair<int, string>(Int32.Parse(item.Key.ToString()), item.Value.ToString());
                    }
                    //MessageBox.Show(item.Key.ToString());
                }


            }

        }

        private int validarInt(string valor)
        {
            try
            {
                valorEntero = Int32.Parse(valor);
                return valorEntero;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                MessageBox.Show("Error al convertir:" + valor + " a entero");
                return -1;
            }
        }

        private void actualizarCombo()
        {
            if (bd1.ListaEmpresas() != null)
            {
                comboEmpresa.DataSource = new BindingSource(bd1.ListaEmpresas(), null);
                comboEmpresa.DisplayMember = "Value"; // Lo que se muestra en el ComboBox
                comboEmpresa.ValueMember = "Key"; // Lo que se usará como identificador
            }

        }
        private void comboUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Dictionary<int, string> usuarios = new Dictionary<int, string>{};
            //usuarios.
        }
    }
}
