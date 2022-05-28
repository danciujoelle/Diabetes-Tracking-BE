using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiabetesTrackingServer.ViewModels
{
    public class User
    {
        [Key, Required]
        public Guid UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public ICollection<DiabetesPrediction> Predictions { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<GlucoseLog> GlucoseLogs { get; set; }
    }
}
