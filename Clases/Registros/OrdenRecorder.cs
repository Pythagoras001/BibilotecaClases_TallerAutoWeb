using BibTaller.Clases.EstrucPersona;
using BibTaller.Clases.EstrucReparcion;
using BibTaller.Clases.Registros;
using BibTaller.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace BibTaller.Clases.Registros
{
    public class OrdenRecorder : IOrdenRecorder
    {
        // Cremos los atributos necesarios para la clase
        public List<OrdenReparacion> listaOrdenes;
        public string rutaArhivo;
        public JsonSerializerOptions opciones = new JsonSerializerOptions { WriteIndented = true };

        public OrdenRecorder(string rutaArchivoOrdenes)
        {
            rutaArhivo = rutaArchivoOrdenes;
        }


        // Cremos para escribir en el archivo JSON
        public void EscribirJsonOrden(List<OrdenReparacion> listOrdenes)
            => File.WriteAllText(rutaArhivo, JsonSerializer.Serialize(listOrdenes, opciones));


        public List<OrdenReparacion> DeserializarJson()
            => JsonSerializer.Deserialize<List<OrdenReparacion>>(File.ReadAllText(rutaArhivo)) ?? new List<OrdenReparacion>();


        // Implementamos los metodos de la base de datos
        public void RegistrarOrden(OrdenReparacion orden)
        {
            listaOrdenes = DeserializarJson();

            listaOrdenes.Add(orden);

            EscribirJsonOrden(listaOrdenes);
        }

        public void EliminarOrden(ulong idOrden)
        {

            listaOrdenes = DeserializarJson();

            listaOrdenes.RemoveAll(p => p.IdOrden == idOrden);

            EscribirJsonOrden(listaOrdenes);
        }

        public void ModificarOrden(ulong idOldOrden, OrdenReparacion NewOrden)
        {
            int indexOldOrden;

            listaOrdenes = DeserializarJson();

            indexOldOrden = listaOrdenes.FindIndex(p => p.IdOrden == idOldOrden);

            listaOrdenes[indexOldOrden] = NewOrden;

            EscribirJsonOrden(listaOrdenes);
        }

        public List<OrdenReparacion> GetListarOrdenes()
        {
            listaOrdenes = DeserializarJson();
            return listaOrdenes;
        }

    }
}

