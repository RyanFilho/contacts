using Core.Entities;

namespace Data
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetContactsByUserIdAsync(int userId);
        Task<Contact> GetContactByIdAsync(int contactId);
        Task AddContactAsync(Contact contact);
        Task UpdateContactAsync(Contact contact);
        Task DeleteContactAsync(int contactId);
    }
}
