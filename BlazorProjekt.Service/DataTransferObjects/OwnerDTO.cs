using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProjekt.Service.DataTransferObjects
{
    public class OwnerDTO
    {
        public int OwnerId { get; set; }
        [Required]
        [RegularExpression(@"[ABC]{1}", ErrorMessage = "WTF U DOING!")]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        public bool Admin { get; set; }
        public List<AccountDTO> Accounts { get; set; }
        public int FKSexId { get; set; }
        public SexDTO Sex { get; set; }
        public CredentialDTO Credential { get; set; }
    }
}
