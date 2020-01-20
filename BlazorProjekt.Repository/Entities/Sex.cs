using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProjekt.Repository.Entities
{
    public class Sex
    {
        [Key]
        public int SexId { get; set; }
        public string Name { get; set; }
        public List<Owner> Owners { get; set; }
    }
}
