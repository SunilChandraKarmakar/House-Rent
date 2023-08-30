using Microsoft.AspNetCore.Identity;

namespace HouseRentWebApi.Domain
{
    public class User : IdentityUser
    {
        public User()
        {
            Properties = new HashSet<Property>();
        }

        public string FullName { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastModifiedTime { get; set; }

        public ICollection<Property> Properties { get; set; }
    }
}