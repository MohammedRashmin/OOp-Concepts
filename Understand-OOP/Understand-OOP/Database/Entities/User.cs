using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Understand_OOP.Database.Entities
{
    [Table("Users")] // Explicitly mapping to the database table "Users"
    public class User : BaseUser
    {
        [Column(TypeName = "nvarchar(50)")]
        public string Role { get; set; } = "Manager";

        [Column(TypeName = "datetime2")]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;

        public void SetPassword(string password)
        {
            Password = password;
        }
    }
}
