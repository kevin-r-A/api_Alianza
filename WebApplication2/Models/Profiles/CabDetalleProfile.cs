using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models.Clases;
using WebApplication2.Models.DTO;

namespace WebApplication2.Models.Profiles
{
    public class CabDetalleProfile:Profile
    {
        public CabDetalleProfile() {
            CreateMap<CabDetalle, CabDetalleDTO>();
            CreateMap<CabDetalleDTO, CabDetalle>();
        }
    }
}