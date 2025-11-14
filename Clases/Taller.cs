using BibTaller.Clases.EstrucPersona;
using BibTaller.Interfaces;
using BibTaller.Fabricas;
using BibTaller.Clases.EstrucReparcion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibTaller.Eventos;
using BibTaller.Aspectos;

namespace BibTaller.Clases {
    public class Taller {

        // Suscriptors
        private AdministradorOrden _administradorOrden;
        private AdministradorUsuario _administradorUsuario;
        private AdministradorPago _administradorPago;

        // Factory
        private RegistroFactory _registroFactory;

        // Proxys
        private IOrdenRecorder _ordenRecorderProxy;
        private IUserRecorder _userRecorderProxy;
        private IFacturaRecorder _facturaRecorderProxy;

        // Publishers
        public Publi_RegistroDeUsuario PublicadorRegistroDeUsuario = new Publi_RegistroDeUsuario();
        public Publi_ProcesoDeReparacion PublicadorProcesoDeReparacion = new Publi_ProcesoDeReparacion();

        // Constructor
        public Taller(Interceptor_RegistroDB interceptor, string rutaArhivoUser, string rutaArhivoOrden, string rutaArhivoFactura) {
            _registroFactory = new RegistroFactory(interceptor);

            _ordenRecorderProxy = _registroFactory.CrearRegistroOrden(rutaArhivoOrden);
            _userRecorderProxy = _registroFactory.CrearRegistroUsuario(rutaArhivoUser);
            _facturaRecorderProxy = _registroFactory.CrearRegistroFactura(rutaArhivoFactura);

            AdministradorOrden = new AdministradorOrden(_ordenRecorderProxy, PublicadorProcesoDeReparacion, rutaArhivoOrden);
            AdministradorPago = new AdministradorPago(_facturaRecorderProxy, _userRecorderProxy, PublicadorProcesoDeReparacion, rutaArhivoFactura);
            AdministradorUsuario = new AdministradorUsuario(_userRecorderProxy, PublicadorRegistroDeUsuario, rutaArhivoUser);
        }

        // Accesores
        public AdministradorOrden AdministradorOrden { get => _administradorOrden; set => _administradorOrden = value; }
        public AdministradorUsuario AdministradorUsuario { get => _administradorUsuario; set => _administradorUsuario = value; }
        public AdministradorPago AdministradorPago { get => _administradorPago; set => _administradorPago = value; }
    }
}
