﻿using System.ComponentModel.DataAnnotations;

namespace Phoenix.Models
{
    public class Login
    {
        [Required]
        public string UserName { get; set; }
        //[Required]
        public string Password { get; set; }
    }
}