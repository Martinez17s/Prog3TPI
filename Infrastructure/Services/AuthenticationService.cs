using Application.DTOs.Requests;
using Application.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services
{
    public class AuthenticationService : ICustomAuthentication
    {
        private readonly IUserRepository _userRepository;
        private readonly AuthenticacionServiceOptions _options;

        public AuthenticationService(IUserRepository userRepository, IOptions<AuthenticacionServiceOptions> options)
        {
            _userRepository = userRepository;
            _options = options.Value;
        }
        public class AuthenticacionServiceOptions
        {
            public const string AuthenticacionService = "AuthenticacionService";

            public string Issuer { get; set; }
            public string Audience { get; set; }
            public string SecretForKey { get; set; }
        }

        private async Task<User> ValidateUserAsync(AuthenticationRequest request)
        {
            if (string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Password))
                return null;
            var user = await _userRepository.GetUserByUserNameAsync(request.UserName);
            if (user == null)
                return null;
            if (user.UserName == request.UserName && user.Password == request.Password)
                return user;

            return null;
        }

        public async Task<string> AutenticarAsync(AuthenticationRequest request)
        {
            var user = await ValidateUserAsync(request);

            if (user == null)
                throw new NotAllowedException("User authentication failed");

            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.SecretForKey));

            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>
            {
                new Claim("sub", user.Id.ToString()),
                new Claim("name", user.Name),
                new Claim("email", user.Email),
                new Claim("role", user.Role.ToString())
            };

            var jwtSecurityToken = new JwtSecurityToken(
                _options.Issuer,
                _options.Audience,
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                credentials);

            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return tokenToReturn.ToString();
        }

    }
}
