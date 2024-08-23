using  AutoMapper;
using Core.Entities;
using Core.Models;

namespace Presentation
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Contact, ContactModel>();
        }
    }

}
