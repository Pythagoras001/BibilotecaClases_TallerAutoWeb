using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BibTaller.Clases.EstrucReparcion;

namespace BibTaller.Clases.EstrucPago
{
    public class PagoContado : EstrategiaPago
    {
        // Constructor
        public PagoContado(OrdenReparacion ordenAPagar) : base(ordenAPagar) {}

        // Metodo Pagar
        public override Factura Pagar()
        {
            Factura factura = new Factura(tipoPago.Pago_Contado, this.OrdenAPagar );
            return factura;

        }

        
    }
}
