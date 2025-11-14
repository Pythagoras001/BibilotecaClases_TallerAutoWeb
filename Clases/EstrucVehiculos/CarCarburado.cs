using BibTaller.Clases.EstrucPersona;
using BibTaller.Clases.Reglas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BibTaller.Clases.EstrucVehiculos;

namespace BibTaller.Clases.EstrucVehiculos
{
    public class CarCarburado : Carro
    {
        // Creamos los atributos
        private byte _nroCilindros;

        // Constructor JSON
        [JsonConstructor]
        public CarCarburado(string placa, string marca, string modelo, ushort year, Cliente propietario, byte nroCilindros)
            : base(placa, marca, modelo, year, propietario)
        {
            NroCilindros = nroCilindros;
        }

        // Accesor
        public byte NroCilindros
        {
            get => _nroCilindros;
            set
            {
                if (value < ReglaEstrucVehiculo.MIN_NRO_CILINDROS)
                    throw new Exception($"El número de cilindros debe ser al menos {ReglaEstrucVehiculo.MIN_NRO_CILINDROS}.");
                _nroCilindros = value;
            }
        }
    }
}
