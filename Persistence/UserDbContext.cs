using apiCrud.Entities;

namespace apiCrud.Persistence
{
    public class UserDbContext
    {
        public List<User> Users { get; set; }
        public UserDbContext()
        {
            Users = new List<User>();
        }
    }
}
