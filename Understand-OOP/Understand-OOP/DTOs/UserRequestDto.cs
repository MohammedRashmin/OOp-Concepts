using System.ComponentModel.DataAnnotations;

namespace Understand_OOP.DTOs
{
    public class UserRequestDto
    {

        public string Name { get; set; }


        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
