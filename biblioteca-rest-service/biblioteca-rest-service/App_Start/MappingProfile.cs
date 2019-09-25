using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using biblioteca_rest_service.Dtos;
using biblioteca_rest_service.Models;

namespace biblioteca_rest_service.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Catalogo, t_catalogo>().ReverseMap();
            CreateMap<Lector, t_lector>().ReverseMap();
            CreateMap<Prestamo, t_prestamo>().ReverseMap();
        }
    }
}