﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string IC { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Mobile { get; set; }

        public string? PIN { get; set; }
        public string? EmailDigits {  get; set; }
        public string? MobileDigits { get; set; }
    }
}
