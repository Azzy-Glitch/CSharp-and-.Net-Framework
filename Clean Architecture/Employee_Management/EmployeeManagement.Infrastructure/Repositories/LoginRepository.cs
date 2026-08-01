using EmployeeManagement.Application.Interfaces.Repositories;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly EmployeeDbContext _context;

        public LoginRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Login>> GetAllAsync() =>
            await _context.Logins.ToListAsync();

        public async Task<Login?> GetByIdAsync(int id) =>
            await _context.Logins.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Login?> GetByEmailAsync(string email) =>
            await _context.Logins.FirstOrDefaultAsync(x => x.Email == email);

        public async Task AddAsync(Login login) =>
            await _context.Logins.AddAsync(login);

        public Task RemoveAsync(Login login)
        {
            _context.Logins.Remove(login);
            return Task.CompletedTask;
        }

        public async Task RemoveAllAsync()
        {
            var logins = await _context.Logins.ToListAsync();
            _context.Logins.RemoveRange(logins);
        }

        public async Task<bool> AnyAsync() => await _context.Logins.AnyAsync();

        public async Task ResetIdentityAsync() =>
            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Logins', RESEED, 0)");

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
