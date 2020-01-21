using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProjekt.Repository.Entities
{
    public class Owner
    {
        [Key]
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Admin { get; set; }
        public List<Account> Accounts { get; set; }
        public int FKSexId { get; set; }
        public Sex Sex { get; set; }
        public Credential Credential { get; set; }
    }
}
