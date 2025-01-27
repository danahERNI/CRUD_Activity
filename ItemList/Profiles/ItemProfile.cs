using AutoMapper;
using ItemList.Data.DTOs;
using ItemList.Model.Entities;

namespace ItemList.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        { 
            CreateMap<AddItemDTOs, ItemModel>().ReverseMap();
        }
    }
}
