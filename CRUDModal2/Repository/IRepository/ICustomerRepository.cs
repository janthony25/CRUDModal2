using CRUDModal2.Models;
using CRUDModal2.Models.Dto;

namespace CRUDModal2.Repository.IRepository
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomersAsync();
        Task AddCustomerAsync(AddCustomerDto model);
        Task<CustomerDetailsDto> GetCustomerByIdAsync(int id);
        Task<bool> UpdateCustomerById(UpdateCustomerDto model);
    }
}
