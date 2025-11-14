using BibTaller.Clases.EstrucVehiculos;
using BibTaller.Clases.Reglas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BibTaller.Clases.EstrucPersona
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(Cliente), "cliente")]
    [JsonDerivedType(typeof(Mecanico), "mecanico")]
    [JsonDerivedType(typeof(Admin), "admin")]

    public abstract class Persona
    {
        // Atributos
        private ulong _id;
        private string? _nombre;
        private ulong _telefono;

        // Constructor JSON
        [JsonConstructor]
        public Persona(ulong id, string nombre, ulong telefono)
        {
            Id = id;
            Nombre = nombre;
            Telefono = telefono;
        }

        // Accessor
        public ulong Id
        {
            get => _id;
            set
            {

                if (value < ReglaEstrucPersona.MIN_ID)
                {
                    throw new Exception("La identificación de la persona debe ser mínimo 1000000");
                }
                else
                {
                    _id = value;
                }
            }
        }
        public string? Nombre
        {
            get => _nombre;
            set
            {

                if ( string.IsNullOrWhiteSpace(value) || value.Trim().Length < ReglaEstrucPersona.MIN_NOMBRE_LENGTH)
                {

                    throw new Exception("El nombre de la persona debe tener 3 caracteres como mínimo");

                }
                else
                {
                    _nombre = value;
                }


            }
        }
        public ulong Telefono { get => _telefono;
            set
            {

                if (value.ToString().Length < ReglaEstrucPersona.MIN_TELEFONO_LENGTH)
                {

                    throw new Exception("El telefono de la persona debe tener 7 caracteres como mínimo");

                }
                else
                {
                    _telefono = value;
                }


            }
        }
    }
}
