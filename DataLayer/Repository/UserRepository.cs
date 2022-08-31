using Domain.IRepository;
using Domain.Models;
using Newtonsoft.Json;

namespace Domain.Repository
{
    public class UserRepository : IUserRepository
    {
        public IEnumerable<User> GetAllUsers()
        {
            IEnumerable<User> _data;
            String JSONFile = File.ReadAllText(@"./Data/UserList.txt");
            _data = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<User>>(JSONFile);
            return _data;
        }

        public bool CreateUser(User user)
        {
            var previousData = GetAllUsers().ToList();
            previousData.Add(user);
            string json = JsonConvert.SerializeObject(previousData.ToArray());

            //write string to file
            System.IO.File.WriteAllText(@"./Data/UserList.txt", json);
            return true;
        }
    }
}
