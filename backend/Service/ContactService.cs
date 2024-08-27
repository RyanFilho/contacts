using AutoMapper;
using Core.Entities;
using Core.Models;
using Data;

namespace Service
{
    public interface IContactService
    {
        Task<IEnumerable<ContactModel>> GetContactsByUserIdAsync(int userId);
        Task<ContactModel> GetContactByIdAsync(int contactId);
        Task AddContactAsync(ContactModel contact);
        Task UpdateContactAsync(ContactModel contact);
        Task DeleteContactAsync(int contactId);
        Task<IEnumerable<ContactModel>> GetContactsByAdObjIdAsync(string asObjId);
    }
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContactModel>> GetContactsByUserIdAsync(int userId)
        {
            var contacts = await _contactRepository.GetContactsByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<ContactModel>>(contacts);
        }

        public async Task<IEnumerable<ContactModel>> GetContactsByAdObjIdAsync(string asObjId)
        {
            var contacts = await _contactRepository.GetContactsByAdObjIdAsync(asObjId);
            return _mapper.Map<IEnumerable<ContactModel>>(contacts);
        }

        public async Task<ContactModel> GetContactByIdAsync(int contactId)
        {
            var contact = await _contactRepository.GetContactByIdAsync(contactId);
            return _mapper.Map<ContactModel>(contact);
        }

        public async Task AddContactAsync(ContactModel contact)
        {
            var contactEntity = _mapper.Map<Contact>(contact);
            await _contactRepository.AddContactAsync(contactEntity);
        }

        public async Task UpdateContactAsync(ContactModel contact)
        {
            var contactEntity = _mapper.Map<Contact>(contact);
            await _contactRepository.UpdateContactAsync(contactEntity);
        }

        public async Task DeleteContactAsync(int contactId)
        {
            await _contactRepository.DeleteContactAsync(contactId);
        }
    }
}
