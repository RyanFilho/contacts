using  AutoMapper;
using Core.Entities;
using Core.Models;

namespace API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Contact, ContactModel>();
        }
    }

}
