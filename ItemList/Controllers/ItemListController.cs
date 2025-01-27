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
        private readonly AppDbContext dbContext;

        //public ItemListController(AppDbContext dbContext)
        //{
        //    this.dbContext = dbContext;
        //}
        public ItemListController(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }
        //[HttpGet]
        //public IActionResult GetAllItemLists()
        //{
        //    var allItems = dbContext.ItemModels.ToList();
        //    return Ok(allItems);
        //}
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
        public async Task
    }
}
