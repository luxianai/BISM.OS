using BISM.OS.DatabaseCore;
using BISM.OS.Entity;
using BISM.OS.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BISM.OS.Repository
{
    public class UsersRepository : DbContext<Users>, IUsersRepository
    {
        public int Add(Users entity)
        {
            // var db = CurrentDb.FullClient;
            return 1;
        }

        public bool Edit(Users entity)
        {
            throw new NotImplementedException();
        }
    }
}
