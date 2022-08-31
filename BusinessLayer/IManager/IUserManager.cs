using Domain.Models;

namespace Domain.IManager
{
    public interface IUserManager
    {
        public Task<IEnumerable<User>> GtAllUsers();
        public bool CreateUser(User user);
    }
}
