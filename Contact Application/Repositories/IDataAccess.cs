using Contact_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Application.DataAccessLayer
{
    interface IDataAccess
    {
        List<User> GetAllUser();
        User UpdateUser();
        void DeleteUser();
        void SaveChanges();
        User AddUser();

    }
}
