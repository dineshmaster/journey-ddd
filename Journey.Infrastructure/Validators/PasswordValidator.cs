using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Journey.Infrastructure.Validators
{
    public  class PasswordValidator:ValidatorBase
    {
        private static int MIN_LETTERS_COUNT = 2;
        private static int MIN_DIGITS_COUNT = 2;
        private static int PASSWORD_MIN_LENGTH = 6;
        private static int PASSWORD_MAX_LENGTH = 10;

        public bool IsValid(string password)
        {
            return IsValidPassword(password);
        }
        bool IsValidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password) && 
                password.Length>= PASSWORD_MIN_LENGTH && 
                password.Length<=PASSWORD_MAX_LENGTH &&
               (password.Any(c => IsLetter(c)) 
                    && password.Count(c => IsLetter(c)) >= MIN_LETTERS_COUNT) &&
               (password.Any(c => IsDigit(c)) 
                    && password.Count(c => IsDigit(c)) >= MIN_DIGITS_COUNT) &&
               password.Any(c => IsSymbol(c));
        }
        bool IsLetter(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
        }

        bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }

        bool IsSymbol(char c)
        {
            return c > 32 && c < 127 && !IsDigit(c) && !IsLetter(c);
        }

        private static PasswordValidator _instance;
        public static PasswordValidator Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PasswordValidator();
                return _instance;
            }
        }
    }
}
