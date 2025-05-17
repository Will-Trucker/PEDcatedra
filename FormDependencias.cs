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
    public partial class FormDependencias : Form
    {

        // Llamar a clase base de datos
        BaseDeDatos bd = new BaseDeDatos();

        public FormDependencias()
        {
            InitializeComponent();
            CargarCombos();
        }

        // cargar datos en el combobox
        private void CargarCombos()
        {
            var tareas = bd.ListaTareas();
            comboTarea.DataSource = new BindingSource(tareas, null);
            comboTarea.DisplayMember = "Value";
            comboTarea.ValueMember = "Key";

            comboPredecesora.DataSource = new BindingSource(tareas,null);
            comboPredecesora.DisplayMember = "Value";
            comboPredecesora.ValueMember = "Key";

        }

       private void CargarRelaciones()
        {
            //dataGridViewRelaciones.DataSource = bd.MostarDependencias();
        }

        private void btnAgregarD_Click(object sender, EventArgs e)
        {
            int tareaId = ((KeyValuePair<int, string>)comboTarea.SelectedItem).Key;
            int preId = ((KeyValuePair<int, string>)comboPredecesora.SelectedItem).Key;

            if(tareaId == preId)
            {
                MessageBox.Show("La Tarea No Puede Depender de Ella Misma");
                return;
            }

            //if (bd.ExistDependencia(tareaId, preId)) {
                MessageBox.Show("La relacion ya existe");
                return;
            //}

            //if (bd.GenerarCiclo(tareaId, preId)) {
                MessageBox.Show("Relacion No Valida"); // La relacion genera un ciclo en el grafo. No es apta para el diagrama pert
                return;
            //}

            //bd.AgregarDependencia(tareaId,preId);
            CargarRelaciones();
        }

        private void btnEliminarD_Click(object sender, EventArgs e)
        {
            if(dataGridViewRelaciones.CurrentRow != null)
            {
                int id = (int)dataGridViewRelaciones.CurrentRow.Cells["id"].Value;
                //bd.EliminarDependencia(id);
                CargarRelaciones();
            }
        }
    }
}
