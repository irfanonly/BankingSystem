using BankingSystem.Data;
using BankingSystem.Dtos;
using BankingSystem.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypeController : ControllerBase
    {
        private readonly IAccountTypeService _accountTypeService;
        public AccountTypeController(IAccountTypeService accountTypeService)
        {
            _accountTypeService = accountTypeService;
        }

        // POST: api/AccountType
        [HttpPost]
        public async Task<IActionResult> Create(CreateAccountTypeDto account)
        {
            if (ModelState.IsValid)
            {
                var Id = await _accountTypeService.CreateAsync(account);

                return CreatedAtAction(nameof(GetAccountType), new { id = Id }, account);
            }

            return BadRequest("Invalid request");
        }

        // GET: api/AccountType
        [HttpGet]
        public async Task<IEnumerable<AccountType>> GetAccountTypes()
        {
            return await _accountTypeService.GetAsync();
        }

        // GET: api/AccountType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountType>> GetAccountType(int id)
        {
            var accountType = await _accountTypeService.GetAsync(id);

            if (accountType == null)
            {
                return NotFound();
            }

            return accountType;
        }


        // PUT: api/AccountType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccountType(int id, UpdateAccountTypeDto accountType)
        {
            if (id != accountType.Id)
            {
                return BadRequest();
            }

            var existingAccountType = await _accountTypeService.GetAsync(id);
            if (existingAccountType == null)
            {
                return NotFound();
            }

            await _accountTypeService.UpdateAsync(existingAccountType, accountType);

            

            return NoContent();
        }

        // DELETE: api/AccountType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountType(int id)
        {
            var accountType = await _accountTypeService.GetAsync(id);
            if (accountType == null)
            {
                return NotFound();
            }

            await _accountTypeService.DeleteAsync(accountType);

            return NoContent();
        }
    }
}
