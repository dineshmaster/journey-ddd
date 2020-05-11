using Journey.Domain.Model.Base;
using Journey.Infrastructure.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Journey.Domain.Model.Shared
{
    public class EmailAddress:ValueObject
    {
        public string Value { get; private set; }
        public EmailAddress(string emailAddress)
        {
            if (!EmailAddressValidator.Instance.IsValid(emailAddress))
                throw new InvalidEmailAddressException(emailAddress);
            this.Value = emailAddress;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
