using Contact_Application.Models;
using Contact_Application.Repositories.Interfaces;
using Contact_Application.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Application.Repository
{
    public class TagRepository : ITagRepositoryAsync
    {
        private readonly DatabaseContext _db;

        public TagRepository(DatabaseContext db)
        {
            _db = db;
        }

        public Task addNewTag()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tag>> getAllAsync()
        {
            return await _db.Tag.ToListAsync();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
