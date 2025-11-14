using BibTaller.Clases.EstrucPersona;
using BibTaller.Clases.EstrucReparcion;
using BibTaller.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BibTaller.Clases.Registros
{
    public class UserRecorder : IUserRecorder
    {
        // Cremos los atributos necesarios para la clase
        public List<Persona> listaPersonas;
        public string rutaArhivo;

        public JsonSerializerOptions opciones = new JsonSerializerOptions { WriteIndented = true };

        public UserRecorder(string rutaArchivoUser)
        {
            rutaArhivo = rutaArchivoUser;
        }

        // Cremos para escribir en el archivo JSON
        public void EscribirJsonUser(List<Persona> listOrdenes) 
            => File.WriteAllText(rutaArhivo, JsonSerializer.Serialize(listOrdenes, opciones));


        public List<Persona> DeserializarJson() 
            => JsonSerializer.Deserialize<List<Persona>>(File.ReadAllText(rutaArhivo)) ?? new List<Persona>();


        // Implementamos los metodos de la base de datos
        public void RegistarUsuario(Persona user)
        {
            listaPersonas = DeserializarJson();

            listaPersonas.Add(user);

            EscribirJsonUser(listaPersonas);
        }

        public void EliminarUsuario(ulong iduser)
        {

            listaPersonas = DeserializarJson();

            listaPersonas.RemoveAll(p => p.Id == iduser);

            EscribirJsonUser(listaPersonas);
        }

        public void ModificarUsuario(ulong idOldUser, Persona newUser)
        {
            int indexOldUser;

            listaPersonas = DeserializarJson();

            indexOldUser = listaPersonas.FindIndex(p => p.Id == idOldUser);

            listaPersonas[indexOldUser] = newUser;

            EscribirJsonUser(listaPersonas);
        }

        public List<Persona> GetListarUsuarios()
        {
            listaPersonas = DeserializarJson();
            return listaPersonas;
        }


    }
}
