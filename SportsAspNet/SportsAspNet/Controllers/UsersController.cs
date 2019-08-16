﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsAspNet.Models;
using SportsAspNet.ViewModels;

namespace SportsAspNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SportsContext _context;

        public UsersController(SportsContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        [Route("GetAthletes")]
        public async Task<IActionResult> GetAthletes()
        {

            var athletes = await _context.User.AsQueryable().Where(x => x.userType == "Athlete").ToListAsync();
            return Ok(athletes);
        }
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.User.ToListAsync();
            return Ok(users);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = await _context.User.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers([FromRoute] int id, [FromBody] Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.ID)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        //postAthletes
        [HttpPost]
        [Route("postAthletes/{TestId}")]
        public async Task<IActionResult> PostAthletes([FromBody] AthletesViewModel athletesViewModel)
        {
            var User = _context.User.Where(u => u.Name.Equals(athletesViewModel.Name)).Select(u => u.ID).First();

            UserTypeMap userTypeMap = new UserTypeMap();
            userTypeMap.TestId = athletesViewModel.TestId;
            userTypeMap.UserId = User;
            if (athletesViewModel.CTDistance == null)
            {
                userTypeMap.STTime = athletesViewModel.STTime;
            }
            else {
                userTypeMap.CTDistance = athletesViewModel.CTDistance;
            }


            await _context.AddAsync(userTypeMap);
            await _context.SaveChangesAsync();
            return Ok(userTypeMap);
        }

        //postUsers
        [Route("postUsers")]
        public async Task<IActionResult> postUsers([FromBody] UserViewModel userViewModel)
        {
            Users user = new Users
            {
                Name = userViewModel.Name,
                userType = userViewModel.UserType
            };
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = await _context.User.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.User.Remove(users);
            await _context.SaveChangesAsync();

            return Ok(users);
        }

        private bool UsersExists(int id)
        {
            return _context.User.Any(e => e.ID == id);
        }
    }
}