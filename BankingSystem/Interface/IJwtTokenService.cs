namespace BankingSystem.Interface
{
    public interface IJwtTokenService
    {
        string GenerateToken(string username);
    }
}
