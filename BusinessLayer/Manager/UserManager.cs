using Domain.IManager;
using Domain.Models;
using Domain.IRepository;
using Newtonsoft.Json;
//using AutoMapper;

namespace Domain.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        //private readonly IMapper _mapper;

        public UserManager(IUserRepository userRepository)
        {
            //_mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<User>> GtAllUsers()
        {
            return _userRepository.GetAllUsers().OrderBy(x => x.Last_Name);
        }

        public bool CreateUser(User user)
        {
            return _userRepository.CreateUser(user);
        }
    }
}
