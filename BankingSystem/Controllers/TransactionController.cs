using BankingSystem.Data;
using BankingSystem.Dtos;
using BankingSystem.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IAccountService _accountService;
        private readonly ILogger<TransactionController> _logger;
        public TransactionController(ITransactionService transactionService,IAccountService accountService, ILogger<TransactionController> logger)
        {
            _transactionService = transactionService;
            _accountService = accountService;
            _logger = logger;
        }

        [HttpPost]
        [Route("deposit")]
        public async Task<IActionResult> Deposit(DepositWithdrawalDto depositWithdrawalDto)
        {
            _logger.LogInformation($"Deposit request recieved, payload: {depositWithdrawalDto?.ToString()}");

            if (ModelState.IsValid) {


                await _transactionService.DepositAsync(depositWithdrawalDto!);

                _logger.LogInformation($"Deposit successfully processed");
                return NoContent();
            }
            _logger.LogInformation($"Invalid request");
            return BadRequest();
            
        }

        [HttpPost]
        [Route("withdrawal")]
        public async Task<IActionResult> Withdrawal(DepositWithdrawalDto depositWithdrawalDto)
        {
            _logger.LogInformation($"Withdrawal request recieved, payload: {depositWithdrawalDto?.ToString()}");

            if (!ModelState.IsValid) {
                _logger.LogInformation($"Invalid request");
                return BadRequest();
            }
           
            await _transactionService.WithdrawalAsync(depositWithdrawalDto!);
            _logger.LogInformation($"Withdrawal successfully processed");
            return NoContent();
        }

        [HttpPost]
        [Route("transfer")]
        public async Task<IActionResult> Transfer(TransferDto transferDto)
        {
            _logger.LogInformation($"Transfer request recieved, payload: {transferDto?.ToString()}");

            if (ModelState.IsValid)
            {
                await _transactionService.TransferAsync(transferDto!);
                _logger.LogInformation($"Transfer successfully processed");
                return NoContent();
            }

            _logger.LogInformation($"Invalid request");
            return BadRequest();
            
        }
    }
}
