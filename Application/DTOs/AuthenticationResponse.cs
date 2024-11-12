using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class AuthenticationResponse
    {
        public string Token { get; set; }
        public int UserId { get; set; }
    }
}
