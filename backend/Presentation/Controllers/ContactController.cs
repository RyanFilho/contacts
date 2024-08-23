using Core.Models;
using Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
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
        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes:Read")]
        public async Task<ActionResult<IEnumerable<ContactModel>>> GetContactsByUserId(int userId)
        {
            var contacts = await _contactService.GetContactsByUserIdAsync(userId);
            return Ok(contacts);
        }

        [HttpGet("{userId}/{contactId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ContactModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes:Read")]
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
        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes:Write")]
        public async Task<ActionResult<ContactModel>> AddContact(ContactModel contact)
        {
            await _contactService.AddContactAsync(contact);
            return CreatedAtAction(nameof(GetContactById), new { userId = contact.UserId, contactId = contact.ContactId }, contact);
        }

        [HttpPut("{contactId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes:Write")]
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
        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes:Write")]
        public async Task<IActionResult> DeleteContact(int contactId)
        {
            await _contactService.DeleteContactAsync(contactId);
            return NoContent();
        }
    }


}
