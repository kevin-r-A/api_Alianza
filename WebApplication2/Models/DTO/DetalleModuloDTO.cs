using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.DTO
{
    [Table("ComprobanteContable")]

    public class DetalleModuloDTO
    {
        
        public int IdAsiento { get; set; }
        public int IdComprobante { get; set; }
        public int IdProducto { get; set; }
        public DateTime FechaTransaccion { get; set; }

        public int Empresa { get; set; }

        public string Cuenta { get; set; }
       // [JsonProperty("OficinaDestino")]
        public int OficinaDestino { get; set; }
        //[JsonProperty("AreaDestino")]
        //public int LocalidadDestino { get; set; }
        public int AreaDestino { get; set; }
        public decimal Credito { get; set; }
        public decimal Debito { get; set; }
        public string Concepto { get; set; }
        public decimal CreditoMe { get; set; }
        public decimal DebitoMe { get; set; }
        public decimal Cotizacion { get; set; }
        public string TipoDocumento { get; set; }
        public string TipoTransaccion { get; set; }
        public int Moneda { get; set; }
        //public int Opcion { get; set; }
        //public DateTime FechaEstimada { get; set; }
        //[JsonProperty("Detalle")]

        //public int Detalle1 { get; set; }

        //public int CodigoTransaccion { get; set; }
        //public string SignoTrx { get; set; }
        //public int id { get; set; }
        //public byte IdMoneda { get; set; }
        //public string Operacion { get; set; }

       // public string Referencia { get; set; }
        //public int ResponsableDestino { get; set; }
    }
}