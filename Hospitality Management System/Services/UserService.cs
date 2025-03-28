using HospitalityManagementSystem.Models;
using MongoDB.Driver;
using System.Security.Cryptography;
using System.Text;

namespace HospitalityManagementSystem.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IMongoDatabase database)
        {
            _users = database.GetCollection<User>("Users");
        }

        public async Task<User?> AuthenticateAsync(string email, string password)
        {
            var user = await _users.Find(u => u.Email == email).FirstOrDefaultAsync();
            if (user == null || !VerifyPassword(password, user.PasswordHash))
                return null;

            return user;
        }

        public async Task<bool> RegisterAsync(User user, string password)
        {
            if (await _users.Find(u => u.Email == user.Email).AnyAsync()) return false;

            user.PasswordHash = HashPassword(password);
            await _users.InsertOneAsync(user);
            return true;
        }

        // Fetch a user by ID from the database
        public async Task<User?> GetUserByIdAsync(string userId)
        {
            return await _users.Find(u => userId == u.Id).FirstOrDefaultAsync();
        }

        // This method updates a user's information in the database
        public async Task<bool> UpdateUserAsync(User user)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Id, user.Id);
            var update = Builders<User>.Update
                .Set(u => u.Username, user.Username)
                .Set(u => u.PasswordHash, user.PasswordHash)
                .Set(u => u.Email, user.Email)
                .Set(u => u.Role, user.Role);
            var result = await _users.UpdateOneAsync(filter, update);
            return result.ModifiedCount > 0;
        }


        private static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        private static bool VerifyPassword(string password, string storedHash)
        {
            return HashPassword(password) == storedHash;
        }
    }
}
