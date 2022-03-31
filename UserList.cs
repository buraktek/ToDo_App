using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_App.Models;

namespace ToDo_App
{
    class UserList
    {
        public List<UserModel> users = new List<UserModel>();

        public UserList()
        {   
            users.Add(new UserModel(1, "Burak TEKİN"));
            users.Add(new UserModel(2, "Ali Ucar"));
            users.Add(new UserModel(3, "Ahmet Kacar"));
            users.Add(new UserModel(4, "Mehmet El"));
        }
    }
}
