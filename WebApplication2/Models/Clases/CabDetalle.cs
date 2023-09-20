using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Clases
{
    public class CabDetalle
    {
        public int IdTabla { get; set; }
        public int IdCabeceraModulo { get; set; }
        public DateTime FechaContable { get; set; }
        public int SucursalOrigen { get; set; }
        public decimal TotalDebitoMn { get; set; }
        public decimal TotalDebitoMe { get; set; }
        public decimal TotalCreditoMn { get; set; }
        public decimal TotalCreditoMe { get; set; }
        public int Registros { get; set; }
        public string Digitador { get; set; }
        public string Autorizador { get; set; }
        public string EstadoProceso { get; set; }
        public int LocalidadOrigen { get; set; }
        public int ResponsableOrigen { get; set; }
        public int ModuloCobis { get; set; }

        public List<DetalleModulo> detalleCab { get; set; }
    }
}