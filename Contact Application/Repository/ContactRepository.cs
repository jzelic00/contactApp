using Contact_Application.Models;
using Contact_Application.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Application.Repository
{
    public class ContactRepository:IContactRepositoryAsync
    {
        private readonly DatabaseContext _db;

        public ContactRepository(DatabaseContext db)
        {
            _db = db;
        }

        public async Task addNewContactAsync(Contact newContact)
        {
           await _db.Contact.AddAsync(newContact);

        }

        public async Task deleteContactAsync(int? id)
        {
            Contact contactToDelete = await  _db.Contact.Where(p => p.ContactID == id )
                               .Include(p => p.Mail)
                               .Include(p => p.Number)
                               .FirstOrDefaultAsync();

            _db.Remove(contactToDelete);
        }

        public async Task<IEnumerable<Contact>> getAllAsync()
        {
            return await _db.Contact.AsNoTracking().Include(p=>p.Tag).ToListAsync();
        }

        public async Task<Contact> getContactByIDAsync(int? id)
        {
            return await _db.Contact.AsNoTracking().Where(p=>p.ContactID==id)
                                                   .Include(p=>p.Mail)
                                                   .Include(p=>p.Number)
                                                   .FirstOrDefaultAsync();
        }     

        public void updateContactInformation(Contact contact)
        {
            _db.Entry(contact).State = EntityState.Modified;           
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        #region filter methods
        public async Task<IEnumerable<Contact>> filterByName(string value)
        {
            return await _db.Contact.AsNoTracking().Where(p => p.Name.Contains(value)).ToListAsync();
        }

        public async Task<IEnumerable<Contact>> filterByLastname(string value)
        {
            return await _db.Contact.AsNoTracking().Where(p => p.LastName.Contains(value)).ToListAsync();
        }

        public async Task<IEnumerable<Contact>> filterByTag(string value)
        {
            return await _db.Contact.AsNoTracking().Where(p => p.Tag.TagName.Contains(value)).ToListAsync();
        }
        #endregion
    }
}