using BibTaller.Clases.Reglas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BibTaller.Clases.EstrucPersona
{
    public class Mecanico : Persona
    {
        // Atributos
        private string? _especialidad;

        // Constructor JSON
        [JsonConstructor]
        public Mecanico(ulong id, string nombre, ulong telefono, string especialidad) : base(id, nombre, telefono)
        {
            Especialidad = especialidad;
        }

        // Accesor
        public string? Especialidad
        {
            get => _especialidad; 
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < ReglaEstrucPersona.MIN_ESPECIALIDAD_LENGTH)
                {

                    throw new Exception("La especialidad del mecánico debe tener 3 caracteres como mínimo");

                }
                else
                {
                    _especialidad = value;
                }

            }

        }

    }
}
