using BankingSystem.Dtos;
using BankingSystem.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IAccountService _accountService;
        public TransactionController(ITransactionService transactionService,IAccountService accountService)
        {
            _transactionService = transactionService;
            _accountService = accountService;
        }

        [HttpPost]
        [Route("deposit")]
        public async Task<IActionResult> Deposit(DepositWithdrawalDto depositWithdrawalDto)
        {
            if (ModelState.IsValid) {
                //var account = await _accountService.GetAsync(depositWithdrawalDto.AccountId);
                //if (account == null)
                //{
                //    return NotFound();
                //}
                //if (account.IsClosed)
                //{
                //    return BadRequest("The account is closed");
                //}

                await _transactionService.DepositAsync(depositWithdrawalDto);


                return NoContent();
            }

            return BadRequest();
            
        }

        [HttpPost]
        [Route("withdrawal")]
        public async Task<IActionResult> Withdrawal(DepositWithdrawalDto depositWithdrawalDto)
        {
            if (!ModelState.IsValid) { 
                return BadRequest();
            }

            //var account = await _accountService.GetAsync(depositWithdrawalDto.AccountId);
            //if (account == null)
            //{
            //    return NotFound();
            //}

            //if (account.IsClosed)
            //{
            //    return BadRequest("The account is closed");
            //}
           
            await _transactionService.WithdrawalAsync(depositWithdrawalDto);

            return NoContent();
        }

        [HttpPost]
        [Route("transfer")]
        public async Task<IActionResult> Transfer(TransferDto transferDto)
        {

            if (ModelState.IsValid)
            {
                await _transactionService.TransferAsync(transferDto);

                return NoContent();
            }

            return BadRequest();
            
        }
    }
}
