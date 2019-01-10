using System;
using System.Collections.Generic;
using System.Text;

namespace AngularPOC.Entities.Dto
{
    public class UsersWithPaging
    {
        public UsersWithPaging()
        {
            Users = new List<UserMaster>();
            Count = 0;
        }

        public UsersWithPaging(List<UserMaster> users,int count)
        {
            Users = users;
            Count = count;
        }


        public int Count { get; private set; }

        public IList<UserMaster> Users { get; set; }
    }
}
