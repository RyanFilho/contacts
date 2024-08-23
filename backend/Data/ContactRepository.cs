using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactsDbContext _context;

        public ContactRepository(ContactsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetContactsByUserIdAsync(int userId)
        {
            return await _context.Contacts
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }

        public async Task<Contact> GetContactByIdAsync(int contactId)
        {
            return await _context.Contacts.FindAsync(contactId);
        }

        public async Task AddContactAsync(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateContactAsync(Contact creditCard)
        {
            _context.Entry(creditCard).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContactAsync(int creditCardId)
        {
            var creditCard = await _context.Contacts.FindAsync(creditCardId);
            if (creditCard != null)
            {
                _context.Contacts.Remove(creditCard);
                await _context.SaveChangesAsync();
            }
        }
    }


}
