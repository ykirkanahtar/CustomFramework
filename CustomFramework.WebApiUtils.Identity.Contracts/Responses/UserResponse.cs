using System;

namespace CustomFramework.WebApiUtils.Identity.Contracts.Responses
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }
    }
}