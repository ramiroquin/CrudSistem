using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        // Instaciar la clase
        CN_Productos obejtoCN = new CN_Productos();

        private string idProducto = null;

        // Variable para editar
        private bool Editar = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }
        // Metodo para mostrarpoductos
        private void MostrarProductos()
        {
            CN_Productos objeto = new CN_Productos();
            dataGridView1.DataSource = objeto.MostrarProd();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // INSERTAR

            // En caso de que editar sea falso
            if (Editar == false)
            {
                // caputarador de errores
                try
                {
                    // Al hacer click se inserta
                    obejtoCN.InsertarProd(txtNombre.Text, txtDesc.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text);
                    // Mensaje 
                    MessageBox.Show("Se inserto correctamente");
                    MostrarProductos();
                    limpiarform();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar los datos por: " + ex);
                }
            }
            // EDITAR

            if(Editar == true)
            {
                try
                {
                    obejtoCN.EditarProd(txtNombre.Text, txtDesc.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text, idProducto);
                    MessageBox.Show("Se edito correctamente");
                    MostrarProductos();
                    limpiarform();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar los datos por: " + ex);
                }
            }
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Bandera para activar en caso de que se use
                Editar = true;
                // Selecciona campo de la fila
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtDesc.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtMarca.Text = dataGridView1.CurrentRow.Cells["Marca"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                txtStock.Text = dataGridView1.CurrentRow.Cells["Stock"].Value.ToString();
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione la fila a editar");
            }
        }

        // Limpiar textbox
        private void limpiarform()
        {
            // Itera sobre cada textbox
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    
                    textBox.Clear();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idProducto = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                obejtoCN.EliminarProd(idProducto);
                MessageBox.Show("Eliminado correctamente");
                MostrarProductos();
            }
            else
            
                MessageBox.Show("Seleccione una fila por favor");
            
        }
    }
}
