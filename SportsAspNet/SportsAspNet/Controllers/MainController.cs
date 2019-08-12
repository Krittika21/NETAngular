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

        // GET: api/Main/5
        //[HttpGet]
        //[Route("getParticipants")]
        //public async Task<IActionResult> GetParticipants()
        //{
        //    var type = await _context.TestType.ToListAsync();
        //    return Ok(type);
        //}

        ////GET: api/Main/5
        //[HttpGet]
        //[Route("GetAthletes")]
        //public async Task<IActionResult> GetAthletes()
        //{
        //    var athletes = await _context.TestType.ToListAsync();
        //    return Ok(athletes);
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

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestDetailsListExists(id))
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

        // POST: api/Main
        [HttpPost]
        [Route("PostTest")]
        public async Task<IActionResult> PostTestDetailsList([FromBody] CreateTestViewModel test)
        {
            TestDetailsList newTest = new TestDetailsList {
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestDetailsList([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var testDetailsList = await _context.TestDetails.FindAsync(id);
            if (testDetailsList == null)
            {
                return NotFound();
            }

            _context.TestDetails.Remove(testDetailsList);
            await _context.SaveChangesAsync();

            return Ok(testDetailsList);
        }

        private bool TestDetailsListExists(int id)
        {
            return _context.TestDetails.Any(e => e.ID == id);
        }
    }
}