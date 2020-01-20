using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProjekt.Service.DataTransferObjects
{
    public class AccountDTO
    {
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public int FKOwnerId { get; set; }
        public OwnerDTO Owner { get; set; }
        public int FKAccountTypeId { get; set; }
        public AccountTypeDTO AccountType { get; set; }
    }
}
