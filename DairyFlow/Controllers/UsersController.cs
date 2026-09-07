using DairyFlow.Business.Interfaces;
using DairyFlow.Data.Dtos.UsersDto;
using Microsoft.AspNetCore.Mvc;

namespace DairyFlow.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUsersProvider _userProvider;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUsersProvider userProvider, ILogger<UsersController> logger)
        {
            _userProvider = userProvider;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var result = _userProvider.GetUserById(id);
            return new OkObjectResult(result);
        }

        [HttpGet]
        public IActionResult GetAllUsers([FromQuery] UsersFilters filters)
        {
            var result = _userProvider.GetAllUsers(filters);
            return new OkObjectResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var result = await _userProvider.CreateUser(request);
            return new OkObjectResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserRequest request)
        {
            var result =await _userProvider.UpdateUser(id, request);
            return new OkObjectResult(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userProvider.DeleteUser(id);
            return new OkObjectResult(result);

        }
    }
}
