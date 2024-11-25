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
using WAD.CODEBASE._00016668.Repositories;

namespace WAD.CODEBASE._00016668.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {

        private readonly IRepository<Contacts> _contactsRepository;
        private readonly IMapper _mapper;


        public ContactsController(IRepository<Contacts> contactsRepository, IMapper mapper)
        {
            _contactsRepository = contactsRepository;
            _mapper = mapper;
        }




        // GET: api/Contacts --  getting all items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactDto>>> GetAll()
        {
            var contacts = await _contactsRepository.GetAllAsync();
            var contactDtos = _mapper.Map<IEnumerable<ContactDto>>(contacts);
            return Ok(contactDtos);
        }
            
        


        
        // getting it by id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Contacts), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(int id)
        {
            var resultContact = await _contactsRepository.GetByIdAsync(id);
            if (resultContact == null)
            {
                return NotFound();
            }
            var contactDto = _mapper.Map<ContactDto>(resultContact);  // Map Contact to ContactDto
            return Ok(contactDto);
        }



        // Post api/Contacts -- create a new contact
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] ContactDto contactDto)
        {
            if (contactDto == null)
                return BadRequest();

            var contact = _mapper.Map<Contacts>(contactDto);  // Map ContactDto to Contact entity
            await _contactsRepository.AddAsync(contact);
            return CreatedAtAction(nameof(GetById), new { id = contact.ContactId }, contact);
        }



        // Put api/Contacts/{id} --->  updating
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] ContactDto contactDto)
        {
            if (id != contactDto.ContactId)
                return BadRequest();

            var contact = _mapper.Map<Contacts>(contactDto);  // Map ContactDto to Contact entity
            await _contactsRepository.UpdateAsync(contact);
            return NoContent();
        }



        // Delete api/Contacts/{id} 
        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var existingContact = await _contactsRepository.GetByIdAsync(id);
            if (existingContact == null)
            {
                return NotFound($"No contact found with ID {id}");
            }

            await _contactsRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
