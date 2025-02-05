namespace Boilerplate.Api.DTOs
{
    public class UserProfile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class UpdateProfile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
