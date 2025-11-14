using BibTaller.Clases.ClasesEventArgs;
using BibTaller.Clases.EstrucReparcion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BibTaller.Eventos {
    public class Publi_ProcesoDeReparacion {

        // Enventos
        public event EventHandler<RegistroOrdenEventArgs>? NotificarIngresoVehiculo;
        public event EventHandler<RegistroOrdenEventArgs>? NotificarRepararVehiculo;
        public event EventHandler<RegistroOrdenEventArgs>? NotificarPagarOrden;
        public event EventHandler<RegistroOrdenEventArgs>? NotificarEntregarVehiculo;


        // Metodos - Eventos

        public string IngresarVehiculo(OrdenReparacion ordenReparacion) {

            try {
                NotificarIngresoVehiculo?.Invoke(this, new RegistroOrdenEventArgs(ordenReparacion));
                return "El vehículo ha sido ingresado correctamente.";
            
            } catch (Exception ex) {
                return ex.Message;
            }
        }
        public string RepararVehiculo(OrdenReparacion ordenReparacion) {

            try {
                NotificarRepararVehiculo?.Invoke(this, new RegistroOrdenEventArgs(ordenReparacion));
                return "El vehículo ha sido reparado correctamente.";

            } catch (Exception ex) {
                return ex.Message;
            }
        }

        public string PagarRepVehiculo(OrdenReparacion ordenReparacion) {

            try {
                NotificarPagarOrden?.Invoke(this, new RegistroOrdenEventArgs(ordenReparacion));
                return "El pago de la reparación ha sido procesado correctamente.";

            } catch (Exception ex) {
                return ex.Message;
            }
        }

        public string EntregarVehiculoReparado(OrdenReparacion ordenReparacion) {

            try {
                NotificarEntregarVehiculo?.Invoke(this, new RegistroOrdenEventArgs(ordenReparacion));
                return "El vehículo reparado ha sido entregado correctamente.";

            } catch (Exception ex) {
                return ex.Message;
            }
        }

    }
}
