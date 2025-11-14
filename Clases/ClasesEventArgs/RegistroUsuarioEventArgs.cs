using BibTaller.Clases.EstrucPersona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibTaller.Clases.ClasesEventArgs
{
    public class RegistroUsuarioEventArgs : EventArgs
    {

        public Persona Persona { get; }

        public RegistroUsuarioEventArgs( Persona persona ) { 
            Persona = persona;
        }

    }
}
