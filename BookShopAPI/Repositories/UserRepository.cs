using BookShopAPI.Context;
using BookShopAPI.Interfaces;
using BookShopAPI.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BookShopAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContext _context;
        public UserRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<List<UserModel>> GetAll()
        {
            string query = "SELECT * FROM Users";

            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<UserModel>(query);
                return users.ToList();
            }
        }

        public async Task<UserModelDTO> Get(string email)
        {
            string query = "SELECT * FROM Users WHERE Email=@Email";

            var parameters = new DynamicParameters();
            parameters.Add("Email", email, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var user = await connection.QuerySingleOrDefaultAsync<UserModelDTO>(query, parameters);
                return user;
            }
        }

        public async Task Create(UserModelDTO user)
        {
            string query = "INSERT INTO Users (Email, Password, Admin) VALUES (@Email, @Password, 0)";
            var parameters = new DynamicParameters();
            parameters.Add("Email", user.Email, DbType.String);
            parameters.Add("Password", user.Password, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.QueryAsync<UserModel>(query, parameters);
            }
        }

        public async Task Update(UserModel user)
        {
            string query = "UPDATE Users SET Email=@Email,Password=@Password,Admin=@Admin WHERE Email=@Email";
            var parameters = new DynamicParameters();
            parameters.Add("Email", user.Email, DbType.String);
            parameters.Add("Password", user.Password, DbType.String);
            parameters.Add("Admin", user.Admin, DbType.Boolean);

            using (var connection = _context.CreateConnection())
            {
                await connection.QueryAsync<UserModel>(query, parameters);
            }
        }

        public async Task Delete(string email)
        {
            string query = "DELETE FROM Users WHERE Email=@Email";
            var parameters = new DynamicParameters();
            parameters.Add("Email", email, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.QueryAsync<UserModel>(query, parameters);
            }
        }
    }
}
