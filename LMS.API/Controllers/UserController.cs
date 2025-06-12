using System.Security.Claims;
using Asp.Versioning;
using LMS_Backend.LMS.Application.DTOs.User;
using LMS_Backend.LMS.Application.Interfaces.UserManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace LMS_Backend.LMS.API.Controllers
{
    [ApiController]
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/users")]
    [Produces("application/json")]
    [Authorize(Roles = "Administrator")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        private int GetLoggedInUserId()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            return userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserDataDTO userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var createdBy = GetLoggedInUserId();
                var userId = await _userService.AddUserAsync(userDto, createdBy);
                return Ok(new { success = true, message = "User added successfully.", userId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Error adding user: {ex.Message}" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                Console.WriteLine(users);
                return Ok(new { success = true, message = "Users fetched successfully.", data = users });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Error fetching users: {ex.Message}" });
            }
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetUserById([FromQuery]int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                    return NotFound(new { success = false, message = $"User with ID {id} not found." });

                return Ok(new { success = true, message = "User fetched successfully.", data = user });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Error retrieving user: {ex.Message}" });
            }
        }

        [HttpGet("get-by-role")]
        public async Task<IActionResult> GetUsersByRole([FromQuery] string role)
        {
            try
            {
                var users = await _userService.GetUsersByRoleAsync(role);
                return Ok(new { success = true, message = $"Users with role '{role}' fetched successfully.", data = users });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Error retrieving users by role: {ex.Message}" });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromQuery]int id, [FromBody] UserDataDTO userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                userDto.Id = id; 
                var updatedBy = GetLoggedInUserId();
                var result = await _userService.UpdateUserAsync(userDto, updatedBy);

                if (!result)
                    return NotFound(new { success = false, message = $"User with ID {id} not found." });

                return Ok(new { success = true, message = "User updated successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Error updating user: {ex.Message}" });
            }
        }

        [HttpPatch]
        public async Task<IActionResult> PatchUser( [FromQuery] int id, [FromBody] JsonPatchDocument<UserDataDTO> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest(new { success = false, message = "Invalid patch document." });
            }

            try
            {
                //public bool MyBool { get; set; }

                Console.WriteLine($"Received boolean value from client: {patchDoc}");

                var updatedBy = GetLoggedInUserId();
                var result = await _userService.PatchUserAsync(id, patchDoc, updatedBy);

                if (!result)
                    return NotFound(new { success = false, message = $"User with ID {id} not found." });

                return Ok(new { success = true, message = "User patched successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Error patching user: {ex.Message}" });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromQuery]int id)
        {
            try
            {
                var deletedBy = GetLoggedInUserId();
                var result = await _userService.DeleteUserAsync(id, deletedBy);

                if (!result)
                    return NotFound(new { success = false, message = $"User with ID {id} not found." });

                return Ok(new { success = true, message = "User deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Error deleting user: {ex.Message}" });
            }
        }
    }
}