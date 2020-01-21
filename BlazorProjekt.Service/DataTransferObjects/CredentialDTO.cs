using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProjekt.Service.DataTransferObjects
{
    public class CredentialDTO
    {
        public int CredentialId { get; set; }
        public string HashedUsername { get; set; }
        public string HashedPassword { get; set; }
        public int FKOwnerId { get; set; }
        public OwnerDTO Owner { get; set; }
    }
}
