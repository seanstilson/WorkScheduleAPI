using System;
using AutoMapper;
using Entities=WorkScheduleAPI.Entities;
using Models=WorkScheduleAPI.Models;

namespace WorkScheduleAPI.Mappers
{
    public class WorkScheduleMapping : Profile
    {
        public WorkScheduleMapping()
        {
            CreateMap<Models.WorkScheduleItem, Entities.WorkScheduleItem>()
                .ForMember(dest => dest.DepartmentId, act => act.MapFrom(src => src.Department.Id))
                .ForMember(dest => dest.WorkSchduleItemFromTime, act => act.MapFrom(src => src.WorkSchduleItemFromTime.Hours))
                .ForMember(dest => dest.WorkScheduleItemToTime, act => act.MapFrom(src => src.WorkScheduleItemToTime.Hours))
                .ForMember(dest => dest.Color, act => act.MapFrom(src => src.Color.ToString()));
        }
    }
}
