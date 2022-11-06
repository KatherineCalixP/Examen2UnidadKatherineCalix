using Datos;
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
    public partial class TicketsForms : Form
    {
        public TicketsForms()
        {
            InitializeComponent();
        }
        TickestDatos ver = new TickestDatos();
        private void TicketsForms_Load(object sender, EventArgs e)
        {
            ListarPedidos();
        }
        private void ListarPedidos()
        {
            TicketdataGridView.DataSource = ver.ListarPedidos();
        }
    }
}
