using AlshrouqSchool.Domain.Entities.MediaAndContentModule;
using AlshrouqSchool.Shared.DTOs.GalleryGTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Services.MappingProfiles
{
    internal class GalleryProfile : Profile
    {
        public GalleryProfile()
        { 
            CreateMap<Media,GalleryQueryDTO>();
            CreateMap<Media,GalleryCommandDTO>();

        }
    }
}
