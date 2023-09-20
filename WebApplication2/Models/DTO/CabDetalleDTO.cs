using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.DTO
{
    [Table("ComprobanteContable")]

    public class CabDetalleDTO
    {
        public int IdComprobante { get; set; }
        public int IdProducto { get; set; }
        public int Empresa { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public int OficinaOrigen { get; set; }
        public int AreaOrigen { get; set; }

        public DateTime FechaGraba { get; set; }
        public string Digitador { get; set; }
        public string Descripcion { get; set; }
        public int Perfil { get; set; }
        public int Detalles { get; set; }
        public decimal TotalDebito { get; set; }
        public decimal TotalCredito { get; set; }
        public decimal TotalDebitoMe { get; set; }
        public decimal TotalCreditoMe { get; set; }
        public int Automatico { get; set; }
        public string Reversado { get; set; }
        public string Estado { get; set; }
        //public int LocalidadOrigen { get; set; }
        //public int ResponsableOrigen { get; set; }
        //public int ModuloCobis { get; set; }

        [JsonProperty("AsientoContable")]
        public List<DetalleModuloDTO> detalleCab { get; set; }
    }
}