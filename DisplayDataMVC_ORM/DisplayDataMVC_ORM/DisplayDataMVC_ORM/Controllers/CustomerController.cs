using DisplayDataMVC_ORM.Models;
using DisplayDataMVC_ORM.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DisplayDataMVC_ORM.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICommonRepository<Customer> _customerRepository;

        public CustomerController(ICommonRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            ViewBag.pageTitle = "Customer List";
            var customers = await _customerRepository.GetAllAsync();
            return View(customers);
        }
    }
}
