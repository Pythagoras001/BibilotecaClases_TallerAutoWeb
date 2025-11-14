using BibTaller.Clases.EstrucPersona;
using BibTaller.Clases.EstrucVehiculos;
using BibTaller.Clases.Reglas;
using BibTaller.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BibTaller.Clases.EstrucReparcion
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(RepCambioAceite), "cambio_aceite")]
    [JsonDerivedType(typeof(RepCambioBujia), "cambio_bujia")]
    [JsonDerivedType(typeof(RepPuestaPunto), "rep_puestaPunto")]

    public abstract class Reparacion
    {

        // Atributos
        private DateTime _fecha;
        private Repuesto[]? _repuestosUtilizados;
        private Mecanico[]? _mecanicosEncargados;
        private Carro _carro;
        private ulong _costoManoObra;

        // Constructor JSON
        [JsonConstructor]
        internal Reparacion(DateTime fecha, ulong costoManoObra, Mecanico[] mecanicosEncargados, Carro carro, Repuesto[] repuestosUtilizados)
        {
            Fecha = fecha;
            CostoManoObra = costoManoObra;
            MecanicosEncargados = mecanicosEncargados;
            Carro = carro;
            RepuestosUtilizados = repuestosUtilizados;
        }

        // Constructor
        public Reparacion(ulong costoManoObra, Mecanico[] mecanicosEncargados, Carro carro, Repuesto[] repuestosUtilizados)
        {
            Fecha = DateTime.Now;
            CostoManoObra = costoManoObra;
            MecanicosEncargados = mecanicosEncargados;
            Carro = carro;
            RepuestosUtilizados = repuestosUtilizados;
        }

        // Accesor
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public Repuesto[]? RepuestosUtilizados { get => _repuestosUtilizados; set => _repuestosUtilizados = value; }
        public Mecanico[]? MecanicosEncargados { get => _mecanicosEncargados; set => _mecanicosEncargados = value; }
        public Carro Carro { get => _carro; set => _carro = value; }
        public ulong CostoManoObra
        {
            get => _costoManoObra;
            set
            {
                if (value < ReglaEstrucReparacion.MIN_VALOR_REPARCION)
                    throw new Exception("El costo mínimo de mano de obra es de 5000");
                _costoManoObra = value;
            }
        }

    }
}
