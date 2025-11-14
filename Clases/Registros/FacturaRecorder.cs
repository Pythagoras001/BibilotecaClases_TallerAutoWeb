using BibTaller.Clases.EstrucReparcion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BibTaller.Clases.EstrucPago;
using BibTaller.Interfaces;

namespace BibTaller.Clases.Registros
{
    public class FacturaRecorder : IFacturaRecorder
    {
        // Cremos los atributos necesarios para la clase
        public List<Factura> listaFacturas;
        public string rutaArhivo;
        public JsonSerializerOptions opciones = new JsonSerializerOptions { WriteIndented = true };

        public FacturaRecorder(string rutaArchivoFactura)
        {
            rutaArhivo = rutaArchivoFactura;
        }

        // Cremos para escribir en el archivo JSON
        public void EscribirJsonOrden(List<Factura> listOrdenes)
            => File.WriteAllText(rutaArhivo, JsonSerializer.Serialize(listOrdenes, opciones));


        public List<Factura> DeserializarJson()
            => JsonSerializer.Deserialize<List<Factura>>(File.ReadAllText(rutaArhivo)) ?? new List<Factura>();


        // Implementamos los metodos de la base de datos
        public void RegistrarFactura(Factura factura)
        {
            listaFacturas = DeserializarJson();

            listaFacturas.Add(factura);

            EscribirJsonOrden(listaFacturas);
        }

        public void EliminarFactura(ulong idReparacion)
        {
            listaFacturas = DeserializarJson();

            listaFacturas.RemoveAll(p => p.OrdenPagada.IdOrden == idReparacion);

            EscribirJsonOrden(listaFacturas);
        }

        public List<Factura> GetListaFacturas()
        {
            listaFacturas = DeserializarJson();
            return listaFacturas;
        }

    }
}
