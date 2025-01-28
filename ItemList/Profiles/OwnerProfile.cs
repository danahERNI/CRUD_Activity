using AutoMapper;
using ItemList.Data.DTOs;
using ItemList.Model.Entities;

namespace ItemList.Profiles
{
    public class OwnerProfile : Profile
    {
        public OwnerProfile()
        {
            CreateMap<OwnerDTO, Owner>().ReverseMap();
        }
    }
}
