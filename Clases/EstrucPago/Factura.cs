using BibTaller.Clases.EstrucReparcion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BibTaller.Clases.EstrucPago {
    public class Factura {

        // Atributos
        private DateTime _fecha;
        private EstrategiaPago.tipoPago _tipoPago;
        private OrdenReparacion _ordenPagada;
        private ulong montoPagado;

        // Constructor JSON
        [JsonConstructor]
        internal Factura(DateTime fecha, EstrategiaPago.tipoPago tipoPago, OrdenReparacion ordenPagada, ulong montoPagado) {
            Fecha = fecha;
            TipoPago = tipoPago;
            OrdenPagada = ordenPagada;
            MontoPagado = montoPagado;
        }

        // Constructor JSON
        public Factura(EstrategiaPago.tipoPago tipoPago, OrdenReparacion ordenPagada) {
            Fecha = DateTime.Now;
            TipoPago = tipoPago;
            OrdenPagada = ordenPagada;
            MontoPagado = CalcularMonto();
        }

        // Ascesores
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EstrategiaPago.tipoPago TipoPago { get => _tipoPago; set => _tipoPago = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public OrdenReparacion OrdenPagada { get => _ordenPagada; set => _ordenPagada = value; }
        public ulong MontoPagado { get => montoPagado; set => montoPagado = value; }

        private ulong CalcularMonto() {

            ulong monto = 0;
            Repuesto[]? listaRepuestos = _ordenPagada.Reparacion.RepuestosUtilizados;

            if (listaRepuestos != null) {

                foreach (Repuesto repuesto in listaRepuestos) {

                    monto += repuesto.Costo;

                }
            }

            monto += _ordenPagada.Reparacion.CostoManoObra;
            return monto;

        }

    }

}