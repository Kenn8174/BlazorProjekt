using BlazorProjekt.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProjekt.Repository.Interfaces
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        /// <summary>
        /// Gets the <see cref="Account"/> with the matching accountId or throws if the <see cref="Account"/> does not exist
        /// </summary>
        Task<Account> GetAccountById(int accountId);

        /// <summary>
        /// Deposits an amount into the <see cref="Account"/> with a matching accountId or throws if the <see cref="Account"/> does not exist 
        /// </summary>
        Task Deposit(int accountId, decimal amount);

        /// <summary>
        /// Withdraws an amount from the <see cref="Account"/> with a matching accountId or throws if the <see cref="Account"/> does not exist 
        /// </summary>
        Task Withdraw(int accountId, decimal amount);

        /// <summary>
        /// Charges interests for all bank accounts
        /// </summary>
        Task ChargeInterest();
    }
}
