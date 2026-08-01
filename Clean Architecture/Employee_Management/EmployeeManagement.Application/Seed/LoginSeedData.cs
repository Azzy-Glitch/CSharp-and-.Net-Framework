using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Seed
{
    public static class LoginSeedData
    {
        // NOTE: mirrors the original placeholder — "hashed_password" is a literal,
        // not a real BCrypt hash, so this seeded login won't pass IPasswordHasher.Verify.
        // Swap for _passwordHasher.Hash("<some default>") once you want it usable end-to-end.
        public static Login CreateDefaultLogin() => new()
        {
            Email = "admin@test.com",
            PasswordHash = "hashed_password"
        };
    }
}
