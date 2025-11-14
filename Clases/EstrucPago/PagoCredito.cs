using BibTaller.Clases.EstrucReparcion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BibTaller.Clases.EstrucPago
{
    public class PagoCredito : EstrategiaPago
    {
        // Constructor
        public PagoCredito(OrdenReparacion ordenAPagar) : base(ordenAPagar) { }

        // Metodo Pagar
        public override Factura Pagar()
        {
            Factura factura = new Factura(tipoPago.Pago_Credito, this.OrdenAPagar);
            return factura;

        }
    }
}
