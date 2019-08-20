using System;
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

//Get Users
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.User.ToListAsync();
            return Ok(users);
        }

//Get Athletes
        // GET: api/Users
        [HttpGet]
        [Route("GetAthletes")]
        public async Task<IActionResult> GetAthletes()
        {

            var athletes = await _context.User.AsQueryable().Where(x => x.userType == "Athlete").ToListAsync();
            return Ok(athletes);
        }

        
            [HttpGet]
        [Route("getTestAthletes/{currentTestId}")]
        public async Task<IActionResult> getTestAthletes([FromRoute] int currentTestId)
        {
            var usersToReturn = new List<Users>();
            var athletes = await _context.User.AsQueryable().Where(x => x.userType == "Athlete").ToListAsync();
            var testathletes = await _context.UserTestMap.Where(x => x.TestId == currentTestId).ToListAsync();
            foreach (var item in athletes)
            {
                if (testathletes.Find(u => u.UserId == item.ID) == null)
                {
                    usersToReturn.Add(item);
                }
                
            }
            return Ok(usersToReturn);
        }

        [HttpGet]
        [Route("getUserByTest/{testId}")]
        public async Task<IActionResult> GetUserByTest([FromRoute] int testId)
        {
            var userTest = await _context.UserTestMap.Include(u => u.Users).Where(u => u.TestId == testId).ToListAsync();
            //if (userTest.Users.Name == _context.UserTestMap.Where(x=>x.Users.Name).Single())
            //{

            //}
            return Ok(userTest);
        }
        

        // PUT: api/Users/5
        [HttpPut("putAthletes/{id}")]
        public async Task<IActionResult> PutAthletes([FromRoute] int id, [FromBody] AthletesViewModel athletesViewModel)
        {
            var User = _context.User.Where(u => u.Name.Equals(athletesViewModel.Name)).Select(u => u.ID).First();

            UserTypeMap userTypeMap = _context.UserTestMap.Where(x => x.TestId == id).Where(y => y.UserId == User).First();
            userTypeMap.TestId = athletesViewModel.TestId;
            userTypeMap.UserId = User;
            if (athletesViewModel.CTDistance == 0)
            {
                userTypeMap.STTime = athletesViewModel.STTime;
            }
            else
            {
                userTypeMap.CTDistance = athletesViewModel.CTDistance;
                userTypeMap.FitnessRating = CalculateFitness(athletesViewModel.CTDistance);
            }

            _context.Update(userTypeMap);
            await _context.SaveChangesAsync();
            return Ok(userTypeMap);

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
            if (athletesViewModel.CTDistance == 0)
            {
                userTypeMap.STTime = athletesViewModel.STTime;
            }
            else {
                userTypeMap.CTDistance = athletesViewModel.CTDistance;
                userTypeMap.FitnessRating = CalculateFitness(athletesViewModel.CTDistance);
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

//delete athlete details
        // DELETE: api/Users/5
        [HttpDelete]
        [Route("deleteAthletes/{testId}/{userId}")]
        public async Task<IActionResult> DeleteAthletes([FromRoute] int testId, [FromRoute] int userId)
        {
            var users = await _context.UserTestMap.Where(t => t.TestId == testId).FirstOrDefaultAsync(i => i.UserId == userId);
            if (users == null)
            {
                return NotFound();
            }

            _context.UserTestMap.Remove(users);
            await _context.SaveChangesAsync();

            return Ok(userId);
        }

 //method to calculate the fitness rating
        private String CalculateFitness(double? CTDistance)
        {
            string FitnessRating;
            //var userTest = _dbContext.UserTestMapping.Where(x=>x.ID == id).Single();
            if (CTDistance < 1000)
            {
                FitnessRating = "Below Average";
            }
            else if (CTDistance > 1000 && CTDistance < 2000)
            {
                FitnessRating = "Average";
            }
            else if (CTDistance > 2000 && CTDistance < 3500)
            {
                FitnessRating = "Good";
            }
            else
            {
                FitnessRating = "Very Good";
            }
            return FitnessRating;
        }
    }
}