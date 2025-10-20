using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Buildvise.Application.Common.Interfaces;
using Buildvise.Domain.Clients;
using Buildvise.Domain.Companies;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Buildvise.Infrastructure.Authentication.TokenGenerator;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IOptions<JwtSettings> jwtOptions)
    {
        _jwtSettings = jwtOptions.Value;
    }
    
    public string GenerateToken(object entity)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
        var claims = new List<Claim>();
        
        switch (entity)
        {
            case Client client:
                claims.Add(new Claim("type", "client"));
                claims.Add(new Claim("id", client.Id.ToString()));
                break;

            case Company company:
                claims.Add(new Claim("type", "company"));
                claims.Add(new Claim("id", company.Id.ToString()));
                break;

            default:
                throw new ArgumentException("Unsupported entity type for JWT generation.");
        }
        
        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.TokenExpirationInMinutes),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}