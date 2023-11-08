﻿using WatchDog.src.Attributes;

namespace WatchDogCompleteApiNet6.Models
{
    public class Login
    {
        public string? Username { get; set; }

        [SensitiveString]
        public string? Password { get; set; }
    }
}
