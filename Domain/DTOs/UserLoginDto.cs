﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class UserLoginDto
    {
        [Required]
        [MaxLength(50)]
        public string IC { get; set; }
    }
}
