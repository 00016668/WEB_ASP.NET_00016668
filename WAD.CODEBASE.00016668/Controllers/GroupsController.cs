using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD.CODEBASE._00016668.DTOs;
using WAD.CODEBASE._00016668.Models;
using WAD.CODEBASE._00016668.Repositories;

namespace WAD.CODEBASE._00016668.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IRepository<Groups> _groupRepository;
        private readonly IMapper _mapper;

        public GroupsController(IRepository<Groups> groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult> Getall()
        {
            var groups = await _groupRepository.GetAllAsync();
            var groupDtos = _mapper.Map<IEnumerable<GroupDto>>(groups);
            return Ok(groupDtos);
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var group = await _groupRepository.GetByIdAsync(id);
            if (group == null)
            {
                return NotFound();
            }

            var groupDto = _mapper.Map<GroupDto>(group);
            return Ok(groupDto);
        }

        // PUT: api/Groups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, GroupDto groupDto)
        {
            if (id != groupDto.Id)
            {
                return BadRequest();
            }

            var group = _mapper.Map<Groups>(groupDto);
            await _groupRepository.UpdateAsync(group);
            return NoContent();
        }

        // POST: api/Groups
        [HttpPost]
        public async Task<IActionResult> Create(GroupDto groupDto)
        {
            var group = _mapper.Map<Groups>(groupDto);
            await _groupRepository.AddAsync(group);
            var createdGroupDto = _mapper.Map<GroupDto>(group);
            return CreatedAtAction(nameof(GetById), new { id = createdGroupDto.Id }, createdGroupDto);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var group = await _groupRepository.GetByIdAsync(id);
            if (group == null) { return NotFound(); }

            await _groupRepository.DeleteAsync(id);
            return NoContent();
        }

    }
}
