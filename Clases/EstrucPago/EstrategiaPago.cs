using BibTaller.Clases.EstrucReparcion;
using BibTaller.Interfaces;
using BibTaller.Clases.EstrucPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BibTaller.Clases.EstrucPago
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(PagoContado), "contado")]
    [JsonDerivedType(typeof(PagoCredito), "credito")]

    public abstract class EstrategiaPago : IEstrategiaPago
    {

        // Atributos
        public enum tipoPago { Pago_Contado, Pago_Credito }
        private OrdenReparacion _ordenAPagar;

        // Constructor
        public EstrategiaPago(OrdenReparacion ordenAPagar)
        {
            OrdenAPagar = ordenAPagar;
        }

        // Accesor
        public OrdenReparacion OrdenAPagar { get => _ordenAPagar; set => _ordenAPagar = value; }

        // Metodo
        public abstract Factura Pagar();

    }
}
