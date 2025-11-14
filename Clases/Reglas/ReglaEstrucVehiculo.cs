using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibTaller.Clases.Reglas
{
    public class ReglaEstrucVehiculo
    {
        public static readonly byte LONG_PLACA = 6;

        public static readonly byte MIN_LONG_MARCA = 3;
        public static readonly byte MAX_LONG_MARCA = 15;

        public static readonly byte MIN_LONG_MODELO = 3;
        public static readonly byte MAX_LONG_MODELO = 15;

        public static readonly ushort MIN_YEAR = 1950;
        public static readonly ushort MAX_YEAR = (ushort)((DateTime.Now.Year + 2));

        public static readonly byte MIN_NRO_BATERIAS = 1;
        public static readonly byte MAX_NRO_BATERIAS = 8;

        public static readonly ushort MIN_AUTONOMIA_KM = 50;

        public static readonly byte MIN_NRO_CILINDROS = 2;
    }
}
