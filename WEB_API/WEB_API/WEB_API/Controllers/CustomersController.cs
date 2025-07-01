using WEB_API.Repository;
using Microsoft.AspNetCore.Mvc;
using WEB_API.Models;
namespace WEB_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{

    private readonly ICommonRepository<Customer> _customerRepository;

    public CustomersController(ICommonRepository<Customer> customerRepository)
    {
        _customerRepository = customerRepository;
    }


    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> getAllCustomers()
    {
        var customers = await _customerRepository.GetAllAsync();

        if (customers.Count > 0)
        {
            return Ok(customers);
        }
        else
        {
            return NotFound("Customers Not Found...");

        }
    }


    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Customer>> getCustomer(int id)
    {
        var customer = await _customerRepository.GetDetailsAsync(id);

        if (customer != null)
        {
            return Ok(customer);
        }
        else
        {
            return NotFound($"{id} => this Customer Not Found...");
        }

    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<Customer>> AddCustomer(Customer customer)
    {
        if (ModelState.IsValid)
        {
            int result = await _customerRepository.InsertAsync(customer);

            if (result > 0)
            {
                return CreatedAtAction(
                    actionName: "GetCustomer", 
                    routeValues: new { id = customer.CustomerId },
                    value: customer
                );
            }
            else
            {
                return BadRequest("Unable to add customer...");
            }
        }
        else
        {
            return BadRequest("Ensure all details are correct");
        }
    }


    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult<Customer>> UpdateCustomer(Customer customer)
    {
        if (ModelState.IsValid)
        {
            int result = await _customerRepository.UpdateAsync(customer);
            if (result > 0)
            {
                return NoContent();
            }
            else
            {
                return BadRequest("Modification Not Successful...");
            }
        }
        else
        {
            return BadRequest("Invalid Data...");
        }
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        int result = await _customerRepository.DeleteAsync(id);
        if (result > 0)
        {
            return Ok($"{id} => Customer Deleted Sucessfully...");
        }
        else
        {
            return NotFound($"{id} => this Customer Not Found...");
        }


    }
}