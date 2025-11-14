using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibTaller.Clases.Reglas
{
    public class ReglaEstrucReparacion
    {
        private static Random random = new Random();

        public static readonly byte MIN_LONG_NAME = 10;
        public static readonly byte MAX_LONG_NAME = 60;

        public static readonly byte MIN_LONG_PROVEEDOR = 5;
        public static readonly byte MAX_LONG_PROVEEDOR = 30;

        public static readonly uint MIN_COSTO = 1000;

        public static readonly uint MIN_VALOR_REPARCION = 5000;

        public static readonly byte MIN_CANT_MECANICOS = 1;

        public static ulong ObtenerConsecutivoRandom()
        {
            return (ulong)random.Next(0, 5001); // 0 a 5000 inclusive
        }
    }
}
