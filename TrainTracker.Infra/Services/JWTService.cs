using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Data;
using TrainTracker.Core.Repository;
using TrainTracker.Core.Services;

namespace TrainTracker.Infra.Services
{
    public class JWTService : IJWTService
    {
        private readonly IJWTRepository _JWTrepository;

        public JWTService(IJWTRepository jWTrepository)
        {
            _JWTrepository = jWTrepository;
        }

        public string Auth(User user)
        {
            var result = _JWTrepository.Auth(user);
            if (result == null)
                return null;
            else
            {
                var secertKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKeyomar@345"));
                var signCredential = new SigningCredentials(secertKey, SecurityAlgorithms.Aes128CbcHmacSha256);
                var claims = new List<Claim>
                {

                    new Claim("Email", result.Email),
                    new Claim("RoleId",result.RoleId.ToString()),
                    new Claim("UserId",result.UserId.ToString())
                };
                var tokenOption = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddHours(24),
                    signingCredentials: signCredential);
                var tokenAsString = new JwtSecurityTokenHandler().WriteToken(tokenOption);
                return tokenAsString;
            }
        }
    }
}
