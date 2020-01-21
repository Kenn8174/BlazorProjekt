using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProjekt.Repository.Entities
{
    public class Credential
    {
        public int CredentialId { get; set; }
        public string HashedUsername { get; set; }
        public string HashedPassword { get; set; }
        public int FKOwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}
