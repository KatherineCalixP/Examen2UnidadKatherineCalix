using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tickets
    {
        public int idTickets { get; set; }
        public string UsuarioCorreo { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public string TSoporte { get; set; }
        public string DescripcionSolicitud { get; set; }
        public string DescripcionRes { get; set; }
        public decimal Precio { get; set; }
        public decimal ISV { get; set; }
        public decimal Descuento { get; set; }
        public Decimal Total { get; set; }
    }
}
