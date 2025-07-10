namespace EducationApp.Application.Helpers.PasswordHasher;

public interface IPasswordHasher
{
    string GenerateSalt();
    string Encrypt(string password, string salt);
    bool Verify(string hash, string password, string salt);
}
