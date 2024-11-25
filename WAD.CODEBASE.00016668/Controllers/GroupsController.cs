using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAD.CODEBASE._00016668.Data;
using WAD.CODEBASE._00016668.DTOs;
using WAD.CODEBASE._00016668.Models;

namespace WAD.CODEBASE._00016668.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly ContactDbContext _context;
        private readonly IMapper _mapper;

        public GroupsController(ContactDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupDto>>> GetGroupsDbSet()
        {
            if (_context.GroupsDbSet == null)
            {
                return NotFound();
            }
            var groups = await _context.GroupsDbSet.ToListAsync();
            var groupDtos = _mapper.Map<IEnumerable<GroupDto>>(groups);  // Map Groups to GroupDto
            return Ok(groupDtos);
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupDto>> GetGroups(int id)
        {
          if (_context.GroupsDbSet == null)
          {
              return NotFound();
          }
            var group = await _context.GroupsDbSet.FindAsync(id);

            if (group == null)
            {
                return NotFound();
            }

            var groupDto = _mapper.Map<GroupDto>(group);  // Map Group to GroupDto
            return Ok(groupDto);
        }

        // PUT: api/Groups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroups(int id, [FromBody] GroupDto groupDto)
        {
            if (id != groupDto.GroupId)
            {
                return BadRequest();
            }

            var group = _mapper.Map<Groups>(groupDto);  // Map GroupDto to Group
            _context.Entry(group).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Groups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GroupDto>> PostGroups([FromBody] GroupDto groupDto)
        {
            if (_context.GroupsDbSet == null)
            {
                return Problem("Entity set 'ContactDbContext.GroupsDbSet'  is null.");
            }

            var group = _mapper.Map<Groups>(groupDto);  // Map GroupDto to Group entity
            _context.GroupsDbSet.Add(group);
            await _context.SaveChangesAsync();

            var createdGroupDto = _mapper.Map<GroupDto>(group);  // Map newly created Group to GroupDto
            return CreatedAtAction(nameof(GetGroups), new { id = group.GroupId }, createdGroupDto);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroups(int id)
        {
            if (_context.GroupsDbSet == null)
            {
                return NotFound();
            }
            var groups = await _context.GroupsDbSet.FindAsync(id);
            if (groups == null)
            {
                return NotFound();
            }

            _context.GroupsDbSet.Remove(groups);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroupsExists(int id)
        {
            return (_context.GroupsDbSet?.Any(e => e.GroupId == id)).GetValueOrDefault();
        }
    }
}
