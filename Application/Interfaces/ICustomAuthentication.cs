using Application.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICustomAuthentication
    {
        Task<string> AutenticarAsync(AuthenticationRequest authenticationRequest);
    }
}
