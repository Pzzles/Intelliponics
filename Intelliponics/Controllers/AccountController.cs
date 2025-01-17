using Intelliponics.Models;
using Intelliponics.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Intelliponics.Controllers
{
    [Route("v1/account")]
    public class AccountController : Controller
    {
        private readonly IAdminService _service;

        public AccountController(IAdminService service)
        {
            _service = service;
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        [Route("users")]
        public async Task<ActionResult> FetchUsers()
        {
            try
            {
                var users = await _service.FetchAdminEmployeesAsync();
                return Ok(users);  // Return the user data as JSON
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("users/{id}")]
        public async Task<ActionResult> FetchUser(int id)
        {
            try
            {
                var user = await _service.FetchAdminEmployeeByIdAsync(id);
                if (user == null)
                {
                    return NotFound();  // Return 404 if user not found
                }
                return Ok(user);  // Return the user data as JSON
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [Route("users")]
        public async Task<ActionResult> Register([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // Return 400 if model state is invalid
            }

            try
            {
                await _service.AddAdminEmployeeAsync(user);
                return CreatedAtAction(nameof(FetchUser), new { id = user.EmpID }, user);  // Return 201 with location header
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        [Route("users/{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] User user)
        {
            if (id != user.EmpID)
            {
                return BadRequest("ID mismatch");  // Return 400 if ID in URL does not match ID in body
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // Return 400 if model state is invalid
            }

            try
            {
                await _service.UpdateAdminEmployeeAsync(user);
                return NoContent();  // Return 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete]
        [Route("users/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var user = await _service.FetchAdminEmployeeByIdAsync(id);
                if (user == null)
                {
                    return NotFound();  // Return 404 if user not found
                }

                await _service.DeleteAdminEmployeeAsync(id);
                return NoContent();  // Return 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}