using AutoMapper;
using ItemList.Data;
using ItemList.Data.DTOs;
using ItemList.Model.Entities;
using ItemList.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItemList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemListController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;
        //public ItemListController(AppDbContext dbContext)
        //{
        //    this.dbContext = dbContext;
        //}
        public ItemListController(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<AddItemDTOs>> AddItem(AddItemDTOs item)
        {

            var newItem = _mapper.Map<ItemModel>(item);
            var newDateAdded = await _itemRepository.AddItem(newItem);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AddItemDTOs>> GetItemId(int id)
        {

            var item = await _itemRepository.GetItemId(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        [HttpGet]
        public async Task<IEnumerable<ItemModel>> GetAllItems()
        {
            var list = await _itemRepository.GetAllItems();
            return list;
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult<AddItemDTOs?>> UpdateItem(int id, AddItemDTOs updateItem)
        {
            var updated = _mapper.Map<ItemModel>(updateItem);
            var changeItem = await _itemRepository.UpdateItem(id, updated);

            if (changeItem == null) {
                throw new KeyNotFoundException("No update found.");
            }
            return Ok(changeItem);
        }
    }
}
