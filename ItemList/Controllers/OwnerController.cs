using AutoMapper;
using ItemList.Data.DTOs;
using ItemList.Model.Entities;
using ItemList.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItemList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerRepository ownerRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<OwnerDTO>> AddOwner(OwnerDTO owner)
        {
            var mapNew = _mapper.Map<Owner>(owner);
            var newOwner = await _ownerRepository.AddOwner(mapNew);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<OwnerDTO>> DeleteOwner(int id) 
        { 
            var removeOwner = await _ownerRepository.DeleteOwner(id);
            if (removeOwner == null)
            {
                return NotFound();
            }
            return Ok(removeOwner);
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult<OwnerDTO>> UpdateOwner(int id, OwnerDTO updateOwnerDetails)
        {
            var owner = _mapper.Map<Owner>(updateOwnerDetails);
            var changeDetails = await _ownerRepository.UpdateOwner(id, owner);
            if (changeDetails == null)
            {
                throw new Exception("No update found");
            }
            return Ok(changeDetails);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OwnerDTO>> GetOwnerId(int id)
        {
            var owner = await _ownerRepository.GetOwnerId(id);
            if (owner == null) 
            {
                return NotFound();
            }
            return Ok(owner);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OwnerDTO?>>> GetAllUsers()
        {
            var list = await _ownerRepository.GetAllUsers();
            if (list == null)
            {
                throw new Exception("List empty.");
            }
            var ownerList = _mapper.Map<IEnumerable<OwnerDTO>>(list);
            return Ok(ownerList);
        }
    }
}
