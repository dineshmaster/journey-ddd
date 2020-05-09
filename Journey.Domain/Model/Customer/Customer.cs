using System;
using System.Collections.Generic;
using System.Text;

namespace Journey.Domain.Model.Customer
{
	public sealed class Customer
	{
		public int CustomerId { get; private set; }
		public string EmailAddress { get; private set; }
		public string Password { get; private set; }
		public PhoneNumber PhoneNumber { get; private set; }
		public bool PhoneNumberVarified { get; private set; }
		public bool EmailVerified { get; private set; }
		public Customer(string emailAddress, PhoneNumber phoneNumber, string password)
		{
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
