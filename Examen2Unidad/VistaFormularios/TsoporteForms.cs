using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaFormularios
{
    public partial class TsoporteForms : Form
    {
        public TsoporteForms()
        {
            InitializeComponent();
        }
        //Instancias
        TipoSoporteDatos soporteDatos = new TipoSoporteDatos();
        string tipoOperacion = string.Empty;
        TipoSoporte Tsoporte;
        private void TsoporteForms_Load(object sender, EventArgs e)
        {
            MostrarTipoSoporteDataGrid();

        }
        private async void MostrarTipoSoporteDataGrid()
        {
            TsoporteDataGridView.DataSource = await soporteDatos.DevolverTipoSoporteAsync();
        }

        private void HabilitarControles()
        {
            CodigoTextBox.ReadOnly = false;
            CodigoTextBox.Enabled = true;
            DescripcionTextBox.Enabled = true;
            TSoporteTextBox.Enabled = true;
            PreciotextBox.Enabled = true;
            
        }
        private void LimpiarControles()
        {
            CodigoTextBox.Clear();
            DescripcionTextBox.Clear();
            TSoporteTextBox.Clear();
            PreciotextBox.Clear();
            
        }
        private void DesabilitarControles()
        {
            CodigoTextBox.Enabled = false;
            DescripcionTextBox.Enabled = false;
            TSoporteTextBox.Enabled = false;
            PreciotextBox.Enabled = false;
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            tipoOperacion = "Nuevo";
            HabilitarControles();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DesabilitarControles();
            LimpiarControles();
        }

        private async void EliminarButton_Click(object sender, EventArgs e)
        {
            if (TsoporteDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = await soporteDatos.EliminarAsync(TsoporteDataGridView.CurrentRow.Cells["Codigo"].Value.ToString());
                if (elimino)
                {
                    MostrarTipoSoporteDataGrid();
                    MessageBox.Show("Usuario Eliminado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Usuario no se pudo eliminar", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Salirbutton_Click(object sender, EventArgs e)
        {
            Close();
            MenuForms formulario = new MenuForms();
            Hide();
            formulario.Show();
        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {
            tipoOperacion = "Modificar";
            if (TsoporteDataGridView.SelectedRows.Count > 0)
            {
                CodigoTextBox.Text = TsoporteDataGridView.CurrentRow.Cells["Codigo"].Value.ToString();
                TSoporteTextBox.Text = TsoporteDataGridView.CurrentRow.Cells["TSoporte"].Value.ToString();
                DescripcionTextBox.Text = TsoporteDataGridView.CurrentRow.Cells["Descripcion"].Value.ToString();
                PreciotextBox.Text = TsoporteDataGridView.CurrentRow.Cells["ValorSoporte"].Value.ToString();
                HabilitarControles();
                CodigoTextBox.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void GuardarButton_Click(object sender, EventArgs e)
        {
            Tsoporte = new TipoSoporte();

            if (tipoOperacion == "Nuevo")
            {
                if (string.IsNullOrEmpty(CodigoTextBox.Text))
                {
                    errorProvider1.SetError(CodigoTextBox, "Ingrese un código");
                    CodigoTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(TSoporteTextBox.Text))
                {
                    errorProvider1.SetError(TSoporteTextBox, "Ingrese un Tipo de Soporte");
                    TSoporteTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(DescripcionTextBox.Text))
                {
                    errorProvider1.SetError(DescripcionTextBox, "Ingrese Una descripcion");
                    DescripcionTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(PreciotextBox.Text))
                {
                    errorProvider1.SetError(PreciotextBox, "Ingrese Un valor");
                    PreciotextBox.Focus();
                    return;
                }

                Tsoporte.Codigo = CodigoTextBox.Text;
                Tsoporte.TSoporte = TSoporteTextBox.Text;
                Tsoporte.Descripcion = DescripcionTextBox.Text;
                Tsoporte.ValorSoporte =Convert.ToDecimal( PreciotextBox.Text);
                

                bool inserto = await soporteDatos.InsertarAsync(Tsoporte);
                if (inserto)
                {
                    MostrarTipoSoporteDataGrid();
                    LimpiarControles();
                    DesabilitarControles();
                    MessageBox.Show("El tipo de Sporte fue guardado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El tipo de soporte no se pudo guardar", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (tipoOperacion == "Modificar")
            {
                if (string.IsNullOrEmpty(CodigoTextBox.Text))
                {
                    errorProvider1.SetError(CodigoTextBox, "Ingrese un código");
                    CodigoTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(TSoporteTextBox.Text))
                {
                    errorProvider1.SetError(TSoporteTextBox, "Ingrese un Tipo de Soporte");
                    TSoporteTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(DescripcionTextBox.Text))
                {
                    errorProvider1.SetError(DescripcionTextBox, "Ingrese Una descripcion");
                    DescripcionTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(PreciotextBox.Text))
                {
                    errorProvider1.SetError(PreciotextBox, "Ingrese Un valor");
                    PreciotextBox.Focus();
                    return;
                }

                Tsoporte.Codigo = CodigoTextBox.Text;
                Tsoporte.TSoporte = TSoporteTextBox.Text;
                Tsoporte.Descripcion = DescripcionTextBox.Text;
                Tsoporte.ValorSoporte = Convert.ToDecimal(PreciotextBox.Text);

                bool modifico = await soporteDatos.ActualizarAsync(Tsoporte);
                if (modifico)
                {
                    MostrarTipoSoporteDataGrid();
                    LimpiarControles();
                    DesabilitarControles();
                    MessageBox.Show("El tipo de Sporte fue modificado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El tipo de soporte no se pudo modificar", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
