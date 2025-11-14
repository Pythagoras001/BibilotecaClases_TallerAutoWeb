using BibTaller.Eventos;
using BibTaller.Fabricas;
using BibTaller.Interfaces;
using BibTaller.Clases.ClasesEventArgs;
using BibTaller.Clases.EstrucPersona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibTaller.Clases
{
    public class AdministradorUsuario
    {
        // Atributos
        private IUserRecorder _userRecorder;
        private Publi_RegistroDeUsuario _publi_RegistroDeUsuario;

        // Constructor
        public AdministradorUsuario(IUserRecorder userRecorder, Publi_RegistroDeUsuario publi_RegistroDeUsuario, string rutaArchivoUsuario)
        {
            _userRecorder = userRecorder;
            _publi_RegistroDeUsuario = publi_RegistroDeUsuario;
            Suscribir();

        }

        // Metodos
        public List<Persona> ObtenerUsuarios()
        {
            return _userRecorder.GetListarUsuarios();
        }

        public void ModificarUser(ulong id, Persona newUsuario)
        {
            _userRecorder.ModificarUsuario(id, newUsuario);
        }

        public void RegistrarUsuarioNuevo(Object sender, RegistroUsuarioEventArgs e)
        {
            _userRecorder.RegistarUsuario(e.Persona);
        }

        public void BorrarUsuario(Object sender, RegistroUsuarioEventArgs e)
        {
            _userRecorder.EliminarUsuario(e.Persona.Id);
        }

        public void Suscribir() {
            _publi_RegistroDeUsuario.RegistroUsuarioEvent += RegistrarUsuarioNuevo;
            _publi_RegistroDeUsuario.BorrarUsuario += BorrarUsuario;
        }
    }
}
