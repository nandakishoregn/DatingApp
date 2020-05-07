using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using DatingApp.API.Models;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// Dependency Injection of DataContext Class 
        /// </summary>
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet("")]
        public async Task<IActionResult> GetValues()
        {
            /// <summary>
            /// Converting request to Asynchronous
            /// Add async
            /// retrun type is Task<>
            /// await 
            /// ToListAsync
            /// </summary>
            
            var values =await _context.Values.ToListAsync();
            return Ok(values);
        }

        [AllowAnonymous]
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value =await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(value);
        }

        // POST api/values
        [HttpPost("")]
        public void Poststring(string value) { }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Putstring(int id, string value) { }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void DeletestringById(int id) { }
    }
}