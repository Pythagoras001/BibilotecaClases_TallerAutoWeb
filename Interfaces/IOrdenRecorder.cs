using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibTaller.Clases.EstrucReparcion;

namespace BibTaller.Interfaces
{
    public interface IOrdenRecorder
    {
        void RegistrarOrden(OrdenReparacion orden);
        void EliminarOrden(ulong idOrden);
        void ModificarOrden(ulong idOldOrden, OrdenReparacion NewOrden);
        List<OrdenReparacion> GetListarOrdenes();
    }
}
