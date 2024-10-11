using BankingSystem.Data;
using BankingSystem.Dtos;
using BankingSystem.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountTypeController : ControllerBase
    {
        private readonly IAccountTypeService _accountTypeService;
        private readonly ILogger<AccountTypeController> _logger;
        public AccountTypeController(IAccountTypeService accountTypeService,ILogger<AccountTypeController> logger)
        {
            _accountTypeService = accountTypeService;
            _logger = logger;
        }

        // POST: api/AccountType
        [HttpPost]
        public async Task<IActionResult> Create(CreateAccountTypeDto accountType)
        {
            _logger.LogInformation($"Account type create request recieved, payload: {accountType?.ToString()}");

            if (ModelState.IsValid)
            {
                var Id = await _accountTypeService.CreateAsync(accountType!);

                _logger.LogInformation($"The account type created successfully, account type id:{Id}");

                return CreatedAtAction(nameof(GetAccountType), new { id = Id }, accountType);
            }

            _logger.LogInformation($"Invalid request, payload: {accountType?.ToString()}");
            return BadRequest("Invalid request");
        }

        // GET: api/AccountType
        [HttpGet]
        public async Task<IEnumerable<AccountType>> GetAccountTypes()
        {
            _logger.LogInformation($"GetAccountTypes request recieved");
            return await _accountTypeService.GetAsync();
        }

        // GET: api/AccountType/5
        [HttpGet("{id}")]
        public async Task<AccountType?> GetAccountType(int id)
        {
            _logger.LogInformation($"GetAccountType request recieved, Id:{id}");
            return await _accountTypeService.GetAsync(id);

        }


        // PUT: api/AccountType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccountType(int id, UpdateAccountTypeDto accountType)
        {
            _logger.LogInformation($"UpdateAccountType request recieved, payload:{accountType?.ToString()},Id:{id}");
            if (accountType == null|| id != accountType.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            await _accountTypeService.UpdateAsync(accountType);

            _logger.LogInformation($"AccountType is updated, Id: {id}");
            return NoContent();
        }

        // DELETE: api/AccountType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountType(int id)
        {
            _logger.LogInformation($"AccountType delete request recieved, Id: {id}");
            await _accountTypeService.DeleteAsync(id);

            _logger.LogInformation($"AccountType is deleted, Id: {id}");

            return NoContent();
        }
    }
}
