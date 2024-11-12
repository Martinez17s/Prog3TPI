using Application.DTOs.Requests;
using Application.DTOs; // Asegúrate de incluir el espacio de nombres para AuthenticationResponse
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICustomAuthentication
    {
        Task<string> AutenticarAsync(AuthenticationRequest authenticationRequest);
    }
}