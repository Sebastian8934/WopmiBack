using Application.Interface;
using Application.Models;
using Infrastructure.Identity;
using Infrastructure.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Auth
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly JwtSettings _jwtSettings;

        public AuthService(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IOptions<JwtSettings> jwtOptions)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtSettings = jwtOptions.Value;
        }

        public async Task<AuthResult> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return new AuthResult { Succeeded = false, Error = "Usuario no encontrado." };

            var result = await _signInManager.PasswordSignInAsync(user, password, false, false);

            if (!result.Succeeded)
                return new AuthResult { Succeeded = false, Error = "Credenciales incorrectas." };

            var token = await GenerateToken(user.Id);

            return new AuthResult { Succeeded = true, Token = token };
        }

        public async Task<AuthResult> RegisterAsync(string email, string password)
        {
            var user = new AppUser { Email = email, UserName = email };
            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                var error = result.Errors.FirstOrDefault()?.Description ?? "Error desconocido.";
                return new AuthResult { Succeeded = false, Error = error };
            }

            var token = await GenerateToken(user.Id);
            return new AuthResult { Succeeded = true, Token = token };
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<string> GenerateToken(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                throw new Exception("Usuario no encontrado para generar el token.");

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
