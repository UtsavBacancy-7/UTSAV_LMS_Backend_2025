using LMS_Backend.LMS.Application.Interfaces.UserManagement;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LMS_Backend.LMS.Application.Interfaces.BookTransactions;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using LMS_Backend.LMS.Application.DTOs.BookTransaction;
using Microsoft.AspNetCore.JsonPatch;
using LMS_Backend.LMS.Domain.Entities;
using LMS_Backend.LMS.Common.Exceptions;

namespace LMS_Backend.LMS.API.Controllers
{
    [ApiController]
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/transactions")]
    [Produces("application/json")]
    [Authorize(Roles = "Administrator, Librarian, Student")]
    public class TransactionController : ControllerBase
    {
        private readonly IBorrowService _borrowService;

        public TransactionController(IBorrowService borrowService)
        {
            _borrowService = borrowService;
        }

        private int GetLoggedInUserId()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            return userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;
        }

        [HttpGet("borrow-requests")]
        public async Task<IActionResult> GetAllBorrowRequests()
        {
            try
            {
                var requests = await _borrowService.GetAllBorrowRequestsAsync();
                return requests.Any() ? Ok(requests) : NotFound("No borrow requests found");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving borrow requests");
            }
        }

        [HttpGet("borrow-requests-by-id")]
        public async Task<IActionResult> GetBorrowRequestById([FromQuery]int id)
        {
            try
            {
                var request = await _borrowService.GetBorrowRequestByIdAsync(id);
                return request != null ? Ok(request) : NotFound($"Borrow request with ID {id} not found");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving borrow request");
            }
        }

        [HttpPost("borrow-requests")]
        public async Task<IActionResult> CreateBorrowRequest([FromBody] BorrowRequestCreateDTO request)
        {
            try
            {
                var createdBy = GetLoggedInUserId();
                var success = await _borrowService.AddBorrowRequestAsync(request, createdBy);

                return success ? NoContent() : NotFound($"Borrow request is not created.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPatch("borrow-requests")]
        public async Task<IActionResult> UpdateBorrowRequest([FromQuery] int id, [FromBody] JsonPatchDocument<BorrowRequestUpdateStatusDTO> patchDoc)
        {
            try
            {
                if (patchDoc == null)
                {
                    return BadRequest("Patch document is required");
                }

                var updatedBy = GetLoggedInUserId();
                var success = await _borrowService.PatchBorrowRequestAsync(id, patchDoc, updatedBy);

                return success ? NoContent() : NotFound($"Borrow request with ID {id} not found");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("borrow-requests")]
        public async Task<IActionResult> DeleteBorrowRequest([FromQuery]int id)
        {
            try
            {
                var deletedBy = GetLoggedInUserId();
                var success = await _borrowService.DeleteBorrowRequestAsync(id, deletedBy);

                return success ? NoContent() : NotFound($"Borrow request with ID {id} not found");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting borrow request");
            }
        }
    }
}