using EducationApp.Core.Entities;

namespace EducationApp.Application.Helpers.GenerateJwt;

public interface IJwtTokenHandler
{
    string GenerateAccessToken(User user, string sessionToken);
    string GenerateRefreshToken();
}
