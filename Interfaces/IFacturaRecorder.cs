using BibTaller.Clases.EstrucPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibTaller.Interfaces
{
    public interface IFacturaRecorder
    {
        void RegistrarFactura(Factura factura);
        void EliminarFactura(ulong idReparacion);
        List<Factura> GetListaFacturas();
    }
}
