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
    public class MainController : ControllerBase
    {
        private readonly SportsContext _context;

        public MainController(SportsContext context)
        {
            _context = context;
        }

        // Get the list of tests with date
        // GET: api/Main
        [HttpGet]
        [Route("GetTest")]
        public async Task<IActionResult> GetTestDetails()
        {
            var tests = _context.TestTypeMap.ToList();
            List<CreateTestViewModel> list = new List<CreateTestViewModel>();
            foreach (var item in tests)
            {
                var testDetails = _context.TestDetails.FirstOrDefault(x => x.ID == item.TestId);
                var testType = _context.TestType.First(x => x.ID == item.TestTypeId);

                var userType = await _context.UserTestMap.Where(u => u.TestId == item.TestId).ToListAsync();
                list.Add(new CreateTestViewModel
                {
                    Date = item.TestDetail.Date,
                    ID = item.TestId,
                    user = userType,
                    TestType = testType.TestName
                });
            }
            return Ok(list);
        }

        //Get the list of test types (cooper or sprint test)
        // GET: api/Main/5
        [HttpGet]
        [Route("getTestType")]
        public async Task<IActionResult> GetTestDetailsList()
        {
            var type = await _context.TestType.ToListAsync();
            return Ok(type);
        }

        [HttpGet]
        [Route("getCurrentTestId/{id}")]
        public async Task<IActionResult> GetCurrentTest([FromRoute] int id)
       {
            var userTest = await _context.UserTestMap.Where(s => s.TestId == id).Include(s => s.Users).ToListAsync();
            var test = await _context.TestTypeMap.Where(x => x.TestId == id).Include(x => x.TestTypes).Include(x=>x.TestDetail).ToListAsync();
            return Ok(new {userTest, test });
        }

//Get the current Id of the test for adding athletes as per that perticular Id
        [HttpGet]
        [Route("getTestWithAthlete/{TestID}/{userId}")]
        public async Task<IActionResult> getTestWithAthlete([FromRoute] int TestID, [FromRoute] int userId)
        {
            var testTypeMap = await _context.UserTestMap
                .Where(s => s.TestId == TestID).Where(s =>s.UserId == userId)
                .Include(s => s.Users)
                .FirstOrDefaultAsync();
            var athleteView = new AthletesViewModel {
                UserId = userId,
                TestId = TestID,
                Name = testTypeMap.Users.Name,
                CTDistance = testTypeMap.CTDistance,
                STTime = testTypeMap.STTime,
                fitnessRating = testTypeMap.FitnessRating
            };

            return Ok(athleteView);
        }

        [HttpGet]
        [Route("getTestAthletes/{testId}")]
        public async Task<IActionResult> GetTestAthletes(int testId)
        {
            var listToReturn = new List<AthletesViewModel>();
            var testAthletes = await _context.UserTestMap.Where(x => x.TestId == testId).ToListAsync();
            foreach (var testAthlete in testAthletes)
            {
                var userName =  _context.User.Where(x=>x.ID == testAthlete.UserId).Select(s => s.Name).First();
                listToReturn.Add(new AthletesViewModel {
                    Name = userName,
                    CTDistance = testAthlete.CTDistance,
                    STTime = testAthlete.STTime
                });
            }
            return Ok(listToReturn);
        }

        // PUT: api/Main/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestDetailsList([FromRoute] int id, [FromBody] TestDetailsList testDetailsList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != testDetailsList.ID)
            {
                return BadRequest();
            }

            _context.Entry(testDetailsList).State = EntityState.Modified;


            await _context.SaveChangesAsync();



            return NoContent();
        }

        // POST: api/Main
        [HttpPost]
        [Route("PostTest")]
        public async Task<IActionResult> PostTestDetailsList([FromBody] CreateTestViewModel test)
        {
            TestDetailsList newTest = new TestDetailsList
            {
                Date = test.Date
            };
            TestDetailsList addedTest = _context.TestDetails.Add(newTest).Entity;
            _context.SaveChanges();

            TestType testType = _context.TestType.FirstOrDefault(x => x.TestName == test.TestType);

            TestTypeMap testTypeMap = new TestTypeMap
            {
                TestTypeId = testType.ID,
                TestId = addedTest.ID
            };
            _context.TestTypeMap.Add(testTypeMap);

            await _context.SaveChangesAsync();

           // addedTest.TestTypes = testTypeMap;
            _context.TestDetails.Update(addedTest);
            await _context.SaveChangesAsync();

            return Ok();
        }



        // DELETE: api/Main/5
        [HttpDelete]
        [Route("deleteTestDetails/{testId}")]
        public async Task<IActionResult> DeleteTestDetails([FromRoute] int testId)
        {

            var test = await _context.TestDetails.FindAsync(testId);
            if (test == null)
            {
                return NotFound();
            }

            _context.TestDetails.Remove(test);
            await _context.SaveChangesAsync();

            return Ok(test);
        }
    }
}