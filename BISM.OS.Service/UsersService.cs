using BISM.OS.Common;
using BISM.OS.Entity;
using BISM.OS.IRepository;
using BISM.OS.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace BISM.OS.Service
{
    public class UsersService : IUsersService
    {
        private IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [Cache(ExpireDate = 30)]
        public int Add(Users entity)
        {
            return _usersRepository.Add(entity);
        }

        public bool Edit(Users entity)
        {
            return _usersRepository.Edit(entity);
        }
    }
}
