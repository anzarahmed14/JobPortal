using JobPortal.DTO;
using JobPortal.IServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUserDTO>>> Get()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving users: {ex.Message}");

            }

        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<GetUserDTO>>> Get(long Id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(Id);
                return Ok(user);

            }
            catch (Exception ex)
            {

                return StatusCode(500, $"An error occurred while retrieving users: {ex.Message}");
            }

            

        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<GetUserDTO>> Post([FromBody] CreateUserDTO  createUserDTO)
        {
            try
            {
                var users = await _userService.CreateUserAsync(createUserDTO);
                return Ok(users);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"An error occurred while saving users: {ex.Message}");
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{Id}")]
        public async Task<ActionResult<GetUserDTO>> Put(long Id, [FromBody] UpdateUserDTO  updateUserDTO)
        {
            try
            {
                var users = await _userService.UpdateUserAsync(Id, updateUserDTO);
                return Ok(users);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"An error occurred while updating users: {ex.Message}");
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                var isDeleted = await _userService.DeleteUserAsync(id);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"An error occurred while deleting users: {ex.Message}");
            }
        }
    }
}
