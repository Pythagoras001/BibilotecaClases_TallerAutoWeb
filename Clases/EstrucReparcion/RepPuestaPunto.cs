using BibTaller.Clases.EstrucPersona;
using BibTaller.Clases.EstrucVehiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BibTaller.Clases.EstrucReparcion
{
    public class RepPuestaPunto : Reparacion
    {
        // Constructor JSON
        [JsonConstructor]
        internal RepPuestaPunto(DateTime fecha, ulong costoManoObra, Mecanico[] mecanicosEncargados, Carro carro, Repuesto[] repuestosUtilizados)
            : base(fecha, costoManoObra, mecanicosEncargados, carro, repuestosUtilizados) { }

        // Constructor
        public RepPuestaPunto(ulong costoManoObra, Mecanico[] mecanicosEncargados, Carro carro, Repuesto[]? repuestosUtilizados) : base(costoManoObra, mecanicosEncargados, carro, repuestosUtilizados)
        {
        
        }


    }
}
