using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using HoroscopeBot.Core.Models;
using Npgsql;

namespace HoroscopeBot.Core.Repositories
{
    public class UsersRepository : IRepository<User>
    {
        private readonly string _connectionString;

        public UsersRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection Connection => new NpgsqlConnection(_connectionString);

        public async Task Add(User item)
        {
            using var dbConnection = Connection;
            dbConnection.Open();
            await dbConnection.ExecuteAsync("INSERT INTO users (tgId, tgName, language) VALUES(@tgId,@tgName,@language)", item);
        }

        public async Task Remove(int id)
        {
            using var dbConnection = Connection;
            dbConnection.Open();
            await dbConnection.QueryAsync<User>("SELECT * FROM customer");
        }

        public async Task<User> FindById(int id)
        {
            using var dbConnection = Connection;
            dbConnection.Open();
            return (await dbConnection.QueryAsync<User>("SELECT * FROM users WHERE id = @Id", new { Id = id })).FirstOrDefault();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            using var dbConnection = Connection;
            dbConnection.Open();
            return await dbConnection.QueryAsync<User>("SELECT * FROM users");
        }

        public async Task Update(User item)
        {
            using var dbConnection = Connection;
            dbConnection.Open();
            await dbConnection.QueryAsync("UPDATE users SET tgId = @TgId,  tgName = @TgName, language = @Language WHERE id = @Id", item);
        }

        public async Task<User> FindByTgId(string tgId)
        {
            using var dbConnection = Connection;
            dbConnection.Open();
            return (await dbConnection.QueryAsync<User>("SELECT * FROM users WHERE tgId = @TgId", new { TgId = tgId })).FirstOrDefault();
        }
    }
}