using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contact_Application.Models;
using Contact_Application.Repository.Interfaces;

namespace Contact_Application.Repositories.Interfaces
{
    public interface IContactRepositoryAsync : IRepositoryBase<Contact>
    {
        Task deleteContactAsync(int? id);
        Task<Contact> getContactByIDAsync(int? id);

        //filter methods
        Task<IEnumerable<Contact>> filterByName(string value);
        Task<IEnumerable<Contact>> filterByLastname(string value);
        Task<IEnumerable<Contact>> filterByTag(string value);

        void updateContactInformation(Contact contact);
        Task addNewContactAsync(Contact newContact);
    }
}
