using BibTaller.Clases.ClasesEventArgs;
using BibTaller.Eventos;
using BibTaller.Fabricas;
using BibTaller.Interfaces;
using BibTaller.Clases.EstrucPago;
using BibTaller.Clases.EstrucPersona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibTaller.Clases.ClasesEventArgs;

namespace BibTaller.Clases
{
    public class AdministradorPago
    {
        // Atributos
        public IFacturaRecorder _facturaRecorder;
        public IUserRecorder _userRecorder;
        private Publi_ProcesoDeReparacion _publi_ProcesoDeReparacion;

        // Constructor
        public AdministradorPago(IFacturaRecorder facturaRecorder, IUserRecorder userRecorder, Publi_ProcesoDeReparacion publi_ProcesoDeReparacion, string rutaArchivoFactura)
        {
            _facturaRecorder = facturaRecorder;
            _userRecorder = userRecorder;
            _publi_ProcesoDeReparacion = publi_ProcesoDeReparacion;
            Suscribir();

        }

        // Metodos
        public void GenerarFactura(object? sender, RegistroOrdenEventArgs e)
        {
            Factura factura;

            if (!e.Orden.Reparacion.Carro.Propietario.TieneSaldo) factura = new PagoContado(e.Orden).Pagar();
            else
            {
                var repuestos = e.Orden.Reparacion.RepuestosUtilizados;
                decimal totalCostoRepuesto = repuestos.Select(r => (decimal)r.Costo).Sum();

                e.Orden.Reparacion.Carro.Propietario.SaldoADeber += e.Orden.Reparacion.CostoManoObra + (ulong)totalCostoRepuesto;
                _userRecorder.ModificarUsuario(e.Orden.Reparacion.Carro.Propietario.Id, e.Orden.Reparacion.Carro.Propietario);
                factura = new PagoCredito(e.Orden).Pagar();
            }
            _facturaRecorder.RegistrarFactura(factura);
        }

        public void EliminarFactura(object? sender, RegistroOrdenEventArgs e)
        {
            _facturaRecorder.EliminarFactura(e.Orden.IdOrden);
        }

        public void Suscribir()
        {
            _publi_ProcesoDeReparacion.NotificarEntregarVehiculo += GenerarFactura;
            //_publi_ProcesoDeReparacion.NotificarEliminarOrden += EliminarFactura;
        }
    }
}
