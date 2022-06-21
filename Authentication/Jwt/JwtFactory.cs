namespace Authentication.Jwt
{
    using Authentication.Helpers;
    using Authentication.Models;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    public class JwtFactory : IJwtFactory
    {
        private readonly IConfiguration _configuration;

        public JwtFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateEncodedToken<T>(T @model)
        {
            UserModel user = @model.Map(new UserModel());
            string secretKey = _configuration["Auth:SecretKey"];
            byte[] key = Encoding.ASCII.GetBytes(secretKey);
            ClaimsIdentity Identity = new();
            Identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            Identity.AddClaim(new Claim(ClaimTypes.Email, user.UserName));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = Identity,
                Expires = DateTime.UtcNow.AddDays(10),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(createdToken);
        }
    }
}
