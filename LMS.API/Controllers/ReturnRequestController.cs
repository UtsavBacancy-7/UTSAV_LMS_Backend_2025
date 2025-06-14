using System.Security.Claims;
using Asp.Versioning;
using LMS_Backend.LMS.Application.DTOs.BookTransaction;
using LMS_Backend.LMS.Application.Interfaces.BookTransactions;
using LMS_Backend.LMS.Common.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace LMS_Backend.LMS.API.Controllers
{
    [ApiController]
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/transactions")]
    [Produces("application/json")]
    [Authorize(Roles = "Administrator")]
    public class ReturnRequestController : ControllerBase
    {
        private readonly IReturnService _returnService;

        public ReturnRequestController(
            IReturnService returnService)
        {
            _returnService = returnService;
        }

        private int GetLoggedInUserId()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            return userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;
        }

        [HttpGet("return-requests")]
        public async Task<IActionResult> GetAllReturnRequests()
        {
            try
            {
                var returnRequests = await _returnService.GetAllReturnRequestsAsync();
                return Ok(returnRequests);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("return-requests-by-id")]
        public async Task<IActionResult> GetReturnRequestById([FromQuery]int id)
        {
            try
            {
                var returnRequest = await _returnService.GetReturnRequestByIdAsync(id);

                if (returnRequest == null)
                {
                    return NotFound();
                }

                return Ok(returnRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet("users/return-requests")]
        public async Task<IActionResult> GetReturnRequestsByUserId([FromQuery]int userId)
        {
            try
            {
                var returnRequests = await _returnService.GetReturnRequestsByUserIdAsync(userId);

                if (returnRequests == null || !returnRequests.Any())
                {
                    throw new DataNotFoundException<string>($"No Request found with {userId} id.");
                }

                return Ok(returnRequests);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("return-requests")]
        public async Task<IActionResult> CreateReturnRequest([FromBody] ReturnRequestCreateDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdBy = GetLoggedInUserId();
                var result = await _returnService.AddReturnRequestAsync(request, createdBy);

                if (result)
                {
                    return CreatedAtAction(nameof(GetReturnRequestById), new { id = request.BorrowRequestId }, null);
                }

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create return request");
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPatch("return-requests")]
        public async Task<IActionResult> UpdateReturnRequestStatus(
            [FromQuery]int id,
            [FromBody] JsonPatchDocument<ReturnRequestUpdateStatusDTO> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest("Patch document is required");
            }

            try
            {
                var updatedBy = GetLoggedInUserId();
                var result = await _returnService.PatchReturnRequestAsync(id, patchDoc, updatedBy);

                if (result)
                {
                    return NoContent();
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("return-requests")]
        public async Task<IActionResult> DeleteReturnRequest([FromQuery]int id)
        {
            try
            {
                var deletedBy = GetLoggedInUserId();
                var result = await _returnService.DeleteReturnRequestAsync(id, deletedBy);

                if (result)
                {
                    return NoContent();
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}