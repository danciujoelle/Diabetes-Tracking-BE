﻿using System;

namespace DiabetesTrackingServer.Models
{
    public class UserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool HasDiabetes { get; set; }
        public string DiabetesType { get; set; }
    }
}
