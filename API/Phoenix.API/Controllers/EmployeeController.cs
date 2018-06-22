using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Phoenix.Models;

namespace Phoenix.API.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly PhoenixDbContext _context;
        private readonly IMapper _mapper;
        public EmployeeController(PhoenixDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseMessage<EmployeeDto> Get()
        {
            var responseMessage = new ResponseMessage<EmployeeDto>();
            try
            {
                responseMessage.Items = _mapper.Map<List<Employee>, List<EmployeeDto>>(_context.Employees.ToList());
                responseMessage.Success = true;
            }
            catch (Exception ex)
            {
                responseMessage.Success = false;
                responseMessage.ExceptionMessage = ex.Message + " " + (ex.InnerException == null ? "" : ex.InnerException.Message);
            }

            return responseMessage;
        }
    }
}