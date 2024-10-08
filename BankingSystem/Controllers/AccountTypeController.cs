using BankingSystem.Dtos;
using BankingSystem.Interface;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(CreateAccountTypeDto account)
        {
            if (ModelState.IsValid)
            {
                var Id = await _accountTypeService.CreateAsync(account);

                return Created(Url.Action("Details"), new { id = Id });
            }

            return BadRequest("Invalid request");
        }
    }
}
