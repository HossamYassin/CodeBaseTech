using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class MobileDigits
    {
        [Required]
        public string Mobile {  get; set; }

        [Required]
        [MaxLength(6)]
        public string Digits { get; set; }
    }
}
