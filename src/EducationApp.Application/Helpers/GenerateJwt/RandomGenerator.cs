namespace EducationApp.Application.Helpers.GenerateJwt;

public class RandomGenerator
{
    public static int GenerateInteger(int min, int max)
    {
        return new Random().Next(min, max);
    }
}
