using AutoMapper;
using ConsultaFacilWeb.Models;
using Core;


namespace ConsultaFacilWeb.Mappers
{
    public class MedicoProfile : Profile
    {
        public MedicoProfile() 
        { 
            CreateMap<MedicoModel, TbMedico>().ReverseMap();
        }
    }
}
