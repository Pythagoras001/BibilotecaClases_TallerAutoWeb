using BibTaller.Clases.ClasesEventArgs;
using BibTaller.Clases.EstrucPersona;
using BibTaller.Clases.EstrucReparcion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibTaller.Eventos
{
    public class Publi_RegistroDeUsuario
    {

        // Eventos
        public event EventHandler<RegistroUsuarioEventArgs>? RegistroUsuarioEvent;
        public event EventHandler<RegistroUsuarioEventArgs>? BorrarUsuario;

        // Metodo - Evento
        public string RegistrarUsuario(Persona persona) {
            try
            {
                switch (persona)
                {
                    case Mecanico mecanico:
                        RegistroUsuarioEvent?.Invoke(this, new RegistroUsuarioEventArgs(mecanico));
                        return $"El mecánico con cédula {mecanico.Id} ha sido ingresado correctamente.";

                    case Cliente cliente:
                        RegistroUsuarioEvent?.Invoke(this, new RegistroUsuarioEventArgs(cliente));
                        return $"El cliente con cédula {cliente.Id} ha sido ingresado correctamente.";

                    case Admin admin:
                        RegistroUsuarioEvent?.Invoke(this, new RegistroUsuarioEventArgs(admin));
                        return $"El admin con cédula {admin.Id} ha sido ingresado correctamente.";

                    default:
                        return "Error en la clase Publi_Registro, método RegistrarUsuario: El parametro persona no coincide con ningun tipo válido";
                }
            }catch (Exception ex){
                return ex.Message;
            }
}
    
        public string EliminarUsuario(Persona persona) {
            try
            {
                switch (persona)
                {
                    case Mecanico mecanico:
                        BorrarUsuario?.Invoke(this, new RegistroUsuarioEventArgs(mecanico));
                        return $"El mecánico con cédula {mecanico.Id} ha sido eliminado correctamente.";

                    case Cliente cliente:
                        BorrarUsuario?.Invoke(this, new RegistroUsuarioEventArgs(cliente));
                        return $"El cliente con cédula {cliente.Id} ha sido eliminado correctamente.";

                    case Admin admin:
                        BorrarUsuario?.Invoke(this, new RegistroUsuarioEventArgs(admin));
                        return $"El admin con cédula {admin.Id} ha sido eliminado correctamente.";

                    default:
                        return "Error en la clase Publi_Registro, método RegistrarUsuario: El parametro persona no coincide con ningun tipo válido";
                }
            }catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
