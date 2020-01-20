using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProjekt.Service.DataTransferObjects
{
    public class OwnerDTO
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Admin { get; set; }
        public List<AccountDTO> Accounts { get; set; }
        public int FKSexId { get; set; }
        public SexDTO Sex { get; set; }
    }
}
