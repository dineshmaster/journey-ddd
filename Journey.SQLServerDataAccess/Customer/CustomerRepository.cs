using Dapper;
using Journey.Domain.Model.Customer;
using Journey.Domain.Model.Shared;
using Journey.SQLServerDataAccess.ConnectionCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Journey.SQLServerDataAccess.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IConnectionFactory ConnectionFactory;
        public CustomerRepository(IConnectionFactory connectionFactory)
        {
            this.ConnectionFactory = connectionFactory;
        }
        public async Task<CustomerSignUpResult> AddAsync(Customer customer)
        {
            CustomerSignUpResult customerSignUpResult = null;
            var spName = "spCustomerSignUp";
            var spParams = new DynamicParameters();
            spParams.Add("@EmailAddress", customer.EmailAddress.Value);
            spParams.Add("@PhoneCode", customer.PhoneNumber.PhoneCode);
            spParams.Add("@PhoneNumber", customer.PhoneNumber.Number);
            spParams.Add("@Password", customer.Password.Value);
            spParams.Add("@CustomerId", customer.CustomerId, null, ParameterDirection.Output);

            using (IDbConnection connection = ConnectionFactory.SQLConnection)
            {
                await connection.ExecuteAsync(spName, spParams, commandType: CommandType.StoredProcedure);
                int customerId = spParams.Get<int>("@CustomerId");
                customerSignUpResult = new CustomerSignUpResult(customerId);
                return customerSignUpResult;
            }
        }

        public async Task<bool> GenerateSignUpOTPAsync(CustomerOTP customerOTP)
        {
            var spName = "spGenerateSignUpOTP";
            var spParams = new DynamicParameters();
            spParams.Add("@CustomerId", customerOTP.CustomerId);
            spParams.Add("@OTP", customerOTP.OTP);
            spParams.Add("@ValidUpTo", customerOTP.ValidUpTo, dbType: DbType.DateTime);

            using (IDbConnection connection = ConnectionFactory.SQLConnection)
            {
                int rowsAffected = await connection.ExecuteAsync(spName, spParams, commandType: CommandType.StoredProcedure);
                return rowsAffected > 0;
            }
        }
        public async Task<CustomerOTP> FindOTP(int customerId, double OTP)
        {
            var spName = "spFindCustomerSignUpOTPForVerification";
            var spParams = new DynamicParameters();
            spParams.Add("@CustomerId", customerId);
            spParams.Add("@OTP", OTP);

            using (IDbConnection connection = ConnectionFactory.SQLConnection)
            {
                CustomerOTP customerOTP = await connection.QueryFirstAsync<CustomerOTP>(spName, spParams, commandType: CommandType.StoredProcedure);
                return customerOTP;
            }
        }
        public async Task<CustomerExistanceResult> CustomerExistsAysnc(Customer customer)
        {
            var spName = "spCustomerExists";
            var spParams = new DynamicParameters();
            spParams.Add("@EmailAddress", customer.EmailAddress.Value);
            spParams.Add("@PhoneNumberWithCode", customer.PhoneNumber.PhoneNumberWithCode);

            using (IDbConnection connection = ConnectionFactory.SQLConnection)
            {
                dynamic result = await connection.QueryAsync(spName, spParams, commandType: CommandType.StoredProcedure);
                if (result != null && result.Count>0)
                {
                    var firstRow = result[0];
                    PhoneNumber phoneNumber = new PhoneNumber(firstRow.PhoneCode, firstRow.PhoneNumber);
                    EmailAddress emailAddress = new EmailAddress(firstRow.EmailAddress);
                    CustomerExistanceResult customerExistanceResult = new CustomerExistanceResult(emailAddress, phoneNumber);
                    return customerExistanceResult;
                }
                
            }
            return null;
        }
    }
}
