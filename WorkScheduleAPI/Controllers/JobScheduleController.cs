using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<JobSchedule>> Get()
        {
            return Ok(new List<JobSchedule>());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<JobSchedule> Get(int id)
        {
            return Ok(new JobSchedule());
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]JobSchedule jobSchedule)
        {
            bool saved = false;

            Entities.JobSchedule job = new Entities.JobSchedule
            {
                JobItemId = jobSchedule.JobItemId,
                JobScheduleId = jobSchedule.Id
            };

            saved = _jobScheduleRepository.InsertJobSchedule(job);
            if (!saved)
            {
                Debug.WriteLine("Error saving the job schedule");
                return BadRequest();
            }
                
            List<Entities.WorkScheduleItem> items = new List<Entities.WorkScheduleItem>();
            Entities.WorkScheduleItem newitem = _mapper.Map<Entities.WorkScheduleItem>(jobSchedule.DesignItem);
            items.Add(newitem);
            items.Add(_mapper.Map<Entities.WorkScheduleItem>(jobSchedule.ProductionItem));
            items.Add(_mapper.Map<Entities.WorkScheduleItem>(jobSchedule.ReviewItem));
            items.Add(_mapper.Map<Entities.WorkScheduleItem>(jobSchedule.TransportationItem));

            items.ForEach(i =>
            {
                saved = _workItemRepository.InsertWorkScheduleItem(i);
                if (!saved)
                {
                    Debug.WriteLine("Error saving work schedule items.");
                    return;
                }
                    
            });

            if (!saved)
                return BadRequest();

            return Ok();
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
