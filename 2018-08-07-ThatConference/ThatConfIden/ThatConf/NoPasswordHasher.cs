﻿using Microsoft.AspNetCore.Identity;

namespace ThatConfIden.ThatConf
{
    public class NoPasswordHasher : IPasswordHasher<CustomUser>
    {
        public string HashPassword(CustomUser user, string password)
        {
            return password;
        }

        public PasswordVerificationResult VerifyHashedPassword(CustomUser user, string hashedPassword,
            string providedPassword)
        {
            return PasswordVerificationResult.Success;
        }
    }
}