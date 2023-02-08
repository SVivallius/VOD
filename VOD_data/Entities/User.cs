using System.IdentityModel.Tokens.Jwt;
using VOD_data.Interfaces;

namespace VOD_data.Entities;

public class User : IEntity
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public UserLevel Level { get; set; }
    public JwtSecurityToken LoginToken { get; set; }
}
