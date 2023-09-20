using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;
using WebApplication2.Models.Clases;
using WebApplication2.Models.DTO;

namespace WebApplication2.Controllers
{
    public class TramasController : ApiController
    {
        // GET: api/Tramas
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Tramas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Tramas
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Tramas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Tramas/5
        public void Delete(int id)
        {
        }

        [HttpGet]
        [Route("api/Tramas")]
        public IHttpActionResult Tramas(DateTime fecha)
        {

            using (HVALLESEntities ent = new HVALLESEntities())
            {
                var model = ent.Cabeceras.Where(x => x.FechaContable.Year == fecha.Year &&
                                     x.FechaContable.Month == fecha.Month &&
                                     x.FechaContable.Day == fecha.Day)
                       .ToList();

                List<CabDetalleDTO> cabDetalles = new List<CabDetalleDTO>();
                CabDetalleDTO cabs = new CabDetalleDTO();
                int id = 1;
                foreach (var item in model)
                {
                    cabs = new CabDetalleDTO();

                    //cabs.IdTabla = item.id;
                    cabs.IdComprobante = id++;
                    cabs.IdProducto = 8020;
                    cabs.Empresa = 1;
                    cabs.FechaTransaccion = item.FechaContable;
                    cabs.OficinaOrigen = item.SucursalOrigen;
                    cabs.AreaOrigen = 9;
                    cabs.FechaGraba = DateTime.Now;
                    cabs.Digitador = "console";
                    cabs.Descripcion = item.EstadoProceso;
                    if (cabs.Descripcion == "I")
                    {
                        cabs.Descripcion = "Ingreso";
                    }
                    else if (cabs.Descripcion == "T")
                    {
                        cabs.Descripcion = "Transaccion";
                    }
                    else if (cabs.Descripcion == "D")
                    {
                        cabs.Descripcion = "Depreciacion";
                    }  else
                    {
                        cabs.Descripcion = "Baja";
                    }
                    cabs.Perfil = 0;
                    cabs.Detalles = item.Registros;
                    cabs.TotalDebito = item.TotalDebitoMn;
                    cabs.TotalCredito = item.TotalCreditoMn;
                    cabs.TotalDebitoMe = item.TotalDebitoMe;
                    cabs.TotalCreditoMe = item.TotalCreditoMe;
                    cabs.Automatico = 0;
                    cabs.Reversado = "N";
                    cabs.Estado = "I";                 
                    //cabs.Autorizador = item.Autorizador;
                    //cabs.EstadoProceso = item.EstadoProceso;    
                    //cabs.ResponsableOrigen = item.ResponsableOrigen;
                    //cabs.ModuloCobis = item.ModuloCobis??0;
                    cabs.detalleCab = ent.DetalleModuloes.Where(x => x.IdCabeceraModulo == item.IdCabeceraModulo).Select(x => new DetalleModuloDTO
                    {
                        IdAsiento=x.Registro,
                        IdComprobante = x.IdCabeceraModulo,
                        IdProducto = 8020,
                        FechaTransaccion =cabs.FechaTransaccion,
                        Empresa =1,
                        Cuenta=x.Cuenta,
                        OficinaDestino= x.SucursalDestino,
                        AreaDestino=9,
                        Credito=x.CreditoMn,
                        Debito=x.DebitoMn,
                        Concepto=x.Detalle,
                        CreditoMe=x.CreditoMe,
                        DebitoMe=x.DebitoMe,
                        Cotizacion=0,
                        TipoDocumento=x.TipoNegociacion,
                        TipoTransaccion="B",
                        Moneda=1
                    }).ToList();

                    cabDetalles.Add(cabs);
                }

                return Json(cabDetalles);
            }

        }
    }
}
