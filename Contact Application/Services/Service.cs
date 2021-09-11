using AutoMapper;
using Contact_Application.Models;
using Contact_Application.Repositories.Interfaces;
using Contact_Application.Repository;
using Contact_Application.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Application.Services
{
    public class Service:IService
    {
        private readonly ITagRepositoryAsync _tagRepository;
        private readonly IContactRepositoryAsync _contactRepository;
        private readonly IMapper _mapper;
        public Service(ITagRepositoryAsync tagRepository
                       ,IContactRepositoryAsync contactRepository
                       ,IMapper mapper)
        {
            _mapper = mapper;
            _tagRepository = tagRepository;
            _contactRepository = contactRepository;
        }

        public async Task addNewContactAsync(ContactDTO newContact)
        {
           Contact _newContact = _mapper.Map<Contact>(newContact);
            
            await _contactRepository.addNewContactAsync(_newContact);

            await _contactRepository.SaveAsync();
        }

        public async Task deleteContact(int? contactId)
        {
            await _contactRepository.deleteContactAsync(contactId);

            await _contactRepository.SaveAsync();
        }

        public async Task editContact(Contact contact)
        {
            _contactRepository.updateContactInformation(contact);

            await _contactRepository.SaveAsync();
        }

        public async Task<IEnumerable<ContactHomePageDTO>> getAllContact()
        {
            IEnumerable<Contact> contacts = await _contactRepository.getAllAsync();

             var _allContactsHomePageDTO = _mapper.Map<IEnumerable<Contact>, IEnumerable<ContactHomePageDTO>>(contacts);

            return _allContactsHomePageDTO;
        }

        public async Task<IEnumerable<Tag>> getAllTags()
        {
            return await _tagRepository.getAllAsync();
        }

        public async Task<IEnumerable<ContactHomePageDTO>> getFilterData(string filter,string value)
        {
            IEnumerable<Contact> filterData= Enumerable.Empty<Contact>();

            #region filter conditions

            switch (filter)
            {
                case "Name":
                    filterData = await _contactRepository.filterByName(value);
                    break;
                case "Lastname":
                    filterData = await _contactRepository.filterByLastname(value); ;
                    break;
                case "Tag":
                    filterData = await _contactRepository.filterByTag(value); ;
                    break;
            }
            #endregion 

            var _filterDataDTO = _mapper.Map<IEnumerable<Contact>, IEnumerable<ContactHomePageDTO>>(filterData); ;

            return _filterDataDTO;
        }

        public async Task<Contact> getSingleContact(int? contactID)
        {
            Contact singleContact = await _contactRepository.getContactByIDAsync(contactID);

            return singleContact;
        }
    }
}