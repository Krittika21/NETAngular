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

        // GET: api/Main
        [HttpGet]
        [Route("GetTest")]
        public async Task<IActionResult> GetTestDetails()
        {
            var tests = await _context.TestDetails.ToListAsync();
            List<CreateTestViewModel> list = new List<CreateTestViewModel>();
            foreach (var item in tests)
            {
                var testTypeMap = _context.TestTypeMap.First(x => x.TestId == item.ID);
                var testType = _context.TestType.First(x => x.ID == testTypeMap.TestTypeId);
                list.Add(new CreateTestViewModel
                {
                    Date = item.Date,
                    ID = item.ID,

                    TestType = testType.TestName
                });
            }
            return Ok(list);
        }

        // GET: api/Main/5
        [HttpGet]
        [Route("getTestType")]
        public async Task<IActionResult> GetTestDetailsList()
        {
            var type = await _context.TestType.ToListAsync();
            return Ok(type);
        }

        [HttpGet]
        [Route("getCurrentTest/{id}")]
        public async Task<IActionResult> getCurrentTest(int id)
        {
            var test = await _context.TestDetails.FirstOrDefaultAsync(x => x.ID == id);
            var testTypeMap = await _context.TestTypeMap.FirstOrDefaultAsync(s => s.TestId == id);
            var testType = await _context.TestType.FirstOrDefaultAsync(t => t.ID == testTypeMap.TestTypeId);
            var testView = new CreateTestViewModel
            {
                ID = id,
                Date = test.Date,
                TestType = testType.TestName
            };
            return Ok(testView);
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

        // GET: api/Main/5
        //[HttpGet]
        //[Route("getParticipants")]
        //public async Task<IActionResult> GetParticipants()
        //{
        //    var type = await _context.TestType.ToListAsync();
        //    return Ok(type);
        //}
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

            addedTest.TestTypes = testTypeMap;
            _context.TestDetails.Update(addedTest);
            await _context.SaveChangesAsync();

            return Ok();
        }



        // DELETE: api/Main/5
        [HttpDelete("{testId}")]
        public async Task<IActionResult> DeleteTestDetailsList([FromRoute] int testId)
        {

            var test = await _context.TestDetails.FindAsync(testId);
            if (test == null)
            {
                return NotFound();
            }

            _context.TestDetails.Remove(test);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}