using System;
using AutoMapper;
using System.Collections.Generic;
using System.Text;
using AppXamarin.ViewModels.PostViewModels;
using System.Linq;
using AppXamarin.Models.DB;

namespace AppXamarin.Services
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PostImgViewModel,string>().ForMember(ps=>ps,otp=>otp.MapFrom(path=>path.SourceImg))
                .ReverseMap();
        }
    }
}
