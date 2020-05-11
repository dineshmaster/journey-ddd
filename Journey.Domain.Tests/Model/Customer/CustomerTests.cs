using Journey.Domain.Model.Customer;
using Journey.Domain.Model.Shared;
using Journey.Infrastructure.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Journey.Domain.Test.Model.CustomerTests
{
    public class CustomerTests
    {
        [Fact]
        public void Customer_created()
        {
            PhoneNumber phoneNumber = new PhoneNumber("+91", "9544856526");
            EmailAddress email = new EmailAddress("jason@gmail.com");
            Password password = new Password("Think@123");
            int customerId = 560;

            Customer customer = new Customer(customerId,email, phoneNumber, password);

            Assert.Equal(560, customer.CustomerId);
            Assert.Equal("9544856526", customer.PhoneNumber.Number);
            Assert.Equal("+91",customer.PhoneNumber.PhoneCode);
            Assert.Equal("jason@gmail.com",customer.EmailAddress.Value);
            Assert.Equal("Think@123",customer.Password.Value);
        }
        [Fact]
        public void Customer_with_invalid_phonecode()
        {
            try
            {
                PhoneNumber phoneNumber = new PhoneNumber("91", "9544856526");
                EmailAddress email = new EmailAddress("jason@gmail.com");
                Password password = new Password("Think@123");
                int customerId = 560;

                Customer customer = new Customer(customerId, email, phoneNumber, password);

                Assert.Null(customer);
            }
            catch (Exception ex)
            {
                Assert.Equal(typeof(InvalidPhoneCountryCodeException), ex.GetType());
            }

        }
        [Fact]
        public void Customer_with_invalid_phone_number()
        {
            try
            {
                PhoneNumber phoneNumber = new PhoneNumber("+91", "+9544856526");
                EmailAddress email = new EmailAddress("jason@gmail.com");
                Password password = new Password("Think@123");
                int customerId = 560;

                Customer customer = new Customer(customerId, email, phoneNumber, password);

                Assert.Null(customer);
            }
            catch (Exception ex)
            {
                Assert.Equal(typeof(InvalidPhoneNumberException), ex.GetType());
            }

        }
        [Fact]
        public void Customer_with_invalid_email_address()
        {
            try
            {
                PhoneNumber phoneNumber = new PhoneNumber("+91", "544856526");
                EmailAddress email = new EmailAddress("jason.gmail.com");
                Password password = new Password("Think@123");
                int customerId = 560;

                Customer customer = new Customer(customerId, email, phoneNumber, password);

                Assert.Null(customer);
            }
            catch (Exception ex)
            {
                Assert.Equal(typeof(InvalidEmailAddressException), ex.GetType());
            }

        }
        [Fact]
        public void Customer_with_invalid_password()
        {
            try
            {
                PhoneNumber phoneNumber = new PhoneNumber("+91", "544856526");
                EmailAddress email = new EmailAddress("jason@gmail.com");
                Password password = new Password("Think123");
                int customerId = 560;

                Customer customer = new Customer(customerId, email, phoneNumber, password);

                Assert.Null(customer);
            }
            catch (Exception ex)
            {
                Assert.Equal(typeof(InvalidPasswordException), ex.GetType());
            }

        }
    }
}
