using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.DTOs
{
    public class UpdatePasswordRequestDto
    {
        public Guid UserId { get; set; }
        public string NewPassword { get; set; }
    }
}
