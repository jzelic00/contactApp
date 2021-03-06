using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Application.Repository.Interfaces
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> getAllAsync();
        Task SaveAsync();
    }
}
