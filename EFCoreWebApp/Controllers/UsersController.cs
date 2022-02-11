using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreWebApp.Core.Abstractions.Repositories;
using EFCoreWebApp.Core.Domain;
using EFCoreWebApp.DaraAccess;
using EFCoreWebApp.DaraAccess.Data;
using EFCoreWebApp.DaraAccess.Repositories;
using EFCoreWebApp.Mappers;
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
        /// Просмотр всех пользователй
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
        /// <summary>
        /// Просмотр пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> GetUserById(Guid id)
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
        /// <summary>
        /// Добавление пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<UserViewModel>> AddAsync(UserViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var User = new User();
            
            var user = UserMapper.MapFromModel(model, User);

            try
            {
                await _userRepository.AddAsync(user);
            }
            catch (Exception e)
            {
                _logger.LogInformation("Ошибка при создании пользователя");
                return BadRequest(e.Message);
            }

            _logger.LogInformation("Пользователь добавлен");
            return Ok(user);
        }
        /// <summary>
        /// Редактирование пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<UserViewModel>> UpdateAsync(Guid id, UserViewModel model)
        {
            User User = await _userRepository.GetByIdAsync(id);

            if (User == null)
            {
                return BadRequest();
            }

            User = UserMapper.MapFromModel(model, User);

            try
            {
                await _userRepository.UpdateAsync(User);
            }
            catch (Exception e)
            {
                _logger.LogInformation("Ошибка при редактировании сотрудника");
                return BadRequest(e.Message);
            }
            _logger.LogInformation($"Пользователь {id} изменен");
            return Ok(User);
        }
        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserViewModel>> DeleteAsync(Guid id)
        {
            User toDelete = await _userRepository.GetByIdAsync(id);

            if (toDelete == null)
            {
                return NotFound();
            }

            try
            {
                await _userRepository.DeleteAsync(toDelete);
            }
            catch (Exception e)
            {
                _logger.LogInformation("Ошибка при удалении сотрудника");
                return BadRequest(e.Message);
            }
            _logger.LogInformation($"Пользователь {id} удален");
            return NoContent();
        }
    }
}
