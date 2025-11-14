using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace BibTaller.Clases.EstrucPersona
{
    public class Admin : Persona
    {

        private string _claveAcceso;


        [JsonConstructor]
        public Admin(ulong id, string nombre, ulong telefono, string claveAcceso) : base(id, nombre, telefono)
        {
            ClaveAcceso = claveAcceso;
        }


        public string ClaveAcceso { get => _claveAcceso; set => _claveAcceso = value; }
    }
}
