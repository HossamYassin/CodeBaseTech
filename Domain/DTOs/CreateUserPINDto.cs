using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class CreateUserPINDto
    {
        [Required]
        [MaxLength(50)]
        public string IC { get; set; }
        [Required]
        [MaxLength(6)]
        public string PIN { get; set; }
    }
}
