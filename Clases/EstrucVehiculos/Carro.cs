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
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(CarCarburado), "gasolina")]
    [JsonDerivedType(typeof(CarElectrico), "electrico")]
    [JsonDerivedType(typeof(CarHibrido), "hibrido")]

    public abstract class Carro
    {
        // Atributos
        private string? _placa;
        private string? _marca;
        private string? _modelo;
        private ushort _year;
        private Cliente? _propietario;

        // Constructor JSON
        [JsonConstructor]
        public Carro(string placa, string marca, string modelo, ushort year, Cliente propietario)
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Year = year;
            Propietario = propietario;
        }

        // Accesores
        public string? Placa
        {
            get => _placa;
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length != ReglaEstrucVehiculo.LONG_PLACA)
                    throw new Exception($"La placa debe tener exactamente {ReglaEstrucVehiculo.LONG_PLACA} caracteres.");
                _placa = value;
            }
        }

        public string? Marca
        {
            get => _marca;
            set
            {
                if (string.IsNullOrEmpty(value) ||
                    value.Length < ReglaEstrucVehiculo.MIN_LONG_MARCA ||
                    value.Length > ReglaEstrucVehiculo.MAX_LONG_MARCA)
                    throw new Exception($"La marca debe tener entre {ReglaEstrucVehiculo.MIN_LONG_MARCA} y {ReglaEstrucVehiculo.MAX_LONG_MARCA} caracteres.");
                _marca = value;
            }
        }

        public string? Modelo
        {
            get => _modelo;
            set
            {
                if (string.IsNullOrEmpty(value) ||
                    value.Length < ReglaEstrucVehiculo.MIN_LONG_MODELO ||
                    value.Length > ReglaEstrucVehiculo.MAX_LONG_MODELO)
                    throw new Exception($"El modelo debe tener entre {ReglaEstrucVehiculo.MIN_LONG_MODELO} y {ReglaEstrucVehiculo.MAX_LONG_MODELO} caracteres.");
                _modelo = value;
            }
        }

        public ushort Year
        {
            get => _year;
            set
            {
                if (value < ReglaEstrucVehiculo.MIN_YEAR || value > ReglaEstrucVehiculo.MAX_YEAR)
                    throw new Exception($"El año debe estar entre {ReglaEstrucVehiculo.MIN_YEAR} y {ReglaEstrucVehiculo.MAX_YEAR}.");
                _year = value;
            }
        }

        public Cliente? Propietario
        {
            get => _propietario;
            set => _propietario = value;
        }
    }
}
