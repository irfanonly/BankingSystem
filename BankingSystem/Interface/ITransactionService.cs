using BankingSystem.Dtos;

namespace BankingSystem.Interface
{
    public interface ITransactionService
    {
        Task DepositAsync(DepositWithdrawalDto depositWithdrawalDto);
        Task TransferAsync(TransferDto transferDto);
        Task WithdrawalAsync(DepositWithdrawalDto depositWithdrawalDto);
    }
}
