using Contact_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Application.Services
{
    public interface IService
    {
        //update contact
        Task editContact(Contact contact);
        //Add contact
        Task addNewContactAsync(ContactDTO newContact);
        //delete contact
        Task deleteContact(int? contactId);
        //get all contacts
        Task<IEnumerable<ContactHomePageDTO>> getAllContact();
        //search contact by name etc.
        Task <IEnumerable<ContactHomePageDTO>> getFilterData(string filter,string value);
        //get all tags
        Task<IEnumerable<Tag>> getAllTags();
        //get single contact
        Task<Contact> getSingleContact(int? contactID);

    }
}
