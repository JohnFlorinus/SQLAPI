using Microsoft.AspNetCore.Mvc;
using BookShopAPI.Context;
using BookShopAPI.Repositories;
using BookShopAPI.Models;
using BookShopAPI.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShopAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        public UserController(IUserRepository iuserrepository)
        {
            _userRepo = iuserrepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<UserModel> userList;
            try
            {
                userList = await _userRepo.GetAll();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok(userList);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            UserModelDTO user;
            try
            {
               user = await _userRepo.Get(email);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserModelDTO usermodeldto)
        {
            try
            {
                await _userRepo.Create(usermodeldto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok();
        }

        [HttpPut("{email}")]
        public async Task<IActionResult> Update(UserModel user)
        {
            try
            {
                await _userRepo.Update(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok();
        }

        [HttpDelete("{email}")]
        public async Task<IActionResult> Delete(string email)
        {
            try
            {
                await _userRepo.Delete(email);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok();
        }
    }
}
