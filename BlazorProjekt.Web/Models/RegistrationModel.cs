using BlazorProjekt.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProjekt.Web.Models
{
    public class RegistrationModel
    {
        public string StatusMessage { get; set; }
        public string StatusClass { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public int Sex { get; set; } = 1;

    }
}
