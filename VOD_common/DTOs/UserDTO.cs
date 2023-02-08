using System.IdentityModel.Tokens.Jwt;

namespace VOD_common.DTOs;

internal class UserDTO
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string UserLevelId { get; set; }
    public JwtSecurityToken LoginToken { get; set; }
}
