using BibTaller.Clases.EstrucPago;
using BibTaller.Clases.EstrucReparcion;
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
    public class OrdenReparacion
    {

        // Atributos
        public enum estadoOrden
        {
            Ingresado,
            PendientePorPago,
            ListoParaSalida,
            Completado
        }
        private estadoOrden _estado;
        private ulong _idOrden;
        private Reparacion _reparacion;

        // Constructor JSON
        [JsonConstructor]
        internal OrdenReparacion(estadoOrden estado, ulong idOrden, Reparacion reparacion)
        {
            Estado = estado;
            IdOrden = idOrden;
            Reparacion = reparacion;
        }

        // Constructor
        public OrdenReparacion(Reparacion reparacion)
        {
            Estado = estadoOrden.Ingresado;
            Reparacion = reparacion;
            IdOrden = ReglaEstrucReparacion.ObtenerConsecutivoRandom();
        }

        // Accesor
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public estadoOrden Estado { get => _estado; set => _estado = value; }
        public ulong IdOrden { get => _idOrden; set => _idOrden = value; }
        public Reparacion Reparacion { get => _reparacion; set => _reparacion = value; }

    }
}
