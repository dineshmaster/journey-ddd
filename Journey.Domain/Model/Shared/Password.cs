using Journey.Domain.Model.Base;
using Journey.Infrastructure.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Journey.Domain.Model.Shared
{
    public class Password:ValueObject
    {
        public string Value { get; set; }
        public Password(string password)
        {
            if (!PasswordValidator.Instance.IsValid(password))
                throw new InvalidPasswordException(password);
            this.Value = password;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
