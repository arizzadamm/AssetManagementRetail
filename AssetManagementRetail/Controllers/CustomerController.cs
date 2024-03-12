using AssetManagementRetail.Models;
using AssetManagementRetail.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly CustomersService _customersService;

    public CustomersController(CustomersService customersService)
    {
        _customersService = customersService;
    }

    // GET: api/customers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customers>>> GetCustomers()
    {
        var customers = await _customersService.GetAllCustomersAsync();
        return Ok(customers);
    }

    // GET: api/customers/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Customers>> GetCustomerById(int id)
    {
        var customer = await _customersService.GetCustomerByIdAsync(id);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }

    // POST: api/customers
    [HttpPost]
    public async Task<ActionResult<int>> AddCustomer(Customers customer)
    {
        var customerId = await _customersService.AddCustomerAsync(customer);
        return CreatedAtAction(nameof(GetCustomerById), new { id = customerId }, customerId);
    }

    // PUT: api/customers/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(Guid id, Customers customer)
    {
        if (id != customer.CustomersOid)
        {
            return BadRequest();
        }
        var result = await _customersService.UpdateCustomerAsync(customer);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }

    // DELETE: api/customers/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var result = await _customersService.DeleteCustomerAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}
