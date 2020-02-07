using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkScheduleAPI.Models;
using WorkScheduleAPI.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkScheduleAPI.Controllers
{
    [Route("api/[controller]")]
    public class JobScheduleController : Controller
    {
        private IMapper _mapper;
        private IWorkScheduleItemRepository<Entities.WorkScheduleItem> _workItemRepository;
        private IJobScheduleRepository<Entities.JobSchedule> _jobScheduleRepository;

        public JobScheduleController(IMapper mapper,
            IWorkScheduleItemRepository<Entities.WorkScheduleItem> repository,
            IJobScheduleRepository<Entities.JobSchedule> scheduleRepository)
        {
            _mapper = mapper;
            _workItemRepository = repository;
            _jobScheduleRepository = scheduleRepository;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]JobSchedule jobSchedule)
        {
            List<Entities.WorkScheduleItem> items = new List<Entities.WorkScheduleItem>();
            items.Add(_mapper.Map<Entities.WorkScheduleItem>(jobSchedule.DesignItem));
            items.Add(_mapper.Map<Entities.WorkScheduleItem>(jobSchedule.ProductionItem));
            items.Add(_mapper.Map<Entities.WorkScheduleItem>(jobSchedule.ReviewItem));
            items.Add(_mapper.Map<Entities.WorkScheduleItem>(jobSchedule.TransportationItem));

            bool saved = false;
            items.ForEach(i =>
            {
               
                saved = _workItemRepository.InsertWorkScheduleItem(i);
                if (!saved)
                {
                    Debug.WriteLine("Error saving work schedule items.");
                    return;
                }
                    
            });

            Entities.JobSchedule job = new Entities.JobSchedule
            {
                JobItemId = jobSchedule.JobItemId,
                JobScheduleId = jobSchedule.Id
            };

            saved = _jobScheduleRepository.InsertJobSchedule(job);
            if (!saved)
                Debug.WriteLine("Error saving the job schedule");

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
