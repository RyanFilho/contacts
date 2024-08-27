using Core.Models;
using Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // TODO: Add API Authentication and Authorization
    // [Authorize]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ContactModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ContactModel>>> GetContactsByAdObjIdAsync(string asObjId)
        {
            var contacts = await _contactService.GetContactsByAdObjIdAsync(asObjId);
            return Ok(contacts);
        }

        [HttpGet("{userId}/{contactId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ContactModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContactModel>> GetContactById(int userId, int contactId)
        {
            var contact = await _contactService.GetContactByIdAsync(contactId);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ContactModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactModel>> AddContact(ContactModel contact)
        {
            await _contactService.AddContactAsync(contact);
            return CreatedAtAction(nameof(GetContactById), new { userId = contact.UserId, contactId = contact.ContactId }, contact);
        }

        [HttpPut("{contactId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateContact(int contactId, ContactModel contact)
        {
            if (contactId != contact.ContactId)
            {
                return BadRequest();
            }

            await _contactService.UpdateContactAsync(contact);
            return NoContent();
        }

        [HttpDelete("{contactId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteContact(int contactId)
        {
            await _contactService.DeleteContactAsync(contactId);
            return NoContent();
        }
    }


}
