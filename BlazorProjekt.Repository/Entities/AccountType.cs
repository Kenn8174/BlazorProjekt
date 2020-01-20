using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProjekt.Repository.Entities
{
    public class AccountType
    {
        [Key]
        public int AccountTypeId { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Interrest { get; set; }
        public int MinimumAge { get; set; }
        public List<Account> Accounts { get; set; }

    }
}
