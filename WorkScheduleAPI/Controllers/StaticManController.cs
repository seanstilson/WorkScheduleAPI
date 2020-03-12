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
        private IBuildingSystemCodeRepository<Entities.BuildingSystemCode> _buildingSystemCodeRepository;

        public StaticManController( IDepartmentRepository<Entities.Department> departmentRepository,
                                    IBuildingSystemCodeRepository<Entities.BuildingSystemCode> buildingSystemCodeRepository)
        {
            _departmentRepository           = departmentRepository;
            _buildingSystemCodeRepository   = buildingSystemCodeRepository;
        }

        [HttpGet()]
        [Route("/api/Static/department")]
        public List<Models.Department> GetDepartment()
        {
            return _departmentRepository.GetDepartments();
        }

        [HttpGet()]
        [Route("/api/Static/buildingSystemCode")]
        public List<Models.BuildingSystemCode> GetBuildingSystemCode()
        {
            return _buildingSystemCodeRepository.GetBuildingSystemCodes();
        }




    }
}
