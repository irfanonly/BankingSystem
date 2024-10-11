using BankingSystem.Dtos;
using BankingSystem.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BankingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<AccountController> _logger;    
        public AccountController(IAccountService accountService, ILogger<AccountController> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(CreateAccountDto account)
        {
            _logger.LogInformation($"Account create request recieved, payload: {account?.ToString()}");
            if (ModelState.IsValid)
            {
                var Id = await _accountService.CreateAsync(account!);

                _logger.LogInformation($"Account Successfully Created {Id}");
                return CreatedAtAction(nameof(View), new { id = Id });
            }

            _logger.LogInformation($"Invalid request");
            return BadRequest("Invalid request");
        }

        [HttpGet]
        [Route("view")]
        public async Task<IActionResult> View(Guid Id)
        {
            _logger.LogInformation($"Account view requested, Id: {Id}");
            var account = await _accountService.GetDtoAsync(Id);

            return Ok(account);
        }


        [HttpPut("close/{Id}")]
        public async Task<IActionResult> Close(Guid Id)
        {
            _logger.LogInformation($"Account closure requested, Id: {Id}");
            
            await _accountService.CloseAsync(Id);

            return NoContent();
        }
    }
}
