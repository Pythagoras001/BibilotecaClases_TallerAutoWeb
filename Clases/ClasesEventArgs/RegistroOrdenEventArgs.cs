using BibTaller.Clases.EstrucReparcion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibTaller.Clases.ClasesEventArgs
{
    // --- Clases de argumentos personalizados ---
        
    public class RegistroOrdenEventArgs : EventArgs
    {
            public OrdenReparacion Orden { get; }

            public RegistroOrdenEventArgs(OrdenReparacion orden)
            {
                Orden = orden;
            }

    }
}
