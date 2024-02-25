using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Streamberry.Domain.Abstractions;
using Streamberry.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Streamberry.Application.Services
{
    public class UsuarioService : BaseService<IUsuarioRepository, Usuario>
    {
        private IUsuarioRepository _usuarioRepository;
        private IConfiguration configuration;

        public UsuarioService(IUsuarioRepository usuarioRepository, IConfiguration configuration) : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
            this.configuration = configuration;
        }

        public async Task<string> Authenticate(string email, string password)
        {
            Usuario user = await GetByEmail(email);
            if (user == null || password != user.Senha)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration.GetSection("SigningKey").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.Nome),
                new Claim(ClaimTypes.Email, user.Email)
                    // Add more claims as needed
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<string> Register(string Nome,string email, string senha)
        {
            var user = await GetByEmail(email);
            if (user != null)
            {
                return null;
            }
            var newUser = new Usuario
            {
                Nome = Nome,
                Email = email,
                Senha = senha
            };
            _usuarioRepository.Add(newUser);
            return await Authenticate(email, senha);
        }

        public async Task<Usuario> GetUserFromJWT(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration.GetSection("SigningKey").Value);
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true
            };
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            var email = principal.FindFirst(ClaimTypes.Email)?.Value;
            var user = await GetByEmail(email);
            return user;
        }

        public async Task<Usuario> GetByEmail(string email)
        {
            var user = await _usuarioRepository.GetAll();
            return user.FirstOrDefault(x => x.Email == email);
        }

        public async Task Delete(string email, string senha)
        {
            var user = await GetByEmail(email);
            if (user.Senha == senha)
            {
                _usuarioRepository.Remove(user);
            }
        }

        public async Task<bool> Exists(string email)
        {
            var user = await GetByEmail(email);
            return user != null;
        }
    }
}