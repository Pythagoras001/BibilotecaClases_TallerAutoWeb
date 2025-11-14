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
    public class CarHibrido : Carro
    {
        // Atributos
        private byte _nroBaterias;

        // Constructor JSON
        [JsonConstructor]
        public CarHibrido(string placa, string marca, string modelo, ushort year, Cliente propietario, byte nroBaterias) 
            : base(placa, marca, modelo, year, propietario)
        {
            NroBaterias = nroBaterias;
        }

        // Accesor
        public byte NroBaterias
        {
            get => _nroBaterias;
            set
            {
                if (value < ReglaEstrucVehiculo.MIN_NRO_BATERIAS || value > ReglaEstrucVehiculo.MAX_NRO_BATERIAS)
                    throw new Exception($"El número de baterías debe estar entre {ReglaEstrucVehiculo.MIN_NRO_BATERIAS} y {ReglaEstrucVehiculo.MAX_NRO_BATERIAS}.");
                _nroBaterias = value;
            }
        }
    }
}
