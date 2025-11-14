using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using BibTaller.Aspectos;
using BibTaller.Interfaces;
using BibTaller.Clases.Registros;

namespace BibTaller.Fabricas
{
    public class RegistroFactory
    {
        private readonly ProxyGenerator _proxyGenerator;
        private readonly  Interceptor_RegistroDB _interceptor;

        public RegistroFactory(Interceptor_RegistroDB interceptor)
        {
            _proxyGenerator = new ProxyGenerator();
            _interceptor = interceptor;
        }


        public IOrdenRecorder CrearRegistroOrden(string rutaArchivoOrdenes) 
        {
            var ordernRecorder = new OrdenRecorder(rutaArchivoOrdenes);
            return _proxyGenerator.CreateInterfaceProxyWithTarget<IOrdenRecorder>(
                ordernRecorder,
                _interceptor
            );
        }

        public IUserRecorder CrearRegistroUsuario(string rutaArchivoUsuario)
        {
            var userRecorder = new UserRecorder(rutaArchivoUsuario);
            return _proxyGenerator.CreateInterfaceProxyWithTarget<IUserRecorder>(
                userRecorder,
                _interceptor
            );
        }

        public IFacturaRecorder CrearRegistroFactura(string rutaArchivoFactura)
        {
            var facturaRecorder = new FacturaRecorder(rutaArchivoFactura);
            return _proxyGenerator.CreateInterfaceProxyWithTarget<IFacturaRecorder>(
                facturaRecorder,
                _interceptor
            );
        }

    }
}
