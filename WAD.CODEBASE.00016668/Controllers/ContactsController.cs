using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD.CODEBASE._00016668.DTOs;
using WAD.CODEBASE._00016668.Models;
using WAD.CODEBASE._00016668.Repositories;

namespace WAD.CODEBASE._00016668.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IRepository<Groups> _groupRepository;
        private readonly IRepository<Contacts> _contactsRepository;
        private readonly IMapper _mapper;


        public ContactsController(IRepository<Contacts> contactsRepository,
                                    IRepository<Groups> groupRepository,
                                    IMapper mapper)
        {
            _contactsRepository = contactsRepository;
            _groupRepository = groupRepository;
            _mapper = mapper;
        }




        // GET: api/Contacts --  getting all items
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var contacts = await _contactsRepository.GetAllAsync();
            var contactDtos = _mapper.Map<IEnumerable<ContactDto>>(contacts);
            return Ok(contactDtos);
        }





        // getting it by id
        [HttpGet("{id}")]
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
        public async Task<IActionResult> Create(ContactDto contactDto)
        {
            var groupExists = await _groupRepository.GetByIdAsync(contactDto.GroupId);
            if (groupExists == null)
            {
                return BadRequest($"Group with ID {contactDto.GroupId} does not exist.");
            }

            var contact = _mapper.Map<Contacts>(contactDto);
            await _contactsRepository.AddAsync(contact);
            var createdContactDto = _mapper.Map<ContactDto>(contact);
            return CreatedAtAction(nameof(GetById), new { id = createdContactDto.Id }, createdContactDto);

        }



        // Put api/Contacts/{id} --->  updating
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ContactDto contactDto)
        {
            if (id != contactDto.Id)
                return BadRequest("ID mismatch");

            // Check if the contact exists
            var existingContact = await _contactsRepository.GetByIdAsync(id);
            if (existingContact == null)
                return NotFound("Contact not found");

            // Update the contact properties, excluding GroupName
            existingContact.FirstName = contactDto.FirstName;
            existingContact.LastName = contactDto.LastName;
            existingContact.PhoneNumber = contactDto.PhoneNumber;
            existingContact.Email = contactDto.Email;
            existingContact.DateOfBirth = contactDto.DateOfBirth;
            existingContact.GroupId = contactDto.GroupId;

            await _contactsRepository.UpdateAsync(existingContact);
            return NoContent();
        }



        // Delete api/Contacts/{id} 
        [HttpDelete("{id}")]
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
