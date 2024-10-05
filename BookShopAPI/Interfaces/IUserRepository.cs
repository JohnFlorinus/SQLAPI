using BookShopAPI.Context;
using BookShopAPI.Models;
using Dapper;
using System.Data;

namespace BookShopAPI.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<UserModel>> GetAll();
        public Task<UserModelDTO> Get(string email);
        public Task Create(UserModelDTO user);
        public Task Update(UserModel user);
        public Task Delete(string email);
    }
}
