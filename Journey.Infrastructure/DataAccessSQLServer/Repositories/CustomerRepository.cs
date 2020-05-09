using Dapper;
using Journey.Domain.Model.Customer;
using Journey.Infrastructure.DataAccessSQLServer.ConnectionCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Journey.Infrastructure.DataAccessSQLServer.Repositories
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
            spParams.Add("@EmailAddress", customer.EmailAddress);
            spParams.Add("@PhoneNumber",customer.PhoneNumber.PhoneNumberWithCode);
            spParams.Add("@Password",customer.Password);
            spParams.Add("@CustomerId",customer.CustomerId,null,ParameterDirection.Output);

            using(IDbConnection connection = ConnectionFactory.SQLConnection)
            {
                await connection.ExecuteAsync(spName, spParams,commandType: CommandType.StoredProcedure);
                int customerId = spParams.Get<int>("@CustomerId");
                customerSignUpResult = new CustomerSignUpResult(customerId);
                return customerSignUpResult;
            }
        }

        public async Task GenerateSignUpOTPAsync(int customerId,long otp,DateTime validUpTo)
        {
            var spName = "spGenerateSignUpOTP";
            var spParams = new DynamicParameters();
            spParams.Add("@CustomerId",customerId);
            spParams.Add("@OTP",otp);
            spParams.Add("@ValidUpTo",validUpTo,dbType:DbType.DateTime);

            using (IDbConnection connection = ConnectionFactory.SQLConnection)
            {
                int rowsAffected = await connection.ExecuteAsync(spName, spParams, commandType: CommandType.StoredProcedure);
            }

        }
    }
}
