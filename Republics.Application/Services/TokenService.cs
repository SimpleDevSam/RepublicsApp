using Microsoft.IdentityModel.Tokens;
using Republics.Application.Objects;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Republics.Application.Services;

public static class TokenService
{
    public static string GenerateToken(UserEmailRoles user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("asdasdad12sa123131313213131221asda-fadsf");

        //// Create claims for roles
        //var roleClaims = user.Roles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Email, user.UserEmail),
                //new Claim(ClaimTypes.Role, string.Join(",", user.Roles))
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}

