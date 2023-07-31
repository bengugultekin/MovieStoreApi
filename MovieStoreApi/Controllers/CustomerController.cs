using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieStoreApi.Application.CustomerOperations.Commands;
using MovieStoreApi.Application.CustomerOperations.Queries;
using MovieStoreApi.Application.CustomerOperations.Queries.GetCustomerDetail;

namespace MovieStoreApi;

[ApiController]
[Route("[controller]s")]
public class CustomerController : ControllerBase
{
    private readonly IMovieStoreDbContext _context;
    private readonly IMapper _mapper;

    public CustomerController(IMovieStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetCustomers()
    {
        GetCustomersQuery query = new GetCustomersQuery(_context, _mapper);
        var obj = query.Handle();
        return Ok(obj);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        CustomerDetailViewModel result;
        GetCustomerDetailQuery query = new GetCustomerDetailQuery(_context, _mapper);
        query.CustomerId = id;
        GetCustomerDetailQueryValidator validator = new GetCustomerDetailQueryValidator();
        validator.ValidateAndThrow(query);
        result = query.Handle();
        return Ok(result);
    }


    [HttpPost]
    public IActionResult AddCustomer([FromBody] CreateCustomerModel newCustomer)
    {
        CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
        command.Model = newCustomer;
        CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCustomer(int id, [FromBody] UpdateCustomerViewModel updatedCustomer)
    {
        UpdateCustomerCommand command = new UpdateCustomerCommand(_context);
        command.CustomerId = id;
        command.model = updatedCustomer;
        UpdateCustomerCommandValidator validator = new UpdateCustomerCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer(int id)
    {
        DeleteCustomerCommand command = new DeleteCustomerCommand(_context);
        command.CustomerId = id;
        DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }
}
