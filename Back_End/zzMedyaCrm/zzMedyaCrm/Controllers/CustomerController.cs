﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using zzMedyaCrm.DataAccess;
using zzMedyaCrm.Entities;

namespace zzMedyaCrm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _context;

        public CustomerController(DataContext context)
        {
                
            _context = context;
        }


        [HttpGet]
        public  IActionResult Get()
        {
            var list = _context.Customers.ToList();
            return Ok(list);
        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            var modelId = _context.Customers.FirstOrDefault(x => x.Id == id);

            if (modelId == null)
                return NotFound("İd null");

            return Ok(modelId);
        }


        [HttpPost]
        public IActionResult Post(Customer model)
        {
            _context.Customers.Add(model);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("id")]
        public void Put(Customer model)
        {
            var customerId = _context.Customers.Find(model.Id);
            _context.Update(customerId);
            _context.SaveChanges();
            
        }


        [HttpDelete("id")]
        public void Delete(Customer model)
        {
            var customerId = _context.Customers.Find(model.Id);
            _context.Remove(customerId);
            _context.SaveChanges();

        }
    }
}
