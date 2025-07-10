namespace EducationApp.Application.Helpers.GenerateJwt;

public class JwtOption
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SecretKey { get; set; }
    public int ExpirationInSeconds { get; set; }    
}
