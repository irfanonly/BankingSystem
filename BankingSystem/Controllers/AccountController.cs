using BankingSystem.Dtos;
using BankingSystem.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BankingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        //[HttpPost]
        //[Route("create")]
        //public async Task<IActionResult> Create(CreateAccountDto account)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var Id = await _accountService.CreateAsync(account);

        //        return Created(Url.Action("Details"), new { id = Id });
        //    }

        //    return BadRequest("Invalid request");
        //}

        [HttpGet]
        [Route("view")]
        public async Task<IActionResult> View(Guid Id)
        {
            var account = await _accountService.GetAsync(Id);
            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }
    }
}
