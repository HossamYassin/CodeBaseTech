﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class CreateUserDto
    {
        [Required]
        [MaxLength(50)]
        public string IC { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [EmailAddress]
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(15)]
        public string Mobile { get; set; }
    }
}
