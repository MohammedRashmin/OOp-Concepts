namespace Understand_OOP.Database.Entities
{
    public abstract class BaseUser
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        private string _password;
        public string Password
        {
            get => _password;
            set => _password = HashPassword(value);
        }

        protected string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
