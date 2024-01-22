using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpPost(Name = "get-token")]
    [AllowAnonymous]
    public ActionResult<TokenResponse> GetToken(TokenRequest request)
    {
        var user = (request.UserName == "fatihgurdal")
            ? new
            {
                Id = Guid.NewGuid(),
                FullName = "Fatih GÜRDAL",
                Password = "123456",
                UserName = request.UserName,
                Role = "Admin"
            }
            : null;
        if (user?.Password?.Equals(request.Password) != true)
        {
            throw new Exception("Login Failed");
        }

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, "TestSubject"),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
            new Claim(ClaimTypes.Name, user.Id.ToString()),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("70534671-bc30-44f1-ba0e-9450f8bd1eeb"));
        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(10),
            signingCredentials: signIn);


        return Ok(new TokenResponse
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token)
        });
    }

    [HttpGet(Name = "get-current-user")]
    [Authorize]
    public ActionResult<GetUserResponse> GetUser()
    {
        return Ok(new GetUserResponse()
        {
            Id = 1,
            UserName = "fatihgurdal"
        });
    }
}