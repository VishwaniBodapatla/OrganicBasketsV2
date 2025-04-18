﻿using System.ComponentModel.DataAnnotations;

namespace OrganicBasketsV2.Models
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required, DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
