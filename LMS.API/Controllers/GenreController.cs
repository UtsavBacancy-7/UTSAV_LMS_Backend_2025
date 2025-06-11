using System.Security.Claims;
using Asp.Versioning;
using LMS_Backend.LMS.Application.DTOs.GenreManagement;
using LMS_Backend.LMS.Application.Interfaces.GenreManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS_Backend.LMS.API.Controllers
{
    [ApiController]
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/genre")]
    [Produces("application/json")]
    [Authorize(Roles = "Administrator")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        private int GetLoggedInUserId()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            return userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllGenres()
        {
            try
            {
                var result = await _genreService.GetAllGenresAsync();
                return Ok(new { success = true, message = "Genres fetched successfully.", data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetGenreById([FromQuery]int id)
        {
            try
            {
                var result = await _genreService.GetGenreByIdAsync(id);
                if (result == null)
                    return NotFound(new { success = false, message = "Genre not found." });

                return Ok(new { success = true, message = "Genre fetched successfully.", data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateGenre([FromBody] CreateGenreDTO createGenreDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { success = false, message = "Invalid input", errors = ModelState });

            try
            {
                var loggedInUser = GetLoggedInUserId();
                var genreId = await _genreService.AddGenreAsync(createGenreDto, loggedInUser);
                return Ok(new { success = true, message = "Genre created successfully.", genreId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateGenre([FromBody] UpdateGenreDTO updateGenreDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { success = false, message = "Invalid input", errors = ModelState });

            try
            {
                var loggedInUser = GetLoggedInUserId();
                var genreId = await _genreService.UpdateGenreAsync(updateGenreDto, loggedInUser);
                return Ok(new { success = true, message = "Genre updated successfully.", genreId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteGenre([FromQuery]int id)
        {
            try
            {
                var result = await _genreService.DeleteGenreAsync(id);
                if (!result)
                    return NotFound(new { success = false, message = "Genre not found." });

                return Ok(new { success = true, message = "Genre deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }
    }
}