using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProjekt.Repository.Entities
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Balance { get; set; }
        public int FKOwnerId { get; set; }
        public Owner Owner { get; set; }
        public int FKAccountTypeId { get; set; }
        public AccountType AccountType { get; set; }
    }
}
