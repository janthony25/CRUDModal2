using CRUDModal2.Models.Dto;
using CRUDModal2.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CRUDModal2.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        // GET: Get Customer List
        public async Task<IActionResult> GetCustomers()
        {
            var customer = await _customerRepository.GetCustomersAsync();
            return Json(customer);
        }

        // POST: Add customer
        public async Task<IActionResult> AddCustomer(AddCustomerDto model)
        {
            if (ModelState.IsValid)
            {
                await _customerRepository.AddCustomerAsync(model);
                return Json("Customer Added Successfully!");
            }
            else
            {
                return Json("Unable to add customer");
            }
        }

        // GET: Get Customers Details by id
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);

            if (customer != null)
            {
                return Json(customer);
            }
                return Json("Invalid Id");

        }

        // POST: Update Customer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateCustomerDto model)
        {
            if (ModelState.IsValid)
            {
                await _customerRepository.UpdateCustomerById(model);
                return Json("Customer successfully edited.");
            }

            return Json("Unable to update customer.");
        }
    }
}
