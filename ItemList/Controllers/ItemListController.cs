using AutoMapper;
using ItemList.Data;
using ItemList.Data.DTOs;
using ItemList.Model.Entities;
using ItemList.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItemList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemListController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ItemListController(IItemRepository itemRepository, IMapper mapper) 
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }
        //[HttpGet]
        //public IActionResult GetAllItemLists()
        //{
        //    var allItems = dbContext.ItemLists.ToList();
        //    return Ok(allItems);
        //}
        [HttpPost]
        public async Task<ActionResult<AddItemDTOs>> AddItem(AddItemDTOs item)
        {
            var newItem = _mapper.Map<ItemModel>(item);
            var newDateAdded = await _itemRepository.AddItem(newItem);

            return;
        }
    }
}
