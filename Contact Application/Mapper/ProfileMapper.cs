using AutoMapper;
using Contact_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Application.Mapper
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {          
            CreateMap<Contact, ContactDTO>();
            CreateMap<ContactDTO, Contact>();
            CreateMap<Contact, ContactHomePageDTO>();
            CreateMap<ContactHomePageDTO, Contact>();
        }
    }  
}
