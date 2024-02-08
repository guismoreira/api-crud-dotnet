namespace apiCrud.Entities
{
    public class User
    {
        public User()
        {
            isDeleted = false;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool isDeleted { get; set; }
        public void Update(User entity)
        {
            Name = entity.Name;
            Email = entity.Email;
        }
        public void Delete()
        {
            isDeleted = true;
        }
    }
}
