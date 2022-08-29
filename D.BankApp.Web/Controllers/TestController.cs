using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using D.BankApp.Web.Datas.Context;
using D.BankApp.Web.Datas.Entities;
using D.BankApp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace D.BankApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        private readonly BankContext _context;

        public TestController(BankContext context)
        {
            _context = context;
        }

        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserCreateModel userCreateModel)
        {
            var user = new ApplicationUser()
            {
                Id = new Guid(),
                Name = userCreateModel.Name,
                Surname = userCreateModel.Surname
            };
            _context.ApplicationUsers.Add(user);
            _context.SaveChanges();
            return Ok();
        }
    }
    
}

public class AccountCreate
{
    public decimal balance { get; set; }
    public int AccountNumber { get; set; }
    public string UserId { get; set; }
}