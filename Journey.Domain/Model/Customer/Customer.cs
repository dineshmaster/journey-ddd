using Journey.Domain.Model.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Journey.Domain.Model.Customer
{
	public sealed class Customer
	{
		public int CustomerId { get; private set; }
		public EmailAddress EmailAddress { get; private set; }
		public Password Password { get; private set; }
		public PhoneNumber PhoneNumber { get; private set; }
		public bool PhoneNumberVarified { get; private set; }
		public bool EmailVerified { get; private set; }
		public Customer()
		{

		}
		public Customer(EmailAddress emailAddress, PhoneNumber phoneNumber, Password password)
		{
			this.EmailAddress = emailAddress;
			this.PhoneNumber = phoneNumber;
			this.Password = password;
		}
		public Customer(int customerId,EmailAddress emailAddress, PhoneNumber phoneNumber, Password password)
		{
			this.CustomerId = customerId;
			this.EmailAddress = emailAddress;
			this.PhoneNumber = phoneNumber;
			this.Password = password;
		}
		public void MarkAsEmailVerified()
		{
			this.EmailVerified = true;
		}
		public void MarkAsPhoneNumberVerified()
		{
			this.PhoneNumberVarified = true;
		}
	}
}
