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
        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ResponseMessage<EmployeeDto> Get()
        {
            var responseMessage = new ResponseMessage<EmployeeDto>();
            try
            {
                responseMessage.Items = _mapper.Map<List<Employee>, List<EmployeeDto>>(_context.Employees.ToList().FindAll(e => e.Archived == false));
                responseMessage.Success = true;
            }
            catch (Exception ex)
            {
                responseMessage.Success = false;
                responseMessage.ExceptionMessage = ex.Message + " " + (ex.InnerException == null ? "" : ex.InnerException.Message);
            }

            return responseMessage;
        }

        /// <summary>
        /// Get all a single employee by employee number
        /// </summary>
        /// <param name="id">employee number</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public ResponseMessage<EmployeeDto> GetById(int id)
        {
            var responseMessage = new ResponseMessage<EmployeeDto>();
            try
            {
                responseMessage.Items = new List<EmployeeDto>
                {
                    _mapper.Map<Employee, EmployeeDto>(_context.Employees.FirstOrDefault(e => e.EmployeeNumber == id && e.Archived == false))
                };
                responseMessage.Success = true;
            }
            catch (Exception ex)
            {
                responseMessage.Success = false;
                responseMessage.ExceptionMessage = ex.Message + " " + (ex.InnerException == null ? "" : ex.InnerException.Message);
            }

            return responseMessage;
        }

        /// <summary>
        /// Save an employee to the data store
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseMessage<Employee> Post([FromBody] Employee employee)
        {
            var responseMessage = new ResponseMessage<Employee>();
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                responseMessage.Items = new List<Employee> { _context.Employees.FirstOrDefault(e => e.EmployeeNumber == employee.EmployeeNumber) };
                responseMessage.Success = true;
            }
            catch (Exception ex)
            {
                responseMessage.Success = false;
                responseMessage.ExceptionMessage = ex.Message + " " + (ex.InnerException == null ? "" : ex.InnerException.Message);
            }

            return responseMessage;
        }

        /// <summary>
        /// Update exsisting employee
        /// </summary>
        /// <param name="employee">Updated Employee model</param>
        /// <param name="id">employee GUID</param>
        /// <returns></returns>
        [HttpPut]
        public ResponseMessage<Employee> Put([FromBody] Employee employee, Guid id)
        {
            var responseMessage = new ResponseMessage<Employee>();
            try
            {
                var _employee = _context.Employees.FirstOrDefault(e => e.Id == id);
                _employee.EmployeeNumber = employee.EmployeeNumber;
                _employee.EmploymentStatusId = employee.EmploymentStatusId;
                _employee.FirstName = employee.FirstName;
                _employee.LastName = employee.LastName;
                _employee.LastHireDate = employee.LastHireDate;
                _employee.JobId = employee.JobId;
                _employee.LastUpdated = DateTime.Now;
                _context.Employees.Add(_employee);
                _context.SaveChanges();
                responseMessage.Items = new List<Employee> { _context.Employees.ToList().FirstOrDefault(e => e.Id == id) };
                responseMessage.Success = true;
            }
            catch (Exception ex)
            {
                responseMessage.Success = false;
                responseMessage.ExceptionMessage = ex.Message + " " + (ex.InnerException == null ? "" : ex.InnerException.Message);
            }

            return responseMessage;
        }

        /// <summary>
        /// Archive employee
        /// </summary>
        /// <param name="id">employee GUID</param>
        /// <returns></returns>
        [HttpDelete]
        public ResponseMessage<Employee> Delete(Guid id)
        {
            var responseMessage = new ResponseMessage<Employee>();
            try
            {
                var _employee = _context.Employees.FirstOrDefault(e => e.Id == id);
                if(_employee == null) throw new Exception("Employee Not Found");
                _employee.Archived = true;
                _context.Employees.Add(_employee);
                _context.SaveChanges();
                responseMessage.Items = new List<Employee>{ _context.Employees.FirstOrDefault(e => e.Id == id) };
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