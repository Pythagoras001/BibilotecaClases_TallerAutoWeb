using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibTaller.Clases.ClasesEventArgs;
using BibTaller.Clases.EstrucPersona;
using BibTaller.Clases.EstrucReparcion;
using BibTaller.Clases.EstrucVehiculos;
using BibTaller.Eventos;
using BibTaller.Fabricas;
using BibTaller.Interfaces;

namespace BibTaller.Clases {
    public class AdministradorOrden {

        // Atributos
        public enum enum_tipoReparacion{PuestaPunto, CambioAceite, CambioBujia }
        public IOrdenRecorder _ordenRecorder;
        private Publi_ProcesoDeReparacion _publi_ProcesoDeReparacion;

        // Constructor
        public AdministradorOrden(IOrdenRecorder ordenRecorder, Publi_ProcesoDeReparacion publi_ProcesoDeReparacion, string rutaArchivoOrden) {
            _ordenRecorder = ordenRecorder;
            _publi_ProcesoDeReparacion = publi_ProcesoDeReparacion;
            Suscribir();
            
        }

        // Metodos
        public List<OrdenReparacion> ObtenerOrdenes() {
            return _ordenRecorder.GetListarOrdenes();
        }
        public void ModificarOrden(ulong id, OrdenReparacion newOrden) {
            _ordenRecorder.ModificarOrden(id, newOrden);
        }  

        private void IngresarVehiculo(Object sender, RegistroOrdenEventArgs e) {
            _ordenRecorder.RegistrarOrden(e.Orden);
        }

        public void RepararVehiculo(Object sender, RegistroOrdenEventArgs e) {
            e.Orden.Estado = OrdenReparacion.estadoOrden.PendientePorPago;
            _ordenRecorder.ModificarOrden(e.Orden.IdOrden, e.Orden);
        }

        public void RegistrarPagoVehiculo(Object sender, RegistroOrdenEventArgs e) {
            e.Orden.Estado = OrdenReparacion.estadoOrden.ListoParaSalida;
            _ordenRecorder.ModificarOrden(e.Orden.IdOrden, e.Orden);
        }

        public void RegistrarSalidaVehiculo(Object sender, RegistroOrdenEventArgs e) {
            e.Orden.Estado = OrdenReparacion.estadoOrden.Completado;
            _ordenRecorder.ModificarOrden(e.Orden.IdOrden, e.Orden);
        }

        public void Suscribir() {
            _publi_ProcesoDeReparacion.NotificarIngresoVehiculo += IngresarVehiculo;
            _publi_ProcesoDeReparacion.NotificarRepararVehiculo += RepararVehiculo;
            _publi_ProcesoDeReparacion.NotificarPagarOrden += RegistrarPagoVehiculo;
            _publi_ProcesoDeReparacion.NotificarEntregarVehiculo += RegistrarSalidaVehiculo;

        }
    }
}
