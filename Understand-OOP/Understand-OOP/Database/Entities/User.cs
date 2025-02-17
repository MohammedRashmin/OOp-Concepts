namespace Understand_OOP.Database.Entities
{
    public class User : BaseUser
    {

        public string Role { get; set; } = "Customer";
        public DateTime DateCreated { get; set; } = DateTime.UtcNow; 
        public bool IsActive { get; set; } = true; 



    }

}    
 
