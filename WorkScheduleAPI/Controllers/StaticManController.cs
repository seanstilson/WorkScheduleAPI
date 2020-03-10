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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkScheduleAPI.Controllers
{
    [Route("api/[controller]")]
    public class StaticManController : Controller
    {
        private IDepartmentRepository<Entities.Department> _departmentRepository;

        public StaticManController(IDepartmentRepository<Entities.Department> repository)
        {
            _departmentRepository = repository;
        }

        [HttpGet()]
        [Route("/api/Static/department")]
        public List<Models.Department> Get()
        {
            return _departmentRepository.GetDepartments();
        }




    }
}
