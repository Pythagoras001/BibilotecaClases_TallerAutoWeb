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
    public class CarElectrico : Carro
    {
        // Creamos los atributos
        private ushort _autonomiaKm;

        // Constructor JSON
        [JsonConstructor]
        public CarElectrico(string placa, string marca, string modelo, ushort year, Cliente propietario, ushort autonomiaKm) 
            : base(placa, marca, modelo, year, propietario)
        {
            AutonomiaKm = autonomiaKm;
        }

        // Accesor
        public ushort AutonomiaKm
        {
            get => _autonomiaKm;
            set
            {
                if (value < ReglaEstrucVehiculo.MIN_AUTONOMIA_KM)
                    throw new Exception($"La autonomía debe ser como mínimo de {ReglaEstrucVehiculo.MIN_AUTONOMIA_KM} km.");
                _autonomiaKm = value;
            }
        }
    }
}
