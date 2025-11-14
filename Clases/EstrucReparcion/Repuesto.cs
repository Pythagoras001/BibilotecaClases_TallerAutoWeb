using BibTaller.Clases.Reglas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BibTaller.Clases.EstrucReparcion
{
    public class Repuesto
    {
        // Atributos
        private string? _nombre;
        private string? _proveedor;
        private DateTime _fechaAdquisicion;
        private ulong _costo;

        // Constructor JSON
        [JsonConstructor]
        internal Repuesto(string nombre, string proveedor, DateTime fechaAdquisicion, ulong costo)
        {
            Nombre = nombre;
            Proveedor = proveedor;
            FechaAdquisicion = fechaAdquisicion;
            Costo = costo;
        }

        // Constructor
        public Repuesto(string nombre, string proveedor, ulong costo)
        {
            Nombre = nombre;
            Proveedor = proveedor;
            FechaAdquisicion = DateTime.Now;
            Costo = costo;
        }

        // Accessor
        public string? Nombre
        {
            get => _nombre;
            set
            {
                if (value == null || value.Length < ReglaEstrucReparacion.MIN_LONG_NAME || value.Length > ReglaEstrucReparacion.MAX_LONG_NAME)
                    throw new Exception("El nombre del repuesto debe tener entre 10 y 60 caracteres");
                _nombre = value;
            }
        }

        public string? Proveedor
        {
            get => _proveedor;
            set
            {
                if (value == null || value.Length < ReglaEstrucReparacion.MIN_LONG_PROVEEDOR || value.Length > ReglaEstrucReparacion.MAX_LONG_PROVEEDOR)
                    throw new Exception("El nombre del proveedor debe tener entre 5 y 30 caracteres");
                _proveedor = value;
            }
        }
        public DateTime FechaAdquisicion { get => _fechaAdquisicion; set => _fechaAdquisicion = value; }
        public ulong Costo
        {
            get => _costo; 
            set
            {
                if (value >= ReglaEstrucReparacion.MIN_COSTO)
                {
                    _costo = value;
                }
                else
                {
                    throw new Exception("El costo minimo de un repuesto es de 1000");
                }
            }
        }

    }
}
