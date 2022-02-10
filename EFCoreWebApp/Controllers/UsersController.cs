using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreWebApp.Core.Abstractions.Repositories;
using EFCoreWebApp.Core.Domain;
using EFCoreWebApp.DaraAccess;
using EFCoreWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCoreWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IRepository<User> userRepository, ILogger<UsersController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAsync()
        {
            var users = await _userRepository.GetAllAsync();

            var userModelList = users.Select(x => new UserViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Age = x.Age,
                

            }).ToList();

            return userModelList;
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                return NotFound();
            var userModel = new UserViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age
            };

            _logger.LogInformation($"Пользователь {id} просмотрен");
            return userModel;
        }

        
    }
}
