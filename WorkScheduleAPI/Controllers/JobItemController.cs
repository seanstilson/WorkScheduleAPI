using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkScheduleAPI.Repositories;
using WorkScheduleAPI.Extensions;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkScheduleAPI.Controllers
{
    [Route("api/[controller]")]
    public class JobItemController : Controller
    {
        private readonly IJobItemRepository<Entities.JobItem> _jobItemRepository;

        public JobItemController(IJobItemRepository<Entities.JobItem> repository)
        {
            _jobItemRepository = repository;
        }



        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }



        // GET api/values/5
        [HttpGet()]
        [Route("/api/JobItem/jobType/{jobType}")]
        public List<Models.JobItem> Get(string jobType)
        {
            return _jobItemRepository.GetJobItems(jobType);
        }



        // POST api/values
        [HttpPost]
        public void Post([FromBody] Models.JobItem jobItem)
        {
 
            _jobItemRepository.AddJobItemAsync(jobItem.ToEntity());
        }



        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }



        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }



    }
}
