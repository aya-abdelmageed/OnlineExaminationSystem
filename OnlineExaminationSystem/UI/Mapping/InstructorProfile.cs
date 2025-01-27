using AutoMapper;
using BusinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Mapping
{
    public  class InstructorProfile : Profile {
        public InstructorProfile()
        {
            CreateMap<DataRow, InstructorDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Convert.ToInt32(src["INS_ID"])))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src["FName"].ToString()));
        }
    }
}
