using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BibTaller.Clases.EstrucPersona
{
    public class Cliente : Persona
    {
        // Atributos
        private ulong _saldoADeber;
        private bool _tieneSaldo;

        // Constructor JSON
        [JsonConstructor]
        internal Cliente(ulong id, string nombre, ulong telefono, ulong saldoADeber,  bool tieneSaldo) 
            : base(id, nombre, telefono)
        {
            SaldoADeber = saldoADeber;
            TieneSaldo = tieneSaldo;
        }

        // Constructor
        public Cliente(ulong id, string nombre, ulong telefono, bool tieneSaldo) 
            : base(id, nombre, telefono)
        {
            SaldoADeber = 0;
            TieneSaldo = tieneSaldo;
        }

        // Accesor
        public ulong SaldoADeber { get => _saldoADeber; set => _saldoADeber = value; }
        public bool TieneSaldo { get => _tieneSaldo; set => _tieneSaldo = value; }
    }
}
