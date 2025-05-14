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
    public partial class FormTareas: Form
    {
        BaseDeDatos bd1 = new BaseDeDatos();
        int valorEntero;
        public FormTareas()
        {
            InitializeComponent();
            dataGridView1.DataSource = bd1.MostrarTareas();
            actualizarComboUsuarios();
            actualizarComboPryectos();
            actualizarComboEmpresa();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (txtID.Text != "")
            {

                bd1.CrearTarea(validarInt(txtID.Text), txtNombre.Text, txtDescripcion.Text, dtInicio.Value, dtFin.Value, (int)((KeyValuePair<int, string>)comboProyecto.SelectedItem).Key, (int)((KeyValuePair<int, string>)comboEmpresa.SelectedItem).Key, (int)((KeyValuePair<int, string>)comboUsuario.SelectedItem).Key);
                dataGridView1.DataSource = bd1.MostrarTareas();
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
                bd1.ActualizarTarea(validarInt(txtID.Text), txtNombre.Text, txtDescripcion.Text, dtInicio.Value, dtFin.Value, (int)((KeyValuePair<int, string>)comboProyecto.SelectedItem).Key, (int)((KeyValuePair<int, string>)comboEmpresa.SelectedItem).Key, (int)((KeyValuePair<int, string>)comboUsuario.SelectedItem).Key);
                dataGridView1.DataSource = bd1.MostrarTareas();
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
                bd1.EliminarTarea(validarInt(txtID.Text));
                dataGridView1.DataSource = bd1.MostrarTareas();
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
                DataGridViewRow filaSeleccionada = dataGridView1.Rows[e.RowIndex]; try
                {
                    txtID.Text = filaSeleccionada.Cells["id"].Value.ToString();
                    txtNombre.Text = filaSeleccionada.Cells["nombre"].Value.ToString();
                    txtDescripcion.Text = filaSeleccionada.Cells["descripcion"].Value.ToString();
                    dtInicio.Value = DateTime.Parse(filaSeleccionada.Cells["fecha_inicio"].Value.ToString());
                    dtFin.Value = DateTime.Parse(filaSeleccionada.Cells["fecha_fin"].Value.ToString());
                    foreach (KeyValuePair<int, string> item in comboUsuario.Items)
                    {
                        if (filaSeleccionada.Cells["id_usuarioRes"].Value.ToString() == item.Key.ToString())
                        {
                            comboUsuario.SelectedItem = new KeyValuePair<int, string>(Int32.Parse(item.Key.ToString()), item.Value.ToString());
                        }
                        //MessageBox.Show(item.Key.ToString());
                    }
                    foreach (KeyValuePair<int, string> item in comboProyecto.Items)
                    {
                        if (filaSeleccionada.Cells["id_proyecto"].Value.ToString() == item.Key.ToString())
                        {
                            comboProyecto.SelectedItem = new KeyValuePair<int, string>(Int32.Parse(item.Key.ToString()), item.Value.ToString());
                        }
                        //MessageBox.Show(item.Key.ToString());
                    }
                    foreach (KeyValuePair<int, string> item in comboEmpresa.Items)
                    {
                        if (filaSeleccionada.Cells["id_empresa"].Value.ToString() == item.Key.ToString())
                        {
                            comboEmpresa.SelectedItem = new KeyValuePair<int, string>(Int32.Parse(item.Key.ToString()), item.Value.ToString());
                        }
                        //MessageBox.Show(item.Key.ToString());
                    }
                }
                catch(Exception ex)
                {

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

        private void actualizarComboUsuarios()
        {
            if (bd1.ListaUsuarios() != null)
            {
                comboUsuario.DataSource = new BindingSource(bd1.ListaUsuarios(), null);
                comboUsuario.DisplayMember = "Value"; // Lo que se muestra en el ComboBox
                comboUsuario.ValueMember = "Key"; // Lo que se usará como identificador
            }

        }
        private void actualizarComboPryectos()
        {
            if (bd1.ListaProyectos() != null)
            {
                comboProyecto.DataSource = new BindingSource(bd1.ListaProyectos(), null);
                comboProyecto.DisplayMember = "Value"; // Lo que se muestra en el ComboBox
                comboProyecto.ValueMember = "Key"; // Lo que se usará como identificador
            }

        }
        private void actualizarComboEmpresa()
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
