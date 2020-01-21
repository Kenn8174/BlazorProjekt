using BlazorProjekt.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProjekt.Service.Interfaces
{
    public interface IAccountService : IGenericService<AccountDTO>
    {
        /// <summary>
        /// Gets the <see cref="AccountDTO"/> with the matching accountId or returns null if the <see cref="AccountDTO"/> does not exist.
        /// </summary>
        Task<AccountDTO> GetAccountById(int accountId);

        /// <summary>
        /// Deposits an amount into the <see cref="AccountDTO"/> with a matching accountId.
        /// </summary>
        Task Deposit(int accountId, decimal amount);

        /// <summary>
        /// Withdraws an amount from the <see cref="AccountDTO"/> with a matching accountId.
        /// </summary>
        Task Withdraw(int accountId, decimal amount);

        /// <summary>
        /// Charges interests for all bank accounts.
        /// </summary>
        Task ChargeInterest();
    }
}
