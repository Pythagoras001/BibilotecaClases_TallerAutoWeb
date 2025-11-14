using BibTaller.Clases.EstrucPersona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibTaller.Interfaces
{
    public interface IUserRecorder
    {
        void RegistarUsuario(Persona user);
        void EliminarUsuario(ulong iduser);
        void ModificarUsuario(ulong idOldUser, Persona newUser);
        List<Persona> GetListarUsuarios();
    }
}
