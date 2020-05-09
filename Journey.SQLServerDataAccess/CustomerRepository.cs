using Dapper;
using Journey.Domain.Model.Customer;
using Journey.SQLServerDataAccess.ConnectionCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Journey.SQLServerDataAccess
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
    }
}
