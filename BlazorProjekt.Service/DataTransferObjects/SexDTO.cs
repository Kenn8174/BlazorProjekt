using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProjekt.Service.DataTransferObjects
{
    public class SexDTO
    {
        public int SexId { get; set; }
        public string Name { get; set; }
        public List<OwnerDTO> Owners { get; set; }
    }
}
