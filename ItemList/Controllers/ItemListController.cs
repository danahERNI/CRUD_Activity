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
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;

        public ItemListController(IItemRepository itemRepository, IMapper mapper, IOwnerRepository ownerRepository)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
            _ownerRepository = ownerRepository;
        }
        [HttpPost]
        public async Task<ActionResult<AddItemDTOs>> AddItem(AddItemDTOs item)
        {

            var mapItem = _mapper.Map<ItemModel>(item);
            var newItem = await _itemRepository.AddItem(mapItem);

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
            updated.Id = id;
            var changeItem = await _itemRepository.UpdateItem(id, updated);

            if (changeItem == null) {
                throw new KeyNotFoundException("No update found.");
            }
            return Ok(changeItem);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<AddItemDTOs?>> DeleteItem(int id) 
        {
            var removeItem = await _itemRepository.DeleteItem(id);
            if (removeItem == null)
            {
                return NotFound();
            }
            return Ok(removeItem);
        }
    }
}
