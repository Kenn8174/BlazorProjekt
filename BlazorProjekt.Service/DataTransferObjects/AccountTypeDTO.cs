using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProjekt.Service.DataTransferObjects
{
    public class AccountTypeDTO
    {
        public int AccountTypeId { get; set; }
        public string Name { get; set; }
        public decimal Interrest { get; set; }
        public int MinimumAge { get; set; }
        public List<AccountDTO> Accounts { get; set; }
    }
}
