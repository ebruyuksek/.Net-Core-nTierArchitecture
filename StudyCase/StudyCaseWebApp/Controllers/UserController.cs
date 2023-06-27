using AutoMapper;
using Bussines.Repositories;
using Microsoft.AspNetCore.Mvc;
using StudyCaseWebApp.DAL.Models;

namespace StudyCaseWebApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IBaseRepository<User> _userRepository;
        private IMapper _mapper;

        public UserController(IBaseRepository<User> context, IMapper mapper)
        {
            _userRepository = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var userInfo = _userRepository.Get(id);
            var user = _mapper.Map<VmGetUser>(userInfo);
            return Ok(user);
        }

        [HttpPut]
        public IActionResult Add(VmUser vmUser)
        {
            var user = _mapper.Map<User>(vmUser);
            user.CreatedDateTime = DateTime.Now;
            _userRepository.Add(user);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(VmUpdateUser vmUser)
        {
            var user = _userRepository.Get(vmUser.Id);
            _mapper.Map(vmUser, user);

            user.UpdatedDateTime = DateTime.Now;
            _userRepository.Update(user);

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int? userId)
        {
            if (userId.HasValue && userId > 0)
            {
                _userRepository.Delete(userId);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
