using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Addie.Models
{
    public class User : BaseEntity
    {
        [MaxLength(55)]
        public string Username { get; set; }
        
        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }
    }
}