﻿namespace CustomFramework.WebApiUtils.Authorization.Contracts.Responses
{
    public class UserResponse
    {
        public int Id { get; set; }

        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }

        public int? CustomerId { get; set; }

        public int? PersonId { get; set; }

    }
}