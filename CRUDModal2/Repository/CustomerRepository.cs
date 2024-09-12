using Azure.Core;
using Azure.Identity;
using CRUDModal2.Data;
using CRUDModal2.Models;
using CRUDModal2.Models.Dto;
using CRUDModal2.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CRUDModal2.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _dataContext;

        public CustomerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddCustomerAsync(AddCustomerDto model)
        {
            var customer = new Customer
            {
                CustomerName = model.CustomerName,
                CustomerEmail = model.CustomerEmail,
                CustomerNumber = model.CustomerNumber
            };

            _dataContext.Customers.Add(customer);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<CustomerDetailsDto> GetCustomerByIdAsync(int id)
        {
            return await _dataContext.Customers
                .Where(c => c.CustomerId == id)
                .Select(c => new CustomerDetailsDto
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    CustomerEmail = c.CustomerEmail,
                    CustomerNumber = c.CustomerNumber,
                    DateAdded = c.DateAdded
                }).FirstOrDefaultAsync();



        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _dataContext.Customers.ToListAsync();
        }

        public async Task<bool> UpdateCustomerById(UpdateCustomerDto model)
        {
            // Fetch customer by id
            var customer = await _dataContext.Customers.FindAsync(model.CustomerId);

            customer.CustomerName = model.CustomerName;
            customer.CustomerEmail = model.CustomerEmail;
            customer.CustomerNumber = model.CustomerNumber;

            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}
