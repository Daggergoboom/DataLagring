﻿namespace Business.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Full name property for convenience
        public string FullName => $"{FirstName} {LastName}";
    }
}