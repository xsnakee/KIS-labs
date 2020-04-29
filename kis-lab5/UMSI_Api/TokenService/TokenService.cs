using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Common;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using TokenAuthentication.Claims;
using UMIS.DAL.Domain.Contracts.Models.Auth;

namespace TokenAuthentication
{
    public class TokenService : ITokenService
    {
        public string GenerateToken(User user, List<int> permissionsIds)
        {
            string jsonUserPermissions = string.Empty;

            if (permissionsIds != null && permissionsIds.Any())
            {
                jsonUserPermissions = JsonConvert.SerializeObject(permissionsIds);
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(UmisClaimTypes.JsonPermissionsClaimName, jsonUserPermissions)
            };

            SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.JwtSecret));
            SigningCredentials signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: Constants.JwtIssuer,
                audience: Constants.JwtAudience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Constants.JwtLifeTime),
                signingCredentials: signinCredentials

            );
            var tokenString = new JwtSecurityTokenHandler()
                .WriteToken(tokeOptions);

            return tokenString;
        }
    }
}
