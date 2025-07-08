using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Application.Models.Dtos
{
    public class LoginResponseDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string AccessToken { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;

        public List<string> Roles { get; set; } = new();
        public List<string> Permissions { get; set; } = new();
    }
}
