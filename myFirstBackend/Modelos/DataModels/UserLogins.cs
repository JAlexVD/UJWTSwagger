﻿using System.ComponentModel.DataAnnotations;

namespace myFirstBackend.Modelos.DataModels
{
    public class UserLogins
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
