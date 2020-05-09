using System.Threading.Tasks;

namespace Journey.Domain.Model.Customer
{
    public interface ICustomerService
    {
        Task<CustomerSignUpResult> SignUpCustomerAsync(Customer customer);
    }
}