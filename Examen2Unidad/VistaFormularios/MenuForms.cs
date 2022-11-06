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
    public partial class MenuForms : Form
    {
        public MenuForms()
        {
            InitializeComponent();
        }

        //TsoporteForms _TsoporteForm = null;
       // TicketsForms _TicketsForm = null;
        private void tiposDeSoporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
           TsoporteForms formulario = new TsoporteForms();
            Hide();
            formulario.Show();
        }

        private void ingresarTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TicketsForms formulario = new TicketsForms();
            Hide();
            formulario.Show();
        }

        private void MenuForms_Load(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
