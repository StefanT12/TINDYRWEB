using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Pictures.Queries
{
    public class PictureVM : IMapFrom<Picture>
    {
        public string FileName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Picture, PictureVM>()
                .ForMember(d => d.FileName, opt => opt.MapFrom(s => s.FileName));
        }
    }
}
