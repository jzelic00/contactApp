using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contact_Application.Models;
using Contact_Application.Repository.Interfaces;

namespace Contact_Application.Repositories.Interfaces
{
    public  interface ITagRepositoryAsync: IRepositoryBase<Tag>
    {
        Task addNewTag();
        
    }
}
